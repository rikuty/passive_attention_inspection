/************************************************************************************

Copyright   :   Copyright 2017 Oculus VR, LLC. All Rights reserved.

Licensed under the Oculus VR Rift SDK License Version 3.4.1 (the "License");
you may not use the Oculus VR Rift SDK except in compliance with the License,
which is provided at the time of installation or download, or which
otherwise accompanies this software in either electronic or hard copy form.

You may obtain a copy of the License at

https://developer.oculus.com/licenses/sdk-3.4.1

Unless required by applicable law or agreed to in writing, the Oculus VR SDK
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.

************************************************************************************/

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Text;
//using WhiteCat.Paths;

public class ForceForPath : MonoBehaviour
{
	public class BoolMonitor
	{
		public delegate bool BoolGenerator();

		private string m_name = "";
		private BoolGenerator m_generator;
		private bool m_prevValue = false;
		private bool m_currentValue = false;
		private bool m_currentValueRecentlyChanged = false;
		private float m_displayTimeout = 0.0f;
		private float m_displayTimer = 0.0f;

		public BoolMonitor(string name, BoolGenerator generator, float displayTimeout = 0.5f)
		{
			m_name = name;
			m_generator = generator;
			m_displayTimeout = displayTimeout;
		}

		public void Update()
		{
			m_prevValue = m_currentValue;
			m_currentValue = m_generator();

			if (m_currentValue != m_prevValue)
			{
				m_currentValueRecentlyChanged = true;
				m_displayTimer = m_displayTimeout;
			}

			if (m_displayTimer > 0.0f)
			{
				m_displayTimer -= Time.deltaTime;

				if (m_displayTimer <= 0.0f)
				{
					m_currentValueRecentlyChanged = false;
					m_displayTimer = 0.0f;
				}
			}
		}

		public void AppendToStringBuilder(ref StringBuilder sb)
		{
			sb.Append(m_name);

			if (m_currentValue && m_currentValueRecentlyChanged)
				sb.Append(": *True*\n");
			else if (m_currentValue)
				sb.Append(":  True \n");
			else if (!m_currentValue && m_currentValueRecentlyChanged)
				sb.Append(": *False*\n");
			else if (!m_currentValue)
				sb.Append(":  False \n");
		}
	}

//	public Text uiText;
//	public Text txtLog;
	private float waitCount=0f;
	private List<BoolMonitor> monitors;
	private StringBuilder data;

	//public MoveAlongPathWithSpeed alongPath;

