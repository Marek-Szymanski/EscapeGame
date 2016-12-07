using UnityEngine;
using System.Collections;

public class ZamknijTelefon : MonoBehaviour {
	public GameObject zagadka;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void onClick()
	{
		zagadka.SetActive (false);
	}


}
