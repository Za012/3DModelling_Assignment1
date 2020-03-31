using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameInit : MonoBehaviour
{
    private void Awake()
    {
        StartCoroutine(LoadGame());
    }
    private IEnumerator LoadGame()
    {
        Debug.Log("Loading...");
        SceneManager.LoadScene(
            "Level1", LoadSceneMode.Additive);
        SceneManager.LoadScene(
            "UIScene", LoadSceneMode.Additive);
        yield return null;
        Debug.Log("Loaded.");
        InitGame();
    }

    public void InitGame()
    {
        Game.UI.ChangeAnnouncementText("Get the cube into the goal! \n Stuck? Press R to Retry",2);
    }
}
