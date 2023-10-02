using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Move_Loop_Trap : GameUnit
{
    public Transform tf_Target2;
    public Transform tf_Target1;
    public Transform tf_Rote;
    protected Enemy enemy;
    Coroutine co_move;
    private void Awake()
    {
        enemy = GetComponent<Enemy>();
    }
    // Start is called before the first frame update
    void Start()
    {
        enemy.Set_Anim(Constants.anim_str.slide);
        Set_Move_1();
    }

    public void Set_Move_1()
    {
        tf.DOMove(tf_Target2.position, Constants.Cons_Value.time_Enemy_Move_Loop).SetEase(Ease.Linear).OnComplete(() => {

            tf.LookAt(tf_Target1);
            Set_Move_2();

            //tf_Rote.DORotate(tf_Target1.rotation.eulerAngles, Constants.Cons_Value.time_Enemy_Rote_Loop).SetEase(Ease.Linear).OnComplete(() => {
            //    Set_Move_2();

            //});
        });
    }
    public void Set_Move_2()
    {
        tf.DOMove(tf_Target1.position, Constants.Cons_Value.time_Enemy_Move_Loop).SetEase(Ease.Linear).OnComplete(() => {

            tf.LookAt(tf_Target2);
            Set_Move_1();
            //tf_Rote.DORotate(tf_Target1.rotation.eulerAngles, Constants.Cons_Value.time_Enemy_Rote_Loop).SetEase(Ease.Linear).OnComplete(() => {
            //    Set_Move_1();

            //});
        });
    }

    public void Set_Stop()
    {
        tf.DOKill();
        
    }
}
