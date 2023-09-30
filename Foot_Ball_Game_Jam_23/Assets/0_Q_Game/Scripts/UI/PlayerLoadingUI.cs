using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerLoadingUI : MonoBehaviour
{
    public Transform Ball, nameHolder;

    public Animator m_Anim;

    public float endXValue, time, delayTime, ballTime, nameTime;

    const string SliceState = "Loading";

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadingAnim());
    }

    IEnumerator LoadingAnim()
    {
        transform.DOMoveX(endXValue, time);
        yield return Yielders.Get(delayTime);
        m_Anim.SetTrigger(SliceState);
        yield return Yielders.Get(ballTime);
        Ball.SetParent(transform);
        yield return Yielders.Get(nameTime);
        nameHolder.DOScale(1, 1.5f);
    }
}
