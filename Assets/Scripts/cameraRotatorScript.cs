using UnityEngine;
using System.Collections;

public class cameraRotatorScript : MonoBehaviour {

	public bool startRotating;
	public float rotateSpeed;

	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
		if (startRotating) {
			Vector3 target = new Vector3(0.0f, 350.0f, 90.0f);
			transform.Rotate (0, rotateSpeed * Time.deltaTime, 0);
			print(Mathf.Abs (transform.localEulerAngles.x));
			if (Mathf.Abs (transform.localEulerAngles.x - target.x) < 3 && 
				Mathf.Abs(transform.localEulerAngles.y - target.y) < 3 && 
				Mathf.Abs(transform.localEulerAngles.z - target.z) < 3) {
					startRotating = false;
				transform.localEulerAngles = new Vector3 (0.0f, -12.0f, 90.0f);
			}
		}
	}
}
