using UnityEngine;
using System.Collections;

public class ZombieController : MonoBehaviour {

	public Animator animator;
	public GameObject HealthBar;
	public GameObject barricade;
	float step;
	public float enemySpeed;
	bool alreadyStarted;
	bool standingUp;
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		alreadyStarted = false;
		standingUp = true;
	}

	// Update is called once per frame
	void Update ()
	{
		if (GameObject.Find ("Game Manager").GetComponent<GameManagerController> ().start){
			if (!alreadyStarted) {
				animator.SetBool ("walk", true);
			}
			alreadyStarted = true;
			//transform.localEulerAngles = new Vector3 (0, 180, 0);
			if(standingUp){
				step = enemySpeed * Time.deltaTime;
				transform.position = Vector3.MoveTowards(transform.position, barricade.transform.position, step);
			}
		}


		if (HealthBar.GetComponent<HealthBarController>().greenCurrentHealth <= 0) {
			GameObject.Find ("Canvas").GetComponent<canvasController> ().score++;
			//Destroy (gameObject);
			animator.SetBool ("backFall", true);
			animator.SetBool ("walk", false);
			animator.SetBool ("attack", false);
			standingUp = false;
		}
	}

	void FixedUpdate(){
	}

	void OnCollisionEnter(Collision coll){
		if (coll.gameObject.tag == "Ball") {
			HealthBar.GetComponent<HealthBarController>().greenCurrentHealth -= 2;
			HealthBar.GetComponent<HealthBarController>().redCurrentHealth += 2;
			//getbackUp ();
		}

		if(coll.gameObject.tag =="Baricade2"){
			print ("Zombie starts Striking..!!");
			animator.SetBool ("walk", false);
			animator.SetBool ("attack", true);
		}
	}

	void getbackUp(){
		standingUp = true;
		animator.SetBool ("backFall", false);
		animator.SetBool ("walk", true);
		step = enemySpeed * Time.deltaTime;
		transform.position = Vector3.MoveTowards(transform.position, barricade.transform.position, step);
	}
}
