using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Arrow_Up_Down : GameUnit
{
    private void OnEnable()
    {
        tf.DOLocalMoveZ(1.958f, 0.5f).SetEase(Ease.Linear).SetLoops(-1,LoopType.Yoyo);
    }
}
