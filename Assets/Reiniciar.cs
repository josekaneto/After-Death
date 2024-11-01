using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Reiniciar : MonoBehaviour
{
    private UIDocument document;
    private Button botaoReiniciar;
    private Button botaoSair;

    private void Awake()
    {
        document = GetComponent<UIDocument>();
        botaoReiniciar = document.rootVisualElement.Q<Button>("botaoreiniciar");
        botaoSair = document.rootVisualElement.Q<Button>("botaosair");
        botaoSair.RegisterCallback<ClickEvent>(OnPlayGame);
        if (botaoReiniciar != null)
        {
            botaoReiniciar.RegisterCallback<ClickEvent>(OnRestartGame);
        }
        else if (botaoSair != null)
        {
            botaoSair.RegisterCallback<ClickEvent>(OnPlayGame);
        }
    }

    void OnRestartGame(ClickEvent evt)
    {
        SceneManager.LoadScene("CenaPrincipal");
    }
    void OnPlayGame(ClickEvent evt)
    {
        SceneManager.LoadScene("Menu");
    }
}
