using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : Character
{
    private bool isFind = false;
    private GameObject enemy;

    private BoxCollider2D enemyCollider;

    protected override void UpdateTarget()
    {
        if (!isFind)
        {
            enemy = GameObject.FindWithTag("Enemys");
            enemyCollider = enemy.GetComponent<BoxCollider2D>();            
        }        
    }
    protected override void Move()
    {
        if (enemy != null)
        {
            isFind = true;
            animator.SetBool("isRunning", true);
        }

        Vector2 playerPos = transform.position;
        Vector2 surfacePoint = Physics2D.ClosestPoint(playerPos, enemyCollider);
        float dist = Vector2.Distance(playerPos, surfacePoint);
        UnityEngine.Debug.Log(dist);

        if (dist <= attackRange)
        {
            canAttack = true;
            UnityEngine.Debug.Log("공격 가능");
            
        }
        else
        {
            canAttack = false;
            Vector2 dir = (surfacePoint - playerPos).normalized;
            Vector2 moveTarget = surfacePoint - dir * attackRange;
            transform.position = Vector2.MoveTowards(playerPos, moveTarget, Time.deltaTime * 3f);
        }
    }

    protected override void Attack()
    {
        if (canAttack)
        {
            animator.SetBool("isAttack", true);
        }
    }
}
