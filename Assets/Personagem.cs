using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Personagem : MonoBehaviour
{
    public GameObject balaProjetil;
    public Transform arma;
    private bool tiro;
    public float forcaDoTiro;
    public float velocidade = 5f;
    public float jumpforce;
    private bool pulo, isgrounded;

    public GameObject novoPersonagemPrefab;
    private GameObject personagemTransformado;

    private Rigidbody2D playerRb;  

    private void Awake()
    {
       
        playerRb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Mover();
        tiro = Input.GetButtonDown("Fire1");
        Atirar();

       
        pulo = Input.GetButtonDown("Jump");
        if (pulo && isgrounded)
        {
            playerRb.AddForce(new Vector2(0, jumpforce), ForceMode2D.Impulse);
            isgrounded = false;
        }

      
        if (Input.GetKeyDown(KeyCode.R))
        {
            TrocarPersonagem();
        }
    }

    public void Mover()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(horizontalInput, 0);
        playerRb.linearVelocity = new Vector2(movement.x * velocidade, playerRb.linearVelocity.y);

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
            temp.GetComponent<Rigidbody2D>().linearVelocity = new Vector2(forcaDoTiro * direcao, 0);

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

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("tirocobra") || col.gameObject.CompareTag("espinho") || col.gameObject.CompareTag("enemy"))
        {
            Destroy(col.gameObject);
            Destroy(this.gameObject);
            SceneManager.LoadScene("GameOver");
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("enemy"))
        {
            Destroy(col.gameObject);
            Destroy(this.gameObject);
            SceneManager.LoadScene("GameOver");
        }

        if (col.gameObject.CompareTag("chao"))
        {
            isgrounded = true;
        }
    }

}
