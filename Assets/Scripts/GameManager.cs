using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    [SerializeField] private UIManager gameUI;

    private GridManager gridManager;

    public int time;

    [SerializeField] private Animator animator;

    private void Start()
    {
        gameUI.enabled = true;
        gridManager = GetComponent<GridManager>();
    }

    public void Begin()
    {
        StartCoroutine(TimeCounter());
    }

    private IEnumerator TimeCounter()
    {
        yield return new WaitForSeconds(.5f);

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

        yield return new WaitForSeconds(3f);

        Debug.Log("The End!");
        animator.SetTrigger("FadeOut");
    }
}
