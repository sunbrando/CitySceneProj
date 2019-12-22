using FairyGUI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveAndAnim : MonoBehaviour
{
    public Vector3 startPos;
    public Vector3[] end;
    public string[] animNames;
    public float[] delays;
    public string[] delaysAnimNames;

    public Dictionary<int, EventCallback0> posCallbacks = new Dictionary<int, EventCallback0>();
    public Dictionary<string, EventCallback0> animCallbacks = new Dictionary<string, EventCallback0>();

    Vector3 startLocalEulerAngles;
    int index;
    NavMeshAgent nav;
    int animIndex;
    int delaysIndex;
    float delay;

    [HideInInspector]
    public bool isPlay;

    void Awake()
    {
        nav = GetComponent<NavMeshAgent>();
        startPos = this.transform.localPosition;
        startLocalEulerAngles = this.transform.localEulerAngles;
    }

    void Update()
    {
        if (isPlay)
        {
            PlayPos();
        }
    }

    public void Play()
    {
        isPlay = true;

        nav.enabled = false;
        this.transform.position = startPos;
        this.transform.localEulerAngles = startLocalEulerAngles;
        index = 0;
        nav.enabled = true;
        animIndex = 0;
        delay = 0;
        delaysIndex = -1;
        PlayNavAnimator();
        SetDelay();
    }

    void SetIsEnd(bool isToEnd)
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

    void PlayNavAnimator()
    {
        if (animNames.Length > 0 && animNames.Length > animIndex)
        {
            PlayAnimator(animNames[animIndex]);
            animIndex++;
        }
    }

    void PlayDelaysAnimator()
    {
        if (delaysAnimNames.Length > 0 && delaysAnimNames.Length > index)
        {
            if (delaysIndex != index)
            {
                PlayAnimator(delaysAnimNames[index]);
                delaysIndex = index;
            }
        }
    }

    void PlayAnimator(string animName)
    {
        if (string.IsNullOrEmpty(animName))
        {
            return;
        }
        Transform child = transform.GetChild(0);

        if (child.GetComponent<Animator>() != null)
        {
            if (animCallbacks != null)
            {
                if (animCallbacks.ContainsKey(animNames[animIndex]))
                {
                    animCallbacks[animNames[animIndex]]();
                    animCallbacks.Remove(animNames[animIndex]);
                }
            }

            Animator animator = child.GetComponent<Animator>();
            animator.Play(animName);
        }
    }

    void PlayPos()
    {
        if (nav.enabled)
        {
            nav.destination = end[index];
        }

        NexPosition();
    }

    void NexPosition()
    {
        if (Vector3.Distance(this.transform.position, end[index]) < 1)
        {
            if (posCallbacks != null)
            {
                if (posCallbacks.ContainsKey(index))
                {
                    posCallbacks[index]();
                    posCallbacks.Remove(index);
                }
            }

            if (delay > 0)
            {
                delay -= Time.deltaTime;
                PlayDelaysAnimator();
                nav.enabled = false;
            }
            else
            {
                nav.enabled = true;
                bool isToEnd;

                if (end.Length > index + 1)
                {
                    isToEnd = false;
                    index++;
                    SetDelay();
                }
                else
                {
                    isToEnd = true;
                }

                PlayNavAnimator();
                SetIsEnd(isToEnd);
            }
        }
    }

    void SetDelay()
    {
        if (delays != null && delays.Length > index)
        {
            delay = delays[index];
        }
    }

    public void AddPosCallbacks(int posIndex, EventCallback0 eventCallback0)
    {
        if (posCallbacks.ContainsKey(posIndex))
        {
            posCallbacks.Remove(posIndex);
        }

        posCallbacks.Add(posIndex, eventCallback0);
    }
}
