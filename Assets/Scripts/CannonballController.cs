using UnityEngine;
using System.Collections;

public class CannonballController : MonoBehaviour {
	private Rigidbody rb;
	private Vector3 dir;
	public float ballSpeed;
	// Use this for initialization
	void Start () {
		gameObject.GetComponent<Renderer>().material.color = Color.black;
		rb = gameObject.GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown (0)) {
			dir = GameObject.Find ("Cannon").gameObject.transform.forward;
			rb.AddForce (dir * ballSpeed);
		}
	}
}
