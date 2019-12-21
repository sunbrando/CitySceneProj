using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SceneState
{
    None,
    SceneMotoRun,
    SceneProjTalk,
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
    public static bool isGodView = true;

    public static CtrlBase GetSceneCtrl()
    {
        switch (CtrlModel.sceneState)
        {
            case SceneState.SceneMotoRun:
                return SceneMotoCtrl.GetInstance();
            case SceneState.SceneProjTalk:
                return SceneProjTalkCtrl.GetInstance();
            case SceneState.UIWenJuan:
                return SceneMotoCtrl.GetInstance();
            case SceneState.UIZhaoCha:
                return SceneMotoCtrl.GetInstance();
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
            case SceneState.UIWenJuan:
                return new SceneMotoModel();
            case SceneState.UIZhaoCha:
                return new SceneMotoModel();
            default:
                return null;
        }
    }

    public static void SwicthState(SceneState sceneState)
    {
        if (CtrlModel.sceneState != sceneState || CtrlModel.isGodView)
        {
            CtrlModel.isGodView = false;
            CtrlModel.sceneState = sceneState;
            CtrlModel.sceneModel = CtrlModel.GetSceneModel(sceneState);
            CtrlModel.moveOrUI = MoveOrUI.None;
        }
    }
}
