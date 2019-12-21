using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SceneMotoCtrl : CtrlBase
{
    public static SceneMotoCtrl instance;

    public static SceneMotoCtrl GetInstance()
    {
        if (instance == null)
        {
            instance = new SceneMotoCtrl();
        }
        return instance;
    }

    public override void Play()
    {
        base.Play();
    }
}
