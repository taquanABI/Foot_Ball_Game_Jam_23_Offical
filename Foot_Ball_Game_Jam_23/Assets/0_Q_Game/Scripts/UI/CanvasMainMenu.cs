using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasMainMenu : UICanvas
{
    public void PlayGameButton()
    {
        
        GameManager.ins.Load_Game_Play();
        Close();
    }
}
