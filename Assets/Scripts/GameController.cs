using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class GameController : UtilComponent {

	//public Force force;

	public CountDownComponent cdCarib;
	public CountDownComponent cdCountDown;

    [SerializeField] private Context context;
    [SerializeField] private GameObject objMeterCanvas;
    [SerializeField] private GameObject objAvatarCanvas;

    [SerializeField] private GazeButtonInput[] btnsFinish;

	public enum STATUS_ENUM : int{
		NON,
		OPEN,
		CARIB,
		PREPARE,
		COUNT,
		PLAY,
        FINISH
	}
	private STATUS_ENUM currentStatus = STATUS_ENUM.NON;

	[SerializeField] GameObject objOpen;
	[SerializeField] GameObject objCarib;
	[SerializeField] GameObject objPrepare;
	[SerializeField] GameObject objCount;
    [SerializeField] GameObject objPlay;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip audioClip;


	// Use this for initialization
	void Start () {
		SetActive(this.objOpen, true);
		SetActive(this.objCarib, false);
		SetActive(this.objPrepare, false);
		SetActive(this.objCount, false);
        SetActive(this.objPlay, false);
        SetActive(this.objMeterCanvas, true);
        SetActive(this.objAvatarCanvas, false);
		this.currentStatus = STATUS_ENUM.OPEN;
        foreach(GazeButtonInput btn in btnsFinish){
            btn.m_OnClickGaze.AddListener(this.ClickedFinish);
        }
	}
	
	// Update is called once per frame
	void Update () {
		switch(this.currentStatus){
		case STATUS_ENUM.OPEN:
			this.UpdateOpen();
			break;
		case STATUS_ENUM.CARIB:
			this.UpdateCarib();
			break;
		case STATUS_ENUM.PREPARE:
			this.UpdatePrepare();
			break;
		case STATUS_ENUM.COUNT:
			this.UpdateCount();
			break;
		case STATUS_ENUM.PLAY:
			this.UpdatePlay();
			break;
        case STATUS_ENUM.FINISH:
            this.UpdateFinish();
            break;
		}
	}
		

	private void UpdateOpen(){
	}

	public void ClickSetButton(){
		this.currentStatus = STATUS_ENUM.CARIB;
		SetActive(this.objOpen, false);
		SetActive(this.objCarib, true);
		this.cdCarib.Initialize(0f, 
			()=>{
				this.currentStatus = STATUS_ENUM.PREPARE;
				SetActive(this.objCarib, false);
				SetActive(this.objPrepare, true);
			},
			false);
	}

	private void UpdateCarib(){
		
	}

	private void UpdatePrepare(){
	}

	public void ClickStartButton(){
		this.currentStatus = STATUS_ENUM.COUNT;
		SetActive(this.objPrepare, false);
		SetActive(this.objCount, true);
	}

	private void UpdateCount(){
		this.cdCountDown.Initialize(3f, ()=>{
			this.currentStatus = STATUS_ENUM.PLAY;
            SetActive(this.objPlay, true);
            //this.force.isPlay = true;
            this.context.isStart = true;
            this.audioSource.PlayOneShot(this.audioClip);
		},
		true);

	}

	private void UpdatePlay(){
        if(this.context.isFinish){
            this.currentStatus = STATUS_ENUM.FINISH;
            SetActive(this.objMeterCanvas, false);
            SetActive(this.objAvatarCanvas, true);
            //this.force.isPlay = false;
        }
	}

    private void UpdateFinish()
    {

    }


    private void ClickedFinish()
    {
        Gamestrap.GSAppExampleControl.Instance.LoadScene(Gamestrap.ESceneNames.scene_title);

    }


}
