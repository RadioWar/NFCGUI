// ---------------------------------------------------------------------------

#include <vcl.h>
#pragma hdrstop
#include <boost/regex.hpp>

#include "Unit1.h"
// ---------------------------------------------------------------------------
#pragma package(smart_init)
#pragma resource "*.dfm"
TForm1 *Form1;

// ---------------------------------------------------------------------------
__fastcall TForm1::TForm1(TComponent* Owner) : TForm(Owner) {
}

// ---------------------------------------------------------------------------
AnsiString __fastcall TForm1::PipeCall(AnsiString szAppName,
	AnsiString szCmdLine) {
	// TODO:   Add   your   source   code   here
	AnsiString Sreturn;
	if (FileExists(szAppName)) {

		char readBuf[50000];
		DWORD bytesRead = 0;
		HANDLE hReadPipe, hWritePipe;
		PROCESS_INFORMATION pi;
		LPPROCESS_INFORMATION lppi;
		SECURITY_ATTRIBUTES lsa; // 安全属性
		STARTUPINFO myStartup;
		lsa.nLength = sizeof(SECURITY_ATTRIBUTES);
		lsa.lpSecurityDescriptor = NULL;
		lsa.bInheritHandle = true;
		lppi = &pi; // 创建管道
		if (!CreatePipe(&hReadPipe, &hWritePipe, &lsa, 0)) {
	
			Sreturn = "进程管道建立失败 ";
			Memo1->Lines->Add(Sreturn);
			return Sreturn;
		}
		memset(&myStartup, 0, sizeof(STARTUPINFO));
		myStartup.cb = sizeof(STARTUPINFO);
		myStartup.dwFlags = STARTF_USESHOWWINDOW | STARTF_USESTDHANDLES;
		myStartup.wShowWindow = SW_HIDE;
		myStartup.hStdOutput = hWritePipe;
		if (!CreateProcess(WideString(szAppName).c_bstr() /* 批文件或执行文件名 */ ,
			WideString(szCmdLine).c_bstr(), NULL, NULL, true,
			CREATE_NEW_CONSOLE, NULL, NULL, &myStartup, &pi)) {
			Sreturn =
				("CreateProcess   error: " + IntToStr((int)GetLastError()));
			Memo1->Lines->Add(Sreturn);
			return Sreturn;
		}
		Memo1->Lines->Clear();
		while (true) {
			bytesRead = 0;
			if (!PeekNamedPipe(hReadPipe, readBuf, 1, &bytesRead, NULL, NULL))
				break;
			if (bytesRead) {
				if (!ReadFile(hReadPipe, readBuf, 49999, &bytesRead, NULL))
					break;
				readBuf[bytesRead] = 0;

				Sreturn =
					Form1->Memo1->Lines->Strings[Form1->Memo1->Lines->Count - 1]
					+ " " + readBuf;

				Form1->Memo1->Lines->Strings[Form1->Memo1->Lines->Count - 1] =
					Sreturn;

			}
			else {
				if (WaitForSingleObject(pi.hProcess, 0) == WAIT_OBJECT_0)
					break;
				Sleep(1000);
			}
		}
		CloseHandle(hReadPipe);
		CloseHandle(pi.hThread);
		CloseHandle(pi.hProcess);
		CloseHandle(hWritePipe);
	}
	else {
		Sreturn = szAppName + " 文件不存在！";
		Memo1->Lines->Clear();
		Memo1->Lines->Add(Sreturn);
		return Sreturn;
	}
	return Sreturn;
}
// ------------------------------------------------------------------------------

