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
}
