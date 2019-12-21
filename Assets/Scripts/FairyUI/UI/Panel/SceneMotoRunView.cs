using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FairyGUI;

public class SceneMotoRunView: SceneView
{
    public static SceneMotoRunView instance;

    public static SceneMotoRunView GetInstance()
    {
        if (instance == null)
        {
            instance = new SceneMotoRunView();
        }
        return instance;
    }

    public override void InitView(EventCallback0 eventCallback0)
    {
        this.eventCallback0 = eventCallback0;
        panel = new GamePanel("Main", "SceneMotoRun");
        GComponent uIBackground = panel.com.GetChild("UIBackground").asCom;

        GButton button_Close = uIBackground.GetChild("Button_Close").asButton;

        GTextField text = panel.com.GetChild("text").asTextField;
        PlayTypeEffect(text);

        button_Close.onClick.Set(() => {
            Dispose();
        });
    }

}
