using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


[System.Serializable]
public class HandManager 
{
   [SerializeField] public OVRHand leftHand;
   [SerializeField] public OVRHand rightHand;
   
   public enum HandToUse
   {
      leftHand,
      righthand,
   }

   
   [SerializeField] public OVRSkeleton leftHandSkeleton;
   [SerializeField] public OVRSkeleton rightHandSkeleton;

   
   
}
