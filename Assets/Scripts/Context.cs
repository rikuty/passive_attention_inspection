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


    public int playCount = 0;


    public int correctCount = 0;

    [NonSerialized] public bool isPlay = false;

    [NonSerialized] public bool isAnswering = false;


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
    }
        
    public void SetNextAnswers()
    {        

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
        return result;
    }
}
