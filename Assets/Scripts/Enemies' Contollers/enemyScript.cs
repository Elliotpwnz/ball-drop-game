using UnityEngine;
using System.Collections;

public class enemyScript : MonoBehaviour {

	public GameObject HealthBar;
	public GameObject barricade;
	public float enemySpeed;
	private Vector3 firstTransition, secondTransition;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update ()
	{
		float step = enemySpeed * Time.deltaTime;
	
		transform.position = Vector3.MoveTowards(transform.position, barricade.transform.position, step);

		if (HealthBar.GetComponent<HealthBarController>().greenCurrentHealth <= 0) {
			Destroy (gameObject);
		}
	}

	void OnCollisionEnter(Collision coll){
		if (coll.gameObject.tag == "Ball") {
			HealthBar.GetComponent<HealthBarController>().greenCurrentHealth -= 2;
			HealthBar.GetComponent<HealthBarController>().redCurrentHealth += 2;
		}
	}
}