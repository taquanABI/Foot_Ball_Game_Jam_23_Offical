using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHomeUI : MonoBehaviour
{
    public Animator m_Anim;

    const string Happy_State = "Happy";
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(HappyLoop());
    }

    IEnumerator HappyLoop()
    {
        float delayTime = Random.Range(5, 8);
        yield return Yielders.Get(delayTime);
        int index = Random.Range(1, 3);
        m_Anim.SetTrigger(Happy_State + index.ToString());
        StartCoroutine(HappyLoop());
    }

}
