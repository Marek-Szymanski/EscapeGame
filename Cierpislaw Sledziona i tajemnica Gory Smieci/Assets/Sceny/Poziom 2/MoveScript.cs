using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour {

    // Use this for initialization
    public GameObject cierpislawSledziona;
    public Camera kamera;
	void Start () {

    }

    // Update is called once per frame


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "YourWallName")  // or if(gameObject.CompareTag("YourWallTag"))
        {
            rigidbody.velocity = Vector3.zero;
        }
    }

    void Update () {
        if (Input.GetKey(KeyCode.W))
        {
            Vector3 temp = new Vector3(0.0f, 0.5f, 0.0f);
            cierpislawSledziona.transform.position += temp;
        }
        if (Input.GetKey(KeyCode.S))
        {
            Vector3 temp = new Vector3(0.0f, 0.5f, 0.0f);
            cierpislawSledziona.transform.position -= temp;
        }
        if (Input.GetKey(KeyCode.A))
        {
            Vector3 temp = new Vector3(0.5f, 0.0f, 0.0f);
            cierpislawSledziona.transform.position -= temp;
        }
        if (Input.GetKey(KeyCode.D))
        {
            Vector3 temp = new Vector3(0.5f, 0.0f, 0.0f);
            cierpislawSledziona.transform.position += temp;
        }

        kamera.transform.position = cierpislawSledziona.transform.position;

        kamera.transform.position -= new Vector3(0.0f,0.0f,10.0f);


    }
}
