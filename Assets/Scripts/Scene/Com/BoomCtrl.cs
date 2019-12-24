using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomCtrl : MonoBehaviour
{
    void OnEnable()
    {
        Invoke("Hide", 1f);
    }

    void OnDisable()
    {
        CancelInvoke("Hide");
    }

    void Hide()
    {
        gameObject.SetActive(false);
    }
}
