using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class besouro : MonoBehaviour
{
    public float velocidade = 5f;
    void Start()
    {
        
    }

    
    void Update()
    {
        Mover();

    }
    public void Mover()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(horizontalInput, verticalInput).normalized;
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = movement * velocidade;


        if (horizontalInput > 0)
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        else if (horizontalInput < 0)
        {
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("tirocobra") || col.gameObject.CompareTag("espinho"))
        {
            Destroy(col.gameObject);
            Destroy(this.gameObject);
        }
    }
}
