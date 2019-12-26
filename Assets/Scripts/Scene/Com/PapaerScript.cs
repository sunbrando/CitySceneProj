using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PapaerScript : MonoBehaviour
{
    GameObject StartNode;
    Vector3 startPos;
    Vector3 startEulerAngles;

    public GameObject endNode;
    public Animator animator;

    bool isFinish = false;

    private void Awake()
    {
        StartNode = this.transform.parent.gameObject;
        startPos = this.transform.localPosition;
        startEulerAngles = this.transform.localEulerAngles;
    }

    void Update()
    {
        if (CtrlModel.sceneState != SceneState.SceneProjTalk)
        {
            this.transform.parent = StartNode.transform;
            this.transform.localPosition = startPos;
            this.transform.localEulerAngles = startEulerAngles;

            isFinish = false;
        }
        else
        {
            if (Vector3.Distance(this.transform.position, endNode.transform.position) < 0.8)
            {
                AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
                if (stateInfo.IsName("Di") && !isFinish)
                {
                    this.transform.parent = endNode.transform;
                    this.transform.localPosition = new Vector3(-0.042f, 0.027f, 0.113f);
                    this.transform.localEulerAngles = new Vector3(-18.859f, 125.04f, 1.1f);
                    isFinish = true;
                }
                else
                    isFinish = false;
            }
        }
    }
}
