using UnityEngine;
using UnityEngine.SceneManagement;


public class CanvasSwapper : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject creditsMenu;


    void Start()
    {
        BackToMenu(); 
    }

    public void PlayGame()
    {
        int sceneNum = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(sceneNum + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ActivateCredits()
    {
        creditsMenu.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void BackToMenu()
    {
        mainMenu.SetActive(true);
        creditsMenu.SetActive(false);
    }
}
