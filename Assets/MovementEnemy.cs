using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MovementEn : MonoBehaviour
    
{
    public float speed;
    public Rigidbody2D enemyRb;
    private bool faceFlip;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject cobra = GameObject.Find("cobra");
        GameObject jacare = GameObject.Find("jacare");

        if (gameObject == jacare)
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
        else if (gameObject == cobra)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
    }


    private void FlipEnemy()
    {
        if (faceFlip)
        {
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            gameObject.transform.rotation = Quaternion.Euler(0,180,0);
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col != null && !col.collider.CompareTag("Player"))
        {
            faceFlip = !faceFlip;
        }
        FlipEnemy();
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("bala"))
        {
            Destroy(col.gameObject);
            Destroy(this.gameObject);
        }
    }
}
