﻿using UnityEngine;
using System.Collections;

public class MonsterController : MonoBehaviour {
	public Animator animator;
	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		animator.SetBool ("walk", true);
		animator.SetBool ("run", true);
	}
}