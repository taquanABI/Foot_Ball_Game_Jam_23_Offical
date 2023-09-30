    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

public class PoolController : Singleton<PoolController>
{
    [Header("=== MiniPool_Line ===")]
    public Transform tf_MiniPool_Line_Blue;// cai luu tren hierechy
    public GameObject obj_Prefab_Line_Blue;// cai luu tren hierechy
    public MiniPool<Line> miniPool_Line_Blue;// cai luu tren hierechy
    
    [Header("=== MiniPool_Line ===")]
    public Transform tf_MiniPool_Line_White;// cai luu tren hierechy
    public GameObject obj_Prefab_Line_White;// cai luu tren hierechy
    public MiniPool<Line> miniPool_Line_White;// cai luu tren hierechy
    

// Start is called before the first frame update
    protected override void Awake()
    {
        base.Awake();

        DontDestroyOnLoad(this.gameObject);

        miniPool_Line_Blue = new MiniPool<Line>(obj_Prefab_Line_Blue, 5, tf_MiniPool_Line_Blue);
        miniPool_Line_White = new MiniPool<Line>(obj_Prefab_Line_White, 20, tf_MiniPool_Line_White);
        
    }

}
