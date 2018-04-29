using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	private GameObject charObject;
	private Transform charTransform;
	private Rigidbody rb;

	void Start()
	{
		rb = GetComponent<Rigidbody> ();
		charObject = GameManager.instance.GetCharObject ();
		charTransform = charObject.transform;
	}

	void FixedUpdate()
	{
		transform.position = Vector3.Lerp (transform.position, charTransform.position, 2f * Time.deltaTime);
		float yMax = GameManager.instance.ReturnRowMinusTwoYPosition();
		rb.position = new Vector3(0.0f,Mathf.Clamp(rb.position.y,3.8f,yMax),-10.0f);
	}
}
