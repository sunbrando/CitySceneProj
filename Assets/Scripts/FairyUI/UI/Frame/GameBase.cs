using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FairyGUI;

public class GameBase {

    UIPackage uiPackage;
    public GComponent com;

    public GameBase() { }

    public GameBase(string packageName, string comName)
    {
        CreateFGUI(packageName, comName);
    }

    public void CreateFGUI(string packageName, string comName)
    {
        uiPackage = UIPackage.AddPackage("FGUI/" + packageName);
        com = uiPackage.CreateObject(comName).asCom;
        com.width = Screen.width;
        com.height = Screen.height;

        GRoot.inst.AddChild(com);
        com.Center();
    }

    public void Dispose()
    {
        com.Dispose();
    }
}
