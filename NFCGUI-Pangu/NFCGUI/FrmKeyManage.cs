using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace NFCGui
{
    public partial class FrmKeyManage : Form
    {
        private static byte[] Acl=new byte[4];
        private static int tabType=0;
    
        private string[] Skey=new String[]
        {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "0",
            "A",
            "B",
            "C",
            "D",
            "E",
            "F"
        };
  
        private Common.AccessCondition accesscodition=new Common.AccessCondition();
        public FrmKeyManage()
        {
            this.InitializeComponent();
        }public String BlockPermString


        {
            get
            {
                return this.textBox1.Text;
            }
            set
            {
                this.textBox1.Text=value;
                this.accesscodition.AccessConditionString=this.textBox1.Text;
                Acl=this.accesscodition.AccessBits;
                checkBox2.Checked=accesscodition.StandardizedCards;
                checkBox1.Checked=accesscodition.MultiApplicationCard;
            }
        }
        private void CreateACL(Byte[] a)
        {
            this.accesscodition.AccessBits=Acl;
            this.textBox1.Text=this.accesscodition.AccessConditionString;
            //decodeACL(result);
        }private string checkStr(string str)

        {
            str=str.ToUpper().PadRight(8, '0');
            string Res="";
           
            for (int i=0; i < 8; i++)
            {
                if (this.Skey.Contains(str.Substring(i, 1)))
                {
                    Res+=str.Substring(i, 1);
                }
            }
            Res=Res.PadRight(8, '0');
            return Res;
        }

        private void DrawTableA(int dtype, int selectid)
        {
            this.changeState(selectid);
            this.groupBox1.Text=dtype == 3 ? "Security Block" : string.Format("Data Block {0}", dtype.ToString()); this.groupBox1.Refresh();

            Graphics g=Graphics.FromHwnd(this.groupBox1.Handle);

            //  g.Clear(Color.FromKnownColor(KnownColor.Control));
            int[] datasize=new int[]
            {
                50,
                50,
                100,
                100,
                150
            };
            String[][] datablock=new string[][]
            {
                new string[]
                {
                    "Key A|B",
                    "Key A|B",
                    "Key A|B",
                    "Key A|B",
                    "Transport Configuration"
                },
                new string[]
                {
                    "Key A|B",
                    "Never",
                    "Never",
                    "Never",
                    "Read/Write Block"
                },
                new string[]
                {
                    "Key A|B",
                    "Key B",
                    "Never",
                    "Never",
                    "Read/Write Block"
                },
                new string[]
                {
                    "Key A|B",
                    "Key B",
                    "Key B",
                    "Key A|B",
                    "Value Block"
                },
                new string[]
                {
                    "Key A|B",
                    "Never",
                    "Never",
                    "Key A|B",
                    "Value Block"
                },
                new string[]
                {
                    "Key B",
                    "Key B",
                    "Never",
                    "Never",
                    "Read/Write Block"
                },
                new string[]
                {
                    "Key B",
                    "Never",
                    "Never",
                    "Never",
                    "Read/Write Block"
                },
                new string[]
                {
                    "Never",
                    "Never",
                    "Never",
                    "Never",
                    "Read/Write Block"
                },
            };
            int[] secsize=new int[]
            {
                50,
                50,
                50,
                50,
                50,
                50,
                150
            };
            //  string[] secblocktitle = new string[] { "R};
            String[][] secblock=new string[][]
            {
                new string[]
                {
                    "Never",
                    "Key A",
                    "Key A",
                    "Never",
                    "Key A",
                    "Key A",
                    "Key B may be read"
                },
                new string[]
                {
                    "Never",
                    "Never",
                    "Key A",
                    "Never",
                    "Key A",
                    "Never",
                    "Key B may be read"
                },
                new string[]
                {
                    "Never",
                    "Key B",
                    "Key A|B",
                    "Never",
                    "Never",
                    "Key B",
                    ""
                },
                new string[]
                {
                    "Never",
                    "Never",
                    "Key A|B",
                    "Never",
                    "Never",
                    "Never",
                    ""
                },
                new string[]
                {
                    "Never",
                    "Key A",
                    "Key A",
                    "Key A",
                    "Key A",
                    "Key A",
                    "Transport Configuration"
                },
                new string[]
                {
                    "Never",
                    "Key B",
                    "Key A|B",
                    "Key B",
                    "Never",
                    "Key B",
                    ""
                },
                new string[]
                {
                    "Never",
                    "Never",
                    "Key A|B",
                    "Key B",
                    "Never",
                    "Never",
                    ""
                },
                new string[]
                {
                    "Never",
                    "Never",
                    "Key A|B",
                    "Never",
                    "Never",
                    "Never",
                    ""
                }
            };

            Pen pen=new Pen(Color.Black, 1);
            Pen penS=new Pen(Color.Yellow, 2);
            StringFormat sf=new StringFormat();
            sf.Alignment=StringAlignment.Center;
            Font font=new System.Drawing.Font(FontFamily.GenericSansSerif, 9);
            Font fontB=new System.Drawing.Font(FontFamily.GenericSansSerif, 9, FontStyle.Bold);
            Brush brush=Brushes.Black;
            int x=40;
            int y=16;
            string[][] drw;
            int[] tsize; string[] title;
            if (dtype != 3)
            {
                drw=datablock;
                tsize=datasize;
                g.DrawRectangle(pen, x, y, 300, 22);
                g.DrawString("Access Condition For", fontB, brush, new Rectangle(x, y, 300, 22), sf);
                g.DrawRectangle(pen, x + 300, y, 150, 22);
                g.DrawString("Application", fontB, brush, new Rectangle(x + 300, y, 150, 22), sf);
                title=new string[]
                {
                    "Read",
                    "Write",
                    "Increment",
                    "Dec/Transfer/\r\nRestore",
                    ""
                };
                y=38;
                for (int i=0; i < title.Length; i++)
                {
                    if (i == 0)
                    {
                        x=40;
                    }
                    else
                    {
                        x=x + tsize[i - 1];
                    }
                    g.DrawRectangle(pen, x, y, tsize[i], 32);
                    g.DrawString(title[i], fontB, brush, new Rectangle(x, y, tsize[i], 32), sf);
                }
            }
            else
            {
                drw=secblock;
                tsize=secsize;

                g.DrawRectangle(pen, x, y, 100, 22);
                g.DrawString("Key A", fontB, brush, new Rectangle(x, y, 100, 22), sf);
                x=x + 100;
                g.DrawRectangle(pen, x, y, 100, 22);
                g.DrawString("Access Bits", fontB, brush, new Rectangle(x, y, 100, 22), sf);
                x=x + 100;
                g.DrawRectangle(pen, x, y, 100, 22);
                g.DrawString("Key B", fontB, brush, new Rectangle(x, y, 100, 22), sf);
                x=x + 100;
                g.DrawRectangle(pen, x, y, 150, 22);
                g.DrawString("Remark", fontB, brush, new Rectangle(x, y, 150, 22), sf);
                title=new string[]
                {
                    "Read",
                    "Write",
                    "Read",
                    "Write",
                    "Read",
                    "Write",
                    ""
                };
                y=38;
                for (int i=0; i < title.Length; i++)
                {
                    if (i == 0)
                    {
                        x=40;
                    }
                    else
                    {
                        x=x + tsize[i - 1];
                    }
                    g.DrawRectangle(pen, x, y, tsize[i], 32);
                    g.DrawString(title[i], fontB, brush, new Rectangle(x, y, tsize[i], 32), sf);
                }
            }
            y=70;
            for (int i=0; i < drw.Length; i++)
            {
                for (int j=0; j < drw[i].Length; j++)
                {
                    if (j == 0)
                    {
                        x=40;
                    }
                    else
                    {
                        x=x + tsize[j - 1];
                    }
                    g.DrawRectangle(pen, x, y + i * 22, tsize[j], 22);
                    g.DrawString(drw[i][j], font, brush, new Rectangle(x, y + i * 22, tsize[j], 22), sf);
                }
            }

            g.DrawRectangle(penS, 40, y + selectid * 22, 450, 22);
            //   g.
        }private void button1_Click(object sender, EventArgs e)

        {
            tabType=0;
            this.DrawTableA(tabType, Acl[tabType]);
        }private void button2_Click(object sender, EventArgs e)

        {
            tabType=1;
            this.DrawTableA(tabType, Acl[tabType]);
        }private void radioButton8_CheckedChanged(object sender, EventArgs e)

        {
        }private void button3_Click(object sender, EventArgs e)

        {
            tabType=2;
            this.DrawTableA(tabType, Acl[tabType]);
        }private void button4_Click(object sender, EventArgs e)

        {
            tabType=3;
            this.DrawTableA(tabType, Acl[tabType]);
        }private void changeState(int select)

        {
            this.radioButton1.Checked=false;
            this.radioButton2.Checked=false;
            this.radioButton3.Checked=false;
            this.radioButton4.Checked=false;
            this.radioButton5.Checked=false;
            this.radioButton6.Checked=false;
            this.radioButton7.Checked=false;
            this.radioButton8.Checked=false;
            if (select == 0)
            {
                this.radioButton1.Checked=true;
            }
            if (select == 1)
            {
                this.radioButton2.Checked=true;
            }if (select == 2)
            {
                this.radioButton3.Checked=true;
            }if (select == 3)
            {
                this.radioButton4.Checked=true;
            }if (select == 4)
            {
                this.radioButton5.Checked=true;
            }if (select == 5)
            {
                this.radioButton6.Checked=true;
            }if (select == 6)
            {
                this.radioButton7.Checked=true;
            }if (select == 7)
            {
                this.radioButton8.Checked=true;
            }
        }private void radioButton8_Click(object sender, EventArgs e)

        {
            if (this.radioButton1.Checked)
            {
                Acl[tabType]=0; this.DrawTableA(tabType, Acl[tabType]);
            }
            if (this.radioButton2.Checked)
            {
                //  DrawTableA(tabType, 1);
                Acl[tabType]=1; this.DrawTableA(tabType, Acl[tabType]);
            }
            if (this.radioButton3.Checked)
            {
                //   DrawTableA(tabType, 2);
                Acl[tabType]=2; this.DrawTableA(tabType, Acl[tabType]);
            }
            if (this.radioButton4.Checked)
            {
                //    DrawTableA(tabType, 3);
                Acl[tabType]=3; this.DrawTableA(tabType, Acl[tabType]);
            }
            if (this.radioButton5.Checked)
            {
                //  DrawTableA(tabType, 4);
                Acl[tabType]=4; this.DrawTableA(tabType, Acl[tabType]);
            }
            if (this.radioButton6.Checked)
            {
                //    DrawTableA(tabType, 5);
                Acl[tabType]=5; this.DrawTableA(tabType, Acl[tabType]);
            }
            if (this.radioButton7.Checked)
            {
                //  DrawTableA(tabType, 6);
                Acl[tabType]=6; this.DrawTableA(tabType, Acl[tabType]);
            }
            if (this.radioButton8.Checked)
            {
                // DrawTableA(tabType, 7);
                Acl[tabType]=7; this.DrawTableA(tabType, Acl[tabType]);
            }
            this.CreateACL(Acl);
        }private void button7_Click(object sender, EventArgs e)

        {
            this.accesscodition.AccessConditionString=this.textBox2.Text;
            tabType=0;
            this.DrawTableA(tabType, Acl[tabType]);
            //textBox2.Text=textBox2.Text.Length != 32 ? "FFFFFFFFFFFFFF078069FFFFFFFFFFFFFF" : textBox2.Text;
            //MiFareHelper.AccessConditions access=MiFareHelper.AccessBits.GetAccessConditions(MiFareHelper.HexEncoding.GetBytes(textBox2.Text));
            //MessageBox.Show(access.ToString());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DialogResult=DialogResult.Cancel;
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult=System.Windows.Forms.DialogResult.OK;
        }

        private void FrmKeyManage_Load(object sender, EventArgs e)
        {
            comboBox1.Items.AddRange(Enum.GetNames(typeof(Common.MadVersionEnum)));
            comboBox1.SelectedIndex=comboBox1.Items.Count - 1;
            checkBox2.Checked=accesscodition.StandardizedCards;
            checkBox1.Checked=accesscodition.MultiApplicationCard;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                accesscodition.MadVersion=(Common.MadVersionEnum)Enum.Parse(typeof(Common.MadVersionEnum), comboBox1.Text) ;
                textBox1.Text=accesscodition.AccessConditionString;
            }
            catch (Exception ex)
            {
                Common.Log.WriteLog(ex.Message.ToString());
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            accesscodition.MultiApplicationCard=checkBox1.Checked;
            textBox1.Text=accesscodition.AccessConditionString;
            checkBox1.Text=checkBox1.Checked ? "MultiApplicationCard" : "MonoApplicationCard";
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            accesscodition.StandardizedCards=checkBox2.Checked;
            textBox1.Text=accesscodition.AccessConditionString;
        }
    }
}