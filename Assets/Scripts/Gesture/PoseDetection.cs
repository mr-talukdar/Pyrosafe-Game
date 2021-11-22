using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class PoseDetection : MonoBehaviour
{
    public HandManager handManager;
    public OVRSkeleton.BoneId finger;
    public float minPinchDown;
    public float maxPinchreleased;

    private OVRSkeleton handSkeleton;
    public bool pinch;

    public TMP_Text logDebugger;

    public UnityEvent onPinchPoseEvents;
    public UnityEvent onPinchReleaseEvents;


    private OVRBone _thumbTip;
    private OVRBone _finger;
    public void HandleGesture( )
    {

        

        if (_thumbTip != null && _finger != null)
        {
            float diff = Vector3.Distance(_thumbTip.Transform.position, _finger.Transform.position);
            if ( diff<= minPinchDown && !pinch)
            {
                pinch = true;
                LogDebugger("diff : "+diff);
                onPinchPoseEvents.Invoke();
                
            }
            else if (diff >= maxPinchreleased )
            {
                pinch = false;
                logDebugger.text = "Not Pinching";
                onPinchReleaseEvents.Invoke();
                LogDebugger("diff : "+diff);
            }
           
        }
        
    }

    private void Start()
    {
        handSkeleton =  handManager.rightHandSkeleton; 
        if (handManager.leftHand == null && handManager.rightHand == null)
        {
            Debug.Log("Hands Not associated");
            LogDebugger("Hands not associated");
            return;
        }

        _thumbTip = handSkeleton.Bones.SingleOrDefault(b => b.Id == OVRSkeleton.BoneId.Hand_MiddleTip);
        _finger = handSkeleton.Bones.SingleOrDefault(b => b.Id == finger);
      
    }

    private void Update()
    {
       HandleGesture();
    }

    public void LogDebugger(String message)
    {
        logDebugger.text = message;
    }
}
