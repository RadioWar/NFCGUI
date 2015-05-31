object Form1: TForm1
  Left = 0
  Top = 0
  BorderIcons = [biSystemMenu, biMinimize]
  Caption = 'NFC GUI FREE 0.3'
  ClientHeight = 532
  ClientWidth = 641
  Color = cl3DLight
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'Tahoma'
  Font.Style = []
  OldCreateOrder = False
  PixelsPerInch = 96
  TextHeight = 13
  object Memo1: TMemo
    Left = 8
    Top = 318
    Width = 610
    Height = 194
    Color = cl3DLight
    Lines.Strings = (
      'NFC GUI FREE 03')
    ReadOnly = True
    ScrollBars = ssVertical
    TabOrder = 0
  end
  object GroupBox1: TGroupBox
    Left = 15
    Top = 16
    Width = 217
    Height = 145
    Caption = #22522#26412#21151#33021
    TabOrder = 1
    object Label1: TLabel
      Left = 24
      Top = 66
      Width = 42
      Height = 13
      Caption = #21407'UID'#65306
    end
    object Label2: TLabel
      Left = 24
      Top = 111
      Width = 42
      Height = 13
      Caption = #26032'UID'#65306
    end
    object Button1: TButton
      Left = 24
      Top = 21
      Width = 75
      Height = 25
      Caption = #35835#22522#26412#20449#24687
      TabOrder = 0
      OnClick = Button1Click
    end
    object Button2: TButton
      Left = 118
      Top = 21
      Width = 75
      Height = 25
      Caption = #20462#25913'UID'
      TabOrder = 1
      OnClick = Button2Click
    end
    object Edit1: TEdit
      Left = 80
      Top = 60
      Width = 113
      Height = 27
      Color = cl3DLight
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -16
      Font.Name = 'Tahoma'
      Font.Style = []
      MaxLength = 8
      ParentFont = False
      ReadOnly = True
      TabOrder = 2
    end
    object Edit2: TEdit
      Left = 80
      Top = 103
      Width = 113
      Height = 27
      Font.Charset = DEFAULT_CHARSET
      Font.Color = clWindowText
      Font.Height = -16
      Font.Name = 'Tahoma'
      Font.Style = []
      MaxLength = 8
      ParentFont = False
      TabOrder = 3
      OnKeyPress = Edit2KeyPress
    end
  end
  object GroupBox2: TGroupBox
    Left = 256
    Top = 16
    Width = 369
    Height = 57
    Caption = #26522#20030#21151#33021
    TabOrder = 2
    object Label5: TLabel
      Left = 256
      Top = 26
      Width = 48
      Height = 13
      Caption = #20844#24046#33539#22260
    end
    object Label6: TLabel
      Left = 124
      Top = 26
      Width = 72
      Height = 13
      Caption = #25506#27979#27599#20010#25159#21306
    end
    object Button3: TButton
      Left = 24
      Top = 21
      Width = 75
      Height = 25
      Caption = #26522#20030#23494#38053
      Enabled = False
      TabOrder = 0
      OnClick = Button3Click
    end
    object Edit3: TEdit
      Left = 208
      Top = 23
      Width = 26
      Height = 21
      MaxLength = 2
      NumbersOnly = True
      TabOrder = 1
      Text = '20'
    end
    object Edit4: TEdit
      Left = 319
      Top = 23
      Width = 26
      Height = 21
      MaxLength = 2
      NumbersOnly = True
      TabOrder = 2
      Text = '20'
    end
  end
  object GroupBox3: TGroupBox
    Left = 256
    Top = 79
    Width = 369
    Height = 81
    Caption = #35835#12289#20889#21151#33021
    TabOrder = 3
    object Button4: TButton
      Left = 24
      Top = 21
      Width = 75
      Height = 25
      Caption = #35835#12289#20889#21345
      TabOrder = 0
      OnClick = Button4Click
    end
    object Panel1: TPanel
      Left = 136
      Top = 3
      Width = 233
      Height = 75
      BevelOuter = bvNone
      Ctl3D = False
      ParentCtl3D = False
      TabOrder = 1
      object RadioButton1: TRadioButton
        Left = 32
        Top = 16
        Width = 89
        Height = 17
        Caption = #35835#19968#33324#30333#21345
        Checked = True
        TabOrder = 0
        TabStop = True
      end
      object RadioButton2: TRadioButton
        Left = 135
        Top = 16
        Width = 81
        Height = 17
        Caption = #35835'UID'#30333#21345
        TabOrder = 1
      end
      object RadioButton3: TRadioButton
        Left = 33
        Top = 47
        Width = 89
        Height = 17
        Caption = #20889#19968#33324#30333#21345
        TabOrder = 2
      end
      object RadioButton4: TRadioButton
        Left = 136
        Top = 47
        Width = 89
        Height = 17
        Caption = #20889'UID'#30333#21345
        TabOrder = 3
      end
    end
  end
  object GroupBox4: TGroupBox
    Left = 15
    Top = 167
    Width = 610
    Height = 145
    Caption = #25991#20214#35774#32622
    TabOrder = 4
    object Label3: TLabel
      Left = 24
      Top = 31
      Width = 55
      Height = 13
      Caption = 'DUMP '#25991#20214
    end
    object Label4: TLabel
      Left = 24
      Top = 89
      Width = 45
      Height = 13
      Caption = 'KEY '#25991#20214
    end
    object Button5: TButton
      Left = 544
      Top = 22
      Width = 42
      Height = 25
      Caption = #25171#24320
      TabOrder = 0
      OnClick = Button5Click
    end
    object Button6: TButton
      Left = 544
      Top = 80
      Width = 42
      Height = 25
      Caption = #25171#24320
      TabOrder = 1
      OnClick = Button6Click
    end
    object Edit5: TEdit
      Left = 24
      Top = 53
      Width = 562
      Height = 21
      MaxLength = 256
      TabOrder = 2
      Text = 'c:\d.dump'
    end
    object Edit6: TEdit
      Left = 24
      Top = 111
      Width = 562
      Height = 21
      MaxLength = 256
      TabOrder = 3
    end
    object Button7: TButton
      Left = 488
      Top = 80
      Width = 25
      Height = 25
      Caption = #8595
      TabOrder = 4
      OnClick = Button7Click
    end
    object RadioButton5: TRadioButton
      Left = 152
      Top = 88
      Width = 113
      Height = 17
      Caption = 'KEY A'
      Checked = True
      TabOrder = 5
      TabStop = True
    end
    object RadioButton6: TRadioButton
      Left = 296
      Top = 88
      Width = 113
      Height = 17
      Caption = 'KEY B'
      TabOrder = 6
    end
  end
  object OpenDialog1: TOpenDialog
    Left = 504
    Top = 176
  end
end
