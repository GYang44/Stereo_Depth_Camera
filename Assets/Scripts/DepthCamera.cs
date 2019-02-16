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

        snapCam.SetReplacementShader(depthShader, "Opaque");
        Shader.SetGlobalTexture("_GBuffer", snapCam.targetTexture);
        Debug.Log("shader replaced");
       
        width = snapCam.targetTexture.width;
        height = snapCam.targetTexture.height;

        snapCam.gameObject.SetActive(false);
/*
        private void Awake()
        {
            camera.CopyFrom(Camera.main);

            var target = new RenderTexture(Screen.width, Screen.height, 16, RenderTextureFormat.Depth);
            camera.targetTexture = target;
            camera.depthTextureMode = DepthTextureMode.None;

            camera.SetReplacementShader(Shader.Find("Hidden/Camera-CustomDepthTexture"), "RenderType");
            Shader.SetGlobalTexture("_GBuffer", target);
        }
        */
    }
    // Update is called once per frame
 
}
