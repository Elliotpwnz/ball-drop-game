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
	public bool strikingInvoked;
	public GameObject barricadeHealth;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		alreadyStarted = false;
		standingUp = true;
		strikingInvoked = false;
		barricadeHealth = GameObject.Find ("BarricadesToStrike1").GetComponent<barricadeController> ().HealthBar.gameObject;
		if (!barricade) {
			barricade = GameObject.Find ("Barricades_001 (1)").gameObject;
		}
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
			//Destroy (gameObject);
			animator.SetBool ("backFall", true);
			animator.SetBool ("walk", false);
			animator.SetBool ("attack", false);
			if (standingUp) {
				GameObject.Find ("Canvas").GetComponent<canvasController> ().score++;

				Instantiate (Resources.Load ("zombie"), GameObject.Find ("Spawnpoint1").gameObject.transform.position, Quaternion.Euler(0,180,0));
			}
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
			if (!strikingInvoked) {
				InvokeRepeating ("strike", 3.0f, 3.0f);
				strikingInvoked = true;
			}
		}
	}

	void getbackUp(){
		standingUp = true;
		animator.SetBool ("backFall", false);
		animator.SetBool ("walk", true);
		step = enemySpeed * Time.deltaTime;
		transform.position = Vector3.MoveTowards(transform.position, barricade.transform.position, step);
	}

	void strike(){
		if (standingUp) {
			barricadeHealth.GetComponent<HealthBarController> ().greenCurrentHealth -= 2;
			barricadeHealth.GetComponent<HealthBarController> ().redCurrentHealth += 2;

			if (barricadeHealth.GetComponent<HealthBarController> ().greenCurrentHealth <= 0) {
				UnityEngine.SceneManagement.SceneManager.LoadScene ("gameOver");
			}
		}
	}
}
