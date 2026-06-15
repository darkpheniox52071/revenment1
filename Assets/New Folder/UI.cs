using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject optionsMenu;
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync("revenmet");

    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void ShowOptions()
    {
        mainMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }
    public void BackToMain()
    {
        optionsMenu.SetActive(false);
        mainMenu.SetActive(true);
    }
    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}