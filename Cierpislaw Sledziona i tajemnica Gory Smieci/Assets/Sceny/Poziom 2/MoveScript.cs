
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

struct ZagadkaStr2
{
    public string tresc;
    public string prawidlowaOdpowiedz;
    public string odpowiedzA;
    public string odpowiedzB;
    public string odpowiedzC;
    public string odpowiedzD;
}

public class MoveScript : MonoBehaviour {

    // Use this for initialization
   public Rigidbody2D rb;
    private Vector3 zasieg; 

    public GameObject[] smieci;
    public GameObject smiec;

    public Text licznikCzasuStr;
    public Text licznikPunktowStr;

    public Text trescZagadki; //treść
    public Button odpowiedzA; //odpowiedzi
    public Button odpowiedzB;
    public Button odpowiedzC;
    public Button odpowiedzD;
    public GameObject zagadka; //canvas (od widoczności)


    private string pytanie;
    private string odp_A;
    private string odp_B;
    private string odp_C;
    private string odp_D;
    private string odp_poprawna;

    private int[] zagatkaBool;

    private bool showPopUp = false;
    private string stringToEdit;

    private List<ZagadkaStr2> zagadki = new List<ZagadkaStr2>();

    private float licznikCzasu;
    private int punkty;

    private int count;
    private bool isdone=true;




    void Start () {
        
        rb = GetComponent<Rigidbody2D>();
        count = Random.Range(20,50);
        smieci = new GameObject[count];
        for(int i = 0; i < count; i++)
        {
            smieci[i] = smiec;
        }
        
        generowanieZagadek();
        zagatkaBool = new int[count];
 
        for (int i = 0; i < count; i++)
        {
            zagatkaBool[i] = 1;
        }
        zagadka.SetActive(false);

        licznikCzasu = 300.0f;
        punkty = 0;

        licznikCzasuStr.text = "Pozostały czas: 300";
        licznikPunktowStr.text = "Punkty: 0";
        Debug.Log("spawn1 ");

        SpawnSmieci();
 

    }


    void SpawnSmieci()
    {
        for (int i = 0; i < count; i++)
        {
            Debug.Log("spawn2 ");
            Vector3 randomSpwan = new Vector3(Random.Range(-29.32808f, -10.56179f), Random.Range(-30.43662f, 191.0547f) - 10.0f);
            Instantiate(smieci[i], randomSpwan, Quaternion.identity);
        }
    }
  

