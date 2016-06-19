using UnityEngine;
using System.Collections;

public class canvasController : MonoBehaviour {

	public GameObject remainingBallsText;
	public GameObject pressEnterText;
	public GameObject cannonRotator;
	public GameObject cannon;
	public GameObject cameraRotator;
	public GameObject mainCamera;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.anyKey) {
			pressEnterText.GetComponent<UnityEngine.UI.Text> ().text = "";
			cameraRotator.GetComponent<cameraRotatorController> ().startRotating = true;
		}


		remainingBallsText.GetComponent<UnityEngine.UI.Text> ().text = cannonRotator.GetComponent<RotatorController>().remainingBalls.ToString();
	}
}
