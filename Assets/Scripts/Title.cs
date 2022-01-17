using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Title : MonoBehaviour
{
    public Button start, quit;

    private void Start()
    {
        start.onClick.AddListener(SwitchScene);
        start.OnPointerEnter(null);
        quit.onClick.AddListener(Quit);
    }

    private void Quit()
    {
        Application.Quit();
    }

    private void SwitchScene()
    {
        SceneManager.LoadScene(1);
    }
}