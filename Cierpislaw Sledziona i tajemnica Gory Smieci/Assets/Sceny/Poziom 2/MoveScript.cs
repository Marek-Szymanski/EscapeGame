using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveScript : MonoBehaviour {

    // Use this for initialization
   public Rigidbody2D rb;
    void Start () {

        rb = GetComponent<Rigidbody2D>();

    }


    void Update () {
        
        if (Input.GetKey(KeyCode.W))
        {
            rb.velocity = new Vector2(5f, 5f);
	
        }else
        if (Input.GetKey(KeyCode.S))
        {
             rb.velocity =new Vector2(0f, -5f);
    
        }else
        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector2(-5f, 0.0f);
       
        }else
        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector2(5f, 0.0f);
  
        }else
        rb.velocity = new Vector2(0, 0);
        Debug.Log(rb.velocity);

    }
}
