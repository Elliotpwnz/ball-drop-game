using UnityEngine;
using System.Collections;

public class RedHealthBarController : MonoBehaviour {
	public GameObject HolderObject, GreenHealthBar;
	public int currentHealth;
	public int maxHealth;
	public float healthPercent;
	public float oldScaleX;
	public Vector3 currentScale;
	public float newScaleX;
	public Vector3 position;

	// Use this for initialization
	void Start () {
		gameObject.GetComponent<Renderer> ().material.color = Color.red;
		position = new Vector3((GreenHealthBar.transform.position.x + GreenHealthBar.transform.localScale.x / 2), GreenHealthBar.transform.position.y, GreenHealthBar.transform.position.z);
		gameObject.transform.position = position;
		currentHealth = 0;
		oldScaleX = GreenHealthBar.transform.localScale.x;
	}

	// Update is called once per frame
	void Update () {
			healthPercent = (currentHealth * 1.0f) / (maxHealth * 1.0f); //Make sure float
			currentScale = transform.localScale;
			newScaleX = oldScaleX * healthPercent;

			transform.localScale = new Vector3(newScaleX, currentScale.y, currentScale.z);
			transform.Translate((currentScale.x - newScaleX)/2, 0, 0);

		if (HolderObject.GetComponent<ArcherController> ().gotShot) {
			currentHealth += 2;
		}
	}
}