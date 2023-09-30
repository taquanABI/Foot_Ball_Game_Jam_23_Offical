using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Ball : MonoBehaviour
{
    bool isStoped_By_Enemy;
    [HideInInspector] public bool isCan_Move;
    [HideInInspector] public Transform tf;
    public int index_Point_Moved;
    [Tooltip("Speed của cầu thủ sút")]
    [HideInInspector] public float force_Kick;
    [HideInInspector] public Goal goal_Reach;
    public Colider_Ball colider_Ball;

    public List<Player> list_Player_Target;

    Sequence sequence_Move_Ball;

    [Tooltip("Khai báo trước mới dừng Coroutine lại được")]
    Coroutine ie_Move;

    private void Awake()
    {
        tf = transform;
        // Create a sequence of Tweens
        sequence_Move_Ball = DOTween.Sequence();
    }
    // Start is called before the first frame update
    void Start()
    {
        On_Init();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void On_Init()
    {
        StartCoroutine(IE_Regist_Manager());
    }
    IEnumerator IE_Regist_Manager()
    {
        yield return new WaitUntil(() => Draw_Line_Control.ins != null);
        Draw_Line_Control.ins.ball = (this);
        Draw_Line_Control.ins.Set_Point_Start(tf);
    }

    public void Set_Move()
    {
        ie_Move = StartCoroutine(IE_Set_Move());
    }
    public IEnumerator IE_Set_Move()
    {
        if (list_Player_Target.Count > 1)
        {
            list_Player_Target[0].Rot_To_Target(list_Player_Target[1].tf);
        }
        for (int i = 0; i < list_Player_Target.Count; i++)
        {
            //if (isStoped_By_Enemy)// Lệnh này méo dừng quả bóng lại đc, lại phải if (!isStoped_By_Enemy) ở bên dưới
            //{
            //    Set_Cancel_Move();
            //}
            //int zz = i;//cake value

            if (list_Player_Target.Count > 1 && (i < list_Player_Target.Count -1) && (i > 0))
            {
                list_Player_Target[i - 1].Rot_To_Target(list_Player_Target[i].tf);
            }
            else if (list_Player_Target.Count == 1)
            {
                list_Player_Target[0].Rot_To_Target(list_Player_Target[1].tf);
            }

            yield return Cache.GetWFS(Constants.Cons_Value.time_Rote_Character);

            list_Player_Target[i].Set_Anim(Constants.anim_str.kick);

            yield return Cache.GetWFS(Constants.Cons_Value.time_anim_Character_Kick);

            list_Player_Target[i].Set_Anim(Constants.anim_str.idle);

            float distance = Vector3.Distance(tf.position, list_Player_Target[i].tf_Ball_In.position);

            force_Kick = list_Player_Target[i].force_Kick;

            float time_Move_Each_Point = distance / force_Kick;
            var temp = tf.DOMove(list_Player_Target[i].tf_Ball_In.position, time_Move_Each_Point).SetEase(Ease.OutQuad).OnComplete(() => Debug.Log(" Kick " + i.ToString()));

            yield return temp.WaitForCompletion();

            list_Player_Target[i].Set_Anim(Constants.anim_str.idle);
            //yield return Cache.GetWFS(Constants.Cons_Value.time_Rote_Character);
        }
        if (goal_Reach != null)
        {

            

            if (Get_Is_Pass_All_Player())
            {
                list_Player_Target[list_Player_Target.Count - 1].Rot_To_Target(goal_Reach.tf_Target_Win);

                yield return Cache.GetWFS(Constants.Cons_Value.time_Rote_Character);

                float distance = Vector3.Distance(tf.position, goal_Reach.tf_Target_Win.position);

                force_Kick = list_Player_Target[list_Player_Target.Count - 1].force_Kick;

                float time_Move_Each_Point = distance / force_Kick / 3;

                var temp = tf.DOMove(goal_Reach.tf_Target_Win.position, time_Move_Each_Point).SetEase(Ease.OutQuad).OnComplete(() => Debug.Log(" Kick on gold"));

                yield return temp.WaitForCompletion();

            }
            else
            {
                list_Player_Target[list_Player_Target.Count - 1].Rot_To_Target(goal_Reach.tf_Target_Fail);

                yield return Cache.GetWFS(Constants.Cons_Value.time_Rote_Character);

                float distance = Vector3.Distance(tf.position, goal_Reach.tf_Target_Fail.position);

                force_Kick = list_Player_Target[list_Player_Target.Count - 1].force_Kick;

                float time_Move_Each_Point = distance / force_Kick / 3;

                var temp = tf.DOMove(goal_Reach.tf_Target_Fail.position, time_Move_Each_Point).SetEase(Ease.OutQuad).OnComplete(() => Debug.Log(" Kick out gold"));

                yield return temp.WaitForCompletion();

            }

        }

        //TODO: complete Ball move
        if (!isStoped_By_Enemy)
        {
            Set_Complete_Move();
        }
    }

    public void Set_Complete_Move()
    {
        Debug.Log(" Complete Kick ");
        colider_Ball.rig.isKinematic = false;
        bool isPass_All_Player = Get_Is_Pass_All_Player();

        bool reach_Goal = (goal_Reach != null);

        if (isPass_All_Player && reach_Goal)
        {
            IngameManager.ins.Set_Level_Win();
        }
        else
        {
            IngameManager.ins.Set_Level_Fail();
        }
    }

    public bool Get_Is_Pass_All_Player()
    {
        return Draw_Line_Control.ins.list_Player_Check_Once_Pass.Count == IngameManager.ins.list_Player_Inlevel.Count;
    }

    public void Set_List_Target_Move(List<Player> _list_Player_Target)
    {
        //list_Player_Target = _list_Player_Target; // reference

        //clone
        for (int i = 0; i < _list_Player_Target.Count; i++)
        {
            list_Player_Target.Add(_list_Player_Target[i]);
        }
    }
    public void Set_Target_Goal(Goal _goal)
    {
        goal_Reach= _goal;
    }
    public void Set_Stop_By_Enemy()
    {
        Debug.Log(" Stopp    ");
        isStoped_By_Enemy = true;

        tf.DOKill();

        Set_Cancel_Move();
        //StopCoroutine(IE_Set_Move()); // Lệnh này méo dừng quả bóng lại đc, lại phải if (!isStoped_By_Enemy) 

        IngameManager.ins.Set_Level_Fail();
    }


    // Lệnh này méo dừng quả bóng lại đc, lại phải if (!isStoped_By_Enemy) 
    public void Set_Cancel_Move()
    {
        tf.DOKill();
        StopCoroutine(ie_Move);
    }
}
/*
 public void Set_Move()
    {
        for (int i = 0; i < list_Player_Target.Count; i++)
        {
            int zz = i;
            float distance = Vector3.Distance(tf.position, list_Player_Target[zz].tf_Ball_In.position);

            force_Kick = list_Player_Target[zz].force_Kick;

            float time_Move_Each_Point = distance / force_Kick;
            //Debug.Log(" Bien i:    " + i.ToString());


            sequence_Move_Ball.Append
                (
                tf.DOMove(list_Player_Target[zz].tf_Ball_In.position, time_Move_Each_Point)
                //.SetEase(Ease.Linear)
                .OnComplete(()=> { Debug.Log(" Kick " + zz.ToString()); })
                );

        }

        sequence_Move_Ball.Play();

    }





public IEnumerator IE_Set_Move()
    {
        for (int i = 0; i < list_Player_Target.Count; i++)
        {
            //if (isStoped_By_Enemy)// Lệnh này méo dừng quả bóng lại đc, lại phải if (!isStoped_By_Enemy) ở bên dưới
            //{
            //    Set_Cancel_Move();
            //}
            //int zz = i;
            float distance = Vector3.Distance(tf.position, list_Player_Target[i].tf_Ball_In.position);

            force_Kick = list_Player_Target[i].force_Kick;

            float time_Move_Each_Point = distance / force_Kick;
            if (!isStoped_By_Enemy)
            {
                var temp = tf.DOMove(list_Player_Target[i].tf_Ball_In.position, time_Move_Each_Point).SetEase(Ease.OutQuad).OnComplete(() => Debug.Log(" Kick " + i.ToString()));
            
                yield return temp.WaitForCompletion();
            }
        }
        if (goal_Reach != null)
        {
            //if (isStoped_By_Enemy)// Lệnh này méo dừng quả bóng lại đc, lại phải if (!isStoped_By_Enemy) ở bên dưới
            //{
            //    Set_Cancel_Move();
            //}
            if (!isStoped_By_Enemy)
            {
                if (Get_Is_Pass_All_Player())
                {
                    float distance = Vector3.Distance(tf.position, goal_Reach.tf_Target_Win.position);

                    force_Kick = list_Player_Target[list_Player_Target.Count - 1].force_Kick;

                    float time_Move_Each_Point = distance / force_Kick / 3 ;

                    var temp = tf.DOMove(goal_Reach.tf_Target_Win.position, time_Move_Each_Point).SetEase(Ease.OutQuad).OnComplete(() => Debug.Log(" Kick on gold" ));

                    yield return temp.WaitForCompletion();

                }
                else
                {
                    float distance = Vector3.Distance(tf.position, goal_Reach.tf_Target_Fail.position);

                    force_Kick = list_Player_Target[list_Player_Target.Count - 1].force_Kick;

                    float time_Move_Each_Point = distance / force_Kick / 3 ;

                    var temp = tf.DOMove(goal_Reach.tf_Target_Fail.position, time_Move_Each_Point).SetEase(Ease.OutQuad).OnComplete(() => Debug.Log(" Kick out gold" ));

                    yield return temp.WaitForCompletion();

                }
            }

        }

        //TODO: complete Ball move
        if (!isStoped_By_Enemy)
        {
            Set_Complete_Move();
        }
    }











 */