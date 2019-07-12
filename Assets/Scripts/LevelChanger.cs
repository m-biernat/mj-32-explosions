using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelChanger : MonoBehaviour
{
    public static int levelIndex = 0;

    public void OnLoad()
    {
        GameObject gameManager = GameObject.FindWithTag("GameManager");

        if (gameManager != null)
        {
            gameManager.GetComponent<GameManager>().Begin();
        }
    }

    public void LoadLevel()
    {
        SceneManager.LoadScene(levelIndex, LoadSceneMode.Single);
    }
}
