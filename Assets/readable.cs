using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class readable : MonoBehaviour {

	public string page1 = "Lorem Ipsum";
	public string page2 = "";

	public bool close = false;
	public bool bookOpen = false;

	public GameObject interactTextUI;
	public GameObject bookUI;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (close && Input.GetButtonDown ("Interact")) {
			if (bookOpen) {
				bookUI.SetActive (false);
				bookOpen = false;
			} else {
				bookUI.SetActive (true);
				bookUI.transform.GetChild(0).GetComponent<Text> ().text = "\n" + page1;
				bookUI.transform.GetChild(1).GetComponent<Text> ().text = "\n" + page2;
				bookOpen = true;
			}
		}
	}


	void OnTriggerEnter2D(Collider2D other) {
		//Debug.Log ("player entered trigger");
		close = true;
		interactTextUI.SetActive (true);
	}

	void OnTriggerExit2D (Collider2D coll) {
		close = false;
		interactTextUI.SetActive (false);

		bookUI.SetActive (false);
		bookOpen = false;
	}
}
