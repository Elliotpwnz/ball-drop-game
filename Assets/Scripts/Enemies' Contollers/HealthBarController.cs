using UnityEngine;
using System.Collections;

public class HealthBarController : MonoBehaviour {

	//HealthBar control variables
	public GameObject GreenHealthBar, RedHealthBar;
	public int greenMaxHealth, redMaxHealth;
	public int greenCurrentHealth, redCurrentHealth;
	public float greenHealthPercent, redHealthPercent;
	public float greenOldScaleX, redOldScaleX;
	public Vector3 greenCurrentScale, redCurrentScale;
	public float greenNewScaleX, redNewScaleX;
	public Vector3 redPosition;

	// Use this for initialization
	void Start () {
		//GreenHealthBar set up
		GreenHealthBar.GetComponent<Renderer> ().material.color = Color.green;
		greenCurrentHealth = greenMaxHealth;
		greenOldScaleX = GreenHealthBar.transform.localScale.x;

		//RedHealthBar set up
		RedHealthBar.GetComponent<Renderer> ().material.color = Color.red;
		redPosition = new Vector3((GreenHealthBar.transform.position.x + GreenHealthBar.transform.lossyScale.x / 2), GreenHealthBar.transform.position.y, GreenHealthBar.transform.position.z);
		RedHealthBar.transform.position = redPosition;
		redCurrentHealth = 0;
		redOldScaleX = GreenHealthBar.transform.localScale.x;
	}
	
	// Update is called once per frame
	void Update () {
		if (greenMaxHealth != 0) {

			//GreenHealthBar Update
			greenHealthPercent = ((greenCurrentHealth * 1.0f) / (greenMaxHealth * 1.0f))*100; //Make sure float
			greenCurrentScale = GreenHealthBar.transform.localScale;
			greenNewScaleX = greenOldScaleX * greenHealthPercent/100;

			GreenHealthBar.transform.localScale = new Vector3(greenNewScaleX, greenCurrentScale.y, greenCurrentScale.z);
			GreenHealthBar.transform.Translate((greenNewScaleX - greenCurrentScale.x)/2, 0, 0);

			//RedHealthBar Update
			redHealthPercent = ((redCurrentHealth * 1.0f) / (redMaxHealth * 1.0f))*100; //Make sure float
			redCurrentScale = RedHealthBar.transform.localScale;
			redNewScaleX = redOldScaleX * redHealthPercent/100;

			RedHealthBar.transform.localScale = new Vector3(redNewScaleX, redCurrentScale.y, redCurrentScale.z);
			RedHealthBar.transform.Translate((redCurrentScale.x - redNewScaleX)/2, 0, 0);
		}
	}
}
