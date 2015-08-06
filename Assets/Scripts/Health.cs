﻿using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	TextMesh health;
	public GameObject explosion;
	public GameObject g;
	private Spawn spawn;
	public int points_value;
	public int cash_value;

	// Use this for initialization
	void Start () {
		GameObject spawn_obj = GameObject.FindWithTag ("Spawn");
		if (spawn_obj != null) {
			spawn = spawn_obj.GetComponent<Spawn> ();
		} 
		else {
			Debug.Log ("Cannot find 'Spawn' script");
		}
		health = GetComponent<TextMesh> ();
	}
	
	// Update is called once per frame
	void Update () {
		transform.forward = Camera.main.transform.forward;
	}

	public int Current() {
		return health.text.Length;
	}

	public void Decrease() {
		if (Current () > 1) {
			health.text = health.text.Remove (health.text.Length - 1);
		} 
		else {
			Instantiate (explosion, g.transform.position, g.transform.rotation);
			Destroy (transform.parent.gameObject);
			if (g.tag == "Monster") {
				spawn.AddPoints (points_value);
				spawn.MakeKash (cash_value);
			}
			else if (g.tag == "Prize") {
				spawn.GameOver();
			}
		}
	}
}