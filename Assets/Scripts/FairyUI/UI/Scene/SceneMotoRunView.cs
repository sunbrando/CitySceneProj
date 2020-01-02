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
        if (panel == null)
            panel = new GamePanel("Main", "SceneDesc");
        GComponent uIBackground = panel.com.GetChild("com_desc").asCom;
        GButton button_Close = uIBackground.GetChild("Button_Close").asButton;

        GComponent com_title = uIBackground.GetChild("com_title").asCom;
        GTextField text = com_title.GetChild("title").asTextField;
        text.text = @"一名青年駕駛電單車超越一輛私家車時，撞毀私家車的倒後鏡，並加速離開。私家車司機追趕，在一處交通燈位置追上該名青年，下車後對青年拳打腳踢。一名交通警員到場，私家車司機向交通警員表示為休班警員，毋須同僚處理。最後青年要送院留醫。
廉政公署接到投訴，經調查認為涉案警員濫用私刑，將案件移交檢察院偵辦。法院審結該案，青年違反《道路法典》的規定－交通意外之後不顧而去，處2個月徒刑，緩刑1年，另須賠償2千元給對方；而涉案警員因故意傷人罪被判監7個月，緩刑2年，還須向受害人賠償1萬7千元。";
        PlayTypeEffect(text);

        button_Close.onClick.Set(() => {
            Dispose();
        });
    }

}
