using System;
using UnityEngine;

public class StartObject : UtilComponent
{
    
    [SerializeField] private GameObject objTutorial;

    [SerializeField] protected GameObject objCube;
    [SerializeField] protected ParticleSystem exprosion;
    //[SerializeField] protected ChildColliderController childCollider;

    [SerializeField] protected int answer;

    [SerializeField] private AudioSource audioSource;
    //[SerializeField] private AudioClip audioClip;


    public Context context;


    public event Action<int> cutEvent;

    private bool isEnter = false;

    public void Init(Context context, Action<int> cutEvent)
    {
        this.context = context;
        this.cutEvent = cutEvent;
        SetActive(this.objCube, true);
        this.exprosion.Stop();
        SetActive(this.objTutorial, this.context.playCount == 0);
    }


    public void Reset()
    {
        SetActive(this.objCube, true);
        this.exprosion.Stop();
        SetActive(this.objTutorial, this.context.playCount == 0);
    }


    public void Gaze(){
        this.cutEvent(this.answer);
        this.Explode();
    }

    public void Explode()
    {
        SetActive(this.objCube, false);
        this.exprosion.Play();
        if (this.audioSource != null)
        {
            this.audioSource.PlayOneShot(this.audioSource.clip);
        }
    }

    private void Update()
    {
        if (this.isEnter) return;
        if (Input.GetKey(KeyCode.A))
        {
            //Debug.Log("cccc");
            if (this.answer == 0)
            {
                //Debug.Log("cccc");
                this.isEnter = true;
                SetActive(this.objCube, false);
                this.cutEvent(this.answer);
                this.exprosion.Play();
            }
        }
        if (Input.GetKey(KeyCode.S))
        {
            if (this.answer == 1)
            {
                this.isEnter = true;
               SetActive(this.objCube, false);
                this.cutEvent(this.answer);
                this.exprosion.Play();
            }
        }
        if (Input.GetKey(KeyCode.D))
        {
            if (this.answer == 2)
            {
                this.isEnter = true;
                SetActive(this.objCube, false);
                this.cutEvent(this.answer);
                this.exprosion.Play();
            }
        }
        if (Input.GetKey(KeyCode.F))
        {
            if (this.answer == 3)
            {
                this.isEnter = true;
                SetActive(this.objCube, false);
                this.cutEvent(this.answer);
                this.exprosion.Play();
            }
        }
        if (Input.GetKey(KeyCode.G))
        {
            if (this.answer == 4)
            {
                this.isEnter = true;
                SetActive(this.objCube, false);
                this.cutEvent(this.answer);
                this.exprosion.Play();
            }
        }
        if (Input.GetKey(KeyCode.H))
        {
            if (this.answer == 5)
            {
                this.isEnter = true;
                SetActive(this.objCube, false);
                this.cutEvent(this.answer);
                this.exprosion.Play();
            }
        }
        if (Input.GetKey(KeyCode.J))
        {
            if (this.answer == 6)
            {
                this.isEnter = true;
                SetActive(this.objCube, false);
                this.cutEvent(this.answer);
                this.exprosion.Play();
            }
        }
        if (Input.GetKey(KeyCode.K))
        {
            if (this.answer == 7)
            {
                this.isEnter = true;
                SetActive(this.objCube, false);
                this.cutEvent(this.answer);
                this.exprosion.Play();
            }
        }
        if (Input.GetKey(KeyCode.L))
        {
            if (this.answer == 8)
            {
                this.isEnter = true;
                SetActive(this.objCube, false);
                this.cutEvent(this.answer);
                this.exprosion.Play();
            }
        }
    }

    public void CanAnswer(){
        this.isEnter = false;
    }

    //public void OnTriggerEnter(Collider other){
    //    if(this.context.isInvoke){
    //        isEnter = true;
    //    }
    //}

    //public void OnTriggerExit(Collider other) {
    //    if (other.gameObject.tag == "Sowrd" && this.isEnter /*&& this.childCollider.isCutFromOutside && this.context.isLongSord*/) {
    //        CallSwitchInvoke();
    //        //WasCut();
    //        cutEvent(this.answer);
    //        //this.context.SetLongSord(false);
    //        Invoke("CallSwitchInvoke", 1.5f);
    //    }
    //    this.isEnter = false;
    //}

    //private void CallSwitchInvoke(){
    //    this.context.SwitchInvoke();
    //}


}
