using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasVictory : UICanvas
{
    public Text text;

    public void OnInitData(int data)
    {
        text.text = data.ToString();
    }

    public void CloseButton()
    {
        SoundManager.PlayEfxSound(SoundManager.ins.btn_Click);
        GameManager.ins.Load_Game_Play();
        Close();
    }
}
