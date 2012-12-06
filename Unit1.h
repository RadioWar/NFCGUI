//---------------------------------------------------------------------------

#ifndef Unit1H
#define Unit1H
//---------------------------------------------------------------------------
#include <System.Classes.hpp>
#include <Vcl.Controls.hpp>
#include <Vcl.StdCtrls.hpp>
#include <Vcl.Forms.hpp>
#include <Vcl.Dialogs.hpp>
#include <Vcl.ExtCtrls.hpp>
//---------------------------------------------------------------------------
class TForm1 : public TForm
{
__published:	// IDE-managed Components
	TMemo *Memo1;
	TGroupBox *GroupBox1;
	TButton *Button1;
	TButton *Button2;
	TEdit *Edit1;
	TEdit *Edit2;
	TLabel *Label1;
	TLabel *Label2;
	TGroupBox *GroupBox2;
	TButton *Button3;
	TEdit *Edit3;
	TEdit *Edit4;
	TGroupBox *GroupBox3;
	TButton *Button4;
	TRadioButton *RadioButton1;
	TRadioButton *RadioButton2;
	TRadioButton *RadioButton3;
	TRadioButton *RadioButton4;
	TGroupBox *GroupBox4;
	TLabel *Label3;
	TLabel *Label4;
	TButton *Button5;
	TButton *Button6;
	TEdit *Edit5;
	TEdit *Edit6;
	TButton *Button7;
	TRadioButton *RadioButton5;
	TRadioButton *RadioButton6;
	TOpenDialog *OpenDialog1;
	TLabel *Label5;
	TLabel *Label6;
	TPanel *Panel1;
	AnsiString __fastcall PipeCall(AnsiString szAppName, AnsiString szCmdLine) ;
	void __fastcall Button1Click(TObject *Sender);
	void __fastcall Button7Click(TObject *Sender);
	void __fastcall Button5Click(TObject *Sender);
	void __fastcall Button6Click(TObject *Sender);
	void __fastcall Button2Click(TObject *Sender);
	void __fastcall Button3Click(TObject *Sender);
	void __fastcall Edit2KeyPress(TObject *Sender, System::WideChar &Key);
	void __fastcall Button4Click(TObject *Sender);
private:	// User declarations
public:		// User declarations
	__fastcall TForm1(TComponent* Owner);
};
//---------------------------------------------------------------------------
extern PACKAGE TForm1 *Form1;
//---------------------------------------------------------------------------
#endif
