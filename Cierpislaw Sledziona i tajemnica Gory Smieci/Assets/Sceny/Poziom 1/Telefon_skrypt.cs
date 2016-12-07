using UnityEngine;
using System.Collections;

public class Telefon_skrypt : MonoBehaviour {
	public GameObject zagadkaTelefon;
	// Use this for initialization
	void Start () {
		zagadkaTelefon.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton (0)) {
			Vector3 pos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			RaycastHit2D hitInfo = Physics2D.Raycast (pos, Vector2.zero);
			if (hitInfo != null && hitInfo.collider != null) {
				zagadkaTelefon.SetActive (true);

			} else {
				Debug.Log ("NIE");
			}
		}
	}


}
