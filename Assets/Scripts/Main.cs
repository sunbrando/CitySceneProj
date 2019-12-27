using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FairyGUI;

public class Main : MonoBehaviour
{


    bool isPass = false;

    void Awake()
    {
        CtrlModel.sceneOrUI = SceneOrUI.Main;
        GRoot.inst.SetContentScaleFactor(Screen.width, Screen.height);
    }

    IEnumerator Start()
    {
        #if UNITY_EDITOR
            CtrlModel.isPass = true;
            yield return null;
        #else
            yield return StartCoroutine(CheckIsPass.GetRequest());
        #endif

        StartCoroutine(IsPass());
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

    public IEnumerator IsPass()
    {
        if (!CtrlModel.isPass)
        {
            yield return null;
        }

        MainCtrl.SwitchMainState();
        yield return null;
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
