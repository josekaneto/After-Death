using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personagem : MonoBehaviour
{
    public GameObject balaProjetil;
    public Transform arma;
    private bool tiro;
    public float forcaDoTiro;
    public float velocidade = 5f;

 
    public GameObject novoPersonagemPrefab;
    private GameObject personagemTransformado;

    void Update()
    {
        Mover();
        tiro = Input.GetButtonDown("Fire1");
        Atirar();

        if (Input.GetKeyDown(KeyCode.R))
        {
            TrocarPersonagem();
        }
    }

    public void Mover()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(horizontalInput, verticalInput).normalized;
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = movement * velocidade;

       
        if (horizontalInput > 0)
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        else if (horizontalInput < 0)
        {
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
    }

    private void Atirar()
    {
        if (tiro)
        {
            GameObject temp = Instantiate(balaProjetil);
            temp.transform.position = arma.position;

         
            float direcao = transform.localScale.x > 0 ? 1 : -1;
            temp.GetComponent<Rigidbody2D>().velocity = new Vector2(forcaDoTiro * direcao, 0);

            Destroy(temp.gameObject, 3f);
        }
    }

    private void TrocarPersonagem()
    {
        if (personagemTransformado != null)
        {
            Destroy(personagemTransformado);
        }

        if (novoPersonagemPrefab != null)
        {
       
            personagemTransformado = Instantiate(novoPersonagemPrefab, transform.position, transform.rotation);
            Destroy(gameObject); 
        }
    }
}
