using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballFollow : MonoBehaviour {

    public Transform ballTransform;
    public Vector3 cam;

    [Range(0.01f, 1.0f)]
    public float SmoothFactor = 0.15f;
    public bool RotateBall = true;

	void Start () {
        cam = transform.position - ballTransform.position;
        cam.y = 0.4f;
	}
	

	void Update () {

        if(RotateBall)
        {
            Quaternion camTurnAngle = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * 2f, Vector3.up);
            cam = camTurnAngle * cam;
        }


        Vector3 newPos = ballTransform.position + cam;

        transform.position = Vector3.Slerp(transform.position, newPos, SmoothFactor);
	}
}
