using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameData : MonoBehaviour
{

    /// <summary>
    /// Gaze待機時間
    /// </summary>
    public readonly float WAIT_TIME = 0.5f;

    /// <summary>
    /// Gaze判定時間
    /// </summary>
    public readonly float COUNT_TIME = 0.7f;

    /// <summary>
    /// アクション制限時間
    /// </summary>
    public readonly float ACT_LIMIT_TIME = 5f;

    /// <summary>
    /// 制限時間
    /// </summary>
    public float limitTime
    {
        get
        {
            return WAIT_TIME + COUNT_TIME + ACT_LIMIT_TIME;
        }
    }


    public static GameData Instance { get; private set; }

    public string   id              { get; private set; }
    public DateTime dateTime        { get; private set; }
    public Vector2 startVector      { get; private set; }
    public Vector2 endVector        { get; private set; }
    public int trialCount           { get; private set; }
    public Context  context         { get; private set; }



    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

    }


    public void Init(string id, DateTime dateTime, Vector2 startVector, Vector2 endVector, int trialCount)
    {
        this.id = id;
        this.dateTime = dateTime;
        this.startVector = startVector;
        this.endVector = endVector;
        this.trialCount = trialCount;
    }


    public void SetContext(Context context){
        this.context = context;
    }
}