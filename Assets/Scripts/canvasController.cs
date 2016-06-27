using UnityEngine;
using System.Collections;

public class canvasController : MonoBehaviour {

	public GameObject remainingBallsText;
	public GameObject pressEnterText;
	public GameObject cannonRotator;
	public GameObject cannon;
	public GameObject cameraRotator;
	public GameObject mainCamera;
	public GameObject scoreText;
	private bool gameStarted;
	public int score;

	// Use this for initialization
	void Start () {
		gameStarted = false;
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.anyKey && !gameStarted) {
			gameStarted = true;
			pressEnterText.GetComponent<UnityEngine.UI.Text> ().text = "";
			cameraRotator.GetComponent<cameraRotatorController> ().startRotating = true;
		}

		scoreText.GetComponent<UnityEngine.UI.Text> ().text = "Score:" + score;
		remainingBallsText.GetComponent<UnityEngine.UI.Text> ().text = cannonRotator.GetComponent<RotatorController>().remainingBalls.ToString();
	}
}
