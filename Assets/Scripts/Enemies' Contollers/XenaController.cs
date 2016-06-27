using UnityEngine;
using System.Collections;

public class XenaController : MonoBehaviour {

	public Animator animator;
	public GameObject HealthBar;
	public GameObject barricade;
	public float enemySpeed;
	bool standingUp, alreadyStarted;
	public bool strikingInvoked;
	public GameObject barricadeHealth;
	public GameObject spawnpoint;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		standingUp = true;
		alreadyStarted = false;
		strikingInvoked = false;
		if (!barricade) {
			barricade = GameObject.Find ("Barricades_001 (9)").gameObject;
		}
		barricadeHealth = GameObject.Find ("BarricadesToStrike1").GetComponent<barricadeController> ().HealthBar.gameObject;

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

			if (standingUp) {
				float step = enemySpeed * Time.deltaTime;
				transform.position = Vector3.MoveTowards(transform.position, barricade.transform.position, step);
			}

			//transform.localEulerAngles = new Vector3 (0, 180, 0);
			//float step = enemySpeed * Time.deltaTime;
			//transform.position = Vector3.MoveTowards(transform.position, barricade.transform.position, step);
		}


		if (HealthBar.GetComponent<HealthBarController>().greenCurrentHealth <= 0) {
			animator.SetBool ("die", true);
			animator.SetBool ("attack", false);
			animator.SetBool ("walk", false);
			if (standingUp) {
				GameObject.Find ("Canvas").GetComponent<canvasController> ().score++;
				Instantiate (Resources.Load ("zena"), GameObject.Find ("Spawnpoint2").gameObject.transform.position, Quaternion.Euler(0,180,0));
			}
			standingUp = false;
			Invoke("death", 3.0f);
			//Destroy (gameObject);
		}
	}

	void OnCollisionEnter(Collision coll){
		if (coll.gameObject.tag == "Ball") {
			HealthBar.GetComponent<HealthBarController>().greenCurrentHealth -= 2;
			HealthBar.GetComponent<HealthBarController>().redCurrentHealth += 2;
		}

		if(coll.gameObject.tag =="Baricade2"){
			print ("Xena starts Striking..!!");
			animator.SetBool ("attack", true);
			animator.SetBool ("run", false);
			animator.SetBool ("walk", true);
			if (!strikingInvoked) {
				InvokeRepeating ("strike", 3.0f, 3.0f);
				strikingInvoked = true;
			}


		}
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

	void death(){
		Destroy (gameObject);
	}
}
