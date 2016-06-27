using UnityEngine;
using System.Collections;

public class GameManagerController : MonoBehaviour {
	public GameObject[] enemies;
	private GameObject Archer, Knight, Necromancer, Wizard;
	public bool start;

	// Use this for initialization
	void Start () {
		start = false;
		Archer = enemies [0];
		Knight = enemies [1];
		Necromancer = enemies [2];
		Wizard = enemies [3];

		Instantiate(Archer, new Vector3(72.0f, 1.0f, 160.0f), Quaternion.identity);

	}
	
	// Update is called once per frame
	void Update () {
		int rand = Random.Range(0, 5);


		//WaitForSeconds (5);


	}
}