    void Update () {

        Debug.Log(rb.position);

        if (Input.GetKey(KeyCode.W))
        {
            rb.velocity = new Vector2(0.0f, 10.0f);
	
        }else
        if (Input.GetKey(KeyCode.S))
        {
             rb.velocity =new Vector2(0.0f, -10.0f);
    
        }else
        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector2(-10.0f, 0.0f);
       
        }else
        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector2(10.0f, 0.0f);
  
        }else
        rb.velocity = new Vector2(0.0f, 0.0f);
        



        if (punkty >= 6)
        {
            Application.LoadLevel("poziom1");
        }
        Debug.Log("zagadka1 ");
        if (Input.GetMouseButton(0) && isdone==true)
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hitInfo = Physics2D.Raycast(pos, Vector2.zero);
            if (hitInfo != null && hitInfo.collider != null)
            {
                Random rnd = new Random();
                int rand = 0;
                
                while (zagatkaBool[rand] == 0)
                {
                    rand = System.DateTime.Now.Millisecond % count;
                }
                if (hitInfo.collider.tag == "zagadki" && zagatkaBool[rand] == 1 && !zagadka.active)
                    {

                        pobierzZagadke(rand);
                        zagatkaBool[rand] = 0;
                        showPopUp = true;
                        isdone = false;
                    }
                

            }
            else
            {
                if (licznikCzasu - 1 > 0)
                    licznikCzasu -= 1;
                else
                    Application.LoadLevel("Menu");
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
            zagadka.SetActive(true);
            trescZagadki.text = pytanie;
            odpowiedzA.GetComponentInChildren<Text>().text = odp_A;
            odpowiedzA.GetComponentInChildren<Text>().fontSize = 30;

            odpowiedzB.GetComponentInChildren<Text>().text = odp_B;
            odpowiedzB.GetComponentInChildren<Text>().fontSize = 30;

            odpowiedzC.GetComponentInChildren<Text>().text = odp_C;
            odpowiedzC.GetComponentInChildren<Text>().fontSize = 30;

            odpowiedzD.GetComponentInChildren<Text>().text = odp_D;
            odpowiedzD.GetComponentInChildren<Text>().fontSize = 30;
        }
        else
            zagadka.SetActive(false);


    }


    public void odpA()
    {
        if (odpowiedzA.GetComponentInChildren<Text>().text == odp_poprawna)
        {
            isdone = true;
            showPopUp = false;
            Debug.Log("TAK");
            punkty += 3;
            licznikPunktowStr.text = "Punkty: " + punkty;
        }
        else
        {
            isdone = true;
            showPopUp = false;
            punkty--;
            licznikPunktowStr.text = "Punkty: " + punkty;
        }
    }

    public void odpB()
    {
        if (odpowiedzB.GetComponentInChildren<Text>().text == odp_poprawna)
        {
            isdone = true;
            showPopUp = false;
            Debug.Log("TAK");
            punkty += 3;
            licznikPunktowStr.text = "Punkty: " + punkty;
        }
        else
        {
            isdone = true;
            showPopUp = false;
            punkty--;
            licznikPunktowStr.text = "Punkty: " + punkty;
        }
    }

    public void odpC()
    {
        if (odpowiedzC.GetComponentInChildren<Text>().text == odp_poprawna)
        {
            isdone = true;
            showPopUp = false;
            Debug.Log("TAK");
            punkty += 3;
            licznikPunktowStr.text = "Punkty: " + punkty;
        }
        else
        {
            isdone = true;
            showPopUp = false;
            punkty--;
            licznikPunktowStr.text = "Punkty: " + punkty;
        }
    }

    public void odpD()
    {
        if (odpowiedzD.GetComponentInChildren<Text>().text == odp_poprawna)
        {
            isdone = true;
            showPopUp = false;
            Debug.Log("TAK");
            punkty += 3;
            licznikPunktowStr.text = "Punkty: " + punkty;
        }
        else
        {
            isdone = true;
            showPopUp = false;
            punkty--;
            licznikPunktowStr.text = "Punkty: " + punkty;
        }
    }

    void pobierzZagadke(int i)
    {
        int a, b, c, d;
        a = 5;
        b = 5;
        c = 5;
        d = 5;

        bool losowanie = true;

        while (losowanie)
        {
            Random rnd = new Random();
            int rand = 0;
            rand = System.DateTime.Now.Millisecond % 4;


            if (a != rand && b != rand && c != rand && d != rand)
            {
                if (a == 5)
                {
                    a = rand;
                }
                else if (b == 5)
                {
                    b = rand;
                }
                else if (c == 5)
                {
                    c = rand;
                }
                else if (d == 5)
                {
                    d = rand;
                }
            }
            else if (a != 5 && b != 5 && c != 5 && d != 5)
            {
                losowanie = false;
            }
        }

        switch (a)
        {
            case 0:
                odp_A = zagadki[i].odpowiedzA;
                break;
            case 1:
                odp_A = zagadki[i].odpowiedzB;
                break;
            case 2:
                odp_A = zagadki[i].odpowiedzC;
                break;
            case 3:
                odp_A = zagadki[i].odpowiedzD;
                break;
        }

        switch (b)
        {
            case 0:
                odp_B = zagadki[i].odpowiedzA;
                break;
            case 1:
                odp_B = zagadki[i].odpowiedzB;
                break;
            case 2:
                odp_B = zagadki[i].odpowiedzC;
                break;
            case 3:
                odp_B = zagadki[i].odpowiedzD;
                break;
        }

        switch (c)
        {
            case 0:
                odp_C = zagadki[i].odpowiedzA;
                break;
            case 1:
                odp_C = zagadki[i].odpowiedzB;
                break;
            case 2:
                odp_C = zagadki[i].odpowiedzC;
                break;
            case 3:
                odp_C = zagadki[i].odpowiedzD;
                break;
        }
        switch (d)
        {
            case 0:
                odp_D = zagadki[i].odpowiedzA;
                break;
            case 1:
                odp_D = zagadki[i].odpowiedzB;
                break;
            case 2:
                odp_D = zagadki[i].odpowiedzC;
                break;
            case 3:
                odp_D = zagadki[i].odpowiedzD;
                break;
        }
        pytanie = zagadki[i].tresc;
        //					odp_A = zagadki [0].odpowiedzA;
        //					odp_B = zagadki [0].odpowiedzB;
        //					odp_C = zagadki [0].odpowiedzC;
        //					odp_D = zagadki [0].odpowiedzD;
        odp_poprawna = zagadki[i].prawidlowaOdpowiedz;

    }






    void generowanieZagadek()
    {
        ZagadkaStr2 temp;

        temp.tresc = "Obecnie w Europie dominującym typem krajobrazu jest:";
        temp.odpowiedzA = "naturalny";
        temp.odpowiedzB = "pierwotny";
        temp.odpowiedzC = "kulturowy"; //
        temp.odpowiedzD = " ";
        temp.prawidlowaOdpowiedz = "kulturowy"; //
        zagadki.Add(temp);

        temp.tresc = "Efekt cieplarniany spowodowany jest przez:";
        temp.odpowiedzA = "dwutlenek węgla";//
        temp.odpowiedzB = "dwutlenek siarki";
        temp.odpowiedzC = "tlenek ołowiu";
        temp.odpowiedzD = " ";
        temp.prawidlowaOdpowiedz = "dwutlenek węgla";//
        zagadki.Add(temp);

        temp.tresc = "Niszczenie warstwy ozonowej powoduje:";
        temp.odpowiedzA = "opad pyłu";
        temp.odpowiedzB = "freon";//
        temp.odpowiedzC = "tlenek węgla";
        temp.odpowiedzD = " ";
        temp.prawidlowaOdpowiedz = "freon";//
        zagadki.Add(temp);

        temp.tresc = "Blisko 80 % energii produkowanej w Polsce pochodzi ze spalania:";
        temp.odpowiedzA = "węgla kamiennego i brunatnego";//
        temp.odpowiedzB = "ropy naftowej";
        temp.odpowiedzC = "węgla kamiennego";
        temp.odpowiedzD = " ";
        temp.prawidlowaOdpowiedz = "węgla kamiennego i brunatnego";//
        zagadki.Add(temp);

        temp.tresc = "Czad to:";
        temp.odpowiedzA ="dwutlenek węgla";
        temp.odpowiedzB = "tlenek węgla";//
        temp.odpowiedzC = "dwutlenek azotu";
        temp.odpowiedzD = " ";
        temp.prawidlowaOdpowiedz = "tlenek węgla";//
        zagadki.Add(temp);

        temp.tresc = "Hydrosferą nazywamy";
        temp.odpowiedzA = "zasoby wód słodkich";
        temp.odpowiedzB = "zasoby wód słonych";
        temp.odpowiedzC = "całość powłoki wodnej Ziemi";//
        temp.odpowiedzD = " ";
        temp.prawidlowaOdpowiedz = "całość powłoki wodnej Ziemi";//
        zagadki.Add(temp);

        temp.tresc = "Lasami najmniej wrażliwymi na emisje przemysłowe są:"; 
        temp.odpowiedzA = "iglaste";
        temp.odpowiedzB = "liściaste";//
        temp.odpowiedzC = "mieszane";
        temp.odpowiedzD = " ";
        temp.prawidlowaOdpowiedz = "liściaste";//
        zagadki.Add(temp);

        temp.tresc = "Sosna pospolita w ogólnej powierzchni lasów w Polsce zajmuje";
        temp.odpowiedzA = "30 % powierzchni";
        temp.odpowiedzB = "ponad 70 % powierzchni";//
        temp.odpowiedzC = "90 % powierzchni";
        temp.odpowiedzD = " ";
        temp.prawidlowaOdpowiedz = "ponad 70 % powierzchni";//
        zagadki.Add(temp);

        temp.tresc = "Największą dawkę zanieczyszczeń w stosunku do masy ciała wraz z żywnością otrzymują: ";
        temp.odpowiedzA = "dzieci";//
        temp.odpowiedzB = "ludzie w wieku emerytalnym";
        temp.odpowiedzC = "kobiety";
        temp.odpowiedzD = " ";
        temp.prawidlowaOdpowiedz = "dzieci";//
        zagadki.Add(temp);

        temp.tresc = "Pierwszy na świecie park narodowy powstał w:";
        temp.odpowiedzA = "Europie";
        temp.odpowiedzB = "Ameryce Południowej";
        temp.odpowiedzC = "Ameryce Północnej";//
        temp.odpowiedzD = " ";
        temp.prawidlowaOdpowiedz = "Ameryce Północnej";//
        zagadki.Add(temp);

        temp.tresc = "Najwyższą formą ochrony przyrody są:";
        temp.odpowiedzA = "strefy chronionego krajobrazu";
        temp.odpowiedzB = "parki narodowe";//
        temp.odpowiedzC = "parki krajobrazowe";
        temp.odpowiedzD = " ";
        temp.prawidlowaOdpowiedz = "parki narodowe";//
        zagadki.Add(temp);

        temp.tresc = "Symbolem ochrony przyrody w Polsce jest: ";
        temp.odpowiedzA = "łoś";
        temp.odpowiedzB = "żubr";//
        temp.odpowiedzC = "bóbr";
        temp.odpowiedzD = " ";
        temp.prawidlowaOdpowiedz = "żubr";//
        zagadki.Add(temp);

        temp.tresc = "Polskim parkiem narodowym wpisanym na Listę Dziedzictwa Światowego jest:";
        temp.odpowiedzA = "Świętokrzyski";
        temp.odpowiedzB = "Tatrzański";
        temp.odpowiedzC = "Białowieski";//
        temp.odpowiedzD = " ";
        temp.prawidlowaOdpowiedz = "Białowieski";//
        zagadki.Add(temp);

        temp.tresc = "Energię odnawialną tworzą:";
        temp.odpowiedzA = "woda, promieniowanie słoneczne, wiatr, falowanie mórz";//
        temp.odpowiedzB = "zasoby paliw ciekłych i gazowych";
        temp.odpowiedzC = "zasoby paliw stałych";
        temp.odpowiedzD = " ";
        temp.prawidlowaOdpowiedz = "woda, promieniowanie słoneczne, wiatr, falowanie mórz";//
        zagadki.Add(temp);

        temp.tresc = "W prawidłowo zestawionym jadłospisie warzywa i owoce powinny wystąpić";
        temp.odpowiedzA = "w jednym posiłku";
        temp.odpowiedzB = "koniecznie tylko w drugim śniadaniu i podwieczorku";
        temp.odpowiedzC = "we wszystkich posiłkach podstawowych";//
        temp.odpowiedzD = " ";
        temp.prawidlowaOdpowiedz = "we wszystkich posiłkach podstawowych";//
        zagadki.Add(temp);

        temp.tresc = "Tak zwana dziura ozonowa może stanowić przyczynę";
        temp.odpowiedzA = "zwiększenia liczby zachorowań na choroby nowotworowe";//
        temp.odpowiedzB = "zmniejszenia liczby zawałów";
        temp.odpowiedzC = "ograniczenia oddziaływania promieniowania ultrafioletowego";
        temp.odpowiedzD = " ";
        temp.prawidlowaOdpowiedz = "zwiększenia liczby zachorowań na choroby nowotworowe";//
        zagadki.Add(temp);

        temp.tresc = "Pomnik przyrody to:";
        temp.odpowiedzA = "egzotyczny okaz ze świata zwierząt";
        temp.odpowiedzB = "cenny twór przyrody, prawnie chroniony";//
        temp.odpowiedzC = "krajobraz naturalny bez działań antropogenicznych";
        temp.odpowiedzD = " ";
        temp.prawidlowaOdpowiedz = "cenny twór przyrody, prawnie chroniony";//
        zagadki.Add(temp);

        temp.tresc = "Akcja Sprzątanie Świata przywędrowała do Polski z:";
        temp.odpowiedzA = "Ameryki Północnej";
        temp.odpowiedzB = "Australii";//
        temp.odpowiedzC = "Afryki";
        temp.odpowiedzD = " ";
        temp.prawidlowaOdpowiedz = "Australii";//
        zagadki.Add(temp);

        temp.tresc = "Największy kompleks bagien w Polsce tworzą rozlewiska:";
        temp.odpowiedzA = "Biebrzy";   // 
        temp.odpowiedzB = "Bzury";
        temp.odpowiedzC = "Notec";
        temp.odpowiedzD = " ";
        temp.prawidlowaOdpowiedz = "Biebrzy";   // 
        zagadki.Add(temp);

        temp.tresc = "Detergenty są to:";
        temp.odpowiedzA = "promienie świetlne";
        temp.odpowiedzB = "inna nazwa ścieków";
        temp.odpowiedzC = "substancje syntetyczne używane do prania i zmywania";//
        temp.odpowiedzD = " ";
        temp.prawidlowaOdpowiedz = "substancje syntetyczne używane do prania i zmywania";//
        zagadki.Add(temp);

        temp.tresc = "Międzynarodowy Dzień Ziemi jest obchodzony:";
        temp.odpowiedzA = "05 czerwca"; 
        temp.odpowiedzB = "22 maja";
        temp.odpowiedzC = "22 kwietnia";//
        temp.odpowiedzD = " ";
        temp.prawidlowaOdpowiedz = "22 kwietnia";//
        zagadki.Add(temp);

        temp.tresc = "Greenpeace to: ";
        temp.odpowiedzA = "międzynarodowa organizacja ekologiczna";//
        temp.odpowiedzB = "agenda ONZ do spraw ekologii";
        temp.odpowiedzC = "Przyjaciel Ziemi";
        temp.odpowiedzD = " ";
        temp.prawidlowaOdpowiedz = "międzynarodowa organizacja ekologiczna";//
        zagadki.Add(temp);

        temp.tresc = "Zwiększenie wysokości komina kotłowni spowoduje:";
        temp.odpowiedzA = "zmniejszenie stężeń zanieczyszczeń na terenach przyległych";//
        temp.odpowiedzB = "obniżenie emisji zanieczyszczeń";
        temp.odpowiedzC = "nie ma istotnego wpływu na środowisko";
        temp.odpowiedzD = " ";
        temp.prawidlowaOdpowiedz = "zmniejszenie stężeń zanieczyszczeń na terenach przyległych";//
        zagadki.Add(temp);

        temp.tresc = "Elektrofiltr to: ";
        temp.odpowiedzA = "urządzenie pomiarowe systemu klimatyzacji";
        temp.odpowiedzB = "element oczyszczalni ścieków";
        temp.odpowiedzC = "urządzenie wychwytujące zanieczyszczenia pyłowe oraz aerozole";//
        temp.odpowiedzD = " ";
        temp.prawidlowaOdpowiedz = "urządzenie wychwytujące zanieczyszczenia pyłowe oraz aerozole";//
        zagadki.Add(temp);

        temp.tresc = "Największy udział w emisji toksycznych spalin samochodowych ma: ";
        temp.odpowiedzA = "dwutlenek węgla";
        temp.odpowiedzB = "tlenek węgla";//
        temp.odpowiedzC = "dwusiarczek węgla";
        temp.odpowiedzD = " ";
        temp.prawidlowaOdpowiedz = "tlenek węgla";//
        zagadki.Add(temp);

        temp.tresc = "Ostatnio prowadzi się badania w celu wykorzystania w produkcji paliw w Polsce: ";
        temp.odpowiedzA = "rzepaku";//
        temp.odpowiedzB = "kukurydzy";
        temp.odpowiedzC = "wierzby koszykarskiej";
        temp.odpowiedzD = " ";
        temp.prawidlowaOdpowiedz = "rzepaku";//
        zagadki.Add(temp);

        temp.tresc = "Celem określenia wielkości hałasu prowadzi się pomiar:";
        temp.odpowiedzA = "natężenia dźwięku";//
        temp.odpowiedzB = "ciśnienia akustycznego";
        temp.odpowiedzC = "mocy akustycznej";
        temp.odpowiedzD = " ";
        temp.prawidlowaOdpowiedz = "natężenia dźwięku";//
        zagadki.Add(temp);

        temp.tresc = "Recykling oznacza proces:";
        temp.odpowiedzA = "likwidacji szczególnie toksycznych odpadów przemysłowych";   
        temp.odpowiedzB = "odsiarczania spalin";
        temp.odpowiedzC = "ponownego wykorzystania odpadów w produkcji";//
        temp.odpowiedzD = " ";
        temp.prawidlowaOdpowiedz = "ponownego wykorzystania odpadów w produkcji";//
        zagadki.Add(temp);

        temp.tresc = "Jedynym ssakiem zdolnym do aktywnego lotu jest:";
        temp.odpowiedzA = "pingwin";
        temp.odpowiedzB = "nietoperz";//
        temp.odpowiedzC = "dziobak";
        temp.odpowiedzD = " ";
        temp.prawidlowaOdpowiedz = "nietoperz";//
        zagadki.Add(temp);

        temp.tresc = "Jednymi z pierwszych roślin zasiedlających skały są:";
        temp.odpowiedzA = "mchy";//
        temp.odpowiedzB = "nagonasienne";
        temp.odpowiedzC = "okrytonasienne";
        temp.odpowiedzD = " ";
        temp.prawidlowaOdpowiedz = "mchy";//
        zagadki.Add(temp);

        temp.tresc = "Najważniejszym czynnikiem utrzymania żyzności gleby jest: ";
        temp.odpowiedzA = "melioracja";
        temp.odpowiedzB = "nawadnianie";
        temp.odpowiedzC = "właściwe użytkowanie";//
        temp.odpowiedzD = " ";
        temp.prawidlowaOdpowiedz = "właściwe użytkowanie";//
        zagadki.Add(temp);

        temp.tresc = "Park Narodowy Yellowstone został utworzony ze względu na występowanie:";
        temp.odpowiedzA = "bogatych i unikalnych drzewostanów";
        temp.odpowiedzB = "pól gejzerowych";//
        temp.odpowiedzC = "przepięknych kanionów";
        temp.odpowiedzD = " ";
        temp.prawidlowaOdpowiedz = "pól gejzerowych";//
        zagadki.Add(temp);

        temp.tresc = "W Polsce świstak występuje w:";
        temp.odpowiedzA = "Sudetach";
        temp.odpowiedzB = "Bieszczadach";
        temp.odpowiedzC = "Tatrach";//
        temp.odpowiedzD = " ";
        temp.prawidlowaOdpowiedz = "Tatrach";//
        zagadki.Add(temp);

        temp.tresc = "Puszcza Jodłowa znajduje się w obrębie: ";
        temp.odpowiedzA = "Gorczańskiego Parku Narodowego";
        temp.odpowiedzB = "Ojcowskiego Parku Narodowego";
        temp.odpowiedzC = "Świętokrzyskiego Parku Narodowego";//
        temp.odpowiedzD = " ";
        temp.prawidlowaOdpowiedz = "Świętokrzyskiego Parku Narodowego";//
        zagadki.Add(temp);

        temp.tresc = "Salamandra to symbol:";
        temp.odpowiedzA = "Wielkopolskiego Parku Narodowego";
        temp.odpowiedzB = "Gorczańskiego Parku Narodowego";//
        temp.odpowiedzC = "Kampinoskiego Parku Narodowego";
        temp.odpowiedzD = " ";
        temp.prawidlowaOdpowiedz = "Gorczańskiego Parku Narodowego";//
        zagadki.Add(temp);

        temp.tresc = "Wśród gadów żyjących w Polsce gatunkiem jadowitym jest: ";
        temp.odpowiedzA = "zaskroniec";
        temp.odpowiedzB = "żmija zygzakowata";//
        temp.odpowiedzC = "padalec";
        temp.odpowiedzD = " ";
        temp.prawidlowaOdpowiedz = "żmija zygzakowata";//
        zagadki.Add(temp);

        temp.tresc = "Jakakolwiek ingerencja człowieka wykluczona jest w: ";
        temp.odpowiedzA = "rezerwatach ścisłych";//
        temp.odpowiedzB = "rezerwatach częściowych";
        temp.odpowiedzC = "parkach krajobrazowych";
        temp.odpowiedzD = " ";
        temp.prawidlowaOdpowiedz = "rezerwatach ścisłych";//
        zagadki.Add(temp);

        temp.tresc = "Numerki z literą E oznaczają:";
        temp.odpowiedzA = "chemiczne dodatki do żywności";//
        temp.odpowiedzB = "nieszkodliwe materiały izolacyjne";
        temp.odpowiedzC = "zdrową żywność";
        temp.odpowiedzD = " ";
        temp.prawidlowaOdpowiedz = "chemiczne dodatki do żywności";//
        zagadki.Add(temp);

        temp.tresc = "Hibernacja oznacza: ";
        temp.odpowiedzA = "sen zwierząt ułatwiający przeżycie niekorzystnego okresu zimowego";//
        temp.odpowiedzB = "następstwo pór roku";
        temp.odpowiedzC = "przedłużenie okresu wegetacji roślin użytkowych";
        temp.odpowiedzD = " ";
        temp.prawidlowaOdpowiedz = "sen zwierząt ułatwiający przeżycie niekorzystnego okresu zimowego";//
        zagadki.Add(temp);

        temp.tresc = "W naturalny sposób siarka do atmosfery dostaje się poprzez";
        temp.odpowiedzA = "proces oddychania żywych organizmów";
        temp.odpowiedzB = "wybuchy wulkanów";//
        temp.odpowiedzC = "eksploatację złóż rud żelaza";
        temp.odpowiedzD = " ";
        temp.prawidlowaOdpowiedz = "wybuchy wulkanów";//
        zagadki.Add(temp);

        temp.tresc = "Największy udział wśród gleb leśnych Polski mają";
        temp.odpowiedzA = "mady";
        temp.odpowiedzB = "bielice";//
        temp.odpowiedzC = "czarnoziemy";
        temp.odpowiedzD = " ";
        temp.prawidlowaOdpowiedz = "bielice";//
        zagadki.Add(temp);

        temp.tresc = "Rumowiska skalne podlegają ochronie na terenie";
        temp.odpowiedzA = "Świętokrzyskiego Parku Narodowego";//
        temp.odpowiedzB = "Bieszczadzkiego Parku Narodowego";
        temp.odpowiedzC = "Pienińskiego Parku Narodowego";
        temp.odpowiedzD = " ";
        temp.prawidlowaOdpowiedz = "Świętokrzyskiego Parku Narodowego";//
        zagadki.Add(temp);

        temp.tresc = "Batalion to symbol";
        temp.odpowiedzA = "Kampinoskiego Parku Narodowego";
        temp.odpowiedzB = "Biebrzańskiego Parku Narodowego";//
        temp.odpowiedzC = "Poleskiego Parku Narodowego";
        temp.odpowiedzD = " ";
        temp.prawidlowaOdpowiedz = "Biebrzańskiego Parku Narodowego";//
        zagadki.Add(temp);

        temp.tresc = "Beznogim gadem jest";
        temp.odpowiedzA = "padalec";//
        temp.odpowiedzB = "szop";
        temp.odpowiedzC = "kolczatka";
        temp.odpowiedzD = " ";
        temp.prawidlowaOdpowiedz = "padalec";//
        zagadki.Add(temp);

        temp.tresc = "Pod względem powierzchni największym parkiem narodowym w Polsce jest:";
        temp.odpowiedzA = "Bieszczadzki";
        temp.odpowiedzB = "Słowiński";
        temp.odpowiedzC = "Biebrzański";//
        temp.odpowiedzD = " ";
        temp.prawidlowaOdpowiedz = "Biebrzański";//
        zagadki.Add(temp);

        temp.tresc = "W Tatrach w piętrze roślinności turniowej występują:";
        temp.odpowiedzA = "mszaki i porosty";//
        temp.odpowiedzB = "kosodrzewina";
        temp.odpowiedzC = "lasy jodłowe";
        temp.odpowiedzD = " ";
        temp.prawidlowaOdpowiedz = "mszaki i porosty";//
        zagadki.Add(temp);

        temp.tresc = "Pierwszym miastem Polski, które zyskało status specjalnie chronionego jest: ";
        temp.odpowiedzA = "Lublin";
        temp.odpowiedzB = "Zabrze";
        temp.odpowiedzC = "Kraków";//
        temp.odpowiedzD = " ";
        temp.prawidlowaOdpowiedz = "Kraków";//
        zagadki.Add(temp);

        temp.tresc = "Erozja to: ";
        temp.odpowiedzA = "obniżenie odporności gatunków na skażenie pyłowe środowiska";
        temp.odpowiedzB = "zakłócenie obiegu materii w ekosystemie";
        temp.odpowiedzC = "mechaniczne niszczenie powierzchni Ziemi przez różne czynniki";//
        temp.odpowiedzD = " ";
        temp.prawidlowaOdpowiedz = "mechaniczne niszczenie powierzchni Ziemi przez różne czynniki";//
        zagadki.Add(temp);

        temp.tresc = "Kwaśne deszcze działają negatywnie na:";
        temp.odpowiedzA = "zabytkowe obiekty kamienne";//
        temp.odpowiedzB = "częstotliwość opadów deszczu";
        temp.odpowiedzC = "amplitudę wahań temperatury";
        temp.odpowiedzD = " ";
        temp.prawidlowaOdpowiedz = "zabytkowe obiekty kamienne";//
        zagadki.Add(temp);

        temp.tresc = "Najmniej zanieczyszczeń powietrza podczas procesu spalania wytwarza:";
        temp.odpowiedzA = "węgiel kamienny";
        temp.odpowiedzB = "gaz ziemny";//
        temp.odpowiedzC = "olej opałowy";
        temp.odpowiedzD = " ";
        temp.prawidlowaOdpowiedz = "gaz ziemny";//
        zagadki.Add(temp);


    }

}
