﻿using UnityEngine;
using System.Collections;

[AddComponentMenu(" Camera Control / Mouse Look")]

public class MouseLook : MonoBehaviour {

	public enum RotationAxes {MouseXandY = 0, MouseX = 1, MouseY = 2};
	public RotationAxes axes = RotationAxes.MouseXandY;

	public float sensitivityX = 15F;
	public float sensitivityY = 15F;
	public float minimumX = -360F;
	public float maximumX = 360F;
	public float minimumY = -60F;
	public float maximumY = 60F;
	float rotationX = 0F;
	float rotationY = 0F;

	Quaternion originalRotation; 


	// Use this for initialization
	void Start () {
		Rigidbody rig = GetComponent<Rigidbody> ();
		if (rig) {
			rig.freezeRotation = true;
		}
		originalRotation = transform.localRotation;
	}
	
	// Update is called once per frame
	void Update () {
		if (axes == RotationAxes.MouseXandY) {
			rotationX += Input.GetAxis ("Mouse X") * sensitivityX;
			rotationY += Input.GetAxis ("Mouse Y") * sensitivityY;

			rotationX = ClampAngle (rotationX, minimumX, maximumX);
			rotationY = ClampAngle (rotationY, minimumY, maximumY);

			Quaternion xQuaternion = Quaternion.AngleAxis (rotationX, Vector3.up);
			Quaternion yQuaternion = Quaternion.AngleAxis (rotationY, Vector3.right);
			transform.localRotation = originalRotation * xQuaternion * yQuaternion;

		} 

		else if (axes == RotationAxes.MouseX) {
			rotationX += Input.GetAxis ("Mouse X") * sensitivityX;
			rotationX += ClampAngle (rotationX, minimumX, maximumX);
			Quaternion xQuaternion = Quaternion.AngleAxis (rotationX, Vector3.up);
			transform.localRotation = originalRotation * xQuaternion;
		} 

		else {
			rotationY += Input.GetAxis ("Mouse Y") * sensitivityY;
			rotationY += ClampAngle (rotationY, minimumY, maximumY);
			Quaternion yQuaternion = Quaternion.AngleAxis (-rotationY, Vector3.right);
			transform.localRotation = originalRotation * yQuaternion;
		}

	}

	public static float ClampAngle (float angle, float min, float max){
		if (angle < -360)
			angle += 360;
		if (angle > 360)
			angle -= 360;
		return Mathf.Clamp (angle, min, max);
	}
}
