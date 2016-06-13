using UnityEngine;
using System.Collections;

public class canvasController : MonoBehaviour {

	public GameObject remainingBallsText;
	public GameObject cannonRotator;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		remainingBallsText.GetComponent<UnityEngine.UI.Text> ().text = cannonRotator.GetComponent<RotatorController>().remainingBalls.ToString();
	}
}
