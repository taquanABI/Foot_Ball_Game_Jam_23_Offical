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
            
            Colider_Enemy_Trap colider_Enemy_Trap = other.GetComponent<Colider_Enemy_Trap>();
            Debug.Log("Va vao Trap");
            if (colider_Enemy_Trap != null)
            {
                colider_Enemy_Trap.Set_Stop_Enemy();
            }
            ball.Set_Stop_By_Enemy();


            other.GetComponentInParent<Enemy>().DisplayEmj();
        }
    }
}
