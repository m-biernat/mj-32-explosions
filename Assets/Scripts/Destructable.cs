using UnityEngine;
using System.Collections.Generic;

public class Destructable : MonoBehaviour
{
    [HideInInspector] public bool destroyed;

    private void Start()
    {
        destroyed = false;

        if (GameManager.destructables == null)
        {
            GameManager.destructables = new List<Destructable>();
        }

        if (GameManager.destructables != null)
        {
            GameManager.destructables.Add(this);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 10)
        {
            destroyed = true;
        }
    }
}
