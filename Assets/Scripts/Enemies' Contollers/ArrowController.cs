using UnityEngine;
using System.Collections;

public class ArrowController : MonoBehaviour {

	public float thrust;
	private Transform archer;
	private Rigidbody ballRigidBody;
	// Use this for initialization
	void Start () {
		archer = GameObject.Find ("Archer").transform;
		gameObject.GetComponent<Renderer> ().material.color = Color.red;
		ballRigidBody = gameObject.GetComponent<Rigidbody> ();
		Vector3 aimingDirection = - archer.forward;
		ballRigidBody.AddForce (aimingDirection * thrust);
	}

	void FixedUpdate(){
		//transform.rotation = Quaternion.Euler (transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 0.0f);
		//ballRigidBody.AddForce (speed);
		//transform.Rotate((Input.GetAxis("Mouse Y") * rotator * RotationSpeed * Time.deltaTime), (Input.GetAxis("Mouse X") * RotationSpeed * Time.deltaTime), 0, Space.World);
		//transform.rotation = Quaternion.Euler (transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 0.0f);
	}
}
