using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{
    public Animator animator;
    public Transform attackPoint;
    public LayerMask attackLayer;
    public LayerMask blockLayer;

    public float attackRange = 0.5f;
    public int attackDamage = 20;
    public float attackRate = 2f;
    public float nextAttack = 0f;
    private bool _isAttacking;
    private bool letAttack = true;
    // Update is called once per frame
    void Update()
    {
        if (letAttack == true)
        {
            if (Time.time >= nextAttack)
            {
                if (Input.GetKeyDown(KeyCode.X))
                {
                    Attack();
                    nextAttack = Time.time + 1f / attackRate;

                }
                if (Input.GetKeyDown(KeyCode.C))
                {

                    Block();
                    nextAttack = Time.time + 1f / attackRate;
                }
                if (Input.GetKeyDown(KeyCode.V))
                {

                    Throw();
                    nextAttack = Time.time + 1f / attackRate;
                }
            }
        }

    }

    void CanNotAttack()
    {
        letAttack = false;
    }

    void CanAttack()
    {
        letAttack = true;
    }

    void Attack()
    {
        animator.SetTrigger("Attack1");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, attackLayer);

        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("We hit " + enemy.name);
            enemy.GetComponent<Player2Health>().TakeDamage(attackDamage);
        }
    }

    void BlockFlase()
    {

        gameObject.layer = 8;

    }


    void Block()
    {
        animator.SetTrigger("Block");
        if (Input.GetKeyDown(KeyCode.C))
        {
            animator.SetBool("IdleBlock", true);
            gameObject.layer = 9;
        }
        

    }

    void Throw()
    {
        animator.SetTrigger("Attack3");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, blockLayer);

        foreach (Collider2D enemy in hitEnemies)
        {
            Debug.Log("We hit " + enemy.name);
            enemy.GetComponent<Player2Health>().TakeDamage(attackDamage);
        }

    }

   
  
    void OnDrawGizmosSelected()
    {
 
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
