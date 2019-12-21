using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FairyGUI;
using DG.Tweening;

public class MainView {

    public static MainView instance;

    public static MainView GetInstance()
    {
        if (instance == null)
        {
            instance = new MainView();
        }
        return instance;
    }

    public void InitView()
    {
        GRoot.inst.SetContentScaleFactor(Screen.width, Screen.height);

        GamePanel panel1 = new GamePanel("Main", "MainPanel");
        //GButton button1 = panel1.com.GetChild("button_1").asButton;
        //GButton button2 = panel1.com.GetChild("button_2").asButton;
        //GButton button3 = panel1.com.GetChild("button_3").asButton;
        //GButton button4 = panel1.com.GetChild("button_4").asButton;
        GButton button5 = panel1.com.GetChild("button_5").asButton;

        //button1.onClick.Set(button1_Click);
        //button2.onClick.Set(button2_Click);
        //button3.onClick.Set(button3_Click);
        //button4.onClick.Set(button4_Click);
        button5.onClick.Set(button5_Click);
    }

    //void button1_Click()
    //{
    //    CtrlModel.SwicthState(SceneState.SceneMotoRun);
    //}

    //void button2_Click()
    //{
    //    CtrlModel.SwicthState(SceneState.SceneProjTalk);
    //}

    //void button3_Click()
    //{
    //    Debug.Log("button3_Click");
    //}

    //void button4_Click()
    //{
    //    Debug.Log("button4_Click");
    //}

    void button5_Click()
    {
        Transform cam = Camera.main.transform;

        cam.transform.DOMove(Main.defaultCamPos, 1);
        cam.transform.DORotate(Main.defaultCamEulerAngles, 1);
        Main.Init();
    }
}
