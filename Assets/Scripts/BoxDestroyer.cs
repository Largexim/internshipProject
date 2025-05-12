using UnityEngine;

public class BoxDestroyer : MonoBehaviour
{
    void Update()
    {
        if(transform.position.y < -6)
            Destroy(gameObject);
    }
}
