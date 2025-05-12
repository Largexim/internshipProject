using System.Collections;
using UnityEngine;

public class BoxFallingLogic : MonoBehaviour
{
    private Rigidbody2D rb2D;
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        StartCoroutine(IncreaseGravity());
    }

    IEnumerator IncreaseGravity()
    {
        for (int i = 10; i > 0; i--)
        {
            yield return new WaitForSeconds(0.1f);
            if(rb2D.linearDamping > 0)
                rb2D.linearDamping--;
        }
    }
}





//c++ array wrong index