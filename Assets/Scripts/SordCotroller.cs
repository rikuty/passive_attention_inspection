using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ControllerSelection;

public class SordCotroller : UtilComponent {
    
    public OVRRawRaycaster rawRaycaster;
    public OVRPointerVisualizer visualizer;

    public GameObject objNormalSord;
    public GameObject objSpecialSord;


    private Context context;
    private OVRInput.Controller activeController;
	// Use this for initialization
	void Start () {
	}

    public void Init(Context context)
    {
        this.context = context;
    }

    // Update is called once per frame
    void Update () {
        activeController = OVRInput.GetActiveController();
        Quaternion rot = OVRInput.GetLocalControllerRotation(activeController);
        bool isLongSord = false;
        isLongSord |= (240f < rot.eulerAngles.x && rot.eulerAngles.x < 270f);
        isLongSord |= (270f < rot.eulerAngles.y && rot.eulerAngles.y < 300f);
        isLongSord |= (60f < rot.eulerAngles.y && rot.eulerAngles.y < 90f);

        bool isForceShortSord = true;
        isForceShortSord &= (20f < rot.eulerAngles.x && rot.eulerAngles.x < 30f);
        isForceShortSord &= (350f < rot.eulerAngles.y && rot.eulerAngles.y < 360f)
            || (0f < rot.eulerAngles.y && rot.eulerAngles.y < 10f);
        isForceShortSord &= this.context.isPlay;

        //Debug.Log(isLongSord.ToString());
        if(isLongSord || isForceShortSord){
            //this.context.SetLongSord(isLongSord && !isForceShortSord);
        }

        //this.SetLongSord(this.context.isLongSord);
	}

    private void SetLongSord(bool isLongSord){
        if (isLongSord)
        {
            //this.rawRaycaster.raycastDistance = 6f;
            //this.visualizer.rayDrawDistance = 6f;
            SetActive(this.objNormalSord, false);
            SetActive(this.objSpecialSord, true);
        }else{
            //this.rawRaycaster.raycastDistance = 2f;
            //this.visualizer.rayDrawDistance = 2f;  
            SetActive(this.objNormalSord, true);
            SetActive(this.objSpecialSord, false);
        }
    }


}
