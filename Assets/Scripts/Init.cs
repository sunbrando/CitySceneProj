using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Init : MonoBehaviour
{
    void Start()
    {
        #if UNITY_EDITOR
            CtrlModel.isPass = true;
        #else
            CtrlModel.isPass = Util.IsPass();
        #endif
    }
}
