using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
    [SerializeField] private UIManager gameUI;

    [HideInInspector] public string sceneName;

    public int time;

    private GridManager gridManager;

    private void Start()
    {
        gameUI.enabled = true;
        sceneName = SceneManager.GetActiveScene().name;
        gridManager = GetComponent<GridManager>();

        StartCoroutine(TimeCounter());
    }

    private IEnumerator TimeCounter()
    {
        int timeLeft = time;

        while (timeLeft >= 0)
        {
            timeLeft--;
            gameUI.UpdateTimer();
            yield return new WaitForSeconds(1f);
        }

        StartCoroutine(ActivateBombs());
    }

    private IEnumerator ActivateBombs()
    {
        gridManager.Disable();

        foreach (Bomb bomb in BombManager.activeBombList)
        {
            if (!bomb.activated)
            { 
                yield return new WaitForSeconds(.5f);
                bomb.Activate();
            }
        }

        yield return new WaitForSeconds(2f);

        Debug.Log("The End!");
    }
}
