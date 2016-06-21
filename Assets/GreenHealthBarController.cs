using UnityEngine;
using System.Collections;

public class GreenHealthBarController : MonoBehaviour {

	public GameObject ConcernedObject;

	public int currentHealth;
	public int maxHealth;
	public float healthPercent;
	public float oldScaleX;
	public Vector3 currentScale;
	public float newScaleX;

	// Use this for initialization
	void Start () {
		gameObject.GetComponent<Renderer> ().material.color = Color.green;
		currentHealth = maxHealth;
		oldScaleX = transform.localScale.x;


	}

	// Update is called once per frame
	void Update () {
		if (maxHealth != 0) {
			healthPercent = (currentHealth * 1.0f) / (maxHealth * 1.0f); //Make sure float
			currentScale = transform.localScale;
			newScaleX = oldScaleX * healthPercent;

			transform.localScale = new Vector3(newScaleX, currentScale.y, currentScale.z);
			transform.Translate((newScaleX - currentScale.x)/2, 0, 0);

		}

		if (ConcernedObject.GetComponent<ArcherController> ().gotShot) {
			currentHealth -= 2;
		}
	}
}
