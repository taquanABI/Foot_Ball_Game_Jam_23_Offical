using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colider_Ball : MonoBehaviour
{
    bool first_Stop;
    public Ball ball;
    [HideInInspector] public Rigidbody rig;
    private void Awake()
    {
        rig = GetComponent<Rigidbody>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (first_Stop)
        {
            return;
        }
        if (other.CompareTag(Constants.tag.enemy))
        {
            first_Stop = true;
            
            ball.Set_Stop_By_Enemy();
        }
    }
}
