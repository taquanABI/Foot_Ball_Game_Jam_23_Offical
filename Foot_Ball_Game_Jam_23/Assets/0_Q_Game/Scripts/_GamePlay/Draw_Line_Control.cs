using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draw_Line_Control : SingletonMonoBehaviour<Draw_Line_Control>
{
    public bool isCanDraw;
    public camera_Follow cam_follow;
    public UITutorial uITutorial;
    public bool is_Drawing;
    [Tooltip("Colider của cầu thủ giữ bóng đầu tiên để vẽ từ đây, phải để 1 trong 3 Layer Default, Waeter thì Colider mới nhận function OnMouseEnter() ")]
    [HideInInspector] public GameObject o_Colider_Player_Start_Draw;

    [Tooltip("đã sút bóng chưa")]
    [HideInInspector] public bool is_Kicked;
    [HideInInspector] public int count_Point_Player;
    [HideInInspector] public int count_Point_Player_Max;

    [HideInInspector] public Line line_Drag;
    //public Line line_conected;

    [HideInInspector] public Vector3 vec_Poit_Start;
    [HideInInspector] public Transform tf_Start_Drawn;
    public Transform tf_Plan;
    public Transform tf_Plan_White_Line;

    [HideInInspector] public Player player_Init;
    public List<Player> list_Player_Will_Draw;
    /*[HideInInspector] */public List<Player> list_Player_Check_Once_Pass;
    public List<Line> list_LineWhite_Draw;
    public Ball ball;

    [Tooltip("số lần vẽ")]
    public int times_Drag;
    [Tooltip("số lần được vẽ")]
    public int times_Can_Drag_Max;
    // Start is called before the first frame update
    void Start()
    {
        On_Init();
    }
    public void On_Init()
    {
        list_Player_Will_Draw = new List<Player>();
        list_Player_Check_Once_Pass = new List<Player>();
        //vec_Poit_Start = tf_Start_Drawn.position;



        int _level = DataManager.ins.playerData.level;

        count_Point_Player_Max = GameConfig.ins.Get_max_Count_Point_Connect(_level);

        

        times_Drag = 0;
        times_Can_Drag_Max = 1;

        //Set có thể vẽ khi di chuột qua thằng đầu tiên giữ bóng
        Set_Enable_Draw();
    }

    public void Set_Init_List(Player _player_Init)
    {
        player_Init = _player_Init;
        list_Player_Will_Draw.Add(_player_Init);
        list_Player_Check_Once_Pass.Add(_player_Init);
    }

    // Update is called once per frame
    void Update()
    {
        if (!isCanDraw)
        {
            return;
        }




        if (Input.GetMouseButtonDown(0))
        {
            if (!isCanDraw || is_Kicked)
            {
                return;
            }



            
        }
        

        if (Input.GetMouseButton(0))
        {
            if (!isCanDraw || is_Kicked)
            {
                return;
            }
            if (times_Drag < times_Can_Drag_Max)
            {
                this.GetMouseDrag();
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (!isCanDraw || is_Kicked)
            {
                return;
            }
            if (is_Drawing)
            {
                times_Drag++;
                if (!is_Kicked)
                {
                    Set_Done_Draw();
                }
            }
        }
    }



    /// <summary>
    /// Set có thể vẽ khi di chuột qua thằng đầu tiên giữ bóng
    /// </summary>
    /// <param name="myBool">Parameter value to pass.</param>
    /// <returns>Returns an integer based on the passed value.</returns>

    public void Set_Enable_Draw()
    {
        Debug.Log("Set start enable draw");
        //o_Colider_Player_Start_Draw.SetActive(true);
    }
    
    public void Set_Start_Draw()
    {
        StartCoroutine(ie_Wait_player_Init());
    }

    IEnumerator ie_Wait_player_Init()
    {
        yield return new WaitUntil(()=> player_Init!= null);
        if (times_Drag < times_Can_Drag_Max)
        {
            line_Drag = (Line)(PoolController.Ins.miniPool_Line_Blue.Spawn(Vector3.zero, Quaternion.identity));


            Vector3 v_start = new Vector3(player_Init.tf.position.x, tf_Plan_White_Line.position.y, player_Init.tf.position.z);


            line_Drag.UpdateTrajectory(v_start, v_start);
        }
        isCanDraw = true;
    }

    private void GetMouseDrag()
    {
        if (!isCanDraw && is_Kicked)
        {
            return;
        }
        is_Drawing = true;
        var output = Check_Ray_Cast.Ins.Get_Pos_Raycast_Hit_Plan();
        if (output.Item1)
        {
            line_Drag.UpdateTrajectory(output.Item2, vec_Poit_Start);
        }
        else
        {
            // ko raycast vào plan
        }

        var colider_Player = Check_Ray_Cast.Ins.Get_Raycast_Colider_Player();
        if (colider_Player != null)
        {
            if (colider_Player.player != null)
            {
                if (list_Player_Will_Draw.Count != 0)
            {
                if (colider_Player.player != list_Player_Will_Draw[list_Player_Will_Draw.Count - 1])
                {
                    //nếu tay di vào player khác player vừa nối
                    if (count_Point_Player < count_Point_Player_Max - 1)// vì count_Point_Player bắt đầu từ 0 nên đến count_Point_Player_Max - 1 là đủ count_Point_Player_Max điểm
                    {
                        // thêm Player vào list các target .. tạo mới Line trắng qua 2 cầu thủ vừa rồi
                        list_Player_Will_Draw.Add(colider_Player.player);

                        if (colider_Player.player == null)
                        {
                            Debug.LogError("BUGGGG                      ===");
                        }

                        if (!list_Player_Check_Once_Pass.Contains(colider_Player.player))
                        {
                            list_Player_Check_Once_Pass.Add(colider_Player.player);
                        }
                        Line _line_White = (Line)(PoolController.Ins.miniPool_Line_White.Spawn(Vector3.zero, Quaternion.identity));

                        list_LineWhite_Draw.Add(_line_White);




                        int total = list_Player_Will_Draw.Count;

                        Vector3 v_start = new Vector3(list_Player_Will_Draw[total - 2].tf.position.x,tf_Plan_White_Line.position.y , list_Player_Will_Draw[total - 2].tf.position.z);

                        
                        Vector3 v_end = new Vector3(list_Player_Will_Draw[total - 1].tf.position.x,tf_Plan_White_Line.position.y , list_Player_Will_Draw[total - 1].tf.position.z);


                        _line_White.UpdateTrajectory(v_start,v_end);

                        //đổi vị trí điểm đầu tiên của đường xanh lúc merge xong bắt đầu từ cầu thủ tiếp theo
                        //line_Drag.UpdateTrajectory(v_end, v_end);

                        vec_Poit_Start = v_end;

                        count_Point_Player++;
                    }
                    else
                    {
                        //TODO: Kết thúc vẽ Line
                        Set_Done_Draw();
                    }
                }
            }
                
            }
        
        }

        

        var colider_Goal = Check_Ray_Cast.Ins.Get_Raycast_Colider_Goal();
        if (colider_Goal != null)
        {
            //TODO: Kết thúc vẽ Line
            
            Line _line_White = (Line)(PoolController.Ins.miniPool_Line_White.Spawn(Vector3.zero, Quaternion.identity));

            list_LineWhite_Draw.Add(_line_White);




            int total = list_Player_Will_Draw.Count;

            Vector3 v_start = new Vector3(list_Player_Will_Draw[total - 1].tf.position.x, tf_Plan_White_Line.position.y, list_Player_Will_Draw[total - 1].tf.position.z);


            Vector3 v_end = new Vector3(colider_Goal.tf_Target_Win.position.x, tf_Plan_White_Line.position.y, colider_Goal.tf_Target_Win.position.z);


            _line_White.UpdateTrajectory(v_start, v_end);

            ball.Set_Target_Goal(colider_Goal);

            //đổi vị trí điểm đầu tiên của đường xanh lúc merge xong bắt đầu từ cầu thủ tiếp theo
            //line_Drag.UpdateTrajectory(v_end, v_end);

            vec_Poit_Start = v_end;

            count_Point_Player++;
            Set_Done_Draw();
            
        }
    }

    public void Set_Done_Draw()
    {
        //TODO: Camera move góc chéo
        is_Kicked = true;
        line_Drag.gameObject.SetActive(false);

        StartCoroutine(ie_Wait_cam_follow());

    }
    
    IEnumerator ie_Wait_cam_follow()
    {
        yield return new WaitUntil(() => (cam_follow != null));
        cam_follow.Set_Follow_Ball();
        Timer.Schedule(this, Constants.Cons_Value.time_To_Complete_cam1, () =>
        {
            Set_Kick_Ball();
        });
    }


    public void Set_Kick_Ball()
    {
        for (int i = 0; i < list_LineWhite_Draw.Count; i++)
        {
            if (list_LineWhite_Draw[i] != null)
            {
                list_LineWhite_Draw[i].gameObject.SetActive(false);
            }
        }

        ball.Set_List_Target_Move(list_Player_Will_Draw);
        ball.Set_Move();
    }

    public void Set_Point_Start(Transform tf_start)
    {
        vec_Poit_Start = new Vector3(tf_start.position.x, tf_Plan.position.y, tf_start.position.z);
    }
}
