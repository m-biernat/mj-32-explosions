using UnityEngine;
using UnityEngine.UI;

public class Bomb : MonoBehaviour
{
    [SerializeField] private Text label;

    [HideInInspector] public bool activated;

    private float power = 10f;
    private float radius = 5f;
    private float upForce = 1f;

    private void Start()
    {
        activated = false;
    }

    public void SetLabelText(int number)
    {
        label.gameObject.SetActive(true);
        label.text = number.ToString();
    }

    public void Activate()
    {
        Debug.Log("Ding " + label.text);
        activated = true;
        gameObject.SetActive(false);
    }

    private void Detonate()
    {
        Vector3 explosionPosition = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPosition, radius);

        foreach (Collider hit in colliders)
        {

        }
    }
}
