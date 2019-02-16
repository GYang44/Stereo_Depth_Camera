using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[AddComponentMenu("Camera-Control/Smooth Mouse Look")]
[RequireComponent(typeof(Camera))]
public class SnapshotCamera : MonoBehaviour
{

    protected Camera snapCam;
    public int width = 1920;
    public int height = 1080;

    // Start is called before the first frame update
    void Awake()
    {
        snapCam = GetComponent<Camera>();
        if (snapCam.targetTexture == null)
        {
            snapCam.targetTexture = new RenderTexture(width, height, 24);
        }
        else
        {
            width = snapCam.targetTexture.width;
            height = snapCam.targetTexture.height;
        }
        snapCam.gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CallTakeSnapshot();
        }
    }

    public void CallTakeSnapshot()
    {
        snapCam.gameObject.SetActive(true);
    }

    void LateUpdate()
    {
        if (snapCam.gameObject.activeInHierarchy)
        {
            Texture2D snapshot = new Texture2D(width, height, TextureFormat.RGB24, false);
            snapCam.Render();
            RenderTexture.active = snapCam.targetTexture;
            snapshot.ReadPixels(new Rect(0, 0, width, height), 0, 0);
            System.IO.File.WriteAllBytes(SnapshotName(), snapshot.EncodeToPNG());
            Debug.Log("Snapshot taken!");
            snapCam.gameObject.SetActive(false);
        }
    }

    string SnapshotName()
    {
        return string.Format("{0}/Snapshots/snap_{4}_{1}x{2}_{3}.png", Application.dataPath, width, height, System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"), this.name);
    }
}
