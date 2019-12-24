using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneProjTalkModel : SceneModel
{
    public SceneProjTalkModel() : base()
    {
        parentName = "City/SceneProjTalk/";
        SetNavGos(new string[] { "Character_Male_JacketNav", "Character_BusinessMan_SuitNav", "Character_BusinessWomanNav", "Character_Female_JacketNav", "CabrioleteNav" });
        endCamPos = new Vector3(63.29413f, 27.07268f, -166.4784f);
        endCamEulerAngles = new Vector3(27.502f, 45.928f, 0);

        sceneView = SceneProjTalkView.GetInstance();
    }
}
