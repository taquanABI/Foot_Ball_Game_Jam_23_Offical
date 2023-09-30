using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Home_character : MonoBehaviour
{
    public GameObject o_Player;
    // Start is called before the first frame update
    void Start()
    {
        Timer.Schedule(this, 0.7f, () =>
        {
            o_Player.SetActive(true);
        });
    }

    
}
