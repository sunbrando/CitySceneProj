using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveAndAnim : MonoBehaviour
{
    public Vector3 startPos;
    public Vector3[] end;
    public string[] animNames;

    Vector3 startLocalEulerAngles;
    int index;
    NavMeshAgent nav;
    int animIndex;

    [HideInInspector]
    public bool isPlay;

    void Awake()
    {
        nav = GetComponent<NavMeshAgent>();
        startPos = this.transform.localPosition;
        startLocalEulerAngles = this.transform.localEulerAngles;

        isPlay = false;
    }

    void Update()
    {
        if (isPlay)
        {
            nav.destination = end[index];
            if (Vector3.Distance(this.transform.position, end[index]) < 1)
            {
                bool isToEnd;
                if (end.Length > index + 1)
                {
                    isToEnd = false;
                    index++;
                }
                else
                {
                    isToEnd = true;
                }

                PlayAnimator();
                SetIsPlay(isToEnd);
            }
        }
    }

    void SetIsPlay(bool isToEnd)
    {
        if (isToEnd)
        {
            if (animNames.Length > 0)
            {
                if (animNames.Length == animIndex)
                {
                    Transform child = transform.GetChild(0);

                    if (child.GetComponent<Animator>() != null)
                    {
                        Animator animator = child.GetComponent<Animator>();
                        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
                        if (stateInfo.IsName("Stand"))
                        {
                            isPlay = false;
                        }
                    }
                    else
                        isPlay = false;
                }
                else
                    isPlay = true;
            }
            else
                isPlay = false;
        }
        else
            isPlay = true;
    }

    public void Play()
    {
        ResetState();
    }

    public void ResetState()
    {
        nav.enabled = false;
        this.transform.position = startPos;
        this.transform.localEulerAngles = startLocalEulerAngles;
        index = 0;
        nav.enabled = true;
        isPlay = true;
        animIndex = 0;
        PlayAnimator();
    }

    void PlayAnimator()
    {
        if (animNames.Length > 0 && animNames.Length > animIndex)
        {
            Transform child = transform.GetChild(0);

            if (child.GetComponent<Animator>() != null)
            {
                Animator animator = child.GetComponent<Animator>();
                animator.Play(animNames[animIndex]);
                animIndex = animIndex + 1;
            }
        }

    }
}
