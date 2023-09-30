using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    public E_Line type_Line;
    public LineRenderer line_Renderer;
    private List<Vector3> linePoints = new List<Vector3>();
    public Transform tf_Target;
    public Vector3 vec_Offset_Target;
    //// Start is called before the first frame update
    //void Start()
    //{
        
    //}

    //// Update is called once per frame
    //void Update()
    //{
        
    //}
    public void UpdateTrajectory(Vector3 vec_mouse_point, Vector3 _vec_Poit_Start)
    {
        linePoints.Clear();

        linePoints.Add(_vec_Poit_Start);
        linePoints.Add(vec_mouse_point);

        tf_Target.position = vec_mouse_point + vec_Offset_Target;

        line_Renderer.SetPositions(linePoints.ToArray());
    }
}
