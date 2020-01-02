using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FairyGUI;

public class SceneExaminationView : SceneView
{
    public static SceneExaminationView instance;

    public static SceneExaminationView GetInstance()
    {
        if (instance == null)
        {
            instance = new SceneExaminationView();
        }
        return instance;
    }

    public override void InitView(EventCallback0 eventCallback0)
    {
        this.eventCallback0 = eventCallback0;
        if (panel == null)
            panel = new GamePanel("Main", "SceneDesc");
        panel.com.GetController("位置").selectedPage = "左";
        GComponent uIBackground = panel.com.GetChild("com_desc").asCom;
        GButton button_Close = uIBackground.GetChild("Button_Close").asButton;

        GComponent com_title = uIBackground.GetChild("com_title").asCom;
        GTextField text = com_title.GetChild("title").asTextField;
        text.text = @"一名參加駕照考試的市民，於應考時將一千澳門元塞入考官手中，意圖行賄考官以順利通過駕駛考試，考官即時拒絕及舉報廉政公署。案件由廉政公署移交檢察院偵辦。
法院判處該名市民行賄罪名成立，處7個月徒刑，緩刑1年6個月。";
        PlayTypeEffect(text);

        button_Close.onClick.Set(() => {
            Dispose();
        });
    }
}
