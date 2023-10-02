using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Character : MonoBehaviour
{
    public Transform emjHolder;
    public E_Character e_Character;
    [HideInInspector] public Transform tf;
    public Animator anim;
    protected virtual void Awake()
    {
        tf = transform;
    }
    
    // Start is called before the first frame update
    protected virtual void Start()
    {
        
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        
    }

    public void Rot_To_Target(Transform _tf_Rote_Target)
    {
        tf.DOKill();

        Vector3 _vec_tf_Target_z;

        _vec_tf_Target_z = _tf_Rote_Target.position;
        SoundManager.PlayEfxSound(SoundManager.ins.player_Xoay);
        tf.DORotateQuaternion( Get_Quaternion.Get_Get_Quaternion_To_Target( tf.position, _vec_tf_Target_z), Constants.Cons_Value.time_Rote_Character).SetEase(Ease.Linear);
    }
    public void Set_Anim(string _str_trigger)
    {
        Debug.Log("- " + _str_trigger);
        anim.SetTrigger(_str_trigger);
    }
    public void Set_Anim_Random_Idle()
    {
        int ii = UnityEngine.Random.Range( 0, 4);
        if (ii == 0)
        {
            anim.SetTrigger(Constants.anim_str.happy_1);

        }
        else if (ii == 1)
        {
            anim.SetTrigger(Constants.anim_str.happy_2);

        }
        if (ii == 2)
        {
            anim.SetTrigger(Constants.anim_str.happy_3);

        }
        if (ii == 3)
        {
            anim.SetTrigger(Constants.anim_str.happy_4);

        }
    }
}
