using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

struct ZagadkaStr
{
	public string tresc;
	public string prawidlowaOdpowiedz;
	public string odpowiedzA;
	public string odpowiedzB;
	public string odpowiedzC;
	public string odpowiedzD;
}

public class Poziom1 : MonoBehaviour 
{
	//obiekty pokoju
	public GameObject telefon;
	public GameObject notatki;

	//liczniki
	public Text licznikCzasuStr;
	public Text licznikPunktowStr;

	//Zagadka
	public Text trescZagadki; //treść
	public Button odpowiedzA; //odpowiedzi
	public Button odpowiedzB;
	public Button odpowiedzC;
	public Button odpowiedzD;
	public GameObject zagadka; //canvas (od widoczności)

	//Zagadka string
	private string pytanie;
	private string odp_A;
	private string odp_B;
	private string odp_C;
	private string odp_D;
	private string odp_poprawna;


	//czy obiekt z obraska już był
	private bool telefonBool;
	private bool notatiBool;

	//liczniki - wartości numeryczne
	private float licznikCzasu;
	private int punkty;

	//Zagadka
	private bool showPopUp = false;
	private string stringToEdit;

	//lista zagadek
	private List<ZagadkaStr> zagadki = new List<ZagadkaStr>();


	// Use this for initialization
	void Start () 
	{
		generowanieZagadek ();
		telefonBool = true;
		notatiBool = true;
		zagadka.SetActive (false);

		licznikCzasu = 300.0f;
		punkty = 0;

		licznikCzasuStr.text = "Pozostały czas: 300";
		licznikPunktowStr.text = "Punkty: 0";
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (punkty >= 6) 
		{
			Application.LoadLevel ("Menu");
		}
		if (Input.GetMouseButton (0)) 
		{
			Vector3 pos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			RaycastHit2D hitInfo = Physics2D.Raycast (pos, Vector2.zero);
			if (hitInfo != null && hitInfo.collider != null) 
			{
				if (hitInfo.collider.name == "Gabinet Szefa_telefon" && telefonBool && !zagadka.active) 
				{
					int a, b, c, d;
					a = 5;
					b = 5;
					c = 5;
					d = 5;

					bool losowanie = true;

					while (losowanie)
					{
						Random rnd = new Random ();
						int rand = 0;
						rand = System.DateTime.Now.Millisecond % 4;


						if (a != rand && b != rand && c != rand && d != rand) {
							if (a == 5) {
								a = rand;
							} else if (b == 5) {
								b = rand;
							} else if (c == 5) {
								c = rand;
							} else if (d == 5) {
								d = rand;
							}
						} 
						else if(a!=5 && b!=5 && c!=5 && d!=5)
						{
							losowanie = false;
						}
					}

					switch (a)
					{
					case 0:
						odp_A = zagadki [0].odpowiedzA;
						break;
					case 1:
						odp_A = zagadki [0].odpowiedzB;
						break;
					case 2:
						odp_A = zagadki [0].odpowiedzC;
						break;
					case 3:
						odp_A = zagadki [0].odpowiedzD;
						break;
					}

					switch (b)
					{
					case 0:
						odp_B = zagadki [0].odpowiedzA;
						break;
					case 1:
						odp_B = zagadki [0].odpowiedzB;
						break;
					case 2:
						odp_B = zagadki [0].odpowiedzC;
						break;
					case 3:
						odp_B = zagadki [0].odpowiedzD;
						break;
					}

					switch (c)
					{
					case 0:
						odp_C = zagadki [0].odpowiedzA;
						break;
					case 1:
						odp_C = zagadki [0].odpowiedzB;
						break;
					case 2:
						odp_C = zagadki [0].odpowiedzC;
						break;
					case 3:
						odp_C = zagadki [0].odpowiedzD;
						break;
					}
					switch (d)
					{
					case 0:
						odp_D = zagadki [0].odpowiedzA;
						break;
					case 1:
						odp_D = zagadki [0].odpowiedzB;
						break;
					case 2:
						odp_D = zagadki [0].odpowiedzC;
						break;
					case 3:
						odp_D = zagadki [0].odpowiedzD;
						break;
					}
					pytanie = zagadki [0].tresc;
//					odp_A = zagadki [0].odpowiedzA;
//					odp_B = zagadki [0].odpowiedzB;
//					odp_C = zagadki [0].odpowiedzC;
//					odp_D = zagadki [0].odpowiedzD;
					odp_poprawna = zagadki [0].prawidlowaOdpowiedz;
					telefonBool = false;
					showPopUp = true;
				}
				else if (hitInfo.collider.name == "Gabinet Szefa_papiery" && notatiBool && !zagadka.active) 
				{
					notatiBool = false;
					showPopUp = true;
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

		//wyświetlam zagadkę
		if (showPopUp) 
		{
			zagadka.SetActive (true);
			trescZagadki.text = pytanie;
			odpowiedzA.GetComponentInChildren<Text>().text = odp_A;
			odpowiedzA.GetComponentInChildren<Text>().fontSize = 30;

			odpowiedzB.GetComponentInChildren<Text>().text =  odp_B;
			odpowiedzB.GetComponentInChildren<Text>().fontSize = 30;

			odpowiedzC.GetComponentInChildren<Text>().text = odp_C;
			odpowiedzC.GetComponentInChildren<Text>().fontSize = 30;

			odpowiedzD.GetComponentInChildren<Text>().text =  odp_D;
			odpowiedzD.GetComponentInChildren<Text>().fontSize = 30;
		}
		else
			zagadka.SetActive (false);

	}

	public void odpA()
	{
		if(odpowiedzA.GetComponentInChildren<Text>().text == odp_poprawna)
		{
			showPopUp = false;
			Debug.Log ("TAK");
			punkty+=3;
			licznikPunktowStr.text = "Punkty: "+punkty;
		}
		else 
		{
			showPopUp = false;
			punkty--;
			licznikPunktowStr.text = "Punkty: " + punkty;
		}
	}

	public void odpB()
	{
		if(odpowiedzB.GetComponentInChildren<Text>().text == odp_poprawna)
		{
			showPopUp = false;
			Debug.Log ("TAK");
			punkty+=3;
			licznikPunktowStr.text = "Punkty: "+punkty;
		}
		else 
		{
			showPopUp = false;
			punkty--;
			licznikPunktowStr.text = "Punkty: " + punkty;
		}
	}

	public void odpC()
	{
		if(odpowiedzC.GetComponentInChildren<Text>().text == odp_poprawna)
		{
			showPopUp = false;
			Debug.Log ("TAK");
			punkty+=3;
			licznikPunktowStr.text = "Punkty: "+punkty;
		}
		else 
		{
			showPopUp = false;
			punkty--;
			licznikPunktowStr.text = "Punkty: " + punkty;
		}
	}

	public void odpD()
	{
		if (odpowiedzD.GetComponentInChildren<Text> ().text == odp_poprawna) 
		{
			showPopUp = false;
			Debug.Log ("TAK");
			punkty+=3;
			licznikPunktowStr.text = "Punkty: " + punkty;
		} 
		else 
		{
			showPopUp = false;
			punkty--;
			licznikPunktowStr.text = "Punkty: " + punkty;
		}
	}


	void generowanieZagadek()
	{
		ZagadkaStr temp;
		temp.tresc = "Nieznany kolega Boligłowy zadzwonił do niego podczas jego nieobecności i zostawił wiadomość: \n " +
			"Cześć, chciałem przypomnieć Tobie dzisiejszym spotkaniu tam gdzie zawsze, nie zapomnij kamery\nDuch daje" +
			" podpowiedź w formie zagadki:\n Aby odgadnąć z jakiego numeru dzwoniono rozwiąż poniższą zagadkę:\r\nPodaj kolejne 4 liczby z ciągu:" +
			" 243, 29, 85, 89, 145, 42, 20, 4, 16...";
		
		temp.prawidlowaOdpowiedz = "37, 58, 89, 145";
		temp.odpowiedzA = "37, 59, 106, 37";
		temp.odpowiedzB = "36, 45, 89, 145";
		temp.odpowiedzC = "37, 58, 89, 145";
		temp.odpowiedzD = "37, 58, 86, 100";
		zagadki.Add (temp);

//		temp.tresc = "";
//		temp.prawidlowaOdpowiedz = "";
//		temp.odpowiedzA = "";
//		temp.odpowiedzB = "";
//		temp.odpowiedzC = "";
//		temp.odpowiedzD = "";
//		zagadki.Add (temp);




	}


}

