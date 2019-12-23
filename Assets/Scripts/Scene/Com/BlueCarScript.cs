using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BlueCarScript : MonoBehaviour
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
        transform.DOLocalMove(new Vector3(-0.023f, 0.14f, -0.144f), 0.3f);
        transform.DOLocalRotate(new Vector3(0, -25.62f, 0), 0.3f);
    }

}
