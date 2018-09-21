using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	[SerializeField] private Text txtX;

	[SerializeField] private Text txtY;

	[SerializeField] private Text txtZ;

	[SerializeField] private Text txtIsConnect;

	[SerializeField] private Text txtControllerAxisX;
	[SerializeField] private Text txtControllerAxisY;


	[SerializeField] private LogSave log;

	private string txtLog;

	private int updateCount = 0;

	[SerializeField] private InputField txtAll;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		OVRInput.Update();


		this.txtX.text = Input.acceleration.x.ToString();	
		this.txtY.text = Input.acceleration.y.ToString();	
		this.txtZ.text = Input.acceleration.z.ToString();
		this.txtIsConnect.text = OVRInput.IsControllerConnected(OVRInput.Controller.All).ToString();
		Vector2 axis = OVRInput.Get(OVRInput.Axis2D.PrimaryThumbstick, OVRInput.Controller.All);
		this.txtControllerAxisX.text = axis.x.ToString();
		this.txtControllerAxisY.text = axis.y.ToString();


		txtLog += this.txtX.text + "," + this.txtY.text + "," + this.txtZ.text + "\n";
		this.updateCount++;
		if(this.updateCount == 300){
			this.txtAll.text = txtLog;
		}

	}



}
