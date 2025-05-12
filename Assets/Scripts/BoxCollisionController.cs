using System;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.U2D.Aseprite;
using UnityEngine;

public class BoxCollisionController : MonoBehaviour
{
    [SerializeField] private GameObject GOC;
    [SerializeField] private Animator animator;
    private SpriteRenderer spriteRenderer;
    BoxCollider2D c2D;
    bool collided = false;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Awake()
    {
        c2D = GetComponent<BoxCollider2D>();
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground") && !collided)
        {
            c2D.enabled = false;
            if (transform.position.z == -1)
                spriteRenderer.flipY = false;
            else
                spriteRenderer.flipY = true;
            
            animator.SetBool("Flag", true);
            
        }
        else if (other.gameObject.CompareTag("Box") && !collided)
        {
            c2D.enabled = false;
            if (transform.position.z == -1)
            {
                spriteRenderer.flipY = false;
                transform.position -= new Vector3(0, 0, 1);
            }
            else
                spriteRenderer.flipY = true;
            
            animator.SetBool("Flag", true);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            collided = true;
            other.gameObject.SetActive(false);
            GOC.GetComponent<GameOverController>().ShowAnimation();
        }
    }
}
