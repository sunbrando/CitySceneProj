using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneNoneModel : SceneModel
{
    public SceneNoneModel() : base()
    {
        endCamPos = Main.defaultCamPos;
        endCamEulerAngles = Main.defaultCamEulerAngles;

        //CtrlModel.isGodView = true;
    }
}
