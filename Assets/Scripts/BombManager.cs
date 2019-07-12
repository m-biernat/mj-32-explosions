using UnityEngine;
using System.Collections.Generic;

public class BombManager : MonoBehaviour
{
    private GridManager gridManager;

    [SerializeField] private GameObject bombPrefab;

    private int bombCount = 0;
    public int maxBombCount;

    public static List<Bomb> activeBombList;

    private void Start ()
    {
        gridManager = GetComponent<GridManager>();
        activeBombList = new List<Bomb>();
	}

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Transform selection = gridManager.selection;

            if (selection != null && maxBombCount > 0)
            {
                GameObject instance;
                instance = Instantiate(bombPrefab, selection.position, bombPrefab.transform.rotation);
                Bomb bomb = instance.GetComponent<Bomb>();
                activeBombList.Add(bomb);
                selection.gameObject.SetActive(false);
                maxBombCount--;
                bombCount++;
                bomb.SetLabelText(bombCount);
            }
        }

        if (maxBombCount == 0 && gridManager.isActiveAndEnabled)
        {
            gridManager.Disable();
        }
    }
}
