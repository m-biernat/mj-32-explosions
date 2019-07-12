using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text bombCount;
    [SerializeField] private Text level;

    [SerializeField] private Slider timer;

    [SerializeField] private GameObject gameManager;

    private BombManager _bombManager;
    private GameManager _gameManager;

    private float newValue;

    private void Start()
    {
        _bombManager = gameManager.GetComponent<BombManager>();
        _gameManager = gameManager.GetComponent<GameManager>();

        level.text = _gameManager.sceneName;

        timer.maxValue = _gameManager.time;
        timer.value = timer.maxValue;
        newValue = timer.value;
    }

    private void LateUpdate()
    {
        bombCount.text = _bombManager.maxBombCount.ToString();
        timer.value = Mathf.Lerp(timer.value, newValue, Time.deltaTime * 5f);
    }

    public void UpdateTimer()
    {
        newValue = Mathf.Floor(timer.value - 1f);
    }
}
