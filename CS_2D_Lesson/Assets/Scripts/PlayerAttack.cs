using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] [Range(0, 5)] float cooldown;
    public bool canAttack = true;

    float cooldownDelta;
    Animator animator;
    public bool isAttacking;

    [SerializeField] GameObject bullet;
    Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Attack();
    }


    void GetAnimationInfo()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1 && isAttacking == true)
        {
            isAttacking = false;
        }
    }

    private void Attack()
    {
        if (Input.GetMouseButtonDown(0) && canAttack)
        {
            GameObject _projectile = Instantiate(bullet, transform.position, Quaternion.identity);
            _projectile.GetComponent<BulletBehaviour>().direction = rb.velocity;

            canAttack = false;
            isAttacking = true;
            cooldownDelta = cooldown;
        }

        if (canAttack == false)
        {
            cooldownDelta -= Time.deltaTime;

            if (cooldownDelta <= 0)
            {
                canAttack = true;
            }
        }
    }
}
