using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class ResultModalPresenter : MonoBehaviour
{

    [SerializeField] private Text score;
    [SerializeField] private Text leftTime;

    public void Show(ResultModalModel model) {
        TimeSpan ts = new TimeSpan(0, 0, Mathf.RoundToInt(model.averageTime));
        leftTime.text = string.Format("{0:D2}:{1:D2}", ts.Minutes, ts.Seconds);
        //model.Start.Init("Start", model.Context);
        this.gameObject.SetActive(true);
    }

    public void Close(){
        this.gameObject.SetActive(false);
    }

}
