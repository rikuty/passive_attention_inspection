using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class AnswerObject : StartObject {

    [SerializeField] private Text txtAnswer;

    public void SetAnswer(int num){
        SetLabel(this.txtAnswer, num.ToString());
        this.answer = num;
        SetActive(this.objCube, true);
        this.exprosion.Stop();
    }



}
