using UnityEngine;
using System.Collections;

public class zmienScene : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		//Button b = gameObject.GetComponent<infoPrzycisk> ();
		//b.onClick.AddListener (delegate () 
		//{
				Debug.Log("123");
		//});

	}


	
	// Update is called once per frame
	void Update () 
	{
		
	}

	public void nowaScena(string nazwa)
	{
		Application.LoadLevel (nazwa);
	}

}
