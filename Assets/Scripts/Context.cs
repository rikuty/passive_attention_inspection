using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using UnityEngine;




public class Context
{

    public int currentAnswer { get; private set; }

    public float answerTime = 0f;

    /// <summary>
    /// 設問数
    /// </summary>
    public int quizNum = 32;




    /// <summary>
    /// 現在何問目か
    /// </summary>
    public int quizCurrentNum = 0;

    /// <summary>
    /// 現在何周目か
    /// </summary>
    public int playCount = 0;

    /// <summary>
    /// 現在何問正解か
    /// </summary>
    public int correctCount = 0;

    public bool isPlay = false;

    public bool isAnswering = false;

    public bool isFinalQuiz
    {
        get
        {
            return this.quizNum == quizCurrentNum;
        }
    }

    private float[] answerTimes;

    public float sumTime = 0f;

    public float averageTime
    {
        get
        {
            return sumTime / quizCurrentNum;
        }
    }


    public void Init()
    {
        this.isPlay = false;
        this.isAnswering = false;
        this.playCount++;
        this.answerTimes = new float[quizNum * 2];
    }

    // Use this for initialization
    public void StartPlay()
    {
        this.isPlay = true;
        this.SetNextAnswers();
        this.correctCount = 0;
        this.quizCurrentNum = 1;
    }

    private int[] randoms = {1,2,3,4,5,6,7,8};
    public void SetNextAnswers()
    {
        this.quizCurrentNum++;

        bool plus = false;
        foreach (int value in this.randoms)
        {
            if (value != -1)
            {
                plus = true;
            }
        }
        if(!plus){
            randoms = new int[] { 1,2,3,4,5,6,7,8};
        }

        bool hit = false;
        while (hit == false) {
            int ran = UnityEngine.Random.Range(1, 9);
            foreach (int answer in this.randoms)
            {
                if (answer == ran)
                {
                    hit = true;
                }
            }
            if (hit)
            {
                randoms[ran - 1] = -1;
                this.currentAnswer = ran;
            }
        }

        this.answerTime = 0f;
        this.isAnswering = true;
    }



    
    public bool CheckAnswer(int answer)
    {
        bool result = false;
        if(answer == this.currentAnswer){
            this.correctCount++;
            result = true;
        }

        this.sumTime += this.answerTime;
        this.answerTimes[(this.quizCurrentNum - 1)*2] = this.currentAnswer;
        this.answerTimes[(this.quizCurrentNum-1)*2+1] = this.answerTime;

        return result;
    }


    public void Finish(){
        // ファイル書き出し
        // 現在のフォルダにsaveData.csvを出力する(決まった場所に出力したい場合は絶対パスを指定してください)
        // 引数説明：第1引数→ファイル出力先, 第2引数→ファイルに追記(true)or上書き(false), 第3引数→エンコード
        //StreamWriter sw;
        StreamWriter sw = new StreamWriter(Application.persistentDataPath + "/saveData_" + GameData.Instance.id + ".csv", true, Encoding.UTF8);
        //FileInfo fi;
        //fi = new FileInfo(Application.persistentDataPath + "/csv/saveData_" + Gamestrap.MainMenuControl.ID + ".csv");
        //fi = new FileInfo("saveData_" + System.DateTime.Now.ToString("yyMMddHHmm") + ".csv");
        //Debug.Log(Application.persistentDataPath + "/saveData_" + System.DateTime.Now.ToString("yyMMddHHmm") + ".csv");
        //sw = fi.AppendText();

        //sw.WriteLine("x=" + GameData.Instance.x.ToString() + "=" + GameData.Instance.y.ToString());

        // データ出力
        string line = "";
        for (int i = 0; i < this.answerTimes.Length; i++)
        {
            line +=this.answerTimes[i].ToString("F2")+",";
            if (i % 2 == 1)
            {
                sw.WriteLine(line);
                line = "";
            }

        }

        //sw.WriteLine(line);

        sw.WriteLine(this.averageTime.ToString());
        sw.WriteLine("");

        sw.Flush();
        // StreamWriterを閉じる
        sw.Close();
    }
}
