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
        if (panel != null)
        {
            return;
        }
        panel = new GamePanel("Main", "SceneDesc");
        GComponent uIBackground = panel.com.GetChild("com_desc").asCom;
        GButton button_Close = uIBackground.GetChild("Button_Close").asButton;

        GComponent com_title = uIBackground.GetChild("com_title").asCom;
        GTextField text = com_title.GetChild("title").asTextField;
        text.text = @"某大型娛樂場外一段公共道路，在剛完成工程及通車後數天，即出現路面下陷。總承建商於是要求工程分判公司跟進及提交土壤檢測報告，但原來工程分判公司在施工時並未進行有關檢測，如要補回有關檢測，則須再次重新開挖有關路段，為減省工序，分判公司的一名外聘工程顧問及一名高級職員，以澳門幣40,000元賄賂土木工程實驗室一名工程師及一名實驗員，在沒有作出任何取樣及檢測的情況下，製作10份虛假的土壤檢測報告提交予總承建商。
有關人士分別涉嫌實施了《刑法典》規定的行賄罪、公務員實施的偽造罪及受賄作不法行為罪。";
        PlayTypeEffect(text);

        button_Close.onClick.Set(() => {
            Dispose();
        });
    }
}
