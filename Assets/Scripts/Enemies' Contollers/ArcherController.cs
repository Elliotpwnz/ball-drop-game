using UnityEngine;
using System.Collections;

public class ArcherController : MonoBehaviour {

	public GameObject GreenHealthBar;
	public Transform arrowSpawn;
	public GameObject Arrow;
	public float enemySpeed;
	private float step;
	private int fireRate = 5;
	float nextFire;

	public bool gotShot;

	// Use this for initialization
	void Start () {
		GetComponent<Renderer> ().material.color = Color.green;
		nextFire = Time.time;
	}

	// Update is called once per frame
	void Update ()
	{
		gotShot = false;
		if (Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			Instantiate (Arrow, arrowSpawn.position, arrowSpawn.rotation);

		}

		if (GreenHealthBar.GetComponent<GreenHealthBarController> ().currentHealth <= 0) {
			Destroy (gameObject);
		}
	}

	void OnCollisionEnter(Collision coll){
		if (coll.gameObject.tag == "Ball") {
			gotShot = true;
		}
	}
}
