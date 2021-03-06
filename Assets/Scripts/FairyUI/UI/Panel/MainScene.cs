﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FairyGUI;
using DG.Tweening;

public class MainScene : SceneView {

    public static MainScene instance;

    public static MainScene GetInstance()
    {
        if (instance == null)
        {
            instance = new MainScene();
        }
        return instance;
    }

    public override void InitView(EventCallback0 eventCallback0 = null)
    {
        panel = new GamePanel("Main", "MainScene");
        GButton button_sceneBack = panel.com.GetChild("button_sceneBack").asButton;
        GButton button_main = panel.com.GetChild("button_main").asButton;
        GButton button_wenjuan = panel.com.GetChild("button_wenjuan").asButton;
        GButton button_zhaocha = panel.com.GetChild("button_zhaocha").asButton;

        button_sceneBack.onClick.Set(Button_sceneBack_Click);
        button_wenjuan.onClick.Set(Button_wenjuan_Click);
        button_zhaocha.onClick.Set(Button_zhaocha_Click);
        button_main.onClick.Set(Button_main_Click);
    }

    void Button_sceneBack_Click()
    {
        if (!CtrlModel.isGodView)
        {
            Transform cam = Camera.main.transform;

            cam.transform.DOMove(MainCtrl.defaultCamPos, 1);
            cam.transform.DORotate(MainCtrl.defaultCamEulerAngles, 1);
            MainCtrl.Init();
        }
    }

    void Button_main_Click()
    {
        SwitchMainState(SceneOrUI.Main);
    }
    
    void Button_zhaocha_Click()
    {
        SwitchMainState(SceneOrUI.ZhaoCha);
    }
    
    void Button_wenjuan_Click()
    {
        SwitchMainState(SceneOrUI.WenJuan);
    }
}
