using System.Xml.Linq;
using Mono.Cecil.Cil;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
public class Controles : MonoBehaviour
{
    private Button botaoSair;
    private UIDocument document;
    private void Awake()
    {
        document = GetComponent<UIDocument>();
        botaoSair = document.rootVisualElement.Q<Button>("botaosairControles");
        botaoSair.RegisterCallback<ClickEvent>(OnPlayGame);
        if (botaoSair != null)
        {
            botaoSair.RegisterCallback<ClickEvent>(OnPlayGame);
        }
    }
    void OnPlayGame(ClickEvent evt)
    {
        SceneManager.LoadScene("Menu");
    }
   
}
