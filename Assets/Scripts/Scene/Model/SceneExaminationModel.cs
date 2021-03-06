﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneExaminationModel : SceneModel
{
    public SceneExaminationModel() : base()
    {
        parentName = "City/SceneExamination/";
        SetNavGos(new string[] {  "Character_Male_JacketNav", "Car_6Nav" , "Character_Female_JacketNav" });
        endCamPos = new Vector3(-86.03757f, 33.16249f, -3.187508f);
        endCamEulerAngles = new Vector3(26.642f, 52.908f, 0);

        sceneView = SceneExaminationView.GetInstance();

        SetCharacter_Male_JacketCallBack();
        SetCharacter_Female_JacketCallBack();
        Car_6Call();

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
            transform.localEulerAngles = new Vector3(0, -157.2f, 0);
            faceHanTs.gameObject.SetActive(true);
        });
    }

    void Car_6Call()
    {
        string goName = "Car_6Nav";
        Transform transform = gos[goName].transform;
        Transform door = transform.Find("carKao/kao_car/door_R");

        KaoCarScript kaoCarScript = door.GetComponent<KaoCarScript>();
        kaoCarScript.ResetPos();

        posCallbacks.Add(goName + "0", () =>
        {
            kaoCarScript.PlayOpenDoor();
        });
    }

    void SetCharacter_Female_JacketCallBack()
    {
        string goName = "Character_Female_JacketNav";
        Transform transform = gos[goName].transform;
        Transform child = transform.Find("Character_Female_Jacket");
        //子节点隐藏后就无法查找，只能用这种蛋痛的写法了
        Transform money = child.Find("Bip001").Find("Bip001 Pelvis").Find("Bip001 Spine").Find("Bip001 Spine1").Find("Bip001 Spine2").Find("Bip001 Neck").Find("Bip001 R Clavicle").Find("Bip001 R UpperArm").Find("Bip001 R Forearm").Find("Bip001 R Hand").Find("Bip001 R Finger2").Find("Bip001 R Finger21").Find("money");

        child.gameObject.SetActive(false);
        money.gameObject.SetActive(false);

        posCallbacks.Add(goName + "0", () =>
        {
            child.gameObject.SetActive(true);
        });

        posCallbacks.Add(goName + "1", () =>
        {
            transform.localEulerAngles = new Vector3(0, -44.4f, 0);
            Animator animator = child.GetComponent<Animator>();
            animator.Play("diqian_1");
            money.gameObject.SetActive(true);
        });
    }
}
