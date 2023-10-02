using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tut_12_Regist : MonoBehaviour
{
    public UITutorial uITutorial;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(IE_Regist_Manager());
    }
    IEnumerator IE_Regist_Manager()
    {
        yield return new WaitUntil(() => (Draw_Line_Control.ins != null));
        Draw_Line_Control.ins.uITutorial = uITutorial;
    }

}
