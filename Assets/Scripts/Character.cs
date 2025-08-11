using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    [Header("Stats")]
    public int maxHp = 10;
    public int hp;
    public int attackDamage = 1;
    public float attackRange = .5f;
    public float moveSpeed = 3f;

    protected Character target;

    protected Rigidbody2D rb;
    protected Animator animator;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        hp = maxHp;
    }

    protected virtual void Update()
    {
        UpdateTarget();
    }

    protected abstract void UpdateTarget();
}
