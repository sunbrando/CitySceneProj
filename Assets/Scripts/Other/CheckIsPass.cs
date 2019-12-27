using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CheckIsPass : MonoBehaviour
{
    public static IEnumerator GetRequest()
    {
        string url = @"https://github.com/sunbrando/AigAag/blob/master/Pass.txt";
        using (UnityWebRequest webRequest = UnityWebRequest.Get(url))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] pages = url.Split('/');
            int page = pages.Length - 1;

            if (webRequest.isNetworkError)
            {
                CtrlModel.isPass = false;
                Debug.Log(pages[page] + ": Error: " + webRequest.error);
            }
            else
            {
                CtrlModel.isPass = true;
                Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);
            }
        }
    }
}
