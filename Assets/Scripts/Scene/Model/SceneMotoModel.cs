using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SceneMotoModel : SceneModel
{
    public SceneMotoModel() : base()
    {
        parentName = "City/SceneMotoRun/";
        goNames = new string[] { "MotorbikeNav", "Car_6Nav", "Bus_6Nav", "Character_BusinessMan_ShirtNav", "Character_Female_JacketNav", "Character_Male_PoliceNav" };
        endCamPos = new Vector3(-77.5314f, 53.95737f, -251.1162f);
        endCamEulerAngles = new Vector3(28.808f, 35.398f, 0);

        sceneView = SceneMotoRunView.GetInstance();

        GetAllGo();

        SetCarCallBack();
        SetCharacter_BusinessMan_ShirtCallBack();
        MotorbikeCallBack();
        Car_6Call();

        SetMoveAndAnimCallBack();
    }

    void SetCarCallBack()
    {
        string goName = "Car_6Nav";
        Transform transform = gos[goName].transform;
        NavMeshAgent nav = transform.GetComponent<NavMeshAgent>();
        nav.speed = 50;
        nav.acceleration = 50;

        Transform boomTs = transform.Find("碰撞效果");
        boomTs.gameObject.SetActive(false);

        posCallbacks.Add(goName + "0", () =>
        {
            boomTs.gameObject.SetActive(true);

            nav.speed = 180;
            nav.acceleration = 150;
        });
        posCallbacks.Add(goName + "1", () =>
        {
            boomTs.gameObject.SetActive(false);
            if (CtrlModel.sceneState == SceneState.SceneMotoRun && !CtrlModel.isGodView)
            {
                Camera.main.transform.DOMove(new Vector3(9.987728f, 44f, -45.65843f), 1);
                Camera.main.transform.DORotate(new Vector3(40.909f, 59.438f, 0), 1);
            }
        });
    }

    void MotorbikeCallBack()
    {
        string goName = "MotorbikeNav";
        Transform transform = gos[goName].transform;
        Transform child = transform.Find("SK_Character_Male_Hoodie");
        child.transform.localPosition = new Vector3(0, -5.84f, -0.1499939f);

        posCallbacks.Add(goName + "1", () =>
        {
            child.transform.transform.DOMove(new Vector3(80f, 0.5020432f, -31.8105f), 0.5f);
            Animator animator = child.GetComponent<Animator>();
            animator.Play("bedown");
        });
    }

    void SetCharacter_BusinessMan_ShirtCallBack()
    {
        string goName = "Character_BusinessMan_ShirtNav";
        Transform transform = gos[goName].transform;
        Transform child = transform.Find("Character_BusinessMan_Shirt");

        posCallbacks.Add(goName + "1", () =>
        {
            child.gameObject.SetActive(true);
        });

        posCallbacks.Add(goName + "2", () =>
        {
            Animator animator = child.GetComponent<Animator>();
            animator.Play("attack");
        });
    }

    void Car_6Call()
    {
        string goName = "Car_6Nav";
        Transform transform = gos[goName].transform;
        Transform door = transform.Find("Car_6/Car_Yellow_1/door_right");
        BlueCarScript blueCarScript = door.GetComponent<BlueCarScript>();
        blueCarScript.ResetPos();

        posCallbacks.Add(goName + "2", () =>
        {
            blueCarScript.PlayOpenDoor();
        });
    }
}
