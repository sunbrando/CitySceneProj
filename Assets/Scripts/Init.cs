using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Init : MonoBehaviour
{
    IEnumerator Start()
    {
        #if UNITY_EDITOR
            CtrlModel.isPass = true;
            yield return null;
        #else
            yield return StartCoroutine(CheckIsPass.GetRequest());
        #endif

        StartCoroutine(IsPass());
    }

    public IEnumerator IsPass()
    {
        if (!CtrlModel.isPass)
        {
            yield return null;
        }

        UnityEngine.SceneManagement.SceneManager.LoadScene("City");
        yield return null;
    }
}
