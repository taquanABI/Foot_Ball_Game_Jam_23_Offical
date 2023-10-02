using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngameManager : SingletonMonoBehaviour<IngameManager>
{
    public GameObject winEffect;

    public void Set_Goal_Effect()
    {
        winEffect.SetActive(true);
    }

    /*[HideInInspector] */
    public List<Player> list_Player_Inlevel;
    [HideInInspector] public GameObject o_Arrow_Tut;
    protected override void Awake()
    {
        base.Awake();

    }
    // Start is called before the first frame update
    void Start()
    {
        On_Init();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void On_Init()
    {
        LoadLevel();
    }
    

    public void Set_off_Tut()
    {
        StartCoroutine(ie_Wait_player_Init());
    }
    IEnumerator ie_Wait_player_Init()
    {
        yield return new WaitUntil(() => o_Arrow_Tut != null);
        o_Arrow_Tut.SetActive(false);
    }

    public void Set_Level_Win()
    {

        Timer.Schedule(this, 6, () =>
        {
            //TODO: Hiện encard win sau khi Win ở chỗ này
            Debug.Log(" Show win ");
            UIManager.ins.OpenUI(UIID.UICVictory);
            DataManager.ins.playerData.level++;
        });
    }
    
    public void Set_Level_Fail()
    {
        Timer.Schedule(this, 3, () =>
        {
            //TODO: Hiện encard fail sau khi fail ở chỗ này
            Debug.Log(" Show fail ");
            UIManager.ins.OpenUI(UIID.UICFail);                                                                                                                                                                                                                                                             
        });
    }

    private void LoadLevel()
    {
        Instantiate(GameConfig.ins.list_Level[DataManager.ins.playerData.level - 1]);
        Timer.Schedule(this, 1, () =>
        {

        });

        // ảnh 100 * 100: 
    }    
}
/*
 
 Ball
                list<Transform_Target>

                Set_target(list_Transform_Target); 

                Fly(); 
                    Kiểm tra list_Player có rỗng ko
                        di chuyển qua các pos từng Player trong list
                            Remove Player ra khỏi list
                
                
                Va chạm vs enemy
                    Dừng lại
                
                
                
                
                
                
 
            InGamePlay
                Get_Pos_
                list_Player_Will_Draw
                
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 
 */