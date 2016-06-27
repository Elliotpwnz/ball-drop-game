using UnityEngine;
using System.Collections;

public class endgameController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.anyKey) {
			UnityEngine.SceneManagement.SceneManager.LoadScene ("mainScene");
		}
	}
}
