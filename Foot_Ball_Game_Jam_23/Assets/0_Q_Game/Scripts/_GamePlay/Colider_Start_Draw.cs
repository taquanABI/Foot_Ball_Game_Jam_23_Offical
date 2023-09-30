using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colider_Start_Draw : MonoBehaviour
{
    [Tooltip("Colider của cầu thủ giữ bóng đầu tiên để vẽ từ đây, phải để 1 trong 3 Layer Default, Waeter thì Colider mới nhận function OnMouseEnter() ")]
    bool isFist_Mouse_Stay;
    private void OnMouseEnter()
    {
        //Debug.Log("LLLLLL");
        if (isFist_Mouse_Stay)
        {
            this.gameObject.SetActive(false);
            return;
        }
        isFist_Mouse_Stay = true;

        //bắt đầu vẽ
        Draw_Line_Control.ins.Set_Start_Draw();
        IngameManager.ins.Set_off_Tut();
        //Draw_Line_Control.ins.Set_Point_Start();
    }
}
