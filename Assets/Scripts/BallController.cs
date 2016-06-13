using UnityEngine;
using System.Collections;

public class BallController : MonoBehaviour {

	public float thrust;
	private Transform cannonRotator;
	private Rigidbody ballRigidBody;
	// Use this for initialization
	void Start () {
		cannonRotator = GameObject.Find ("Cannon Rotator").transform;
		gameObject.GetComponent<Renderer> ().material.color = Color.black;
		ballRigidBody = gameObject.GetComponent<Rigidbody> ();
		Vector3 aimingDirection = cannonRotator.forward;
		ballRigidBody.AddForce (aimingDirection * thrust);
	}

	void FixedUpdate(){
		//transform.rotation = Quaternion.Euler (transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 0.0f);
		//ballRigidBody.AddForce (speed);
		//transform.Rotate((Input.GetAxis("Mouse Y") * rotator * RotationSpeed * Time.deltaTime), (Input.GetAxis("Mouse X") * RotationSpeed * Time.deltaTime), 0, Space.World);
		//transform.rotation = Quaternion.Euler (transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 0.0f);
	}
}
