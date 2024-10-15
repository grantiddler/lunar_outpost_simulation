using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRInteractor : MonoBehaviour
{
    public OVRHand leftHand;
    public GameObject leftRay;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bool isIndexFingerPinching = leftHand.GetFingerIsPinching(OVRHand.HandFinger.Index);
        if (isIndexFingerPinching){
            leftRay.SetActive(true);
            leftRay.transform.eulerAngles = leftHand.PointerPose.eulerAngles;
            leftRay.transform.forward = leftHand.PointerPose.forward;
            // leftRay.transform.position =
            }
        else leftRay.SetActive(false);
    }
}
