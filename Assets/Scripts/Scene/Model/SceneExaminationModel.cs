using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneExaminationModel : SceneModel
{
    public SceneExaminationModel() : base()
    {
        parentName = "City/SceneExamination/";
        goNames = new string[] { "Character_Male_JacketNav", "Car_6Nav" , "Character_Female_JacketNav" };
        endCamPos = new Vector3(-98.05746f, 44.32618f, -49.71683f);
        endCamEulerAngles = new Vector3(22.517f, 51.773f, 0);

        //sceneView = SceneProjTalkView.GetInstance();

        GetAllGo();



        Transform transform2 = gos["Character_Female_JacketNav"].transform.GetChild(0);
        transform2.gameObject.SetActive(false);

        SetCharacter_Male_JacketCallBack();
        SetCharacter_Female_JacketCallBack();

        SetMoveAndAnimCallBack();
    }

    void SetCharacter_Male_JacketCallBack()
    {
        string goName = "Character_Male_JacketNav";
        Transform transform = gos[goName].transform;
        Transform child = transform.GetChild(0);

        child.gameObject.SetActive(false);

        posCallbacks.Add(goName + "0", () =>
        {
            child.gameObject.SetActive(true);
        });

        posCallbacks.Add(goName + "1", () =>
        {
            transform.localEulerAngles = new Vector3(0, -174.87f, 0);
        });
    }


    void SetCharacter_Female_JacketCallBack()
    {
        string goName = "Character_Female_JacketNav";
        Transform transform = gos[goName].transform;
        Transform child = transform.GetChild(0);

        child.gameObject.SetActive(false);

        posCallbacks.Add(goName + "0", () =>
        {
            child.gameObject.SetActive(true);
        });

        posCallbacks.Add(goName + "1", () =>
        {
            transform.localEulerAngles = Vector3.zero;
        });
    }
}
