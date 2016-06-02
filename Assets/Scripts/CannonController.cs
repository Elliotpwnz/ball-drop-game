using UnityEngine;
using System.Collections;

public class CannonController : MonoBehaviour {

	public float RotationSpeed;
	private Vector3 dir;
	public float ballSpeed;
	// Use this for initialization
	void Start () {
		gameObject.GetComponent<Renderer>().material.color = Color.red;
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate((Input.GetAxis("Mouse Y") * -RotationSpeed * Time.deltaTime), (Input.GetAxis("Mouse X") * RotationSpeed * Time.deltaTime), 0, Space.World);
	
		if (Input.GetMouseButtonDown (0)) {
			dir = transform.forward;
			GameObject cannonBall = Instantiate (Resources.Load ("Cannonball")) as GameObject;
			Rigidbody rb = cannonBall.GetComponent<Rigidbody> ();
			cannonBall.transform.position = transform.position;
			rb.AddForce (dir * ballSpeed);
		}
	}
}
