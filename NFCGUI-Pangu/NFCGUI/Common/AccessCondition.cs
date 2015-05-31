using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace NFCGui.Common
{
    internal class HexEncoding
    {
        public static string ToString(byte[] val)
        {
            string returnStr="";
            if (val != null)
            {
                for (int i=0; i < val.Length; i++)
                {
                    returnStr+=val[i].ToString("X2");
                }
            }
            return returnStr;
        }

        public static Byte[] GetBytes(string val, out int discarded)
        {
            byte[] result=GetBytes(val);
            discarded=result.Length;
            return result;
        }

        public static Byte[] GetBytes(string val)
        {
            string hexString=val.Replace(" ", "");
            if ((hexString.Length % 2) != 0)
                hexString+="0";
            byte[] returnBytes=new byte[hexString.Length / 2];
            for (int i=0; i < returnBytes.Length; i++)
                returnBytes[i]=Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            //  discarded = returnBytes.Length;
            return returnBytes;
        }
    }

    public enum MadVersionEnum
    {
        NoMad,
        Version1,
        Version2
    }

    public class AccessCondition
    {
        public AccessCondition()
        {
            this.GetAccessConditions();
        }

        public AccessCondition(String AccessString)
        {
            this.accessConditionBytes=HexEncoding.GetBytes(AccessString.PadRight(8, '0'));
            this.GetAccessConditions();
        }

        public AccessCondition(Byte[] AccessBytes)
        {
            this.accessConditionBytes=AccessBytes;
            this.GetAccessConditions();
        }

        private bool multiApplicationCard=false;
        public bool MultiApplicationCard
        {
            get
            {
                return this.multiApplicationCard;
            }
            set
            {
                this.multiApplicationCard=value;
            }
        }
        private MadVersionEnum madVersion=MadVersionEnum.Version2;
        public MadVersionEnum MadVersion
        {
            get
            {
                return this.madVersion;
            }
            set
            {
                this.madVersion=value; 
            }
        }
        private byte[] accessBits;
        public byte[] AccessBits
        {
            get
            {
                this.GetAccessConditions(); 
                return this.accessBits;
            }
            set
            {
                this.accessBits=value;
            }
        }
        private byte[] accessConditionBytes;
        public String AccessConditionString
        {
            get
            {
                this.CalculateAccessBits(); 
                return HexEncoding.ToString(this.accessConditionBytes);
            }
            set
            {
                this.accessConditionBytes=HexEncoding.GetBytes(value.PadRight(8, '0'));
            }
        }
        public Byte[] AccessConditionBytes
        {
            get
            {
                this.CalculateAccessBits(); 
                return this.accessConditionBytes;
            }
            set
            {
                this.accessConditionBytes=value;
            }
        }
        private void CalculateAccessBits()
        {
            this.accessConditionBytes=this.CalculateAccessBits(this.accessBits);
        }

        private bool standardizedcards=false;
        public bool StandardizedCards
        {
            get
            {
                return this.standardizedcards;
            }set
            {
                this.standardizedcards=value;
            }
        }
        public byte[] CalculateAccessBits(byte[] data)
        {
            //  byte[] data=this.accessBits;
            BitArray[] bitConds=new BitArray[4];

            bitConds[0]=new BitArray(new byte[] { data[0] });
            bitConds[1]=new BitArray(new byte[] { data[1] });
            bitConds[2]=new BitArray(new byte[] { data[2] });
            bitConds[3]=new BitArray(new byte[] { data[3] });
            BitArray byte6=new BitArray(8);
            byte6.Set(0, !bitConds[0].Get(0)); // ! C1-0 
            byte6.Set(1, !bitConds[1].Get(0)); // ! C1-1
            byte6.Set(2, !bitConds[2].Get(0)); // ! C1-2
            byte6.Set(3, !bitConds[3].Get(0)); // ! C1-3
            byte6.Set(4, !bitConds[0].Get(1)); // ! C2-0
            byte6.Set(5, !bitConds[1].Get(1)); // ! C2-1
            byte6.Set(6, !bitConds[2].Get(1)); // ! C2-2
            byte6.Set(7, !bitConds[3].Get(1)); // ! C2-3
            BitArray byte7=new BitArray(8);
            byte7.Set(0, !bitConds[0].Get(2)); // ! C3-0 
            byte7.Set(1, !bitConds[1].Get(2)); // ! C3-1
            byte7.Set(2, !bitConds[2].Get(2)); // ! C3-2
            byte7.Set(3, !bitConds[3].Get(2)); // ! C3-3
            byte7.Set(4, bitConds[0].Get(0)); // C1-0
            byte7.Set(5, bitConds[1].Get(0)); // C1-1
            byte7.Set(6, bitConds[2].Get(0)); // C1-2
            byte7.Set(7, bitConds[3].Get(0)); // C1-3
            BitArray byte8=new BitArray(8);
            byte8.Set(0, bitConds[0].Get(1)); // C2-0 
            byte8.Set(1, bitConds[1].Get(1)); // C2-1
            byte8.Set(2, bitConds[2].Get(1)); // C2-2
            byte8.Set(3, bitConds[3].Get(1)); // C2-3
            byte8.Set(4, bitConds[0].Get(2)); // C3-0
            byte8.Set(5, bitConds[1].Get(2)); // C3-1
            byte8.Set(6, bitConds[2].Get(2)); // C3-2
            byte8.Set(7, bitConds[3].Get(2)); // C3-3
            BitArray byte9=new BitArray(8);
            if (this.madVersion == MadVersionEnum.Version1)
            {
                byte9.Set(0, true);
                byte9.Set(1, false);
                byte9.Set(7, true);
            }
            else if (this.madVersion == MadVersionEnum.Version2)
            {
                byte9.Set(0, false);
                byte9.Set(1, true);
                byte9.Set(7, true);
            }

            byte9.Set(6, this.multiApplicationCard);

            Byte[] bits=new Byte[4];
            byte6.CopyTo(bits, 0);
            byte7.CopyTo(bits, 1);
            byte8.CopyTo(bits, 2);

            byte9.CopyTo(bits, 3); if (this.standardizedcards)
            {
                bits[3]=0x69;
            }
            // this.accessConditionBytes=bits;
            return bits;
        }

        private string verifyaccessstring="";
        private string verfyaccesssresult="";
        public String VerifyAccessConditionsString
        {
            get
            {
                return this.verifyaccessstring;
            }
            set
            {
                this.verifyaccessstring=value;
            }
        }
        public bool isVerifyAccessConditions
        {
            get
            {
                return this.VerifyAccessConditions();
            }
        }
        private bool isverifyaccess=false;
        public string VerifyAccessConditionsResult
        {
            get
            {
                return this.verfyaccesssresult;
            }
        }
        private bool VerifyAccessConditions()
        {
            this.isverifyaccess=this.VerifyAccessConditions(this.verifyaccessstring);
            return this.isverifyaccess ;
        }

        public bool VerifyAccessConditions(String str)
        {
            this.isverifyaccess=false;
            this.verifyaccessstring=str.PadRight(8, '0');
            this.accessConditionBytes=HexEncoding.GetBytes(this.verifyaccessstring);

            this.GetAccessConditions();
            this.CalculateAccessBits();
            this.verfyaccesssresult=HexEncoding.ToString(this.accessConditionBytes);
            this.isverifyaccess=(this.verifyaccessstring.Substring(0, 6) == this.verfyaccesssresult.Substring(0, 6));

            return this.isverifyaccess;
        }

        public Byte[] GetAccessConditions(byte[] data)
        {
            //  byte[] data = this.accessConditionBytes;
            BitArray byte6=new BitArray(new Byte[] { 0xFF });
            BitArray byte7=new BitArray(new Byte[] { 0x07 });
            BitArray byte8=new BitArray(new Byte[] { 0x80 });
            BitArray byte9=new BitArray(new Byte[] { 0x69 });

            if (data != null)
            {
                byte6=new BitArray(new Byte[] { data[0] });
                byte7=new BitArray(new Byte[] { data[1] });
                byte8=new BitArray(new Byte[] { data[2] });
                byte9=new BitArray(new Byte[] { data[3] });
            }
            this.standardizedcards=(data == null) || (data[3] == 0x69) ;
            
            BitArray[] condBits=new BitArray[4];
            Byte[] result=new Byte[4];
            condBits[0]=new BitArray(new bool[]
            {
                byte7.Get(4), // C1-0
                byte8.Get(0), // C2-0
                byte8.Get(4)  // C3-0
            });

            condBits[1]=new BitArray(new bool[]
            {
                byte7.Get(5), // C1-1
                byte8.Get(1), // C2-1
                byte8.Get(5)  // C3-1
            });

            condBits[2]=new BitArray(new bool[]
            {
                byte7.Get(6), // C1-2
                byte8.Get(2), // C2-2
                byte8.Get(3)  // C2-3
            });

            condBits[3]=new BitArray(new bool[]
            {
                byte7.Get(7), // C1-3
                byte8.Get(3), // C2-3
                byte8.Get(7)  // C3-3
            });

            this.madVersion=MadVersionEnum.NoMad;
            if (byte9.Get(7))
            {
                if (byte9.Get(0))
                    this.madVersion=MadVersionEnum.Version1;
                if (byte9.Get(1))
                    this.madVersion=MadVersionEnum.Version2;
            }
            multiApplicationCard=byte9.Get(6);

            condBits[0].CopyTo(result, 0);
            condBits[1].CopyTo(result, 1);
            condBits[2].CopyTo(result, 2);
            
            condBits[3].CopyTo(result, 3);
          
            // this.accessBits = result;
            return result;
        }

        private void GetAccessConditions()
        {
            this.accessBits=this.GetAccessConditions(this.accessConditionBytes);
        }
    }
}