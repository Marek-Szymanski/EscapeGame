using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Poziom1 : MonoBehaviour {
	public GameObject telefon;
	public GameObject notatki;

	public Text licznikCzasuStr;
	public Text licznikPunktowStr;

	private bool telefonBool;
	private bool notatiBool;


	private float licznikCzasu;
	private int punkty;
	// Use this for initialization
	void Start () {
		telefonBool = true;
		notatiBool = true;

		licznikCzasu = 300.0f;
		punkty = 0;

		licznikCzasuStr.text = "Pozostały czas: 300";
		licznikPunktowStr.text = "Punkty: 0";
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton (0)) {
			Vector3 pos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			RaycastHit2D hitInfo = Physics2D.Raycast (pos, Vector2.zero);
			if (hitInfo != null && hitInfo.collider != null) 
			{
				if (hitInfo.collider.name == "Gabinet Szefa_telefon" && telefonBool) 
				{
					telefonBool = false;
					Debug.Log ("A");
					punkty += 1;
					licznikPunktowStr.text = "Punkty: " + punkty;
				}
				else if (hitInfo.collider.name == "Gabinet Szefa_papiery" && notatiBool) 
				{
					notatiBool = false;
					Debug.Log ("B");
					punkty += 1;
					licznikPunktowStr.text = "Punkty: " + punkty;
				}

			} else {
				if(licznikCzasu-1 > 0)
					licznikCzasu -= 1;
				else
					Application.LoadLevel ("Menu");
				if (licznikCzasu <= 150)
					licznikCzasuStr.color = Color.yellow;
				if (licznikCzasu <= 50)
					licznikCzasuStr.color = Color.red;
				licznikCzasuStr.text = "Pozostały czas: " + licznikCzasu;
			}
		}
	}
}
