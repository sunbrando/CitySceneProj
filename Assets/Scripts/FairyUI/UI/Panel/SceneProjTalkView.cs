using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FairyGUI;

public class SceneProjTalkView : SceneView
{
    public static SceneProjTalkView instance;

    public static SceneProjTalkView GetInstance()
    {
        if (instance == null)
        {
            instance = new SceneProjTalkView();
        }
        return instance;
    }

    public override void InitView(EventCallback0 eventCallback0)
    { 
        this.eventCallback0 = eventCallback0;
        panel = new GamePanel("Main", "SceneProjTalk");
        GComponent uIBackground = panel.com.GetChild("UIBackground").asCom;
        GButton button_Close = uIBackground.GetChild("Button_Close").asButton;

        GTextField text = panel.com.GetChild("text").asTextField;
        PlayTypeEffect(text);

        button_Close.onClick.Set(() => {
            Dispose();
        });
    }

    public override void Dispose()
    {
        base.Dispose();
    }
}
