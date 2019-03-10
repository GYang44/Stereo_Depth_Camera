using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[AddComponentMenu("Camera-Control/Smooth Mouse Look")]
public class SmoothMouseLook : MonoBehaviour {
 
	public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
	public RotationAxes axes = RotationAxes.MouseXAndY;
	public float sensitivityX = 15F;
	public float sensitivityY = 15F;
 
	public float minimumX = -360F;
	public float maximumX = 360F;
 
	public float minimumY = -60F;
	public float maximumY = 60F;
 
	float rotationX = 0F;
	float rotationY = 0F;
 
	private List<float> rotArrayX = new List<float>();
	float rotAverageX = 0F;	
 
	private List<float> rotArrayY = new List<float>();
	float rotAverageY = 0F;
 
	public float frameCounter = 20;

    public float moveSpeed = 20F;
 
	Quaternion originalRotation;
 
	void Update ()
	{
        if (axes == RotationAxes.MouseXAndY)
		{			
			rotAverageY = 0f;
			rotAverageX = 0f;
 
			rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
			rotationX += Input.GetAxis("Mouse X") * sensitivityX;
 
			rotArrayY.Add(rotationY);
			rotArrayX.Add(rotationX);
 
			if (rotArrayY.Count >= frameCounter) {
				rotArrayY.RemoveAt(0);
			}
			if (rotArrayX.Count >= frameCounter) {
				rotArrayX.RemoveAt(0);
			}
 
			for(int j = 0; j < rotArrayY.Count; j++) {
				rotAverageY += rotArrayY[j];
			}
			for(int i = 0; i < rotArrayX.Count; i++) {
				rotAverageX += rotArrayX[i];
			}
 
			rotAverageY /= rotArrayY.Count;
			rotAverageX /= rotArrayX.Count;
 
			rotAverageY = ClampAngle (rotAverageY, minimumY, maximumY);
			rotAverageX = ClampAngle (rotAverageX, minimumX, maximumX);
 
			Quaternion yQuaternion = Quaternion.AngleAxis (rotAverageY, Vector3.left);
             
			transform.localRotation = originalRotation * yQuaternion;
            transform.RotateAround(transform.position, Vector3.up, rotAverageX);
		}
		

        Vector3 pos = transform.position;

        if (Input.GetKey("w"))
        {
            pos += transform.TransformDirection(Vector3.forward * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey("s"))
        {
            pos += transform.TransformDirection(Vector3.back * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey("d"))
        {
            pos += transform.TransformDirection(Vector3.right * moveSpeed * Time.deltaTime);
        }
        if (Input.GetKey("a"))
        {
            pos += transform.TransformDirection(Vector3.left * moveSpeed * Time.deltaTime);
        }


        transform.position = pos;

    }
 
	void Start ()
	{		
        Rigidbody rb = GetComponent<Rigidbody>();	
		if (rb)
			rb.freezeRotation = true;
		originalRotation = transform.localRotation;
	}
 
	public static float ClampAngle (float angle, float min, float max)
	{
		angle = angle % 360;
		if ((angle >= -360F) && (angle <= 360F)) {
			if (angle < -360F) {
				angle += 360F;
			}
			if (angle > 360F) {
				angle -= 360F;
			}			
		}
		return Mathf.Clamp (angle, min, max);
	}
}