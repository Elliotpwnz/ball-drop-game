using UnityEngine;
using System.Collections;

public class ArcherController : MonoBehaviour {

	public Transform arrowSpawn;
	public GameObject Arrow;
	public float enemySpeed;
	private float step;
	private int fireRate = 5;
	float nextFire;
	// Use this for initialization
	void Start () {
		GetComponent<Renderer> ().material.color = Color.green;
		nextFire = Time.time;
	}

	// Update is called once per frame
	void Update ()
	{
		if (Time.time > nextFire) {
			nextFire = Time.time + fireRate;
			Instantiate (Arrow, arrowSpawn.position, arrowSpawn.rotation);

		}
	}
}
