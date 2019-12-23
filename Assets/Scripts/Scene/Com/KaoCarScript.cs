using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class KaoCarScript : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 startPos;
    Vector3 startLocalEulerAngles;

    void Start()
    {
        startPos = this.transform.localPosition;
        startLocalEulerAngles = this.transform.localEulerAngles;
    }

    public void ResetPos()
    {
        this.transform.localPosition = startPos;
        this.transform.localEulerAngles = startLocalEulerAngles;
    }

    // Update is called once per frame
    public void PlayOpenDoor()
    {
        transform.DOLocalMove(new Vector3(10.4f, 5.96f, -2.16f), 0.3f);
        transform.DOLocalRotate(new Vector3(0, -58, 0), 0.3f);
    }

}
