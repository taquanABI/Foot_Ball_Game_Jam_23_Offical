using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    Transform m_Target;

    Vector3 offSet;

    bool isFollow;

    public void SetUpTarget(Transform target)
    {
        m_Target = target;
        offSet = target.position - transform.position;
        isFollow = true;
    }

    private void LateUpdate()
    {
        if (isFollow)
            transform.position = m_Target.position - offSet;
    }

    public void StopFollow()
    {
        isFollow = false;
        m_Target = null;
    }
}
