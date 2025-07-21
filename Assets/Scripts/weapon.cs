using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
#if USING_XR_SDK
    using UnityEngine.XR;
#endif

public class weapon : MonoBehaviour
{
    //public HandState handState;
    //public HandEnum handEnum;
    Pose startPose, endPose;
    float curtime;

    void Start()
    {
        
        //handState = NRInput.Hands.GetHandState(handEnum);
        //startPose = handState.GetJointPose(HandJointID.IndexProximal);
        //endPose = handState.GetJointPose(HandJointID.IndexTip);
        transform.position = startPose.position;
        transform.LookAt(endPose.position);
        curtime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        curtime += Time.deltaTime;
        if (curtime > 5)
        {
            Destroy(this.gameObject);
        }
        transform.Translate(Vector3.forward * 0.2f);
    }


}
