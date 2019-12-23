using FairyGUI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneModel
{
    public string parentName;
    public string[] goNames;

    public Vector3 camPostion;
    public Vector3 camLocalEulerAngles;
    public Camera cam;

    public float movePercent; //百分比
    public float sumTime = 1.0f; //持续时间
    public Vector3 startCamPos;
    public Vector3 endCamPos;
    public Vector3 startCamEulerAngles;
    public Vector3 endCamEulerAngles;
    public bool isPlayCam;
    public SceneView sceneView;

    public Dictionary<string, GameObject> gos = new Dictionary<string, GameObject>();

    //goname + 移动的位置索引
    public Dictionary<string, EventCallback0> posCallbacks = new Dictionary<string, EventCallback0>();
    //goname + 动作名称
    public Dictionary<string, EventCallback0> animCallbacks = new Dictionary<string, EventCallback0>();

    public SceneModel()
    {
        cam = Camera.main;
        startCamPos = cam.transform.localPosition;
        startCamEulerAngles = cam.transform.localEulerAngles;
        isPlayCam = true;
    }

    public Vector3 GetCamToEndPos()
    {
        return new Vector3(endCamPos.x - startCamPos.x, endCamPos.y - startCamPos.y, endCamPos.z - startCamPos.z);
    }


    public Vector3 GetCamToEndEulerAngles()
    {
        return new Vector3(endCamEulerAngles.x - startCamEulerAngles.x, endCamEulerAngles.y - startCamEulerAngles.y, endCamEulerAngles.z - startCamEulerAngles.z);
    }

    public void GetAllGo()
    {
        if (goNames != null)
        {
            for (int i = 0; i < goNames.Length; i++)
            {
                string name = goNames[i];
                GameObject gameObj = GameObject.Find(parentName + name);
                gos.Add(name, gameObj);
            }
        }
    }

    public void SetMoveAndAnimCallBack()
    {
        for (int i = 0; i < goNames.Length; i++)
        {
            string name = goNames[i];
            GameObject gameObj = gos[name];
            MoveAndAnim moveAndAnim = gameObj.GetComponent<MoveAndAnim>();

            for (int j = 0; j < moveAndAnim.end.Length; j++)
            {
                if (posCallbacks.ContainsKey(name + j.ToString()))
                {
                    moveAndAnim.AddPosCallbacks(j, posCallbacks[name + j.ToString()]);
                }
            }
        }
    }


    public void Dispose()
    {
        posCallbacks = new Dictionary<string, EventCallback0>();
        animCallbacks = new Dictionary<string, EventCallback0>();
        
        for (int i = 0; i < goNames.Length; i++)
        {
            string name = goNames[i];
            GameObject gameObj = gos[name];
            MoveAndAnim moveAndAnim = gameObj.GetComponent<MoveAndAnim>();
            moveAndAnim.Dispose();
        }
    }
}
