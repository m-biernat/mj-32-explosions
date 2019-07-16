using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    private void Awake()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag(gameObject.tag);

        if (objects.Length > 1) Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
    }
}
