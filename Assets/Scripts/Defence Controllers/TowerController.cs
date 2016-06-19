using UnityEngine;
using System.Collections;

public class TowerController : MonoBehaviour {

	public float rotationSpeed;
	public GameObject cannonBall;
	public Transform ballSpawn;
	public int rotator;
	public int maxBalls;
	public int remainingBalls;

	// Use this for initialization
	void Start () {
		rotator = -1;
		remainingBalls = maxBalls;
		InvokeRepeating ("refreshBalls", 3, 3); //Runs the refreshBalls() function every 3 seconds
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
			Vector3 cannonRotation = new Vector3 (moveVertical * rotator * rotationSpeed * Time.deltaTime, moveHorizontal * rotationSpeed * Time.deltaTime, 0.0f);
			transform.Rotate (cannonRotation);
		}

		//transform.Rotate((Input.GetAxis("Mouse Y") * rotator * RotationSpeed * Time.deltaTime), (Input.GetAxis("Mouse X") * RotationSpeed * Time.deltaTime), 0, Space.World);
		transform.rotation = Quaternion.Euler (transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 0.0f);

		if (Input.GetButtonDown ("Fire1") && remainingBalls > 0) {
			Instantiate (cannonBall, ballSpawn.position, ballSpawn.rotation);
			remainingBalls--;
		}
	}

	void refreshBalls(){
		if (remainingBalls < maxBalls) {
			remainingBalls++;
		}

}
}
