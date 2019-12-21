using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class OnSceneClick : MonoBehaviour
{
    public SceneState sceneState;

    Tween tweenMove;
    Tween tweenRotate;

    void Start()
    {
        tweenMove = transform.DOMoveY(transform.localPosition.y + 10, 0.5f);
        tweenMove.Pause();
        tweenMove.SetLoops(-1, LoopType.Yoyo);

        tweenRotate = transform.DORotate(new Vector3(0, 180, 0), 0.5f);
        tweenRotate.Pause();
        tweenRotate.SetLoops(-1, LoopType.Yoyo);
    }

    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            CheckSceneOnClick();
        }

        if (CtrlModel.sceneState == sceneState)
        {
            if (!tweenMove.IsPlaying())
            {
                tweenMove.Play();
                tweenRotate.Play();
            }
        }
        else
        {
            if (tweenMove.IsPlaying())
            {
                tweenMove.Pause();
                tweenRotate.Pause();
            }
        }
    }

    public void OnClick()
    {
        CtrlModel.isGodView = false;
        CtrlModel.SwicthState(sceneState);
    }

    void CheckSceneOnClick()
    {
        RaycastHit hit;
        Vector2 screenPosition = Input.mousePosition;
        var ray = Camera.main.ScreenPointToRay(screenPosition);
        if (Physics.Raycast(ray, out hit) && hit.transform == transform)
        {
            OnClick();
        }
    }
}
