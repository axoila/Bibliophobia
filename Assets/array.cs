using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class array : MonoBehaviour
{

	public GameObject repeatedPreFab;
	public Vector2 repeat = Vector2.one;
	public Vector2 offset = Vector2.zero;
	// Use this for initialization
	void Start ()
	{
		//Debug.Log (System.Environment.UserName); <- get's username, works on linux & windows!!
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (!Application.isPlaying) { // only in editor
			//delete all children
			for(int i = transform.childCount-1; i >= 0;i--) {
				DestroyImmediate(transform.GetChild(i).gameObject);
			}

			//make new children at correct positions
			for (int i = 0; i < repeat.x; i++) {
				for (int j = 0; j< repeat.y; j++) {
					GameObject tmpObject = Instantiate(repeatedPreFab);
					tmpObject.transform.SetParent(transform);
					tmpObject.transform.localPosition = new Vector3(i, j, 0) + (Vector3)offset;
					tmpObject.GetComponent<SpriteRenderer> ().sortingOrder = Mathf.FloorToInt(-transform.position.y);
				}
			}
		}
	}
}