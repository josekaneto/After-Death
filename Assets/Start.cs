using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;


public class Start : MonoBehaviour
{
    private UIDocument document;
    private Button botaostart;
    private Button botaoControle;


    private void Awake()
    {
        document = GetComponent<UIDocument>();
        botaostart = document.rootVisualElement.Q<Button>("botaoIniciar");
        botaostart.RegisterCallback<ClickEvent>(OnPlayGame);
        botaoControle = document.rootVisualElement.Q<Button>("botaoControles");
        botaoControle.RegisterCallback<ClickEvent>(OnRestartGame);
    }
    void OnPlayGame(ClickEvent evt)
    {

       if (botaostart != null)
        {
            SceneManager.LoadScene("CenaPrincipal");
        }
      
    }
    void OnRestartGame(ClickEvent evt)
    {

        if (botaoControle != null)
        {
            SceneManager.LoadScene("Controles");
        }

    }
}