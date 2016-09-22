using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelEntryBook : MonoBehaviour {

	public string followUpScene;

	private Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other) {
		anim.SetBool ("open", true);
	}

	void OnTriggerExit2D (Collider2D coll) {
		anim.SetBool ("open", false);
	}

	void OnCollisionEnter2D(Collision2D coll) {
		SceneManager.LoadScene (followUpScene);
	}
}
