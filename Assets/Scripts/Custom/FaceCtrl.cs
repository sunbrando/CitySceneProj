using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FaceCtrl : MonoBehaviour
{
    public Transform faceAngerTs;

    void OnEnable()
    {
        Invoke("ShowFaceAnger", 4.0f);
    }

    void ShowFaceAnger()
    {
        if (CtrlModel.sceneState == SceneState.SceneExamination)
        {
            this.gameObject.SetActive(false);
            faceAngerTs.gameObject.SetActive(true);
            faceAngerTs.DOMoveY(faceAngerTs.localPosition.y + 2, 0.5f);
        }
    }
}
