using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Player : Character
{
    public Transform tf_Ball_In;
    
    public bool is_Point_Start;

    [Tooltip("Speed của cầu thủ sút")]
    public float force_Kick;
    public GameObject o_Arrow;
    public GameObject o_Colider_Start_Hover;

    // Start is called before the first frame update
    protected override void Awake()
    {
        base.Awake();
        if (is_Point_Start)
        {
            if (DataManager.ins.playerData.level != 1 && DataManager.ins.playerData.level != 2)
            {
                o_Colider_Start_Hover.SetActive(true);
                o_Arrow.SetActive(true);

            }
            else
            {
                StartCoroutine(IE_Wait_Done_Tut_lv1_2());
            }
        }
    }
    
    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        StartCoroutine(IE_Regist_Manager());
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        SetUpEmoji();

    }

    IEnumerator IE_Regist_Manager()
    {
        yield return new WaitUntil( ()=> (IngameManager.ins != null && Draw_Line_Control.ins != null));
        if (!IngameManager.ins.list_Player_Inlevel.Contains(this))
        {
            IngameManager.ins.list_Player_Inlevel.Add(this);

        }
        Draw_Line_Control.ins.o_Colider_Player_Start_Draw = (o_Colider_Start_Hover);
        if (is_Point_Start)
        {
            Draw_Line_Control.ins.Set_Init_List(this);
            IngameManager.ins.o_Arrow_Tut = o_Arrow;
        }
    }
    IEnumerator IE_Wait_Done_Tut_lv1_2()
    {
        yield return new WaitUntil( ()=> (Draw_Line_Control.ins != null));
        yield return new WaitUntil( ()=> (Draw_Line_Control.ins.uITutorial != null));
        yield return new WaitUntil( ()=> (Draw_Line_Control.ins.uITutorial.isDone_Tut));
        o_Colider_Start_Hover.SetActive(true);
        o_Arrow.SetActive(true);
    }
    public void Set_Hide_Arrow()
    {
        o_Arrow.SetActive(false);
    }


    #region CamFollowWinAnimComponent
    [Header("Component for Win Anim")]
    public CamFollow camFollow;

    public Transform winDestination;

    public Collider m_CheckCollider, m_MergeCollider;

    public float winTime, slideTime, winEndTime, loseEndTime;

    public void Call_Finalanim(bool win)
    {
        StartCoroutine(FinalAnim( win));
    }

    IEnumerator FinalAnim(bool win)
    {
        camFollow.transform.position = tf.position - Vector3.forward * 11.5f;
        camFollow.transform.GetChild(0).gameObject.SetActive(true);
        camFollow.SetUpTarget(transform);
        m_CheckCollider.enabled = false;
        m_MergeCollider.enabled = false;
        Rot_To_Target(winDestination);
        yield return Cache.GetWFS(Constants.Cons_Value.time_Rote_Character *2);
        if (win)
        {
            Tweener winTween = tf.DOMove(winDestination.position, winTime);
            Set_Anim(Constants.anim_str.run);
            yield return Yielders.Get(slideTime);
            winTween.timeScale = 1.75f;
            Set_Anim(Constants.anim_str.slide);
            yield return Yielders.Get(winEndTime);
            //Hien Win Panel;
            Debug.Log("Win Panel On");
        }
        else
        {
            Set_Anim(Constants.anim_str.lose);
            yield return Yielders.Get(loseEndTime);
            //Hien Lose Panel;
            Debug.Log("Lose Panel On");
        }
    }
    #endregion

    #region Emoji Display

    [Header("Component for Emoji Display")]

    public List<GameObject> happyEmjs, sadEmjs;

    int curEmjIndex;

    public void SetUpEmoji()
    {
        emjHolder.rotation = Camera.main.transform.rotation;
    }

    public void DisplayEmj(bool happy)
    {
        List<GameObject> curEmjList;
        if (happy)
            curEmjList = happyEmjs;
        else
            curEmjList = sadEmjs;

        if (curEmjList.Count < 1)
            return;
        curEmjIndex = UnityEngine.Random.Range(0, curEmjList.Count - 1);

        var emjPrefab = curEmjList[curEmjIndex];
        if (emjPrefab)
        {
            var emj = Instantiate(emjPrefab);
            emj.transform.SetParent(emjHolder);
            emj.transform.localPosition = Vector3.zero;
        }
    }

    #endregion
}
