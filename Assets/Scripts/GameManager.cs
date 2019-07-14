using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    [SerializeField] private UIManager gameUI;

    private GridManager gridManager;

    [SerializeField] private Animator fadeAnimator;
    [SerializeField] private Animator clearAnimator;

    public int time;

    public static List<Destructable> destructables;

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
                bomb.Activate();
                yield return new WaitForSeconds(.5f);
            }
        }

        yield return new WaitForSeconds(.5f);

        CompleteLevel();

        yield return new WaitForSeconds(1f);

        fadeAnimator.SetTrigger("FadeOut");
    }

    private void CompleteLevel()
    {
        bool areAllObjectsDestroyed = true;

        foreach (Destructable item in destructables)
        {
            if (item.destroyed == false)
            {
                Debug.Log(item.name + " " + item.destroyed);
                areAllObjectsDestroyed = false;
            }
        }

        destructables.Clear();
        destructables = null;

        if (areAllObjectsDestroyed == true)
        {
            LevelChanger.levelIndex++;
            clearAnimator.SetTrigger("Clear");
        }
    }

}
