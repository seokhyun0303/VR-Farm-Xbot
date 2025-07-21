
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movetoplayer : MonoBehaviour
{
    GameObject centerEye;
    Vector3 headsetPos;
    void Start()
    {
        centerEye = GameObject.Find("CenterEyeAnchor");
    }

    // Update is called once per frame
    void Update()
    {
        headsetPos = centerEye.transform.position;
        headsetPos[1] = -1.5f;
        transform.LookAt(headsetPos);
        transform.position = Vector3.MoveTowards(gameObject.transform.position, headsetPos, 0.02f);
        if(transform.position == headsetPos)
        {
          Destroy(this.gameObject);
        }


    }
}
