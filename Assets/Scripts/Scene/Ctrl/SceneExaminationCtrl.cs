using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SceneExaminationCtrl : CtrlBase
{
    public static SceneExaminationCtrl instance;

    public static SceneExaminationCtrl GetInstance()
    {
        if (instance == null)
        {
            instance = new SceneExaminationCtrl();
        }
        return instance;
    }

    public override void Play()
    {
        base.Play();
    }
}
