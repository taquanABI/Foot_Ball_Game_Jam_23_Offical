using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
[DefaultExecutionOrder(1)]
public class Check_Ray_Cast : Singleton<Check_Ray_Cast>
{

    #region Khai báo biến
    public LayerMask layerMasks_Plan_Blue;
    public LayerMask layerMasks_Player;
    public LayerMask layerMasks_Goal;
    [HideInInspector] public bool isRay_Cast_Draw;
    [HideInInspector] public bool isRay_Cast_Plan;
    [HideInInspector] public bool isRay_Cast_Colider_Merge;
    [HideInInspector] public bool isRay_Cast_Colider_Goal;
    public Camera cam;
    public Transform tf_Cam;
    [HideInInspector] public Plane_Drawn_Arrow plane_Drawn_Arrow;
    [HideInInspector] public Colider_Merge colider_Merge;
    [HideInInspector] public Goal colider_Goal;



    [HideInInspector] public bool isHold_Mouse;
    Vector3 pos_WorldMousePosition;
    
    //
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        tf_Cam = Camera.main.gameObject.GetComponent<Transform>();
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (!GameManager.ins.isDoneLv)
        //{
        //    Set_Check_Raycast_Break();
        //    Set_Check_Raycast_Draw();
        //    Check_CanDraw_Break();
        //}
        
    }

    

    [ContextMenu("Check_Win_Lose")]
    

    #region Lấy vị trí chuột quy ra World Space
    public Vector3 Get_World_Point_Z_0_Mose()
    {
        pos_WorldMousePosition = cam.ScreenToWorldPoint(Input.mousePosition);
        pos_WorldMousePosition.z = 0;

        return pos_WorldMousePosition;
    }
    #endregion
    
    #region Kiểm tra giữ chuột và thả chuột ra
    public void Set_Check_Mouse_Hold()
    {
        #region Kiểm tra nhấn chuột, Bắn Racast chỉ với các Colider 3D
        if (Input.GetMouseButtonDown(0))
        {
            if (!isHold_Mouse)
            {
                isHold_Mouse = true;
            }

        }
        #endregion
        #region Kiểm tra khi thả chuột
        if (Input.GetMouseButtonUp(0))
        {
            #region Lấy các Floor bị tia Raycast bắn vào
            //Set_Check_Raycast_Stroke();

            #endregion
            //
            isHold_Mouse = false;
            //circle_Image_Ray_Cast = null;
        }
        #endregion
    }
    #endregion





    /* Get value:
        var output = Get_Pos_Raycast_Hit_Plan();
        output.Item1;output.Item2;
        Item1 = bool = có raycast vào plan
        Item2 = Vector3 = vị trí raycast vào colider plan
    */
    public ( bool , Vector3 ) Get_Pos_Raycast_Hit_Plan()//mouse Up
    {
        //**** lấy từ Raycast
        RaycastHit[] hits = new RaycastHit[6];//số phần tử bằng với hàm Get_Raycast()
        hits = Get_Raycast(layerMasks_Plan_Blue);
        for (int i = 0; i < hits.Length; i++)
        {
            //Debug.Log(hits[i].collider.gameObject.name);
            if (hits[i].collider != null)
            {
                plane_Drawn_Arrow = Cache.Get_Plane(hits[i].collider);
                //Floor
                if (plane_Drawn_Arrow != null)
                {
                    isRay_Cast_Plan = true;
                    return ( true, hits[i].point);
                }
            }
            else
            {
                plane_Drawn_Arrow = null;
                isRay_Cast_Plan = false;
            }
        }
        return (true, Vector3.zero);
    }
    
    public Colider_Merge Get_Raycast_Colider_Player()//mouse Up
    {
        //**** lấy từ Raycast
        RaycastHit[] hits = new RaycastHit[6];//số phần tử bằng với hàm Get_Raycast()
        hits = Get_Raycast(layerMasks_Player);
        for (int i = 0; i < hits.Length; i++)
        {
            //Debug.Log(hits[i].collider.gameObject.name);
            if (hits[i].collider != null)
            {
                colider_Merge = Cache.Get_Colider_Merge(hits[i].collider);
                //Floor
                if (colider_Merge != null)
                {
                    isRay_Cast_Colider_Merge = true;
                    return colider_Merge;
                }
            }
            else
            {
                colider_Merge = null;
                isRay_Cast_Colider_Merge = false;
            }
        }
        return null;
    }
    
    public Goal Get_Raycast_Colider_Goal()//mouse Up
    {
        //Debug.Log(" ZZZZZZZZZZZ ");
        //**** lấy từ Raycast
        RaycastHit[] hits = new RaycastHit[6];//số phần tử bằng với hàm Get_Raycast()
        hits = Get_Raycast(layerMasks_Goal);
        for (int i = 0; i < hits.Length; i++)
        {
            //Debug.Log(hits[i].collider.gameObject.name);
            if (hits[i].collider != null)
            {
                colider_Goal = Cache.Get_Colider_Goal(hits[i].collider);
                //Floor
                if (colider_Goal != null)
                {
                    isRay_Cast_Colider_Goal = true;
                    return colider_Goal;
                }
            }
            else
            {
                colider_Goal = null;
                isRay_Cast_Colider_Goal = false;
            }
        }
        return null;
    }
    
    
    
   
    #region Lấy mọi colider mà 1 tia Racast từ camera bắn qua chuột, cho vào Array có 6 phần tử
    public RaycastHit[] Get_Raycast()
    {
        var ray = cam.ScreenPointToRay(Input.mousePosition);

        RaycastHit[] hits = new RaycastHit[6];
        //nếu raycast vào gameObject
        int layerMask = 1 << 0;//TODO: dịch bit, (chon giá trị có thể Raycast của Layer index là 6) = 1 ở trong danh sách các layer (layerMask), (các layer còn lại trong layerMask có giá trị Raycast) = 0
        Physics.RaycastNonAlloc(ray, hits, 1000, layerMask);
        return hits;
    }
    public RaycastHit[] Get_Raycast(LayerMask _layerMask)
    {
        var ray = cam.ScreenPointToRay(Input.mousePosition);

        RaycastHit[] hits = new RaycastHit[6];
        //nếu raycast vào gameObject
        
        Physics.RaycastNonAlloc(ray, hits, 1000, _layerMask);
        return hits;
    }
    #endregion
}
