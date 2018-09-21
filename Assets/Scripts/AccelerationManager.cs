using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccelerationManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		ProcessStart();
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	void ProcessStart()
	{
		// プロセス作成.
		System.Diagnostics.Process process = new System.Diagnostics.Process();

		// 起動するプロセス.
		process.StartInfo.FileName = "/Plugins/MWSDK/Tools/tweprog_py/tweterm.py";

		// プロセス起動にシェルを使用するかどうか(defaultはfalse).
		process.StartInfo.UseShellExecute = false;

		// 標準出力を読み取り可.
		process.StartInfo.RedirectStandardOutput = true;

		// 標準出力イベント設定.
		process.OutputDataReceived += new System.Diagnostics.DataReceivedEventHandler(OutputHandler);

		// エラー出力読み取り可.
		process.StartInfo.RedirectStandardError = true;

		// エラー出力イベント設定.
		process.ErrorDataReceived += new System.Diagnostics.DataReceivedEventHandler(ErrorOutputHanlder);

		// 入力を読み取り不可.
		process.StartInfo.RedirectStandardInput = false;

		// 新しいウインドウを作成しない.
		process.StartInfo.CreateNoWindow = false;

		// 引数の指定（開くファイルの指定等）.
		process.StartInfo.Arguments = "/Plugins/MWSDK/Wks_TWELITE/App_Tag/Parent/Build/App_Tag_Parent_BLUE_MONOSTICK_L1200_V2-1-3.bin";
		// ftdi://ftdi:232:MW2GOC2I/1

		// プロセス終了時にExitedイベントを発生.
		process.EnableRaisingEvents = true;

		// プロセス終了時に呼び出されるイベントの設定.
		process.Exited += new System.EventHandler(Process_Exit);

		// プロセスの起動.
		process.Start();

		// プロセス標準出力.
		process.BeginOutputReadLine();

		// プロセスエラー出力.
		process.BeginErrorReadLine();
	}


	// 標準出力時.
	private void OutputHandler(object sender, System.Diagnostics.DataReceivedEventArgs args)
	{
		if (!string.IsNullOrEmpty(args.Data))
		{
			Debug.Log(args.Data);
		}
	}

	// エラー出力時.
	private void ErrorOutputHanlder(object sender, System.Diagnostics.DataReceivedEventArgs args)
	{
		if (!string.IsNullOrEmpty(args.Data))
		{
			Debug.Log("ERROR----------");
			Debug.Log(args.Data);
		}
	}

	// プロセス終了時.
	private void Process_Exit(object sender, System.EventArgs e)
	{
		System.Diagnostics.Process proc = (System.Diagnostics.Process)sender;

		// プロセスを閉じる.
		proc.Kill();
	}
}
