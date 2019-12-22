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

        SetCharacter_Male_JacketCallBack();
        SetCharacter_Female_JacketCallBack();

        SetMoveAndAnimCallBack();
    }

    void SetCharacter_Male_JacketCallBack()
    {
        string goName = "Character_Male_JacketNav";
        Transform transform = gos[goName].transform;
        Transform child = transform.Find("Character_Male_Jacket");
        Transform faceHanTs = transform.Find("faceHan");
        Transform faceAngerTs = transform.Find("faceAnger");

        child.gameObject.SetActive(false);
        faceHanTs.gameObject.SetActive(false);
        faceAngerTs.gameObject.SetActive(false);

        faceAngerTs.localPosition = new Vector3(faceHanTs.localPosition.x, faceHanTs.localPosition.y-2, faceHanTs.localPosition.z);

        posCallbacks.Add(goName + "0", () =>
        {
            child.gameObject.SetActive(true);
        });

        posCallbacks.Add(goName + "1", () =>
        {
            transform.localEulerAngles = new Vector3(0, -174.87f, 0);
            faceHanTs.gameObject.SetActive(true);
        });
    }

    void ShowFaceAnger()
    {
        string goName = "Character_Male_JacketNav";
        Transform transform = gos[goName].transform;
        Transform faceAngerTs = transform.Find("faceAnger");

        faceAngerTs.gameObject.SetActive(true);
    }

    void SetCharacter_Female_JacketCallBack()
    {
        string goName = "Character_Female_JacketNav";
        Transform transform = gos[goName].transform;
        Transform child = transform.Find("Character_Female_Jacket");

        child.gameObject.SetActive(false);

        posCallbacks.Add(goName + "0", () =>
        {
            child.gameObject.SetActive(true);
        });

        posCallbacks.Add(goName + "1", () =>
        {
            transform.localEulerAngles = Vector3.zero;
            Animator animator = child.GetComponent<Animator>();
            animator.Play("Di");
        });
    }
}
