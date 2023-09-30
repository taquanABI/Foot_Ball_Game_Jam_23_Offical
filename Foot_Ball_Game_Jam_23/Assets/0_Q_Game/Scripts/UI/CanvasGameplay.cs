using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasGameplay : UICanvas
{
    public override void Open()
    {
        base.Open();

        // tính toán j đó vào đây
    }

    public void SettingButton()
    {
        UIManager.ins.OpenUI(UIID.UICSetting);
    }

    public void FailButton()
    {
        UIManager.ins.OpenUI(UIID.UICFail);

        Close();
    }

    public void VictoryButton()
    {
        UIManager.ins.OpenUI<CanvasVictory>(UIID.UICVictory).OnInitData(Random.Range(0, 100));

        Close();
    }

    public override void Close()
    {
        base.Close();

        // viết thêm những logic cần thêm
    }
}
