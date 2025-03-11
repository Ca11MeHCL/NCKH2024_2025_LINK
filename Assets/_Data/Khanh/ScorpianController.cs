using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScorpianController : MonoBehaviour
{
    public float speed = 2f; // T?c �? di chuy?n
    public float leftLimit = -3f; // Gi?i h?n b�n tr�i
    public float rightLimit = 3f; // Gi?i h?n b�n ph?i

    private bool movingRight = true; // Tr?ng th�i di chuy?n
    private bool isAttacking = false; // Tr?ng th�i t?n c�ng
    private Animator animator;
    private Transform player; // Tham chi?u �?n nh�n v?t

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (!isAttacking)
        {
            Move();
        }
    }

    void Move()
    {
        // Di chuy?n tr�i/ph?i
        if (movingRight)
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
            if (transform.position.x >= rightLimit)
            {
                Flip();
                movingRight = false;
            }
        }
        else
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
            if (transform.position.x <= leftLimit)
            {
                Flip();
                movingRight = true;
            }
        }

        animator.SetBool("isMoving", true); // Chuy?n animation sang Move
    }

    void Flip()
    {
        // L?t h�?ng b? c?p
        Vector3 newScale = transform.localScale;
        newScale.x *= -1;
        transform.localScale = newScale;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isAttacking = true;
            animator.SetTrigger("AttackTrigger"); // Chuy?n sang animation Attack
        }
    }

    // H�m n�y c� th? g?i t? animation event �? reset sau khi t?n c�ng
    public void EndAttack()
    {
        isAttacking = false;
        animator.SetBool("isMoving", true); // Ti?p t?c di chuy?n
    }
}
