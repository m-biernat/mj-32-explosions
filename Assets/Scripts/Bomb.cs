using UnityEngine;
using UnityEngine.UI;

public class Bomb : MonoBehaviour
{
    [SerializeField] private Text label;

    [HideInInspector] public bool activated;

    private const float POWER = 14f, RADIUS = 3f, UP_FORCE = 1f;

    [SerializeField] private GameObject explosionFx;

    private void Start()
    {
        activated = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 10 && tag == "PassiveBomb")
        {
            Trigger();
        }
    }

    public void SetLabelText(int number)
    {
        label.gameObject.SetActive(true);
        label.text = number.ToString();
    }

    public void Activate()
    {
        // Debug.Log("Ding " + label.text);
        activated = true;
        Detonate();
        gameObject.SetActive(false);
    }

    public void Trigger()
    {
        if (!activated)
        {
            activated = true;
            Invoke("Activate", .25f);
        }
    }

    private void Detonate()
    {
        Vector3 explosionPosition = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPosition, RADIUS);

        GameObject fx;
        fx = Instantiate(explosionFx, transform.position, explosionFx.transform.rotation);
        Destroy(fx, .5f);

        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();

            if (rb != null)
            {
                rb.AddExplosionForce(POWER, explosionPosition, RADIUS, UP_FORCE, ForceMode.Impulse);
            }

            if (hit.tag == "PassiveBomb")
            {
                hit.GetComponent<Bomb>().Trigger();
            }
        }
    }
}
