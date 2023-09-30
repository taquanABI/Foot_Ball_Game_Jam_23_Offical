using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            o_Colider_Start_Hover.SetActive(true);
            o_Arrow.SetActive(true);
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
    public void Set_Hide_Arrow()
    {
        o_Arrow.SetActive(false);
    }
}
