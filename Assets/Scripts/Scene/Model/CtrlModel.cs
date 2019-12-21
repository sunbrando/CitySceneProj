using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public static SceneState sceneState;
    public static MoveOrUI moveOrUI;
    public static SceneModel sceneModel;
    public static bool isSceneEnd = true;
    public static bool isGodView = true;

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
        CtrlModel.sceneModel = CtrlModel.GetSceneModel(sceneState);
        CtrlModel.moveOrUI = MoveOrUI.None;
        CtrlModel.isSceneEnd = false;
    }
}
