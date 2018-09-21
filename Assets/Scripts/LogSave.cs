using UnityEngine;
using System.Collections;
using System.IO;
using System;


public class LogSave : MonoBehaviour{
	public void logSave(string txt){
		StreamWriter sw;
		FileInfo fi;
		fi = new FileInfo(Application.dataPath + "/FileName.csv");
		sw = fi.AppendText();
		sw.WriteLine(txt);
		sw.Flush();
		sw.Close();
	}
}