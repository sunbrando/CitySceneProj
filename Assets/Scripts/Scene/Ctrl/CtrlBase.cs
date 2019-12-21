using DG.Tweening;
using DG.Tweening.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class CtrlBase
{
    public void MoveCamer()
    {
        if (CtrlModel.sceneModel.isPlayCam)
        {
            if (Vector3.Distance(CtrlModel.sceneModel.startCamEulerAngles, CtrlModel.sceneModel.endCamEulerAngles) > 1)
            {
                CtrlModel.sceneModel.movePercent += Time.deltaTime / CtrlModel.sceneModel.sumTime;
                CtrlModel.sceneModel.cam.transform.localPosition = Vector3.Lerp(CtrlModel.sceneModel.startCamPos, CtrlModel.sceneModel.endCamPos, CtrlModel.sceneModel.movePercent);
                CtrlModel.sceneModel.cam.transform.localEulerAngles = Vector3.Lerp(CtrlModel.sceneModel.startCamEulerAngles, CtrlModel.sceneModel.endCamEulerAngles, CtrlModel.sceneModel.movePercent);
            }
            else
                CtrlModel.sceneModel.isPlayCam = false;
        }
    }

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
                    CtrlModel.moveOrUI = MoveOrUI.None;
                });
            }
            else
            {
                CtrlModel.moveOrUI = MoveOrUI.None;
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
            DOTweenAnimation[] doTweenAnimations = cam.GetComponents<DOTweenAnimation>();
            for (int i = 0; i < doTweenAnimations.Length; i++)
            {
                if (doTweenAnimations[i].animationType == DOTweenAnimationType.LocalMove)
                {
                    doTweenAnimations[i].endValueV3 = CtrlModel.sceneModel.GetCamToEndPos();
                    doTweenAnimations[i].DOPlay();
                }
                else if (doTweenAnimations[i].animationType == DOTweenAnimationType.LocalRotate)
                {
                    doTweenAnimations[i].endValueV3 = CtrlModel.sceneModel.GetCamToEndEulerAngles();
                    doTweenAnimations[i].DOPlay();
                }
            }

            CtrlModel.sceneModel.isPlayCam = false;
        }
    }
}
