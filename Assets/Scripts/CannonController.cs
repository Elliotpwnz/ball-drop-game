using UnityEngine;
using System.Collections;

public class CannonController : MonoBehaviour {

	public float RotationSpeed;
	private Vector3 dir;
	public float ballSpeed;
	public GameObject theCannon;
	public float forwardAngle;
	public int rotator;

	// Use this for initialization
	void Start () {
		theCannon.GetComponent<Renderer>().material.color = Color.red;
		rotator = -1;
	}
	
	// Update is called once per frame
	void Update () {
		//Vector3 targetDir = GameObject.Find ("Forward").transform.position - transform.position;
		//forwardAngle = Vector3.Angle (targetDir, transform.forward);
		//if (forwardAngle > 90) {
		//	rotator = 1;
		//} else {
		//	rotator = -1;
		//}
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		if (moveHorizontal != 0 || moveVertical != 0) {
			Vector3 cannonRotation = new Vector3 (moveVertical * rotator * RotationSpeed * Time.deltaTime, moveHorizontal * RotationSpeed * Time.deltaTime, 0.0f);
			transform.Rotate (cannonRotation);
		}

		//transform.Rotate((Input.GetAxis("Mouse Y") * rotator * RotationSpeed * Time.deltaTime), (Input.GetAxis("Mouse X") * RotationSpeed * Time.deltaTime), 0, Space.World);
		transform.rotation = Quaternion.Euler (transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 0.0f);

		if (Input.GetButtonDown("Fire1")) {
			dir = theCannon.transform.forward;
			GameObject cannonBall = Instantiate (Resources.Load ("Cannonball")) as GameObject;
			cannonBall.GetComponent<Renderer> ().material.color = Color.black;
			Rigidbody rb = cannonBall.GetComponent<Rigidbody> ();
			cannonBall.transform.position = theCannon.transform.position;
			rb.AddForce (dir * ballSpeed);
		}
	}
}
