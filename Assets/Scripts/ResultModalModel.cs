
public class ResultModalModel {
    
    public readonly float averageTime;
    public readonly StartObject Start;
    public readonly Context Context;

    public ResultModalModel(float averageTime, StartObject startObject, Context context){
        averageTime = averageTime;
        Start = startObject;
        Context = context;
    }
}
