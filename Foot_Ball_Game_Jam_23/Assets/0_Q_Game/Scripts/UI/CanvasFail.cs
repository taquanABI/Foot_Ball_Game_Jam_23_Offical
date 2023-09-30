using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasFail : UICanvas
{
    public void CloseButton()
    {
        GameManager.ins.Load_Game_Play();
        Close();
    }
    public void RetryButton()
    {
        GameManager.ins.Load_Game_Play();

        Close();
    }
}
