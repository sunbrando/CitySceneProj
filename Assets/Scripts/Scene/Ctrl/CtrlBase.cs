using DG.Tweening;
using DG.Tweening.Core;
using FairyGUI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CtrlBase
{

    [HideInInspector]
    public EventCallback0 SceneEndCallback;

    public virtual void Play()
    {
        PlayCame();
        if (CtrlModel.moveOrUI == MoveOrUI.Move && IsStop())
        {
            if (CtrlModel.sceneModel.sceneView != null)
            {
                CtrlModel.moveOrUI = MoveOrUI.UI;
                CtrlModel.sceneModel.sceneView.InitView(() =>
                {
                });
                SceneEnd();
            }
            else
            {
                SceneEnd();
            }
        }
        else if (CtrlModel.moveOrUI == MoveOrUI.None)
        {
            CtrlModel.moveOrUI = MoveOrUI.Move;
            MoveAndAnimPlay();
        }
    }

    void MoveAndAnimPlay()
    {
        if (CtrlModel.sceneModel.goNames != null && CtrlModel.sceneModel.goNames.Length > 0)
        {
            for (int i = 0; i < CtrlModel.sceneModel.goNames.Length; i++)
            {
                MoveAndAnim moveAndAnim = Find(CtrlModel.sceneModel.goNames[i]);
                if (moveAndAnim != null)
                {
                    moveAndAnim.Play();
                }
            }
        }
    }

    public bool IsStop()
    {
        if (CtrlModel.sceneModel != null && CtrlModel.sceneModel.goNames != null)
        {
            for (int i = 0; i < CtrlModel.sceneModel.goNames.Length; i++)
            {
                MoveAndAnim moveAndAnim = Find(CtrlModel.sceneModel.goNames[i]);
                if (moveAndAnim != null)
                {
                    if (moveAndAnim.isPlay)
                    {
                        return false;
                    }
                }
            }
        }

        return true;
    }

    public MoveAndAnim Find(string name)
    {
        GameObject gameObj = GameObject.Find(CtrlModel.sceneModel.parentName + name);
        if (gameObj != null)
        {
            return gameObj.GetComponent<MoveAndAnim>();
        }

        return null;
    }


    void PlayCame()
    {
        if (CtrlModel.sceneModel.isPlayCam)
        {
            Transform cam = Camera.main.transform;

            cam.transform.DOMove(CtrlModel.sceneModel.endCamPos, 1);
            cam.transform.DORotate(CtrlModel.sceneModel.endCamEulerAngles, 1);

            CtrlModel.sceneModel.isPlayCam = false;
        }
    }

    void SceneEnd()
    {
        CtrlModel.isSceneEnd = true;
        SceneEndCallback?.Invoke();
    }
}
