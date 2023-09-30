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
        
        GameManager.ins.Load_HomeGame();
        Close();
    }
}
