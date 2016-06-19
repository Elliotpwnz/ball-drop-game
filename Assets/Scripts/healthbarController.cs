using UnityEngine;
using System.Collections;

public class healthbarController : MonoBehaviour {

	public int currentHealth;
	public int maxHealth;
	public float healthPercent;
	float oldScaleX;

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
		}
		Vector3 modifier = transform.localScale;
		modifier.x = oldScaleX * healthPercent;
		transform.localScale = modifier;

		if (currentHealth <= 0) {
			Destroy (transform.parent.gameObject);
		}
	}
}
