using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Main : MonoBehaviour
{
    public static Vector3 defaultCamPos = new Vector3(-288.6969f, 257.4214f, -396.8492f);
    public static Vector3 defaultCamEulerAngles = new Vector3(30.699f, 46.887f, 0);

    bool isPass = false;
    private void Awake()
    {
        isPass = Util.IsPass();
        if (!isPass)
            return;
        Init();
        InitCamera();
        MainView.GetInstance().InitView();
    }

    void Start()
    {

    }

    private void Update()
    {
        if (!isPass)
            return;
        if (CtrlModel.isGodView)
        {
            PlayByGodView();
        }
        else
        {
            Play();
        }
    }

    public static void Init()
    {
        CtrlModel.isGodView = true;
        CtrlModel.sceneState = SceneState.None;
        CtrlModel.moveOrUI = MoveOrUI.None;
    }

    void InitCamera()
    {
        Camera.main.transform.localPosition = defaultCamPos;
        Camera.main.transform.localEulerAngles = defaultCamEulerAngles;
    }

    void PlayByGodView()
    {
        CtrlBase ctrl = CtrlModel.GetSceneCtrl();

        if (ctrl == null || ctrl.IsStop())
        {
            SwitchState();
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

    void SwitchState()
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