void __fastcall TForm1::Button1Click(TObject *Sender) {
	AnsiString Ssuid, Stmp;
	Stmp = PipeCall("nfc-list.exe", "");

	// //////////////////显示UID//////////////////////

	boost::regex rx("UID \\(\\S*\\): ((\\S\\S\\s\\s){4})",
		boost::regex_constants::normal | boost::regex_constants::icase);
	boost::cmatch results;
	if (boost::regex_search(Stmp.c_str(), results, rx)) {
		Ssuid = results.str(1).c_str();
	}
	else {
		Ssuid = "不能识别";
	}

	Edit1->Text = StringReplace(Ssuid, " ", "",
		TReplaceFlags() << rfReplaceAll); ;
}

// ---------------------------------------------------------------------------
void __fastcall TForm1::Button7Click(TObject *Sender) {
	Edit6->Text = Edit5->Text;

}
// ---------------------------------------------------------------------------

void __fastcall TForm1::Button5Click(TObject *Sender) {
	AnsiString Sfile_dir, Stmp;
	try {
		OpenDialog1->Execute();

		Sfile_dir = (OpenDialog1->FileName);
	}

	catch (Exception & E) {

		Memo1->Lines->Add(E.Message);
		return;
	}

	Edit5->Text = Sfile_dir;

}
// ---------------------------------------------------------------------------

void __fastcall TForm1::Button6Click(TObject *Sender) {
	AnsiString Sfile_dir;
	try {
		OpenDialog1->Execute();

		Sfile_dir = (OpenDialog1->FileName);
	}

	catch (Exception & E) {

		Memo1->Lines->Add(E.Message);
		return;
	}
	Edit6->Text = Sfile_dir;
}

// ---------------------------------------------------------------------------
void __fastcall TForm1::Button2Click(TObject *Sender) {
	AnsiString Smuid, Stmp;
	Smuid = Edit2->Text;
	if (Smuid == "" | Smuid.Length() != 8) {
		Memo1->Lines->Add("请输入一个8位的16进制UID值！\r\n");
		return;
	}
	Stmp.sprintf("-f %s", Smuid);
	Stmp = PipeCall("nfc-mfsetuid.exe", Stmp);
}
// ---------------------------------------------------------------------------

void __fastcall TForm1::Button3Click(TObject *Sender) {
	AnsiString St, Sp, Stmp, Sdumpfile;
	Sp = Edit3->Text;
	St = Edit4->Text;
	Sdumpfile = Edit5->Text;

}

// ---------------------------------------------------------------------------
void __fastcall TForm1::Edit2KeyPress(TObject *Sender, System::WideChar &Key) {
	if ((Key < '0' || Key > '9') && (Key < 'a' || Key > 'f') && (Key <
		'A' || Key > 'F'))

	{
		Key = 0;
	}

}
// ---------------------------------------------------------------------------

void __fastcall TForm1::Button4Click(TObject *Sender) {

	AnsiString Skey, Stmp, Sdumpfile, Skeyfile;

	Sdumpfile = Edit5->Text;

	if (Sdumpfile.TrimLeft() == "") {
		Memo1->Lines->Add("DUMP 文件不能为空！\r\n");
		return;
	}

	if (RadioButton5->Checked == True) {
		Skey = "a";
	}
	else {
		Skey = "b";
	}

	if (RadioButton1->Checked == True) {
		Stmp = "r";
	}
	else if (RadioButton2->Checked == True) {
		Stmp = "R";
	}
	else if (RadioButton3->Checked == True) {
		Stmp = "w";
	}
	else if (RadioButton4->Checked == True) {
		Stmp = "W";
	}
	else {
		Memo1->Lines->Add("未选择读写模式！\r\n");
		return ;
	}
	Skeyfile = Edit6->Text;
	if (Skeyfile == "") {
	Stmp.sprintf(" %s %s \"%s\" ", Stmp , Skey , Sdumpfile);
	}
	else{
	Stmp.sprintf(" %s %s \"%s\" \"%s\"", Stmp , Skey , Sdumpfile, Skeyfile);
	}
	Stmp = PipeCall("nfc-mfclassic.exe", Stmp);
}
// ---------------------------------------------------------------------------
