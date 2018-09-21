using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePointView : MonoBehaviour {

	[SerializeField]
	private float RotSpeed = 30f;

	//キャラクター回転
	void Update(){


		//回転速度
		float RotX = 0f , RotY = 0f;

		/////キー入力確認 各キーが押されているか
		if (Input.GetKey(KeyCode.LeftArrow)){
			RotY = -1f;
		}
		else if (Input.GetKey(KeyCode.RightArrow)){
			RotY = 1f;
		}
		if (Input.GetKey(KeyCode.UpArrow)){
			RotX = -1f;
		}
		else if (Input.GetKey(KeyCode.DownArrow)){
			RotX = 1f;
		}



		//回転予定角度X
		float NextRotX = transform.eulerAngles.x + RotX * RotSpeed *Time.deltaTime;


//		//x方向の回転を制限  回転可能角度外
//		if(NextRotX > LimitRotX && NextRotX < 360f - LimitRotX){
//			//下と上のどちらから可能角度を超えたか それに応じて制限
//			NextRotX = NextRotX > 180f ? 360f - LimitRotX : LimitRotX;
//		}


		//回転
		transform.rotation = Quaternion.Euler( 
			NextRotX, 
			transform.eulerAngles.y + RotY * RotSpeed *Time.deltaTime ,
			transform.eulerAngles.z
		) ;
	}
}