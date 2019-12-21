using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SceneNoneCtrl : CtrlBase
{
    public static SceneNoneCtrl instance;

    public static SceneNoneCtrl GetInstance()
    {
        if (instance == null)
        {
            instance = new SceneNoneCtrl();
        }
        return instance;
    }

    public override void Play()
    {
        base.Play();
    }
}
