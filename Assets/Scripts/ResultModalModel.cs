
public class ResultModalModel {

    public readonly int Score;
    public readonly int QuizCount;
    public readonly float LeftTime;
    public readonly StartObject Start;
    public readonly Context Context;

    public ResultModalModel(int score, int count, float leftTime, StartObject startObject, Context context){
        Score = score;
        QuizCount = count;
        LeftTime = leftTime;
        Start = startObject;
        Context = context;
    }
}
