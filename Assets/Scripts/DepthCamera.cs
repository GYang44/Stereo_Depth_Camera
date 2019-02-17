using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[AddComponentMenu("Camera-Control/Smooth Mouse Look")]
[RequireComponent(typeof(Camera))]
public class DepthCamera : SnapshotCamera
{
    public Shader depthShader;

    // Start is called before the first frame update
    void Awake()
    {
        snapCam = GetComponent<Camera>();

        snapCam.SetReplacementShader(depthShader, "");
        Shader.SetGlobalTexture("_GBuffer", snapCam.targetTexture);
        Debug.Log("shader replaced");
       
        width = snapCam.targetTexture.width;
        height = snapCam.targetTexture.height;

        snapCam.gameObject.SetActive(false);

    }
    // Update is called once per frame
 
}
