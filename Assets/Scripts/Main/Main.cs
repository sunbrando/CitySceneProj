using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FairyGUI;
using System.IO;

public class Main : MonoBehaviour
{
    void Awake()
    {
        // UnityEngine.ScreenCapture.CaptureScreenshot(UnityEngine.Application.streamingAssetsPath + "/" + "Screenshot.png");  
        CtrlModel.InitModel();
        GRoot.inst.SetContentScaleFactor(Screen.width, Screen.height);
    }

    void OnDestroy()
    {
        CtrlModel.InitModel();
    }

    void Start()
    {
        IsPass();
    }

    private void Update()
    {
        if (!CtrlModel.isPass)
            return;

        if (CtrlModel.sceneOrUI == SceneOrUI.Scene)
        {
            UpdateScene();
        }
    }

    public void IsPass()
    {
        if (!CtrlModel.isPass)
        {
            return;
        }

        MainCtrl.SwitchMainState();
    }

    void UpdateScene()
    {
        if (CtrlModel.isGodView)
        {
            PlayByGodView();
        }
        else
        {
            Play();
        }
    }

    void PlayByGodView()
    {
        CtrlBase ctrl = CtrlModel.GetSceneCtrl();

        if (ctrl == null || ctrl.IsStop())
        {
            SwitchSceneState();
            CtrlModel.SwicthState(CtrlModel.sceneState);
            CtrlModel.sceneModel.isPlayCam = false;
            CtrlModel.sceneModel.sceneView = null;
        }

        Play();
    }

    void Play()
    {
        if (!CtrlModel.isSceneEnd)
        {
            CtrlBase ctrl = CtrlModel.GetSceneCtrl();
            if (ctrl != null)
            {
                ctrl.Play();
            }
        }
        else
        {
            CtrlModel.SwicthState(CtrlModel.sceneState);
        }
    }


    void SwitchSceneState()
    {
        if (CtrlModel.sceneState == SceneState.SceneExamination)
        {
            CtrlModel.sceneState = SceneState.SceneProjTalk;
        }
        else if(CtrlModel.sceneState == SceneState.SceneMotoRun)
        {
            CtrlModel.sceneState = SceneState.SceneExamination;
        }
        else
        {
            CtrlModel.sceneState = SceneState.SceneMotoRun;
        }
    }
}