	void Start()
	{
//		if (uiText != null)
//		{
//			uiText.supportRichText = false;
//		}

		data = new StringBuilder(2048);

		monitors = new List<BoolMonitor>()
		{
			// virtual
			new BoolMonitor("WasRecentered",                    () => OVRInput.GetControllerWasRecentered()),
			new BoolMonitor("One",                              () => OVRInput.Get(OVRInput.Button.One)),
			new BoolMonitor("OneDown",                          () => OVRInput.GetDown(OVRInput.Button.One)),
			new BoolMonitor("OneUp",                            () => OVRInput.GetUp(OVRInput.Button.One)),
			new BoolMonitor("One (Touch)",                      () => OVRInput.Get(OVRInput.Touch.One)),
			new BoolMonitor("OneDown (Touch)",                  () => OVRInput.GetDown(OVRInput.Touch.One)),
			new BoolMonitor("OneUp (Touch)",                    () => OVRInput.GetUp(OVRInput.Touch.One)),
			new BoolMonitor("Two",                              () => OVRInput.Get(OVRInput.Button.Two)),
			new BoolMonitor("TwoDown",                          () => OVRInput.GetDown(OVRInput.Button.Two)),
			new BoolMonitor("TwoUp",                            () => OVRInput.GetUp(OVRInput.Button.Two)),
			new BoolMonitor("PrimaryIndexTrigger",              () => OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger)),
			new BoolMonitor("PrimaryIndexTriggerDown",          () => OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger)),
			new BoolMonitor("PrimaryIndexTriggerUp",            () => OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger)),
			new BoolMonitor("PrimaryIndexTrigger (Touch)",      () => OVRInput.Get(OVRInput.Touch.PrimaryIndexTrigger)),
			new BoolMonitor("PrimaryIndexTriggerDown (Touch)",  () => OVRInput.GetDown(OVRInput.Touch.PrimaryIndexTrigger)),
			new BoolMonitor("PrimaryIndexTriggerUp (Touch)",    () => OVRInput.GetUp(OVRInput.Touch.PrimaryIndexTrigger)),
			new BoolMonitor("PrimaryHandTrigger",               () => OVRInput.Get(OVRInput.Button.PrimaryHandTrigger)),
			new BoolMonitor("PrimaryHandTriggerDown",           () => OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger)),
			new BoolMonitor("PrimaryHandTriggerUp",             () => OVRInput.GetUp(OVRInput.Button.PrimaryHandTrigger)),
			new BoolMonitor("Up",                               () => OVRInput.Get(OVRInput.Button.Up)),
			new BoolMonitor("Down",                             () => OVRInput.Get(OVRInput.Button.Down)),
			new BoolMonitor("Left",                             () => OVRInput.Get(OVRInput.Button.Left)),
			new BoolMonitor("Right",                            () => OVRInput.Get(OVRInput.Button.Right)),
			new BoolMonitor("Touchpad (Click)",                 () => OVRInput.Get(OVRInput.Button.PrimaryTouchpad)),
			new BoolMonitor("TouchpadDown (Click)",             () => OVRInput.GetDown(OVRInput.Button.PrimaryTouchpad)),
			new BoolMonitor("TouchpadUp (Click)",               () => OVRInput.GetUp(OVRInput.Button.PrimaryTouchpad)),
			new BoolMonitor("Touchpad (Touch)",                 () => OVRInput.Get(OVRInput.Touch.PrimaryTouchpad)),
			new BoolMonitor("TouchpadDown (Touch)",             () => OVRInput.GetDown(OVRInput.Touch.PrimaryTouchpad)),
			new BoolMonitor("TouchpadUp (Touch)",               () => OVRInput.GetUp(OVRInput.Touch.PrimaryTouchpad)),

			// raw
			new BoolMonitor("Start",                            () => OVRInput.Get(OVRInput.RawButton.Start)),
			new BoolMonitor("StartDown",                        () => OVRInput.GetDown(OVRInput.RawButton.Start)),
			new BoolMonitor("StartUp",                          () => OVRInput.GetUp(OVRInput.RawButton.Start)),
			new BoolMonitor("Back",                             () => OVRInput.Get(OVRInput.RawButton.Back)),
			new BoolMonitor("BackDown",                         () => OVRInput.GetDown(OVRInput.RawButton.Back)),
			new BoolMonitor("BackUp",                           () => OVRInput.GetUp(OVRInput.RawButton.Back)),
			new BoolMonitor("A",                                () => OVRInput.Get(OVRInput.RawButton.A)),
			new BoolMonitor("ADown",                            () => OVRInput.GetDown(OVRInput.RawButton.A)),
			new BoolMonitor("AUp",                              () => OVRInput.GetUp(OVRInput.RawButton.A)),
		};
	}
	static string prevConnected = "";
	static BoolMonitor controllers = new BoolMonitor("Controllers Changed", () => { return OVRInput.GetConnectedControllers().ToString() != prevConnected; });

	void Update()
	{
		OVRInput.Controller activeController = OVRInput.GetActiveController();

		data.Length = 0;
		byte recenterCount = OVRInput.GetControllerRecenterCount();
		data.AppendFormat("RecenterCount: {0}\n", recenterCount);

		byte battery = OVRInput.GetControllerBatteryPercentRemaining();
		data.AppendFormat("Battery: {0}\n", battery);

		float framerate = OVRPlugin.GetAppFramerate();
		data.AppendFormat("Framerate: {0:F2}\n", framerate);

		string activeControllerName = activeController.ToString();
		data.AppendFormat("Active: {0}\n", activeControllerName);

		string connectedControllerNames = OVRInput.GetConnectedControllers().ToString();
		data.AppendFormat("Connected: {0}\n", connectedControllerNames);

		data.AppendFormat("PrevConnected: {0}\n", prevConnected);

		controllers.Update();
		controllers.AppendToStringBuilder(ref data);

		prevConnected = connectedControllerNames;

		Quaternion rot = OVRInput.GetLocalControllerRotation(activeController);
		data.AppendFormat("Orientation: ({0:F2}, {1:F2}, {2:F2}, {3:F2})\n", rot.x, rot.y, rot.z, rot.w);

		this.MakeAverage(rot);

		//if(this.CheckCycle(rot) && this.waitCount > 0.5f){
		//	this.alongPath.speed += 3f;
		//	this.waitCount = 0f;
		//}

		//this.waitCount += Time.deltaTime;

		//if(this.waitCount > 0.5f){
		//	this.alongPath.speed -= 0.3f;

		//}

		//if(this.alongPath.speed < 0f){
		//	this.alongPath.speed = 0f;
		//}
		//if(this.alongPath.speed > 30f){
		//	this.alongPath.speed = 30f;
		//}


		//for (int i = 0; i < monitors.Count; i++)
		//{
		//	monitors[i].Update();
		//	monitors[i].AppendToStringBuilder(ref data);
		//}

//		if (uiText != null)
//		{
//			uiText.text = data.ToString();
//		}

//		Debug.Log(rot.x.ToString() + "," + rot.y.ToString() + "," + rot.z.ToString() + "," + rot.w.ToString() + "\n");
//		this.updateCount++;
		//		if(this.updateCount == 300){
		//			this.txtAll.text = txtLog;
		//		}
	}


	private Quaternion[] lists = new Quaternion[100];
	private Quaternion average = new Quaternion();
	private int averageCount = 100;
	private int currentCount = 0;
	public Text uiText;


	private void MakeAverage(Quaternion rot){

		this.lists[this.currentCount % 100] = new Quaternion(rot.x, rot.y, rot.z, rot.w);

		this.currentCount++;

		float sumX = 0f;
		float sumY = 0f;
		float sumZ = 0f;
		float sumW = 0f;

		for(int i=0; i<this.lists.Length; i++){
			sumX += this.lists[i].x;
			sumY += this.lists[i].y;
			sumZ += this.lists[i].z;
			sumW += this.lists[i].w;
		}

		this.average = new Quaternion(sumX / this.lists.Length, sumY / this.lists.Length, sumZ / this.lists.Length, sumW / this.lists.Length);
//		Debug.Log("rot----------");
//		Debug.Log(rot);
//		Debug.Log("average------");
//		Debug.Log(this.average);
		this.uiText.text += "\n"+this.average.x.ToString()+","+this.average.y.ToString()+","+this.average.z.ToString()+","+this.average.w.ToString();

	}

	private float KOTEI = 0.10f;
	private bool CheckCycle(Quaternion rot){
		bool result = false;
		result |= rot.x < this.average.x - KOTEI || this.average.x + KOTEI < rot.x;
		result |= rot.y < this.average.y - KOTEI || this.average.y + KOTEI < rot.y;
		result |= rot.z < this.average.z - KOTEI || this.average.z + KOTEI < rot.z;
		result |= rot.w < this.average.w - KOTEI || this.average.w + KOTEI < rot.w;
		return result;
	}
}

