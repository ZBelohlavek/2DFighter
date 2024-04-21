using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Player2Health : MonoBehaviour
{
    public int maxHealth = 100;
    int currentHealth;
    public Animator animator;
    private player2Combat myCombat;
    private PlayerMovement myMovement;
    private bool isDead = false;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        myCombat = GetComponent<player2Combat>();
        myMovement = GetComponent<PlayerMovement>();
        //healthbar.SetMaxHealthbar(maxHealth);
    }

    public void TakeDamage(int damage)
    {
        if (isDead == false)
        {
            currentHealth -= damage;


            animator.SetTrigger("Hurt");
            //healthbar.SetHealthbar(currentHealth);


            if (currentHealth <= 0)
            {
                Die();
            }
        }
    }

    
    public void Die()
    {
        animator.SetBool("IsDead", true);
        this.enabled = false;
        myCombat.enabled = false;
        myMovement.enabled = false;


    }
    void amDead()
    {
        isDead = true;
    }

    void endGame()
    {
        Debug.Log("GameOver");
        Invoke("gameOver", 5f);
    }

    void gameOver()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
