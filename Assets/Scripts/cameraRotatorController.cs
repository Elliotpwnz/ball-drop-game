using UnityEngine;
using System.Collections;

public class cameraRotatorController : MonoBehaviour {
	public bool startRotating;
	public float rotateSpeed;
	public GameObject cannon;
	public GameObject cameraRotator;
	public GameObject mainCamera;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (startRotating) {
			Vector3 target = new Vector3(0.0f, 356.0f, 90.0f);
			transform.Rotate (0, rotateSpeed * Time.deltaTime, 0);
			print(Mathf.Abs (transform.localEulerAngles.x));
			if (Mathf.Abs (transform.localEulerAngles.x - target.x) < 8 && 
				Mathf.Abs(transform.localEulerAngles.y - target.y) < 8 && 
				Mathf.Abs(transform.localEulerAngles.z - target.z) < 8) {
				startRotating = false;
				transform.localEulerAngles = new Vector3 (0.0f, 356.0f, 90.0f);
				mainCamera.transform.parent = cannon.transform;
				Destroy (gameObject);
			}
		}
	}
}
