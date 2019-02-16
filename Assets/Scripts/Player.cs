using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public StereoSnapshotCamera stereoSnapCam;
    public DepthCamera depthCam;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            stereoSnapCam.CallTakeSnapshot();
            depthCam.CallTakeSnapshot();
        }
    }
}
