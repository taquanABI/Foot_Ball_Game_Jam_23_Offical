using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colider_Enemy_Trap : MonoBehaviour
{
    public Enemy_Trap Enemy_Trap;
    public void Set_Stop_Enemy()
    {
        Enemy_Trap.Set_Anim_Idle();
    }
}
