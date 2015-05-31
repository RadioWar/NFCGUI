using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace NFCGui
{
    public partial class FrmMain : Form
    {
        private delegate void enablelogButtonDelegate(bool val);

        private delegate void enablesaveLogButtonDelegate(bool val);

        private delegate void enablestartStopButtonDelegate(bool val);

        private delegate void updateLogBoxDelegate(string val);

        private delegate void updatelogButtonLabelDelegate(string val);

        private delegate void updatestartStopButtonLabelDelegate(string val);

        private delegate void updateStatusLabelDelegate(string val);

        private delegate void updateTimeLabelDelegate(string val);
        private Thread T; private Thread Time;
        public FrmMain()
        {
            InitializeComponent();
            this.tbKeyFile.AllowDrop=true;
            this.tbDumpFile.AllowDrop=true;

            this.tbKeyFile.DragEnter+=new DragEventHandler(this.dropfileEnter);
            this.tbDumpFile.DragEnter+=new DragEventHandler(this.dropfileEnter);
            this.tbKeyFile.DragDrop+=new DragEventHandler(this.dropfileDrop);
            this.tbDumpFile.DragDrop+=new DragEventHandler(this.dropfileDrop);
            this.listViewKey.AllowDrop=true;
            this.listViewKey.DragEnter+=new DragEventHandler(this.dropfileEnter);
            this.listViewKey.DragDrop+=new DragEventHandler(this.dropfileListDrop);
            this.listBox1.AllowDrop=true;
            this.listBox1.DragEnter+=new DragEventHandler(this.dropfileEnter);
            this.listViewKey.DragDrop+=new DragEventHandler(this.dropfileKeyDrop);
        }

        private void dropfileKeyDrop(object sender, DragEventArgs e)
        {
            try
            {
                string[] data=(string[])e.Data.GetData(DataFormats.FileDrop);
                //  (sender as TextBox).Text = data[0]; ShowDumpFile(data[0]);
                string filename=data[0]; 
                if (!File.Exists(filename))
                {
                    MessageBox.Show("文件不存在！", "错误提示");
                    return;
                }
                StreamReader sr=new StreamReader(filename);
                string str="";
                while ((str=sr.ReadLine().ToUpper()) != null)
                {
                    String Res="";
                    for (int i=0; i < 12; i++)
                    {
                        if (Skey.Contains(str.Substring(i, 1)))
                        {
                            Res+=str.Substring(i, 1);
                        }
                    }
                    Res.PadRight(12, '0');

                    if (!listBox1.Items.Contains(Res))
                    {
                        listBox1.Items.Add(Res);
                    }
                }
                sr.Close();
            }
            catch (Exception ex)
            {
                Common.Log.WriteLog(ex.Message.ToString());
            }
        }

        private void dropfileEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect=DragDropEffects.Copy;
            }
        }

        private void SaveDumpFile(String FileName)
        {
            string str="";
            for (int i=0; i < listViewKey.Items.Count; i++)
            {
                for (int j=1; j < listViewKey.Items[i].SubItems.Count; j++)
                {
                    str+=listViewKey.Items[i].SubItems[j].Text;
                }
            }
            byte[] bs=Common.Common.strToToHexByte(str);
            FileStream fs=new FileStream(FileName, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
            fs.Seek(0, SeekOrigin.Begin);
            fs.Write(bs, 0, bs.Length);
            fs.Close();
            MessageBox.Show("写入文件:" + FileName + " 完成！");
        }

        private void ShowDumpFile(string FileName)
        {
            listViewKey.Tag=FileName;
            listViewKey.Items.Clear();
            // listViewKey.FullRowSelect = false;
            if (!File.Exists(FileName))
            {
                MessageBox.Show("文件不存在！", "错误提示");
                return;
            }
            try
            {
                FileStream fs=new FileStream(FileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                bool f4k=fs.Length < 4096 ? false : true;

                byte[] bs=new byte[(f4k ? fs.Length : 4096)];
                fs.Read(bs, 0, (int)fs.Length);
                fs.Close();
            
                string strHex=Common.Common.byteToHexStr(bs);
                Common.AccessCondition access=new Common.AccessCondition();
                for (int i=0; i < (strHex.Length / 128); i++)
                {
                    ListViewItem li=new ListViewItem(i.ToString());
                    li.UseItemStyleForSubItems=true;
                 
                    for (int j=0; j < 4; j++)
                    {
                        if (j == 3)
                        {
                            li.SubItems.Add(strHex.Substring(i * 128 + j * 32, 12));
                            access.AccessConditionString=strHex.Substring(i * 128 + j * 32 + 12, 8);
                            li.SubItems.Add(access.AccessConditionString);

                            li.SubItems.Add(strHex.Substring(i * 128 + j * 32 + 20, 12));
                        }
                        else
                        {
                            li.SubItems.Add(strHex.Substring(i * 128 + j * 32, 32));
                        }
                    }
                 
                    listViewKey.Items.Add(li);
                }
                listViewKey.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);

                if (!f4k)
                {
                    if (MessageBox.Show("是否保存为4K文件格式？", "非4K文件格式", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        SaveDumpFile(FileName);
                    }
                }
            }
            catch (Exception ex)
            {
                Common.Log.WriteLog(ex.Message.ToString());
                MessageBox.Show("读取文件错误！", "错误提示");
            }
        }

        private void dropfileListDrop(object sender, DragEventArgs e)
        {
            try
            {
                string[] data=(string[])e.Data.GetData(DataFormats.FileDrop);
                ShowDumpFile(data[0]);
            }
            catch (Exception ex)
            {
                Common.Log.WriteLog(ex.Message.ToString());
            }
        }

        private void dropfileDrop(object sender, DragEventArgs e)
        {
            try
            {
                string[] data=(string[])e.Data.GetData(DataFormats.FileDrop);
                (sender as TextBox).Text=data[0]; ShowDumpFile(data[0]);
            }
            catch (Exception ex)
            {
                Common.Log.WriteLog(ex.Message.ToString());
            }
        }

        public void updateLogBox(string val)
        {
            if (this.tbLog.InvokeRequired)
            {
                this.tbLog.Invoke(new updateLogBoxDelegate(this.updateLogBox), new object[] { val });
            }
            else
            {
                this.tbLog.AppendText(val);
            }
        }

        public void updateStatus(int status)
        {
            switch (status)
            {
                case 0:
                    this.updateStatusLabel("Idle");
                    this.updatestartStopButtonLabel("枚举密钥");
                    this.enablestartStopButton(true);
                    //    this.enablelogButton(false);
                    //  this.updatelogButtonLabel("Log unavailible");
                    // this.enablesaveLogButton(false);
                    this.trackTime=false;
                    this.enablestartStopButton(true);
                    return;

                case 1:
                    this.updateStatusLabel("Running");
                    this.enablestartStopButton(false);
                    //     this.enablelogButton(false);
                    //  this.updatelogButtonLabel("Log unavailible");
                    //   this.enablesaveLogButton(false);
                    this.trackTime=true;
                    this.enablestartStopButton(false);
                    return;

                case 2:
                    this.updateStatusLabel("Done");
                    this.updatestartStopButtonLabel("枚举密钥");
                    this.enablestartStopButton(true);
                    //      this.enablelogButton(true);
                    //  this.updatelogButtonLabel("Show Log");
                    //  this.enablesaveLogButton(true);
                    this.trackTime=false;
                    this.enablestartStopButton(true);
                    return;
            }
        }

        public void updatestartStopButtonLabel(string val)
        {
            if (this.button3.InvokeRequired)
            {
                this.button3.Invoke(new updatestartStopButtonLabelDelegate(this.updatestartStopButtonLabel), new object[] { val });
            }
            else
            {
                this.button3.Text=val;
            }
        }

        public void enablestartStopButton(bool val)
        {
            if (this.button3.InvokeRequired)
            {
                this.button3.Invoke(new enablelogButtonDelegate(this.enablestartStopButton), new object[] { val });
            }
            else
            {
                this.button3.Enabled=val;
            }
        }

        public void updateStatusLabel(string val)
        {
            //if (this.statusLabel.InvokeRequired)
            //{
            //    this.statusLabel.Invoke(new updateStatusLabelDelegate(this.updateStatusLabel), new object[] { val });
            //}
            //else
            //{
            this.statusLabel.Text=val;
            //}
        }

        public void updateTimeLabel(string val)
        {
            //if (this.timeLabel.InvokeRequired)
            //{
            //    this.timeLabel.Invoke(new updateTimeLabelDelegate(this.updateTimeLabel), new object[] { val });
            //}
            //else
            //{
            this.timeLabel.Text=val;
            //}
        }

        private void RunResourceStream(String streamName, params Object[] args)
        {
            //string[] aa = this.GetType().Assembly.GetManifestResourceNames();
            //Stream streamObj =this.GetType().Assembly. GetManifestResourceStream(streamName);
            //byte[] bs = new byte[streamObj.Length];
            //streamObj.Read(bs, 0, (int)streamObj.Length);
            byte[] bs=(byte[])Properties.Resources.ResourceManager.GetObject(streamName);
            Assembly asm=Assembly.Load(bs, bs);
            string s=asm.Location;
            MethodInfo info=asm.EntryPoint;
            ParameterInfo[] parameters=info.GetParameters();
           
            if ((parameters != null) && (parameters.Length > 0))
            {
                info.Invoke(null, args);
            }
            else
            {
                info.Invoke(null, null);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //RunResourceStream("mfoc");
            string str=Common.NfcWorker.NfcCall("nfc-list.exe", "");
            tbLog.AppendText(str); tbLog.AppendText("\n");
            Regex regx=new Regex("UID \\(\\S*\\): ((\\S\\S\\s\\s){4})",RegexOptions.IgnoreCase);
            if (regx.IsMatch(str))
            {
                string result=regx.Match(str).Value.ToUpper().Replace(" ", "");
                tbUid.Text=result.Substring(result.Length - 8);
                tbNewUid.Text=tbUid.Text;
            }
            else
            {
                tbUid.Text="不能识别";
            }
        }

        private string ShowOpenFile()
        {
            OpenFileDialog opd=new OpenFileDialog();
            opd.Filter="Dump Files(*.dump)|*.dump|All Files(*.*)|*.*";
            opd.CheckPathExists=true;
            opd.CheckFileExists=false;
            opd.ShowDialog();
            return opd.FileName;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            tbDumpFile.Text=ShowOpenFile();
            if (File.Exists(tbDumpFile.Text))
            {
                ShowDumpFile(tbDumpFile.Text);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            tbKeyFile.Text=ShowOpenFile(); if (File.Exists(tbKeyFile.Text))
            {
                ShowDumpFile(tbDumpFile.Text);
            }
        }

        private ListViewItem Slv;
        private int lvsid=0;
        private void listViewKey_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                this.Slv=listViewKey.SelectedItems[0];
                for (int i=0; i < Slv.SubItems.Count; i++)
                {
                    int lvx=Slv.SubItems[i].Bounds.Location.X;
                    int lvxc=lvx + Slv.SubItems[i].Bounds.Width;
                    if (e.X > lvx && lvxc > e.X)
                    {
                        if (i == 5)
                        {
                            FrmKeyManage f=new FrmKeyManage();
                            f.BlockPermString=Slv.SubItems[i].Text;
                            if (f.ShowDialog() == DialogResult.OK)
                            {
                                Slv.SubItems[i].Text=f.BlockPermString;
                            }
                        }
                        else
                        {
                            tbEdit.Visible=true;
                            lvsid=i;
                            tbEdit.Left=listViewKey.Left + Slv.SubItems[i].Bounds.Left;
                            tbEdit.Top=listViewKey.Top + Slv.SubItems[i].Bounds.Top;
                            tbEdit.Width=Slv.SubItems[i].Bounds.Width;
                            tbEdit.Height=Slv.SubItems[i].Bounds.Height;
                            tbEdit.Text=Slv.SubItems[i].Text ;
                            tbEdit.Focus();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Common.Log.WriteLog(ex.Message.ToString());
            }
        }

        private void tbEdit_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void tbEdit_Leave(object sender, EventArgs e)
        {
            tbEdit.Visible=false;
        }

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
        private void tbEdit_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                //  string[] key = new String[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", "A", "B", "C", "D", "E", "F"};
                if (e.KeyCode == Keys.Enter)
                {
                    string str=tbEdit.Text.ToUpper().PadRight(32, '0');
                    string Res="" ;
                    int count=32;
                    if (lvsid == 4 || lvsid == 6)
                    {
                        count=12;
                    }
                    if (lvsid == 5)
                    {
                        count=8;
                    }
                    for (int i=0; i < count; i++)
                    {
                        if (Skey.Contains(str.Substring(i, 1)))
                        {
                            Res+=str.Substring(i, 1);
                        }
                    }
                    Res=Res.PadRight(count, '0');

                    Slv.SubItems[lvsid].Text=Res;
                    tbEdit.Visible=false;
                }
            }
            catch (Exception ex)
            {
                Common.Log.WriteLog(ex.Message.ToString());
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            SaveDumpFile(ShowOpenFile());
        }

        private void button11_Click(object sender, EventArgs e)
        {
            string filename=ShowOpenFile();
            if (!File.Exists(filename))
            {
                MessageBox.Show("文件不存在！", "错误提示");
                return;
            }
            StreamReader sr=new StreamReader(filename);
            string str="";
            while ((str=sr.ReadLine().ToUpper()) != null)
            {
                String Res="";
                for (int i=0; i < 12; i++)
                {
                    if (Skey.Contains(str.Substring(i, 1)))
                    {
                        Res+=str.Substring(i, 1);
                    }
                }
                Res=Res.PadRight(12, '0');

                if (!listBox1.Items.Contains(Res))
                {
                    listBox1.Items.Add(Res);
                }
            }
            sr.Close();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            StreamWriter sw=new StreamWriter(ShowOpenFile());
            for (int i=0; i < listBox1.Items.Count; i++)
            {
                sw.WriteLine(listBox1.Items[i].ToString());
            }
            sw.Close();
        }

        private void doMfock()
        {
            string keys="";
            for (int i=0; i < listBox1.Items.Count; i++)
            {
                keys+=" -k " + listBox1.Items[i].ToString();
            }
            string dumpfile=tbDumpFile.Text.Length < 2 ? Application.StartupPath + "\\dumpfile.dump" : tbDumpFile.Text;
            Common.MfocWorker.mfoc(this, int.Parse(this.probesNumericUpDown.Value.ToString()), int.Parse(this.distanceNumericUpDown.Value.ToString()), this.tbDumpFile.Text, keys);
        }

        private void keepTime()
        {
            DateTime now=DateTime.Now;
            while (this.trackTime)
            {
                TimeSpan span=(DateTime.Now - now);
                if (span > TimeSpan.FromHours(1.0))
                {
                    this.updateTimeLabel(span.Hours.ToString() + "小时" + span.Minutes.ToString() + "分" + span.Seconds.ToString() + "秒");
                }
                else if (span > TimeSpan.FromMinutes(1.0))
                {
                    this.updateTimeLabel(span.Minutes.ToString() + "分" + span.Seconds.ToString() + "秒");
                }
                else
                {
                    this.updateTimeLabel(span.Seconds.ToString() + "秒");
                }
                Thread.Sleep(20);
            }
        }

        private bool trackTime=false;
        private void button3_Click(object sender, EventArgs e)
        {
            if (this.button3.Text == "枚举密钥")
            {
                this.trackTime=true;
                this.T=new Thread(new ThreadStart(this.doMfock));
                this.Time=new Thread(new ThreadStart(this.keepTime));
                this.T.Start();
                this.Time.Start();
                this.updateStatus(1);
            }
            else if (this.button3.Text == "停止枚举")
            {
                this.T.Abort();
                this.Time.Abort();
                this.updateStatus(0);
                this.trackTime=true;
            }
        }

        private void tbNewUid_KeyPress(object sender, KeyPressEventArgs e)
        {
            string str=e.KeyChar.ToString().ToUpper(); 
            if (!Skey.Contains(str))
            {
                e.KeyChar='0';
            }
            //string str = tbNewUid.Text;
            //String Res = "";
            //for (int i = 0; i < 8; i++)
            //{
            //    if (Skey.Contains(str.Substring(i, 1)))
            //    {
            //        Res += str.Substring(i, 1);
            //    }
            //}
            //Res = Res.PadRight(8, '0');
            //tbNewUid.Text = Res;
        }

        private void tbNewUid_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string str=tbNewUid.Text;
            String Res="";
            for (int i=0; i < 8; i++)
            {
                if (Skey.Contains(str.Substring(i, 1)))
                {
                    Res+=str.Substring(i, 1);
                }
            }
            Res=Res.PadRight(8, '0');
            string result=Common.NfcWorker.NfcCall("nfc-mfsetuid.exe", "-f " + Res);
            tbLog.AppendText(result); tbLog.AppendText("\n");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            ReadWrtieCard("r"); ShowDumpFile(tbDumpFile.Text);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            ReadWrtieCard("w");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ReadWrtieCard("R");
            ShowDumpFile(tbDumpFile.Text);
        }

        private void ReadWrtieCard(string scmd)
        {
            string skey=radioButton1.Checked ? "a" : "b";
            // string scmd = "W";
            if (!File.Exists(tbDumpFile.Text))
            {
                MessageBox.Show("请选择Dump文件！");
                tbDumpFile.Focus();
                return;
            }
            string cmd="";
            //  StringBuilder sb = new StringBuilder("");
            if (!File.Exists(tbKeyFile.Text))
            {
                // sb.AppendFormat(" %s %s \"%s\" ", scmd , skey , tbDumpFile.Text);
                cmd=string.Concat(new object[]
                {
                    " ",
                    scmd,
                    " ",
                    skey,
                    " ",
                    "\"",
                    tbDumpFile.Text,
                    "\""
                });
            }
            else
            {
                //sb.AppendFormat(" %s %s \"%s\" \"%s\" ", scmd , skey , tbDumpFile.Text,tbKeyFile.Text);
                cmd=string.Concat(new object[]
                {
                    " ",
                    scmd,
                    " ",
                    skey,
                    " ",
                    "\"",
                    tbDumpFile.Text,
                    "\"",
                    " ",
                    "\"",
                    tbKeyFile.Text,
                    "\""
                });
            }
            string result=Common.NfcWorker.NfcCall("nfc-mfclassic.exe", cmd);
            tbLog.AppendText(result);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            ReadWrtieCard("W");
        }

        private void button13_Click(object sender, EventArgs e)
        {
            DataTable dt=new DataTable();
            dt.Columns.Add("id");
            dt.Columns.Add("block0");
            dt.Columns.Add("block1");
            dt.Columns.Add("block2");
            dt.Columns.Add("keya");

            dt.Columns.Add("control");
            dt.Columns.Add("keyb");
            for (int i=0; i < this.listViewKey.Items.Count; i++)
            {
                DataRow dr=dt.NewRow();
                for (int j=0; j < listViewKey.Items[i].SubItems.Count; j++)
                {
                    dr[j]=listViewKey.Items[i].SubItems[j].Text ;
                }
                //  dr["id"]=listViewKey.Items[i].SubItems[0];
            }
            Common.ExcelIO.GetInstance().DataTableToExecl(dt, ShowOpenFile(), null);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            FrmKeyManage key=new FrmKeyManage();
            key.ShowDialog();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            MessageBox.Show("什么是RadioWar？\r\n    RadioWar估计是国内首个公开专注研究无线类安全方面的“组织”，之所谓需要使用双引号是因为我们这个组织并没有任何纪律，没有任何规则。彼此都在学习，彼此都在研究相关的技术。我们主要专注于研究2.4GHz无线网络安全、RFID安全、NFC安全以及移动终端等等。我们都是初级入门人士，不能够说在这个圈子有任何的技术领先之类的！希望大家可以跟我们技术研讨。\r\n        RadioWar的成员：\r\n    团-长\r\n    磁力共振\r\n    物理呆呆熊\r\n    IndigoSoul\r\n    douniwan5788（忘记万恶的你！）\r\n    super480（邪恶的人）\r\n    Open（一个每天需要男人的MM）\r\n    鬼仔\r\n    cooaoo\r\n    h4k_b4n\r\n    A.I.");

        }
    }
}