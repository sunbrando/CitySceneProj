using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class FairyTools : AssetPostprocessor
{
    //所有的资源的导入，删除，移动，都会调用此方法，注意，这个方法是static的 
    public static void OnPostprocessAllAssets(string[] importedAsset, string[] deletedAssets, string[] movedAssets, string[] movedFromAssetPaths)
    {
        foreach (string str in importedAsset)
        {
            Debug.Log("importedAsset = " + str);

            if (str.IndexOf(".png") != -1 && str.IndexOf("FGUI") != -1)
            {
                TextureImporter importer = AssetImporter.GetAtPath(str) as TextureImporter;
                if (importer.mipmapEnabled)
                {
                    importer.mipmapEnabled = false;
                    importer.SaveAndReimport();
                }
            }
        }
    }

}
