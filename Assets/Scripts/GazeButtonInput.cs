using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using System;

public class GazeButtonInput : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler {

	[SerializeField] private Image img;

	private float elapsedTime = 0f;

	private float WAIT_TIME = 0.5f;

	private float COUNT_TIME = 2f;

	private enum COUNT_STATUS : int{
		NOT_SELECT,
		WAIT,
		COUNT
	}
	private COUNT_STATUS currentStatus = COUNT_STATUS.NOT_SELECT;

	// Event delegates triggered on click.
	[SerializeField]
    public UnityEvent m_OnClickGaze = new UnityEvent();

	private bool isPointerInside;

	// Use this for initialization
	void Start () {
		if(this.img == null){
			this.img = this.GetComponent<Image>();
		}
	}
	
	// Update is called once per frame
	protected void Update () {
		if(this.isPointerInside){
			Debug.Log("CCCCCCC");
			this.elapsedTime += Time.deltaTime;
			if(this.currentStatus == COUNT_STATUS.WAIT && this.elapsedTime > this.WAIT_TIME){
				this.currentStatus = COUNT_STATUS.COUNT;
				this.elapsedTime = 0f;
			}else if(this.currentStatus == COUNT_STATUS.COUNT && this.elapsedTime < this.COUNT_TIME){
				this.img.fillAmount = this.elapsedTime / this.COUNT_TIME;
			}else if(this.currentStatus == COUNT_STATUS.COUNT && this.elapsedTime >= this.COUNT_TIME){
				UISystemProfilerApi.AddMarker("Button.onClick", this);
				m_OnClickGaze.Invoke();
			}
		}else{
			if(this.img == null){
				this.img = this.GetComponent<Image>();
			}
			this.img.fillAmount = 0f;
			this.elapsedTime = 0f;
		}


	}

	public virtual void OnPointerEnter(PointerEventData eventData)
	{
		Debug.Log("AAAAAAAAAA");
		isPointerInside = true;
		this.currentStatus = COUNT_STATUS.WAIT;
	}

	public virtual void OnPointerExit(PointerEventData eventData)
	{
		Debug.Log("BBBBBBBBBB");
		isPointerInside = false;
	}
		
}
