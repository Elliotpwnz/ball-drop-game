using UnityEngine;
using System.Collections;

public class MonsterController : MonoBehaviour {
	public Animator animator;
	public GameObject HealthBar;
	public GameObject barricade;
	public float enemySpeed;
	bool alreadyStarted, standingUp;
	public bool strikingInvoked;
	public GameObject barricadeHealth;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		alreadyStarted = false;
		standingUp = true;
		strikingInvoked = false;
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
			transform.localEulerAngles = new Vector3 (0, 180, 0);

			alreadyStarted = true;
			if (standingUp) {
				float step = enemySpeed * Time.deltaTime;
				transform.position = Vector3.MoveTowards(transform.position, barricade.transform.position, step);
			}
		}
			

		if (HealthBar.GetComponent<HealthBarController>().greenCurrentHealth <= 0) {
			animator.SetBool ("isHit", true);
			animator.SetBool ("attack2", false);
			animator.SetBool ("die", true);
			GameObject.Find ("Canvas").GetComponent<canvasController> ().score++;
			standingUp = false;
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
			if (!strikingInvoked) {
				InvokeRepeating ("strike", 3.0f, 3.0f);
				strikingInvoked = true;
			}
			animator.SetBool ("run", false);

		}
			
	}

	void strike(){
		barricadeHealth.GetComponent<HealthBarController>().greenCurrentHealth -= 2;
		 barricadeHealth.GetComponent<HealthBarController>().redCurrentHealth += 2;

		if (barricadeHealth.GetComponent<HealthBarController> ().greenCurrentHealth <= 0) {
			UnityEngine.SceneManagement.SceneManager.LoadScene ("gameOver");
		}
	}
}
