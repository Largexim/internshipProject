using System;
using UnityEngine;

public class MainCharacterMovement : MonoBehaviour
{
    [SerializeField] private float dodgeDistance = 1f;
    [SerializeField] private float dodgeDuration = 0.2f;
    [SerializeField] private GameObject player;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private bool isDodging = false;
    private Rigidbody2D rb2D;

    private void Start()
    {
        animator = player.GetComponent<Animator>();
        spriteRenderer = player.GetComponent<SpriteRenderer>();
    }

    void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!isDodging)
        {
            if (Input.GetKeyDown(KeyCode.RightArrow) && transform.position.x < 1.5f)
            {
                StartCoroutine(Dodge(Vector2.right));
            }
            else if (Input.GetKeyDown(KeyCode.LeftArrow) && transform.position.x > -1.5f)
            {
                StartCoroutine(Dodge(Vector2.left));
            }
        }
    }

    System.Collections.IEnumerator Dodge(Vector2 direction)
    {
        isDodging = true;
        animator.SetBool("Flag", true);
        if(direction == Vector2.right)
            spriteRenderer.flipX = true;

        Vector2 start = rb2D.position;
        Vector2 target = start + direction * dodgeDistance;
        float elapsed = 0f;

        while (elapsed < dodgeDuration)
        {
            rb2D.MovePosition(Vector2.Lerp(start, target, elapsed / dodgeDuration));
            elapsed += Time.fixedDeltaTime;
            yield return new WaitForFixedUpdate();
        }

        rb2D.MovePosition(target);
        isDodging = false;
        animator.SetBool("Flag", false);
        if(spriteRenderer.flipX)
            spriteRenderer.flipX = false;
    }
}
