using UnityEngine;
using System.Collections;

public class NecromancerController : MonoBehaviour {

	public float speed;
	private float step;
	private Vector3 backOfftPosition;
	private Vector3 smashPosition;
	// Use this for initialization
	void Start () {
		GetComponent<Renderer> ().material.color = Color.grey;
		step = speed * Time.deltaTime;
		backOfftPosition = transform.position;
		smashPosition = GameObject.Find ("Cannon Rotator").transform.position;
	}

	// Update is called once per frame
	void Update () {
		//transform.position = backOfftPosition;
		backOfftPosition = transform.position;
		transform.position = Vector3.MoveTowards (backOfftPosition, GameObject.Find ("Cannon Rotator").transform.position, step);
	}
}
