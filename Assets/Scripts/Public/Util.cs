using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Util 
{
    public static bool PosIsEqual(Vector3 pos1, Vector3 pos2)
    {
        if ((int)(pos1.x) == (int)(pos2.x) && (int)(pos1.y) == (int)(pos2.y) && (int)(pos1.z) == (int)(pos2.z))
        {
            return true;
        }
        return false;
    }
}
