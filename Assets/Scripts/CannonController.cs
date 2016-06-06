using UnityEngine;
using System.Collections;

public class CannonController : MonoBehaviour {

	public float RotationSpeed;
	private Vector3 dir;
	public float ballSpeed;
	public GameObject theCannon;
	// Use this for initialization
	void Start () {
		theCannon.GetComponent<Renderer>().material.color = Color.red;
	}
	
	// Update is called once per frame
	void Update () {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		if (moveHorizontal != 0 || moveVertical != 0) {
			Vector3 cannonRotation = new Vector3 (moveVertical * -RotationSpeed * Time.deltaTime, moveHorizontal * RotationSpeed * Time.deltaTime, 0.0f);
			transform.Rotate (cannonRotation);
		}

		transform.Rotate((Input.GetAxis("Mouse Y") * -RotationSpeed * Time.deltaTime), (Input.GetAxis("Mouse X") * RotationSpeed * Time.deltaTime), 0, Space.World);
		transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 0.0f);

		if (Input.GetMouseButtonDown (0)) {
			dir = theCannon.transform.forward;
			GameObject cannonBall = Instantiate (Resources.Load ("Cannonball")) as GameObject;
			cannonBall.GetComponent<Renderer> ().material.color = Color.black;
			Rigidbody rb = cannonBall.GetComponent<Rigidbody> ();
			cannonBall.transform.position = theCannon.transform.position;
			rb.AddForce (dir * ballSpeed);
		}
	}
}
