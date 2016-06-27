using UnityEngine;
using System.Collections;

public class MonsterController : MonoBehaviour {
	public Animator animator;
	public GameObject HealthBar;
	public GameObject barricade;
	public float enemySpeed;
	public bool animateMonster;
	public bool followTheMonster;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		animateMonster = false;
		followTheMonster = false;
	}

	// Update is called once per frame
	void Update ()
	{
		if (animateMonster) {
			followTheMonster = true;
			animator.SetBool ("run", true);
			transform.localEulerAngles = new Vector3 (0, 180, 0);
			float step = enemySpeed * Time.deltaTime;
			transform.position = Vector3.MoveTowards(transform.position, barricade.transform.position, step);
		}


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
