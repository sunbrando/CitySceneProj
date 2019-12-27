using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FairyGUI;
using DG.Tweening;

public class MainPanel : SceneView {

    public static MainPanel instance;

    public static MainPanel GetInstance()
    {
        if (instance == null)
        {
            instance = new MainPanel();
        }
        return instance;
    }

    public override void InitView(EventCallback0 eventCallback0 = null)
    {
        panel = new GamePanel("Main", "MainPanel");

        GButton btn_3D = panel.com.GetChild("btn_3D").asButton;
        btn_3D.onClick.Set(Btn3D_Click);
    }


    void Btn3D_Click()
    {
        SwitchMainState(SceneOrUI.Scene);
    }
}
