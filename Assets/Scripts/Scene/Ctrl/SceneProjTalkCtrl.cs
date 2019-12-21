using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SceneProjTalkCtrl : CtrlBase
{
    public static SceneProjTalkCtrl instance;

    public static SceneProjTalkCtrl GetInstance()
    {
        if (instance == null)
        {
            instance = new SceneProjTalkCtrl();
        }
        return instance;
    }

    public override void Play()
    {
        base.Play();
    }
}
