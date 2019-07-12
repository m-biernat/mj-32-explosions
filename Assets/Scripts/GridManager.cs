using UnityEngine;

public class GridManager : MonoBehaviour
{
    private const int GRID_LAYER_INDEX = 9;

    [SerializeField] private GameObject grid;

    [SerializeField] private Material defaultMaterial;
    [SerializeField] private Material selectionMaterial;

    [HideInInspector] public Transform selection;
    private Transform _selection;

    private void Update()
    {
        if (_selection != null)
        {
            Renderer selectionRenderer = _selection.GetComponent<Renderer>();
            selectionRenderer.material = defaultMaterial;
            _selection = null;
        }

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            selection = hit.transform;

            if (selection.gameObject.layer == GRID_LAYER_INDEX)
            {
                Renderer selectionRenderer = selection.GetComponent<Renderer>();

                if (selectionRenderer != null)
                {
                    selectionRenderer.material = selectionMaterial;
                }

                _selection = selection;
            }
            else
            {
                selection = null;
            }
        }
    }

    public void Disable()
    {
        selection = null;
        grid.SetActive(false);
        enabled = false;
    }
}
