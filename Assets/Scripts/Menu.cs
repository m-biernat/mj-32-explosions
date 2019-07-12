using UnityEngine;

public class Menu : MonoBehaviour
{
    [SerializeField] private int nextLevelIndex;
    [SerializeField] private Animator animator;

	private void OnEnable ()
    {
        LevelChanger.levelIndex = nextLevelIndex;
	}

	private void Update ()
    {
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("FadeOut");
        }
    }
}
