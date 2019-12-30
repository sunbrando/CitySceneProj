using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainCtrl
{
    public static Vector3 defaultCamPos = new Vector3(-288.6969f, 257.4214f, -396.8492f);
    public static Vector3 defaultCamEulerAngles = new Vector3(30.699f, 46.887f, 0);
    
    public static void SwitchMainState()
    {
        switch (CtrlModel.sceneOrUI)   
        {
            case SceneOrUI.Main:
                ShowMain();
                return;
            case SceneOrUI.ZhaoCha:
                // ShowMain();
                return;
            case SceneOrUI.WenJuan:
                // ShowMain();
                return;
            case SceneOrUI.Scene:
                ShowScene();
                return;
            default:
                return;
        }
    }


    public static void ShowMain()
    {
        // MainPanel.GetInstance().InitView();
        SceneManager.UnloadSceneAsync("City");
        SceneManager.LoadScene("Init");
    }

    public static void ShowScene()
    {
        Init();
        InitCamera();
        MainScene.GetInstance().InitView();
    }

    
    public static void Init()
    {
        CtrlModel.isGodView = true;
        CtrlModel.sceneState = SceneState.None;
        CtrlModel.moveOrUI = MoveOrUI.None;
    }

    static void InitCamera()
    {
        Camera.main.transform.localPosition = defaultCamPos;
        Camera.main.transform.localEulerAngles = defaultCamEulerAngles;
    }
}
