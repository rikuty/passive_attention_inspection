using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System;

public class AnswerObjectController : UtilComponent
{


    private Context context;
    public AnswerObject[] answerObjects;
    //[SerializeField] private Transform parentLeft;
    //[SerializeField] private Transform parentRight;

    [SerializeField] private GameObject avatar;


    private bool enableInput = true;

    public void Init(Context context, Action<int> action)
    {
        this.context = context;

        for (int i = 0; i < this.answerObjects.Length; i++){
            this.answerObjects[i].Init(this.context, action);
        }
 

        //Array.ForEach(this.answers, answer =>{
        //    //answer.transform.localPosition = new Vector3(0f, 0f, 4f);
        //    answer.cutEvent += action;
        //});
	}

	public void SetAnswers()
    {
        for (int i = 0; i < this.answerObjects.Length; i++){
            SetActive(this.answerObjects[i], false);
            // Unity上用
            this.answerObjects[i].CanAnswer();
        }

        //int answerObjNum = UnityEngine.Random.Range(1, 9);
        SetActive(this.answerObjects[this.context.currentAnswer-1].gameObject, true);
        this.answerObjects[this.context.currentAnswer - 1].Reset();


        this.enableInput = true;
    }

    public void Answer(int objNum){
        //Debug.Log(objName);
        if (!this.enableInput) return;
        this.enableInput = false;
        this.context.isAnswering = false;
        this.CheckAnswer(objNum);

    }

 
    private void Update()
    {
        if(this.context.isAnswering){
            this.context.answerTime += Time.deltaTime;
            if(this.context.answerTime > GameData.Instance.limitTime){
                this.context.answerTime = GameData.Instance.limitTime;
            }

            if (GameData.Instance.limitTime <= this.context.answerTime)
            {
                this.answerObjects[this.context.currentAnswer - 1].Explode();
                this.enableInput = false;
                this.context.isAnswering = false;
                this.CheckAnswer(-1);
            }
        }


    //    if (!this.enableInput) return;
    //    //Debug.Log(Input.GetKey(KeyCode.A));
    //    if (Input.GetKey(KeyCode.Keypad1))
    //    {
    //        this.enableInput = false;
    //        this.CheckAnswer(1);
    //    }
    //    if (Input.GetKey(KeyCode.Keypad2))
    //    {
    //        this.enableInput = false;
    //        this.CheckAnswer(2);
    //   }
    //    if (Input.GetKey(KeyCode.Keypad3))
    //    {
    //        this.enableInput = false;
    //        this.CheckAnswer(3);
    //   }
    }

    private void CheckAnswer(int answer){
        //this.answerObjects[answer-1].WasCut();
        bool result = this.context.CheckAnswer(answer);
        //Debug.Log("CheckAnswer！！");
        StartCoroutine(WaitNextObj());
    }


    IEnumerator WaitNextObj()
    {

        yield return new WaitForSeconds(0.7f);

        for (int i = 0; i < this.answerObjects.Length; i++)
        {
            SetActive(this.answerObjects[i].gameObject, false);
        }

        float rand = UnityEngine.Random.Range(2f, 4f);
        yield return new WaitForSeconds(rand);

        if (this.context.isFinalQuiz) {
            this.context.isPlay = false;
            yield break;
        }
        
        this.SetNextQuiz();
    }

    private void SetNextQuiz(){
        this.context.SetNextAnswers();

        int currentCount = this.context.quizCurrentNum;
        int CountSum = this.context.quizNum;
        float currentX = GameData.Instance.startVector.x + ((GameData.Instance.endVector.x - GameData.Instance.startVector.x) * ((float)currentCount / (float)CountSum));
        float currentY = GameData.Instance.startVector.y + ((GameData.Instance.endVector.y - GameData.Instance.startVector.y) * ((float)currentCount / (float)CountSum));

        this.avatar.transform.rotation = Quaternion.Euler(new Vector3(currentX, currentY, 0f));

        this.SetAnswers();
    }
}