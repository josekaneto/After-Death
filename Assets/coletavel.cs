using UnityEngine;
using UnityEngine.SceneManagement;

public class coletavel : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"));
        {
            Destroy(col.gameObject);
            Destroy(this.gameObject);
            SceneManager.LoadScene("Vitoria");
        }

    }
}
