using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnSceneClick : MonoBehaviour
{
    public SceneState sceneState;

    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            CheckSceneOnClick();
        }
    }

    public void OnClick()
    {
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
