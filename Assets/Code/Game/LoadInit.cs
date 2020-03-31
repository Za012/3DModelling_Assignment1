using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadInit : MonoBehaviour
{
    public int levelId;
    private void Awake()
    {
        Debug.Log("Level Start");
        Scene levelGame = SceneManager.GetSceneByName("GameInit");
        if (!levelGame.isLoaded)
        {
            SceneManager.LoadScene("GameInit", LoadSceneMode.Single);
        }

    }
    private void Start()
    {
        if (levelId != 0)
        {
            Game.CURRENTLEVEL = levelId;
            Game.UI.ChangeLevelText($"LEVEL: {levelId}");
        }
    }
}
