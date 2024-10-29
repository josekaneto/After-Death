using System.Collections;
using UnityEngine;

public class Cobra : MonoBehaviour
{
    public GameObject balaProjetil;
    public Transform arma;
    public float forcaDoTiro;
    private float intervaloDeTiro = 3f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(AutoAtirar());
    }

    private IEnumerator AutoAtirar()
    {
        while (true)
        {
            Atirar();
            yield return new WaitForSeconds(intervaloDeTiro); // Espera 3 segundos antes do próximo tiro
        }
    }

    private void Atirar()
    {
        GameObject temp = Instantiate(balaProjetil);
        temp.transform.position = arma.position;

        float direcao = transform.localScale.x > 0 ? 1 : -1;
        temp.GetComponent<Rigidbody2D>().velocity = new Vector2(forcaDoTiro * direcao, 0);

        Destroy(temp.gameObject, 2f);
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

