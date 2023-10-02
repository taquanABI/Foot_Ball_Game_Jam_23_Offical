using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameConfig : SingletonMonoBehaviour<GameConfig>
{
    public List<Line_Register> list_Line;
    public List<GameObject> list_Level;

    public Vector3 cam_1_vec_Offset_Position;
    public Vector3 cam_1_vec_Offset_Rotation;

    public float cam_2_offset_Distance_Cam2_Player;
    public float cam_2_offsetY_Cam2_Player;

    public List<Count_Point_Connect_Max> list_count_Point_Connect_Max;
    public Line_Register Get_Line(E_Line type)
    {
        return list_Line.Find(x => x.type == type);
    }
    public int Get_max_Count_Point_Connect(int _level)
    {
        return list_count_Point_Connect_Max.Find(x => x.level == _level).max_Count_Point_Connect;
    }
}






[System.Serializable]
public class Line_Register
{
    public E_Line type;
    public GameObject obj;
}
[System.Serializable]
public class Count_Point_Connect_Max
{
    public int level;
    public int max_Count_Point_Connect;
}