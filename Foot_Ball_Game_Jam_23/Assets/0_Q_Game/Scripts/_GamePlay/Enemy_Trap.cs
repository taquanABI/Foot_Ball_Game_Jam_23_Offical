using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Trap : Enemy
{
    public Move_Loop_Trap move_;
    // Start is called before the first frame update
    protected override void Awake()
    {
        base.Awake();
    }

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();

    }
    public void Set_Anim_Idle()
    {
        move_.Set_Stop();
        Set_Anim(Constants.anim_str.idle);
    }
}
