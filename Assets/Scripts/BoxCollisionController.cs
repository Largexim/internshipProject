using System;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.U2D.Aseprite;
using UnityEngine;

public class BoxCollisionController : MonoBehaviour
{
    [SerializeField] private GameObject GOC;
    BoxCollider2D c2D;
    bool collided = false;

    private void Awake()
    {
        c2D = GetComponent<BoxCollider2D>();
    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground") && !collided)
            c2D.enabled = false;
        
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
