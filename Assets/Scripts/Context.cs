using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Context : UtilComponent {

    [NonSerialized] public bool isStart = false;
    [NonSerialized] public bool isFinish = false;

    [NonSerialized] public float time = 60f;
    [NonSerialized] public float speed = 0f;
    [NonSerialized] public float distance = 0f;
    [NonSerialized] public float calorie = 0f;

    private int flameCount = 0;
    private float sumSpeed = 0f;

    [SerializeField] Force force;
    [SerializeField] GameObject player;
   
    [SerializeField] Text[] txtCurrentTime;
    [SerializeField] Text[] txtCurrentSpeed;
    [SerializeField] Text[] txtDistance;
    [SerializeField] Text[] txtCalorie;
    [SerializeField] Text[] txtSumTime;
    [SerializeField] Text[] txtAveSpeed;

	// Use this for initialization
	void Start () {
        this.UpdateTime();
        this.UpdateSpeed();
        this.UpdateDistance();
        this.UpdateCalorie();

        TimeSpan ts = new TimeSpan(0, 0, Mathf.RoundToInt(this.time));
        SetLabel(this.txtCurrentTime, string.Format("{0:D2}:{1:D2}", ts.Minutes, ts.Seconds));
    }

    // Update is called once per frame
    void Update()
    {
        if (this.isStart && !this.isFinish) {
            this.flameCount++;

            this.UpdateTime();
            this.UpdateSpeed();
            this.UpdateDistance();
            this.UpdateCalorie();

        }
	}
		

	private void UpdateTime(){
        this.time -= Time.deltaTime;
        TimeSpan ts = new TimeSpan(0,0,Mathf.RoundToInt(this.time));
        SetLabel(this.txtCurrentTime, string.Format("{0:D2}:{1:D2}", ts.Minutes, ts.Seconds));

        if(time<0f){
            this.isFinish = true;
        }
   	}


    private void UpdateSpeed(){
        this.speed = this.force.rigidBody.velocity.z;
        SetLabel(this.txtCurrentSpeed, this.speed.ToString("f1"));

        this.sumSpeed += this.speed;
        float aveSpeed = this.sumSpeed / this.flameCount;

        SetLabel(this.txtAveSpeed, aveSpeed.ToString("f1"));

	}

	private void UpdateDistance(){
        this.distance = (this.player.transform.localPosition.z / 10f) / 1000f;
        SetLabel(this.txtDistance, this.distance.ToString("f1"));
	}


	private void UpdateCalorie(){
        float mets = this.speed / 3f;
        this.calorie += 70f * mets * (Time.deltaTime / 3600f) * 1.05f;
        SetLabel(this.txtCalorie, this.calorie.ToString("f1"));
	}



}
