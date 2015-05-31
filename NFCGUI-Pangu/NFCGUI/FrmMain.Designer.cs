namespace NFCGui
{
    partial class FrmMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tbNewUid = new System.Windows.Forms.TextBox();
            this.tbUid = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbLog = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button14 = new System.Windows.Forms.Button();
            this.button13 = new System.Windows.Forms.Button();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.button10 = new System.Windows.Forms.Button();
            this.tbKeyFile = new System.Windows.Forms.TextBox();
            this.tbDumpFile = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.tbEdit = new System.Windows.Forms.TextBox();
            this.listViewKey = new System.Windows.Forms.ListView();
            this.ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Block0 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Block1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Block2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.KeyA = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Control = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.KeyB = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.button15 = new System.Windows.Forms.Button();
            this.button12 = new System.Windows.Forms.Button();
            this.button11 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.distanceNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.probesNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.timeLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.button16 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.distanceNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.probesNumericUpDown)).BeginInit();
            this.groupBox6.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(6, 20);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(101, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "读取基本信息";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tbNewUid);
            this.groupBox1.Controls.Add(this.tbUid);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(232, 112);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "基本功能";
            // 
            // tbNewUid
            // 
            this.tbNewUid.Location = new System.Drawing.Point(47, 81);
            this.tbNewUid.Name = "tbNewUid";
            this.tbNewUid.Size = new System.Drawing.Size(169, 21);
            this.tbNewUid.TabIndex = 4;
            this.tbNewUid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbNewUid_KeyDown);
            this.tbNewUid.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbNewUid_KeyPress);
            // 
            // tbUid
            // 
            this.tbUid.Location = new System.Drawing.Point(48, 57);
            this.tbUid.Name = "tbUid";
            this.tbUid.ReadOnly = true;
            this.tbUid.Size = new System.Drawing.Size(169, 21);
            this.tbUid.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "新UID";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "原UID";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(142, 21);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "修改UID";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tbLog);
            this.groupBox2.Location = new System.Drawing.Point(250, 295);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(618, 191);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "信息";
            // 
            // tbLog
            // 
            this.tbLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbLog.Location = new System.Drawing.Point(3, 17);
            this.tbLog.Multiline = true;
            this.tbLog.Name = "tbLog";
            this.tbLog.ReadOnly = true;
            this.tbLog.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbLog.Size = new System.Drawing.Size(612, 171);
            this.tbLog.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button16);
            this.groupBox3.Controls.Add(this.button14);
            this.groupBox3.Controls.Add(this.button13);
            this.groupBox3.Controls.Add(this.radioButton2);
            this.groupBox3.Controls.Add(this.radioButton1);
            this.groupBox3.Controls.Add(this.button10);
            this.groupBox3.Controls.Add(this.tbKeyFile);
            this.groupBox3.Controls.Add(this.tbDumpFile);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.button5);
            this.groupBox3.Controls.Add(this.button4);
            this.groupBox3.Location = new System.Drawing.Point(250, 14);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(615, 110);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "文件设置";
            // 
            // button14
            // 
            this.button14.Enabled = false;
            this.button14.Location = new System.Drawing.Point(369, 47);
            this.button14.Name = "button14";
            this.button14.Size = new System.Drawing.Size(75, 23);
            this.button14.TabIndex = 6;
            this.button14.Text = "Load Excel";
            this.button14.UseVisualStyleBackColor = true;
            // 
            // button13
            // 
            this.button13.Enabled = false;
            this.button13.Location = new System.Drawing.Point(450, 47);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(75, 23);
            this.button13.TabIndex = 5;
            this.button13.Text = "SaveToExcel";
            this.button13.UseVisualStyleBackColor = true;
            this.button13.Click += new System.EventHandler(this.button13_Click);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(112, 73);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(47, 16);
            this.radioButton2.TabIndex = 4;
            this.radioButton2.Text = "KeyB";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(59, 73);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(47, 16);
            this.radioButton1.TabIndex = 4;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "KeyA";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(531, 47);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(78, 23);
            this.button10.TabIndex = 3;
            this.button10.Text = "保存文件";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // tbKeyFile
            // 
            this.tbKeyFile.Location = new System.Drawing.Point(165, 73);
            this.tbKeyFile.Name = "tbKeyFile";
            this.tbKeyFile.Size = new System.Drawing.Size(360, 21);
            this.tbKeyFile.TabIndex = 2;
            // 
            // tbDumpFile
            // 
            this.tbDumpFile.Location = new System.Drawing.Point(65, 20);
            this.tbDumpFile.Name = "tbDumpFile";
            this.tbDumpFile.Size = new System.Drawing.Size(460, 21);
            this.tbDumpFile.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "Key文件";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "Dump文件";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(531, 73);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(78, 23);
            this.button5.TabIndex = 0;
            this.button5.Text = "选择文件";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(531, 20);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(78, 23);
            this.button4.TabIndex = 0;
            this.button4.Text = "选择文件";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.tbEdit);
            this.groupBox4.Controls.Add(this.listViewKey);
            this.groupBox4.Location = new System.Drawing.Point(250, 131);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(615, 158);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "文件信息";
            // 
            // tbEdit
            // 
            this.tbEdit.Location = new System.Drawing.Point(65, 48);
            this.tbEdit.Name = "tbEdit";
            this.tbEdit.Size = new System.Drawing.Size(100, 21);
            this.tbEdit.TabIndex = 1;
            this.tbEdit.Visible = false;
            this.tbEdit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbEdit_KeyDown);
            this.tbEdit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbEdit_KeyPress);
            this.tbEdit.Leave += new System.EventHandler(this.tbEdit_Leave);
            // 
            // listViewKey
            // 
            this.listViewKey.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ID,
            this.Block0,
            this.Block1,
            this.Block2,
            this.KeyA,
            this.Control,
            this.KeyB});
            this.listViewKey.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewKey.FullRowSelect = true;
            this.listViewKey.GridLines = true;
            this.listViewKey.Location = new System.Drawing.Point(3, 17);
            this.listViewKey.MultiSelect = false;
            this.listViewKey.Name = "listViewKey";
            this.listViewKey.ShowItemToolTips = true;
            this.listViewKey.Size = new System.Drawing.Size(609, 138);
            this.listViewKey.TabIndex = 0;
            this.listViewKey.UseCompatibleStateImageBehavior = false;
            this.listViewKey.View = System.Windows.Forms.View.Details;
            this.listViewKey.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listViewKey_MouseDoubleClick);
            // 
            // ID
            // 
            this.ID.Text = "扇区";
            this.ID.Width = 43;
            // 
            // Block0
            // 
            this.Block0.Tag = "32";
            this.Block0.Text = "Block 0";
            this.Block0.Width = 117;
            // 
            // Block1
            // 
            this.Block1.Tag = "32";
            this.Block1.Text = "Block 1";
            this.Block1.Width = 99;
            // 
            // Block2
            // 
            this.Block2.Tag = "32";
            this.Block2.Text = "Block 2";
            this.Block2.Width = 121;
            // 
            // KeyA
            // 
            this.KeyA.Tag = "12";
            this.KeyA.Text = "KeyA";
            this.KeyA.Width = 59;
            // 
            // Control
            // 
            this.Control.Tag = "8";
            this.Control.Text = "Control";
            this.Control.Width = 61;
            // 
            // KeyB
            // 
            this.KeyB.Tag = "12";
            this.KeyB.Text = "KeyB";
            this.KeyB.Width = 64;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.button15);
            this.groupBox5.Controls.Add(this.button12);
            this.groupBox5.Controls.Add(this.button11);
            this.groupBox5.Controls.Add(this.button9);
            this.groupBox5.Controls.Add(this.button8);
            this.groupBox5.Controls.Add(this.button7);
            this.groupBox5.Controls.Add(this.button6);
            this.groupBox5.Controls.Add(this.button3);
            this.groupBox5.Controls.Add(this.distanceNumericUpDown);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Controls.Add(this.probesNumericUpDown);
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Location = new System.Drawing.Point(12, 131);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(232, 158);
            this.groupBox5.TabIndex = 6;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "卡片选项";
            // 
            // button15
            // 
            this.button15.Location = new System.Drawing.Point(129, 69);
            this.button15.Name = "button15";
            this.button15.Size = new System.Drawing.Size(97, 23);
            this.button15.TabIndex = 6;
            this.button15.Text = "计算控制位";
            this.button15.UseVisualStyleBackColor = true;
            this.button15.Click += new System.EventHandler(this.button15_Click);
            // 
            // button12
            // 
            this.button12.Location = new System.Drawing.Point(129, 43);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(97, 23);
            this.button12.TabIndex = 5;
            this.button12.Text = "保存密钥";
            this.button12.UseVisualStyleBackColor = true;
            this.button12.Click += new System.EventHandler(this.button12_Click);
            // 
            // button11
            // 
            this.button11.Location = new System.Drawing.Point(10, 43);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(97, 23);
            this.button11.TabIndex = 5;
            this.button11.Text = "加载密钥";
            this.button11.UseVisualStyleBackColor = true;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(129, 125);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(97, 23);
            this.button9.TabIndex = 4;
            this.button9.Text = "写入UID卡";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(10, 125);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(97, 23);
            this.button8.TabIndex = 4;
            this.button8.Text = "写入一般白卡";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(129, 96);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(97, 23);
            this.button7.TabIndex = 4;
            this.button7.Text = "读取UID卡";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(10, 96);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(97, 23);
            this.button6.TabIndex = 4;
            this.button6.Text = "读取一般白卡";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(10, 69);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(97, 23);
            this.button3.TabIndex = 4;
            this.button3.Text = "枚举密钥";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // distanceNumericUpDown
            // 
            this.distanceNumericUpDown.Location = new System.Drawing.Point(177, 19);
            this.distanceNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.distanceNumericUpDown.Name = "distanceNumericUpDown";
            this.distanceNumericUpDown.Size = new System.Drawing.Size(49, 21);
            this.distanceNumericUpDown.TabIndex = 3;
            this.distanceNumericUpDown.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(141, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 2;
            this.label6.Text = "差距";
            // 
            // probesNumericUpDown
            // 
            this.probesNumericUpDown.Location = new System.Drawing.Point(67, 19);
            this.probesNumericUpDown.Maximum = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.probesNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.probesNumericUpDown.Name = "probesNumericUpDown";
            this.probesNumericUpDown.Size = new System.Drawing.Size(68, 21);
            this.probesNumericUpDown.TabIndex = 1;
            this.probesNumericUpDown.Value = new decimal(new int[] {
            600,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "探测次数";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.listBox1);
            this.groupBox6.Location = new System.Drawing.Point(12, 295);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(232, 191);
            this.groupBox6.TabIndex = 7;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "密钥列表";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Items.AddRange(new object[] {
            "b5ff67cba951",
            "44dd5a385aaf",
            "21a600056cb0",
            "b1aca33180a5",
            "dd61eb6bce22",
            "1565a172770f",
            "3e84d2612e2a",
            "f23442436765",
            "79674f96c771",
            "87df99d496cb",
            "c5132c8980bc",
            "a21680c27773",
            "f26e21edcee2",
            "675557ecc92e",
            "f4396e468114",
            "6db17c16b35b",
            "4186562a5bb2",
            "2feae851c199",
            "db1a3338b2eb",
            "157b10d84c6b",
            "a643f952ea57",
            "df37dcb6afb3",
            "4c32baf326e0",
            "91ce16c07ac5",
            "3c5d1c2bcd18",
            "c3f19ec592a2",
            "f72a29005459",
            "185fa3438949",
            "321a695bd266",
            "d327083a60a7",
            "45635ef66ef3",
            "5481986d2d62",
            "cba6ae869ad5",
            "645a166b1eeb",
            "a7abbc77cc9e",
            "f792c4c76a5c",
            "bfb6796a11db"});
            this.listBox1.Location = new System.Drawing.Point(10, 21);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(207, 160);
            this.listBox1.TabIndex = 0;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel,
            this.timeLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 494);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(879, 22);
            this.statusStrip1.TabIndex = 8;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // statusLabel
            // 
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // timeLabel
            // 
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(0, 17);
            // 
            // button16
            // 
            this.button16.Location = new System.Drawing.Point(8, 47);
            this.button16.Name = "button16";
            this.button16.Size = new System.Drawing.Size(75, 23);
            this.button16.TabIndex = 7;
            this.button16.Text = "About...";
            this.button16.UseVisualStyleBackColor = true;
            this.button16.Click += new System.EventHandler(this.button16_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(879, 516);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(895, 554);
            this.MinimumSize = new System.Drawing.Size(895, 554);
            this.Name = "FrmMain";
            this.Text = "NFC-GUI  -- RadioWar:A.I. Ver";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.distanceNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.probesNumericUpDown)).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox tbNewUid;
        private System.Windows.Forms.TextBox tbUid;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox tbLog;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox tbKeyFile;
        private System.Windows.Forms.TextBox tbDumpFile;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ListView listViewKey;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.NumericUpDown distanceNumericUpDown;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown probesNumericUpDown;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ColumnHeader ID;
        private System.Windows.Forms.ColumnHeader Block0;
        private System.Windows.Forms.ColumnHeader KeyA;
        private System.Windows.Forms.ColumnHeader Control;
        private System.Windows.Forms.ColumnHeader KeyB;
        private System.Windows.Forms.ColumnHeader Block1;
        private System.Windows.Forms.ColumnHeader Block2;
        private System.Windows.Forms.TextBox tbEdit;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button button12;
        private System.Windows.Forms.Button button11;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel statusLabel;
        private System.Windows.Forms.ToolStripStatusLabel timeLabel;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Button button13;
        private System.Windows.Forms.Button button14;
        private System.Windows.Forms.Button button15;
        private System.Windows.Forms.Button button16;
    }
}

