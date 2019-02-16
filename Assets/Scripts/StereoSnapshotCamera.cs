using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[AddComponentMenu("Camera-Control/Smooth Mouse Look")]
public class StereoSnapshotCamera : MonoBehaviour
{

    public SnapshotCamera snapCamL;
    public SnapshotCamera snapCamR;

    public void CallTakeSnapshot()
    {
        snapCamL.CallTakeSnapshot();
        snapCamR.CallTakeSnapshot();
    }

}
