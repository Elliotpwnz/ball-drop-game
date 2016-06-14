using UnityEngine;
using System.Collections;

public class WizardController : MonoBehaviour {

	public float enemySpeed;
	private float step;
	// Use this for initialization
	void Start () {
		GetComponent<Renderer> ().material.color = Color.blue;
		step = enemySpeed * Time.deltaTime;
	}

	// Update is called once per frame
	void Update () {
		//transform.position = Vector3.MoveTowards (transform.position, GameObject.Find ("CannonController").transform.position, step);
	}
}
