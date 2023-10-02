using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasFail : UICanvas
{
    public void HomeButton()
    {
        SoundManager.PlayEfxSound(SoundManager.ins.btn_Click);
        GameManager.ins.Load_HomeGame();
        Close();
    }
    public void RetryButton()
    {
        GameManager.ins.Load_Game_Play();
        SoundManager.PlayEfxSound(SoundManager.ins.btn_Click);
        Close();
    }
}
