using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameState { MainMenu, GamePlay, Finish}
public class GameManager : SingletonMonoBehaviour<GameManager>
{
    
    private static GameState gameState = GameState.MainMenu;
    
    protected override void Awake()
    {
        base.Awake();
        Input.multiTouchEnabled = false;
        Application.targetFrameRate = 60;
        Screen.sleepTimeout = SleepTimeout.NeverSleep;

        int maxScreenHeight = 1280;
        float ratio = (float)Screen.currentResolution.width / (float)Screen.currentResolution.height;
        if (Screen.currentResolution.height > maxScreenHeight)
        {
            Screen.SetResolution(Mathf.RoundToInt(ratio * (float)maxScreenHeight), maxScreenHeight, true);
        }

        ChangeState(GameState.MainMenu);
    }

    public static void ChangeState(GameState state)
    {
        gameState = state;
    }

    public static bool IsState(GameState state)
    {
        return gameState == state;
    }


    // quản lý hệ thống
    private void Start()
    {
        StartCoroutine(ie_LoadGame());
    }

    private IEnumerator ie_LoadGame()
    {
        yield return new WaitUntil(() =>
            LoadingScreen.ins != null
            && SoundManager.ins != null
            && DataManager.ins
            && UIManager.ins
        );

        // show AOA
        // app open ads: show ads// load ads và show: tốn thời gian

        //SoundManager.PlayMusicBg(SoundManager.ins.bgMusic);

        LoadingScreen.ins.SetPercent(0.35f, .3f);
        DataManager.ins.LoadData();
        //StartCoroutine(CountTime());
        yield return Cache.GetWFS(1f);

        LoadingScreen.ins.SetPercent(0.45f, .3f);
        yield return Cache.GetWFS(1f);

        // làm 1 cái j đấy

        LoadingScreen.ins.SetPercent(0.7f, .3f);
        yield return Cache.GetWFS(1f);

        // if (GameManager.ins.data.charUsed == CharacterType.None)
        // {
        //     var checkReward = false;
        //     Timer.Schedule(this, 3f, () => checkReward = true);

        //     yield return new WaitUntil(() => checkReward || MaxManager.Ins.isVideoLoaded);

        //     LoadingScene.ins.Close();
        //     OpenSelectChar();
        // }

        // yield return new WaitUntil(() => GameManager.ins.data.charUsed != CharacterType.None);

        yield return Cache.GetWFS(1f);

        var sync = SceneManager.LoadSceneAsync("Home");

        SoundManager.PlayMusicBg(SoundManager.ins.bg_Sound_All);

        yield return new WaitUntil(() => sync.isDone);

        LoadingScreen.ins.SetPercent(1f, 0.3f);

        yield return Cache.GetWFS(0.5f);


        LoadingScreen.ins.gameObject.SetActive(false);



        UIManager.ins.OpenUI(UIID.UICMainMenu);
        
        // yield return new WaitUntil(() =>
        //     PlayerController.ins != null
        //     && LevelManager.ins != null
        //     && MapParent.ins != null
        // );

        // PlayerPrefs.GetInt // ko dùng nữa
        // DataManager.ins.playerData.gold = 200;
        // DataManager.ins.playerData.pet_id = 200;



        DataManager.ins.SaveData();  // lưu lại data

        // UIManager.ins.OpenUI(UIID.UICVictory);  // bật  victory
        // UIManager.ins.GetUI<CanvasGameplay>(UIID.UICGamePlay).SettingButton();  // lấy ra và gọi hàm trong nó

        //yield return new WaitUntil

        
    }

    public void Load_Game_Play()
    {
        StartCoroutine(ie_Load_Game_Play());
    }
    IEnumerator ie_Load_Game_Play()
    {
        var sync = SceneManager.LoadSceneAsync("GamePlay");

        yield return new WaitUntil(() => sync.isDone);
        SoundManager.PlayMusicBg(SoundManager.ins.bg_Sound_On_Game);
    }
    public void Load_HomeGame()
    {
        //StartCoroutine(ie_Load_HomeGame());
        StartCoroutine(ie_Load_HomeGame());//FAKEE
    }
    IEnumerator ie_Load_HomeGame()
    {
        var sync = SceneManager.LoadSceneAsync("Home");

        yield return new WaitUntil(() => sync.isDone);
        UIManager.ins.OpenUI(UIID.UICMainMenu);
        SoundManager.StopMusicBg_Crown();
        
    }
}
