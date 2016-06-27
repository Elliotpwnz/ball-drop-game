using UnityEngine;
using System.Collections;

public class MonsterController : MonoBehaviour {
	public Animator animator;
	public GameObject HealthBar;
	public GameObject barricade;
	public float enemySpeed;
	bool alreadyStarted;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		alreadyStarted = false;
	}

	// Update is called once per frame
	void Update ()
	{
		if (GameObject.Find ("Game Manager").GetComponent<GameManagerController> ().start){
			if (!alreadyStarted) {
				animator.SetBool ("run", true);
				animator.SetBool ("idle", false);
			}
			alreadyStarted = true;
			transform.localEulerAngles = new Vector3 (0, 180, 0);
			float step = enemySpeed * Time.deltaTime;
			transform.position = Vector3.MoveTowards(transform.position, barricade.transform.position, step);
		}


		if (HealthBar.GetComponent<HealthBarController>().greenCurrentHealth <= 0) {
			GameObject.Find ("Canvas").GetComponent<canvasController> ().score++;
			Destroy (gameObject);
		}
	}

	void OnCollisionEnter(Collision coll){
		if (coll.gameObject.tag == "Ball") {
			HealthBar.GetComponent<HealthBarController>().greenCurrentHealth -= 2;
			HealthBar.GetComponent<HealthBarController>().redCurrentHealth += 2;
		}

		if(coll.gameObject.tag =="Baricade2"){
			print ("Monster starts Striking..!!");
			animator.SetBool ("attack2", true);
		}
	}
}
