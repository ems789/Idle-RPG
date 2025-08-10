using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    private float speed = 3f;
    private float attackRange = .5f;
    private bool isFind = false;
    private GameObject enemy;
    private Rigidbody2D rb;

    private BoxCollider2D enemyCollider;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!isFind)
        {
            enemy = GameObject.FindWithTag("Enemys");
            enemyCollider = enemy.GetComponent<BoxCollider2D>();
            if (enemy != null)
            {
                isFind = true;                
                animator.SetBool("isRunning", true);
            }
        }

        Vector2 playerPos = transform.position;
        Vector2 surfacePoint = Physics2D.ClosestPoint(playerPos, enemyCollider);
        float dist = Vector2.Distance(playerPos, surfacePoint);
        UnityEngine.Debug.Log(dist);
        if (dist <= attackRange)
        {
            UnityEngine.Debug.Log("공격 가능");
            animator.SetBool("isAttack", true);
        }
        else
        {
            Vector2 dir = (surfacePoint - playerPos).normalized;
            Vector2 moveTarget = surfacePoint - dir * attackRange;
            transform.position = Vector2.MoveTowards(playerPos, moveTarget, Time.deltaTime * 3f);
        }
    }
}
