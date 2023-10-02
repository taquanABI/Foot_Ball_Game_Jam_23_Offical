using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class camera_Follow : GameUnit
{
    public Transform tf_follow;
    public Transform tf_Goal_Center;
    public float speed_Follow;
    public Vector3 vec_Offset;
    public bool isCanFlow;
    private void Start()
    {
        StartCoroutine(IE_Regist_Manager());
        vec_Offset = GameConfig.ins.cam_1_vec_Offset_Position;
    }

    IEnumerator IE_Regist_Manager()
    {
        yield return new WaitUntil(() => (Draw_Line_Control.ins != null));
        Draw_Line_Control.ins.cam_follow = this;
    }

    private void Update()
    {
        if (!isCanFlow)
        {
            return;
        }


        tf.position = Vector3.Lerp(tf.position, tf_follow.position + vec_Offset, 50);
       
    }
    private void LateUpdate()
    {
        //if (!isCanFlow)
        //{
        //    return;
        //}

        ////Vector3 direct = tf_follow.position - tf.position;
        ////Vector3 new_Pos = tf.position + direct.normalized * speed_Follow * Time.deltaTime;

        ////tf.position = Vector3.Lerp(tf.position, tf_follow.position + vec_Offset, 50);
        //tf.position = tf_follow.position + vec_Offset;
    }
    public void Set_Follow_Ball()
    {
        if (DataManager.ins.playerData.level == 1 || DataManager.ins.playerData.level == 2)
        {

            return;
        }
        StartCoroutine(IE_Follow_Ball());
    }
    IEnumerator IE_Follow_Ball()
    {
        yield return new WaitUntil(() => (tf_follow != null));
        tf.DOMove(tf_follow.position + vec_Offset, Constants.Cons_Value.time_To_Complete_cam1_Big).SetEase(Ease.Linear).OnComplete(()=> {
            isCanFlow = true;
        });
        tf.DORotate(GameConfig.ins.cam_1_vec_Offset_Rotation, Constants.Cons_Value.time_To_Complete_cam1_Big).SetEase(Ease.Linear).OnComplete(() => {
            isCanFlow = true;
        });
    }
    
    
    
    
    public void Set_Follow_Last_Player(Transform tf_Last_Player)
    {

        Debug.Log($"{tf_Goal_Center == null} - {tf_Last_Player == null}");
        isCanFlow = false;

        Vector3 dir = tf_Goal_Center.position - tf_Last_Player.position;

        Vector3 point_Target = tf_Last_Player.position - dir.normalized * GameConfig.ins.cam_2_offset_Distance_Cam2_Player;

        point_Target = new Vector3(point_Target.x, GameConfig.ins.cam_2_offsetY_Cam2_Player, point_Target.z);

        tf.DOMove(point_Target, Constants.Cons_Value.time_To_Complete_cam1_Big).SetEase(Ease.Linear).OnComplete(() => { 
            
        }).OnUpdate(()=> tf.LookAt(tf_Goal_Center.position));

        //Quaternion qq = Get_Quaternion.Get_Get_Quaternion_To_Target(tf_Last_Player , tf_Goal_Center);

        //tf.DORotateQuaternion(qq, Constants.Cons_Value.time_To_Complete_cam1_Big).SetEase(Ease.Linear).OnComplete(() => { 
            
        //});

        StartCoroutine(IE_Follow_Last_Player());

    }
    IEnumerator IE_Follow_Last_Player()
    {
        yield return Cache.GetWFS(Constants.Cons_Value.time_To_Complete_cam1_Big);
        // new pos
        // new rotation
        Draw_Line_Control.ins.ball.isCam2_Move_Done = true;
    }
}
