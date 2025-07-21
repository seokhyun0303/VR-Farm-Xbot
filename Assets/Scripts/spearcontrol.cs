using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.VisualScripting;
#if USING_XR_SDK
    using UnityEngine.XR;
#endif

public class spearcontrol : MonoBehaviour
{
    public GameObject weapon;
    OVRSkeleton skeleton;
    //public HandState handState;
    //public HandEnum handEnum;
    float currTime;

    void Start()
    {
        weapon = Resources.Load("weapon") as GameObject;
        currTime = 0;
        skeleton = GetComponent<OVRSkeleton>();
    }

    // Update is called once per frame
    void Update()
    {
        
        //handState = NRInput.Hands.GetHandState(handEnum);
        currTime += Time.deltaTime;

        //if (handState.currentGesture == HandGesture.Point)
        {
            if (currTime > 0.5)
            {
                //Instantiate(weapon);
                currTime = 0;
            }
        }

    }

}


