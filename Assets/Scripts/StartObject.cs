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

    [SerializeField] private MeshRenderer meshRenderer;


    [SerializeField] private Material[] materials;



    public Context context;


    public event Action<int> cutEvent;


    //Editorで回答できるか。
    private bool canAnswerEdit = false;

    //コントロール課題用風船かどうか
    private bool isControll = false;

    /// <summary>
    /// ゲームの最初にInit
    /// </summary>
    /// <param name="context"></param>
    /// <param name="cutEvent"></param>
    public void Init(Context context, Action<int> cutEvent)
    {
        this.context = context;
        this.cutEvent = cutEvent;
        this.isControll = false;
        SetActive(this.objCube, true);
        this.exprosion.Stop();
        SetActive(this.objTutorial, this.context.playCount == 0);
    }


    /// <summary>
    /// 全オブジェクトに関するリセット処理
    /// </summary>
    public void CanAnswer()
    {
        this.canAnswerEdit = false;
    }


    /// <summary>
    /// 正解用のオブジェクトのリセット処理
    /// </summary>
    public void Reset(bool isControll = false)
    {
        this.isControll = isControll;
        SetActive(this.objCube, true);
        this.exprosion.Stop();
        SetActive(this.objTutorial, this.context.playCount == 0);

        if (this.isControll)
        {
            meshRenderer.material = materials[UnityEngine.Random.Range(0, materials.Length)];
        }
    }



    public void Gaze(){
        if (isControll) return;

        this.cutEvent(this.answer);
        this.Explode();
    }

    public void Explode()
    {
        SetActive(this.objCube, false);
        if (!isControll)
        {
            this.exprosion.Play();
            if (this.audioSource != null)
            {
                this.audioSource.PlayOneShot(this.audioSource.clip);
            }
        }
    }

    private void Update()
    {
        if (this.canAnswerEdit) return;
        if (isControll) return;

        if (Input.GetKey(KeyCode.A))
        {
            //Debug.Log("cccc");
            if (this.answer == 0)
            {
                //Debug.Log("cccc");
                this.canAnswerEdit = true;
                SetActive(this.objCube, false);
                this.cutEvent(this.answer);
                this.exprosion.Play();
            }
        }
        if (Input.GetKey(KeyCode.S))
        {
            if (this.answer == 1)
            {
                this.canAnswerEdit = true;
               SetActive(this.objCube, false);
                this.cutEvent(this.answer);
                this.exprosion.Play();
            }
        }
        if (Input.GetKey(KeyCode.D))
        {
            if (this.answer == 2)
            {
                this.canAnswerEdit = true;
                SetActive(this.objCube, false);
                this.cutEvent(this.answer);
                this.exprosion.Play();
            }
        }
        if (Input.GetKey(KeyCode.F))
        {
            if (this.answer == 3)
            {
                this.canAnswerEdit = true;
                SetActive(this.objCube, false);
                this.cutEvent(this.answer);
                this.exprosion.Play();
            }
        }
        if (Input.GetKey(KeyCode.G))
        {
            if (this.answer == 4)
            {
                this.canAnswerEdit = true;
                SetActive(this.objCube, false);
                this.cutEvent(this.answer);
                this.exprosion.Play();
            }
        }
        if (Input.GetKey(KeyCode.H))
        {
            if (this.answer == 5)
            {
                this.canAnswerEdit = true;
                SetActive(this.objCube, false);
                this.cutEvent(this.answer);
                this.exprosion.Play();
            }
        }
        if (Input.GetKey(KeyCode.J))
        {
            if (this.answer == 6)
            {
                this.canAnswerEdit = true;
                SetActive(this.objCube, false);
                this.cutEvent(this.answer);
                this.exprosion.Play();
            }
        }
        if (Input.GetKey(KeyCode.K))
        {
            if (this.answer == 7)
            {
                this.canAnswerEdit = true;
                SetActive(this.objCube, false);
                this.cutEvent(this.answer);
                this.exprosion.Play();
            }
        }
        if (Input.GetKey(KeyCode.L))
        {
            if (this.answer == 8)
            {
                this.canAnswerEdit = true;
                SetActive(this.objCube, false);
                this.cutEvent(this.answer);
                this.exprosion.Play();
            }
        }
    }
}
