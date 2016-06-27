using UnityEngine;
using System.Collections;

public class ArcherController : MonoBehaviour {
	public GameObject HealthBar;
	public Transform arrowSpawn;
	public GameObject Arrow;
	public float enemySpeed;
	private float step;
	private int fireRate = 5;
	float nextFire;
	private Vector3 firstTransition, secondTransition;

	// Use this for initialization
	void Start () {
		
		GetComponent<Renderer> ().material.color = Color.green;
		nextFire = Time.time;
		//firstTransition = new Vector3 (5.0f * Time.deltaTime, 0.0f, 0.0f);
		//secondTransition = new Vector3 (0.0f, 0.0f, 10.0f * Time.deltaTime);
		//setupHealthBars();
	}

	// Update is called once per frame
	void Update ()
	{
		//Archer update
		//transform.Translate (new Vector3(-0.5f, 0.0f, 0.0f));
		//transform.Translate (transform.position + secondTransition);

		if (Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			Instantiate (Arrow, arrowSpawn.position, arrowSpawn.rotation);

		}

		if (HealthBar.GetComponent<HealthBarController>().greenCurrentHealth <= 0) {
			Destroy (gameObject);
		}
	}

	void OnCollisionEnter(Collision coll){
	//	if (coll.gameObject.tag == "Ball") {
			HealthBar.GetComponent<HealthBarController>().greenCurrentHealth -= 2;
			HealthBar.GetComponent<HealthBarController>().redCurrentHealth += 2;
		}
	//}
}
