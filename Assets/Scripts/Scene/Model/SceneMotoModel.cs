using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneMotoModel : SceneModel
{
    public SceneMotoModel() : base()
    {
        parentName = "City/SceneMotoRun/";
        goNames = new string[] { "MotorbikeNav", "Car_6Nav", "Bus_6Nav", "Police_2Nav", "Character_BusinessMan_ShirtNav", "Character_Female_JacketNav", "Character_Male_PoliceNav" };
        endCamPos = new Vector3(-77.5314f, 53.95737f, -251.1162f);
        endCamEulerAngles = new Vector3(28.808f, 35.398f, 0);

        sceneView = SceneMotoRunView.GetInstance();
    }
}
