using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarScript : MonoBehaviour
{
    public GameObject parentGo;
    public GameObject pongEffect;

    Vector3 startPos;
    Vector3 endPos;

    private void Awake()
    {
        startPos = this.transform.localPosition;
        endPos = new Vector3(-1.51f, -1.31f, 1.39f);
    }

    void Update()
    {
        if (!parentGo.GetComponent<MoveAndAnim>().isPlay && CtrlModel.sceneState == SceneState.SceneMotoRun)
        {
            pongEffect.SetActive(true);
            this.transform.localPosition = endPos;
        }
        else
        {
            pongEffect.SetActive(false);
            this.transform.localPosition = startPos;
        }
    }
}
