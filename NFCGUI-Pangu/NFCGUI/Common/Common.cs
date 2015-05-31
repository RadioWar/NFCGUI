using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace NFCGui.Common
{
    class Common
    {
        public static string StringToHexString(string s, Encoding encode)
        {
            byte[] b=encode.GetBytes(s);//按照指定编码将string编程字节数组
            string result=string.Empty;
            for (int i=0; i < b.Length; i++)//逐字节变为16进制字符，以%隔开
            {
                result+=Convert.ToString(b[i], 16);
            }
            return result;
        }

        public static string HexStringToString(string hs, Encoding encode)
        {
            //以%分割字符串，并去掉空字符
            char[] chars=hs.ToCharArray();
            byte[] b=new byte[chars.Length];
            //逐个字符变为16进制字节数据
            for (int i=0; i < chars.Length; i++)
            {
                b[i]=Convert.ToByte(chars[i].ToString(), 16);
            }
            //按照指定编码将字节数组变为字符串
            return encode.GetString(b);
        }

        public static string byteToHexStr(byte[] bytes)
        {
            string returnStr="";
            if (bytes != null)
            {
                for (int i=0; i < bytes.Length; i++)
                {
                    returnStr+=bytes[i].ToString("X2");
                }
            }
            return returnStr;
        }

        public static byte[] strToToHexByte(string hexString)
        {
            hexString=hexString.Replace(" ", "");
            if ((hexString.Length % 2) != 0)
                hexString+="0";
            byte[] returnBytes=new byte[hexString.Length / 2];
            for (int i=0; i < returnBytes.Length; i++)
                returnBytes[i]=Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            return returnBytes;
        }

        public static string UnHex(string hex, Encoding chs)
        {
            if (hex == null)
            {
                return "";
            }
            hex=hex.Replace(",", "");
            hex=hex.Replace("\n", "");
            hex=hex.Replace("\\", "");
            hex=hex.Replace(" ", "");
            if (hex.Length % 2 != 0)
            {
                hex+="20";//空格
            }
            // 需要将 hex 转换成 byte 数组。 
            byte[] bytes=new byte[hex.Length / 2];

            for (int i=0; i < bytes.Length; i++)
            {
                try
                {
                    // 每两个字符是一个 byte。 
                    bytes[i]=byte.Parse(hex.Substring(i * 2, 2),
                        System.Globalization.NumberStyles.HexNumber);
                }
                catch
                {
                    // Rethrow an exception with custom message. 
                    //  throw new ArgumentException("hex is not a valid hex number!", "hex");
                }
            }
            //   System.Text.Encoding chs = System.Text.Encoding.GetEncoding(charset);
            return chs.GetString(bytes);
        }

        public static string ToHex(string s, Encoding chs, bool fenge)
        {
            if ((s.Length % 2) != 0)
            {
                s+=" ";//空格
                //throw new ArgumentException("s is not valid chinese string!");
            }
            //System.Text.Encoding chs = System.Text.Encoding.GetEncoding(charset);
            byte[] bytes=chs.GetBytes(s);
            string str="";
            for (int i=0; i < bytes.Length; i++)
            {
                str+=string.Format("{0:X}", bytes[i]);
                if (fenge && (i != bytes.Length - 1))
                {
                    str+=string.Format("{0}", ",");
                }
            }
            return str.ToLower();
        }

        public static void CreateNFCFiles()
        {
            try
            {
                String libnfcdll=System.IO.Path.GetTempPath() + @"\\libnfc.dll";
                String libusb0dll=System.IO.Path.GetTempPath() + @"\\libusb0.dll";
                String filename=""; //System.IO.Path.GetTempPath() + @"\\nfc-anticol.exe";
                FileStream fs;
                byte[] buffer;
                if (!File.Exists(libnfcdll))
                {
                    fs=new FileStream(libnfcdll, FileMode.CreateNew, FileAccess.Write);
                    buffer=Properties.Resources.libnfc;
                    fs.Write(buffer, 0, buffer.Length);
                    fs.Close();
                }
                if (!File.Exists(libusb0dll))
                {
                    fs=new FileStream(libusb0dll, FileMode.CreateNew, FileAccess.Write);
                    buffer=Properties.Resources.libusb0;
                    fs.Write(buffer, 0, buffer.Length);
                    fs.Close();
                }
                filename=System.IO.Path.GetTempPath() + @"\\nfc-anticol.exe";
                if (!File.Exists(filename))
                {
                    fs=new FileStream(filename, FileMode.CreateNew, FileAccess.Write);
                    buffer=Properties.Resources.nfc_anticol;
                    fs.Write(buffer, 0, buffer.Length);
                    fs.Close();
                }
                filename=System.IO.Path.GetTempPath() + @"\\nfc-dep-initiator.exe";
                if (!File.Exists(filename))
                {
                    fs=new FileStream(filename, FileMode.CreateNew, FileAccess.Write);
                    buffer=Properties.Resources.nfc_dep_initiator;
                    fs.Write(buffer, 0, buffer.Length);
                    fs.Close();
                }
                filename=System.IO.Path.GetTempPath() + @"\\nfc-dep-target.exe";
                if (!File.Exists(filename))
                {
                    fs=new FileStream(filename, FileMode.CreateNew, FileAccess.Write);
                    buffer=Properties.Resources.nfc_dep_target;
                    fs.Write(buffer, 0, buffer.Length);
                    fs.Close();
                }
                filename=System.IO.Path.GetTempPath() + @"\\nfc-emulate-forum-tag2.exe";
                if (!File.Exists(filename))
                {
                    fs=new FileStream(filename, FileMode.CreateNew, FileAccess.Write);
                    buffer=Properties.Resources.nfc_emulate_forum_tag2;
                    fs.Write(buffer, 0, buffer.Length);
                    fs.Close();
                }filename=System.IO.Path.GetTempPath() + @"\\nfc-emulate-forum-tag4.exe";
                if (!File.Exists(filename))
                {
                    fs=new FileStream(filename, FileMode.CreateNew, FileAccess.Write);
                    buffer=Properties.Resources.nfc_emulate_forum_tag4;
                    fs.Write(buffer, 0, buffer.Length);
                    fs.Close();
                }
                filename=System.IO.Path.GetTempPath() + @"\\nfc-emulate-tag.exe";
                if (!File.Exists(filename))
                {
                    fs=new FileStream(filename, FileMode.CreateNew, FileAccess.Write);
                    buffer=Properties.Resources.nfc_emulate_tag;
                    fs.Write(buffer, 0, buffer.Length);
                    fs.Close();
                }
                //  nfc-emulate-uid.exe
                filename=System.IO.Path.GetTempPath() + @"\\nfc-emulate-uid.exe";
                if (!File.Exists(filename))
                {
                    fs=new FileStream(filename, FileMode.CreateNew, FileAccess.Write);
                    buffer=Properties.Resources.nfc_emulate_uid;
                    fs.Write(buffer, 0, buffer.Length);
                    fs.Close();
                }
                filename=System.IO.Path.GetTempPath() + @"\\nfc-list.exe";
                if (!File.Exists(filename))
                {
                    fs=new FileStream(filename, FileMode.CreateNew, FileAccess.Write);
                    buffer=Properties.Resources.nfc_list;
                    fs.Write(buffer, 0, buffer.Length);
                    fs.Close();
                }
                filename=System.IO.Path.GetTempPath() + @"\\nfc-mfclassic.exe";
                if (!File.Exists(filename))
                {
                    fs=new FileStream(filename, FileMode.CreateNew, FileAccess.Write);
                    buffer=Properties.Resources.nfc_mfclassic;
                    fs.Write(buffer, 0, buffer.Length);
                    fs.Close();
                }
                filename=System.IO.Path.GetTempPath() + @"\\nfc-mfsetuid.exe";
                if (!File.Exists(filename))
                {
                    fs=new FileStream(filename, FileMode.CreateNew, FileAccess.Write);
                    buffer=Properties.Resources.nfc_mfsetuid;
                    fs.Write(buffer, 0, buffer.Length);
                    fs.Close();
                }

                filename=System.IO.Path.GetTempPath() + @"\\nfc-mfultralight.exe";
                if (!File.Exists(filename))
                {
                    fs=new FileStream(filename, FileMode.CreateNew, FileAccess.Write);
                    buffer=Properties.Resources.nfc_mfultralight;
                    fs.Write(buffer, 0, buffer.Length);
                    fs.Close();
                }
                filename=System.IO.Path.GetTempPath() + @"\\nfc-poll.exe";
                if (!File.Exists(filename))
                {
                    fs=new FileStream(filename, FileMode.CreateNew, FileAccess.Write);
                    buffer=Properties.Resources.nfc_poll;
                    fs.Write(buffer, 0, buffer.Length);
                    fs.Close();
                }
                filename=System.IO.Path.GetTempPath() + @"\\nfc-probe.exe";
                if (!File.Exists(filename))
                {
                    fs=new FileStream(filename, FileMode.CreateNew, FileAccess.Write);
                    buffer=Properties.Resources.nfc_probe;
                    fs.Write(buffer, 0, buffer.Length);
                    fs.Close();
                }
                filename=System.IO.Path.GetTempPath() + @"\\nfc-read-forum-tag3.exe";
                if (!File.Exists(filename))
                {
                    fs=new FileStream(filename, FileMode.CreateNew, FileAccess.Write);
                    buffer=Properties.Resources.nfc_read_forum_tag3;
                    fs.Write(buffer, 0, buffer.Length);
                    fs.Close();
                }
                filename=System.IO.Path.GetTempPath() + @"\\nfc-relay.exe";
                if (!File.Exists(filename))
                {
                    fs=new FileStream(filename, FileMode.CreateNew, FileAccess.Write);
                    buffer=Properties.Resources.nfc_relay;
                    fs.Write(buffer, 0, buffer.Length);
                    fs.Close();
                }
                filename=System.IO.Path.GetTempPath() + @"\\nfc-relay-picc.exe";
                if (!File.Exists(filename))
                {
                    fs=new FileStream(filename, FileMode.CreateNew, FileAccess.Write);
                    buffer=Properties.Resources.nfc_relay_picc;
                    fs.Write(buffer, 0, buffer.Length);
                    fs.Close();
                }
            }
            catch
            {
                MessageBox.Show("程序读写权限不足！", "权限错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        public static void CreateFiles()
        {
            try
            {
                String nfcdll=System.IO.Path.GetTempPath() + @"\\nfc.dll";
                String mfocexe=System.IO.Path.GetTempPath() + @"\\mfoc.exe";
                FileStream fs;
                byte[] buffer;
                if (!File.Exists(nfcdll))
                {
                    fs=new FileStream(nfcdll, FileMode.CreateNew, FileAccess.Write);
                    buffer=Properties.Resources.nfc;
                    fs.Write(buffer, 0, buffer.Length);
                    fs.Close();
                }
                if (!File.Exists(mfocexe))
                {
                    fs=new FileStream(mfocexe, FileMode.CreateNew, FileAccess.Write);
                    buffer=Properties.Resources.mfoc;
                    fs.Write(buffer, 0, buffer.Length);
                    fs.Close();
                }
            }
            catch
            {
                MessageBox.Show("程序读写权限不足！", "权限错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }
    }
}