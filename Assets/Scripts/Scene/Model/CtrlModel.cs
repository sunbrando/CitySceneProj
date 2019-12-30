using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SceneOrUI
{
    Main,
    ZhaoCha,
    WenJuan,
    Scene,
}

public enum SceneState
{
    None,
    SceneMotoRun,
    SceneProjTalk,
    SceneExamination,
    UIWenJuan,
    UIZhaoCha
};

public enum MoveOrUI
{
    None,
    Move,
    UI,
};

public class CtrlModel
{
    public static bool isPass = false;

    public static SceneOrUI sceneOrUI;
    public static SceneState sceneState;
    public static MoveOrUI moveOrUI;
    public static SceneModel sceneModel;
    public static bool isSceneEnd;
    public static bool isGodView;

    public static void InitModel()
    {
        sceneOrUI = SceneOrUI.Scene;
        sceneState = SceneState.None;
        moveOrUI = MoveOrUI.None;
        sceneModel = null;
        isSceneEnd = true;
        isGodView = true;
    }

    public static CtrlBase GetSceneCtrl()
    {
        switch (CtrlModel.sceneState)
        {
            case SceneState.SceneMotoRun:
                return SceneMotoCtrl.GetInstance();
            case SceneState.SceneProjTalk:
                return SceneProjTalkCtrl.GetInstance();
            case SceneState.SceneExamination:
                return SceneExaminationCtrl.GetInstance();
            case SceneState.UIWenJuan:
                return null;
            case SceneState.UIZhaoCha:
                return null;
            default:
                return null;
        }
    }

    public static SceneModel GetSceneModel(SceneState sceneState)
    {
        switch (sceneState)
        {
            case SceneState.SceneMotoRun:
                return new SceneMotoModel();
            case SceneState.SceneProjTalk:
                return new SceneProjTalkModel();
            case SceneState.SceneExamination:
                return new SceneExaminationModel();
            case SceneState.UIWenJuan:
                return null;
            case SceneState.UIZhaoCha:
                return null;
            default:
                return null;
        }
    }

    public static void SwicthState(SceneState sceneState)
    {
        CtrlModel.sceneState = sceneState;
        if (CtrlModel.sceneModel != null)
        {
            CtrlModel.sceneModel.Dispose();
            CtrlModel.sceneModel = null;
        }
        CtrlModel.sceneModel = CtrlModel.GetSceneModel(sceneState);
        CtrlModel.moveOrUI = MoveOrUI.None;
        CtrlModel.isSceneEnd = false;
    }
}
