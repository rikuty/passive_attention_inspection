using System;
using System.Linq;

public class Context {

    //private const float PLAY_TIME = 60f;
    private const int FIRST_NUM = 1;
    private const int CHOICE_COUNT = 3;

    public int currentAnswer { get; private set; }
    public int numMinus { get; private set; }
    //public int nextAnswer { get; private set; }
    public int[] nextAnswers { get; private set; }

    public float speed = 0f;

    public int playCount = 0;


    public int correctCount = 0;

    [NonSerialized] public bool isPlay = false;

    //[NonSerialized] public float leftTime = PLAY_TIME;
    [NonSerialized] public float leftNum = FIRST_NUM;

    public float playTime{ get { return (float)playTimeWatch.Elapsed.TotalSeconds; } } 
    //System.DiagnosticsをusingするとDebugクラスとかぶるそうなので一旦直書き
    private System.Diagnostics.Stopwatch playTimeWatch = new System.Diagnostics.Stopwatch();

    public int quizCount { get; private set; }

    //public bool isLongSord { get; private set; }

    public bool isAnswering = false;

    /// <summary>
    /// 最後の問題かの判定(nextAnsersが全て同じ数値だったら最後)
    /// </summary>
    /// <returns><c>true</c>, if final quiz was ised, <c>false</c> otherwise.</returns>
    //public bool isFinalQuiz { get { return nextAnswers.All(num => num == this.nextAnswer); } }

    public bool isInvoke = true;

	public void Init()
	{
        this.currentAnswer = FIRST_NUM;
        //this.nextAnswer = this.currentAnswer;
        this.playTimeWatch = new System.Diagnostics.Stopwatch();
        this.isPlay = false;
        this.isAnswering = false;
        this.playCount++;
	}

    // Use this for initialization
    public void StartPlay(){
        this.playTimeWatch .Start();
        this.isPlay = true;
        this.SetNextAnswers();
        this.quizCount = 1;
        this.correctCount = 0;
        //TimeSpan ts = new TimeSpan(0, 0, Mathf.RoundToInt(this.leftTime));
        //SetLabel(this.txtCurrentTime, string.Format("{0:D2}:{1:D2}", ts.Minutes, ts.Seconds));
    }
        
    public void SetNextAnswers()
    {        
        this.quizCount++;

        this.currentAnswer = UnityEngine.Random.Range(1, 9);

        this.speed = 0f;
        this.isAnswering = true;
        //int answer = 7;
        //while (this.currentAnswer - answer < 0)
        //    answer = this.currentAnswer;
        //int random2 = answer;
        //int random3 = random2;

        //if (this.currentAnswer >= 10){
        //    while (random2 == answer || this.currentAnswer - random2 < 0)
        //    {
        //        random2 = UnityEngine.Random.Range(1, 10);
        //    }

        //    while (random3 == answer || random3 == random2 || this.currentAnswer - random3 < 0)
        //    {
        //        random3 = UnityEngine.Random.Range(1, 10);
        //    }
        //}

        //int[] randoms = new int[] { answer, random2, random3 };
        ////int correctAnswer = UnityEngine.Random.Range(0, 3);

        //int[] shuffle = randoms.OrderBy(i => Guid.NewGuid()).ToArray();

        ////this.numMinus = randoms[correctAnswer];
        //this.numMinus = answer;
        //this.nextAnswers = new int[] {
        //    this.currentAnswer - shuffle[0],
        //    this.currentAnswer - shuffle[1],
        //    this.currentAnswer - shuffle[2]
        //};
        //this.nextAnswer = this.currentAnswer - answer;
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


    //public void SetLongSord(bool isLong){

    //    this.isLongSord = isLong;
    //}

    public void WatchStop(){
        this.playTimeWatch.Stop();
    }

    public void SwitchInvoke(){
        this.isInvoke = !this.isInvoke;
    }
    //public void SetLeftTime(float leftTime){
    //    this.leftTime -= leftTime;
    //    //TimeSpan ts = new TimeSpan(0,0,Mathf.RoundToInt(this.leftTime));
    //    //SetLabel(this.txtCurrentTime, string.Format("{0:D2}:{1:D2}", ts.Minutes, ts.Seconds));

    //    if(leftTime<0f){
    //        this.isPlay = false;
    //    }
   	//}


}
