using UnityEngine;
using System.Collections;

public class playerWalk : MonoBehaviour {

	public float speed = 1f; //horizontal acceleration
	public float vertSpeed = 0.5f; // vertical speed relative to horizontal speed

	private Rigidbody2D rigid;
	private SpriteRenderer render;

	// Use this for initialization
	void Awake () {
		rigid = GetComponent<Rigidbody2D> ();
		render = GetComponentInChildren<SpriteRenderer> ();
	}

	//PUT INTO OTHER SCRIPT LATER!!!
	void Start () {
		QualitySettings.antiAliasing = 8;
	}
	
	// Update is called once per frame
	void Update () {
		//set's velocity on the base on inputs
		Vector3 moveDirection = new Vector2 (Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")); // get the 
		moveDirection.Normalize ();
		moveDirection *= speed;
		moveDirection.Scale (new Vector2(1, vertSpeed)); //vertical movement is slower than horizontal
		//rigid.AddForce (moveDirection);	//feels really unintuitive and kina... rubbery ?
		//transform.position += moveDirection * Time.deltaTime;  //stutters when running into colliders
		rigid.velocity = moveDirection;		//WORKS

		//set's the renderlayer of the player
		render.sortingOrder = Mathf.FloorToInt(-transform.position.y);
	}
}
