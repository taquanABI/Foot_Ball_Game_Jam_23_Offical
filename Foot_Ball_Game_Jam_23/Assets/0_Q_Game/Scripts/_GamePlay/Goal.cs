using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public E_Goal type;
    [Tooltip("điểm bóng sút vào cuối cùng ở goal")]
    public Transform tf_Target_Win;
    public Transform tf_Target_Fail;
    
}
