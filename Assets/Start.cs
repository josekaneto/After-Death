using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;


public class Start : MonoBehaviour
{
    private UIDocument document;
    private Button botaostart;


    private void Awake()
    {
        document = GetComponent<UIDocument>();
        botaostart = document.rootVisualElement.Q<Button>("botaoIniciar");
        botaostart.RegisterCallback<ClickEvent>(OnPlayGame);
    }
    void OnPlayGame(ClickEvent evt)
    {
        SceneManager.LoadScene("CenaPrincipal");
    }
}