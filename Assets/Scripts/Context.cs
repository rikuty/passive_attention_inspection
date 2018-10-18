using System;
using System.Linq;

public class Context {
    
    public int currentAnswer { get; private set; }

    public float answerTime = 0f;

    /// <summary>
    /// 設問数
    /// </summary>
    public int quizNum = 10;

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

    public bool isFinalQuiz{
        get{
            return this.quizNum == quizCurrentNum;
        }
    }

    public float sumTime = 0f;

    public float averageTime {
        get{
            return sumTime / quizCurrentNum;
        }
    }


	public void Init()
	{
        this.isPlay = false;
        this.isAnswering = false;
        this.playCount++;
	}

    // Use this for initialization
    public void StartPlay(){
        this.isPlay = true;
        this.SetNextAnswers();
        this.correctCount = 0;
        this.quizCurrentNum = 1;
    }
        
    public void SetNextAnswers()
    {        
        this.quizCurrentNum++;

        this.currentAnswer = UnityEngine.Random.Range(1, 9);


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

        return result;
    }
}
