using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{   
    Vector2 movement; 
    [SerializeField]float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Animator animator;
    public float maxHealth = 50f;
    public float currentPhysHealth;
    public float currentEmoHealth;
    public HealthBar physHealthBar;
    public HealthBar emoHealthBar;
    public Interactions interaction;
    // public bool recentEmoAction = false;
    // public bool recentPhysAction = false;

    public TMP_Text instructions;

    // public Plant currentPlant;
    public bool gameOver = false;

    public GameObject gameOverScreen;

    void Start() {
        currentPhysHealth = maxHealth;
        currentEmoHealth = maxHealth;
        physHealthBar.SetMaxHealth(maxHealth);
        emoHealthBar.SetMaxHealth(maxHealth);

        InvokeRepeating("DecreaseEmoHealth", 2, 0.03f);
        InvokeRepeating("DecreasePhysHealth", 2, 0.03f);

        gameOver = false;
        gameOverScreen.SetActive(false);
        // add dead bool as false? 
    }

    // public void OnTriggerEnter2D(Collider2D other)
    // {
    //     if (other.tag == "Plant")
    //     {
    //         GameObject thisPlant = other.GetComponent<Plant>();
    //     }
    // }

    void Update()
    {   
        movement.x = (interaction.isNapping || gameOver) ? 0 : Input.GetAxis("Horizontal");
        movement.y = (interaction.isNapping || gameOver) ? 0: Input.GetAxis("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.magnitude);

        // DecreaseEmoHealth();
        // DecreasePhysHealth();

        EndGame();

        // if (!gameOver)
        // {
        //     // if (interaction.plantBeingWatered && Input.GetKeyDown("space"))
        //     // {    
        //     //     // if (recentEmoAction)
        //     //     // {
        //     //     //     return;
        //     //     // } else if (!recentEmoAction)
        //     //     // {
        //     //         // recentEmoAction = true;
        //     //     // interaction.WaterPlant();
        //     //     // AddEmoHealth(5);
        //     //     // }
        //     // }

        //     // if (interaction.isNapping && Input.GetKeyDown("space"))
        //     // {
        //     //     // if (recentPhysAction)
        //     //     // {
        //     //     //     // animator.SetBool("Asleep", true);
        //     //     //     return;
        //     //     // } else if (!recentPhysAction)
        //     //     // {
        //     //         // recentPhysAction = true;
        //     //     // AddPhysHealth(10);
        //     //         // animator.SetBool("Asleep", true);
        //     //     // }
        //     // }

        //     // if (interaction.isEating && Input.GetKeyDown("space"))
        //     // {
        //     //     AddPhysHealth(5);
        //     // }
        // }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    public void DecreaseEmoHealth ()
    {
        if (currentEmoHealth > 0 && currentEmoHealth < 51) 
        {
            if (gameOver)
            {
                return;
            }
            if (interaction.plantBeingWatered)
            {
                // StartCoroutine(Wait(5));
                return;
            } 
            else
            {
                // StartCoroutine(Wait(2));
                currentEmoHealth -= 0.1f;
                emoHealthBar.SetHealth(currentEmoHealth);
            }
        } if (currentEmoHealth > 50)
        {
            currentEmoHealth = 50;
        }
    }

    public void DecreasePhysHealth ()
    {
        if (currentPhysHealth > 0 && currentPhysHealth < 51)
        {
            if (gameOver)
            {
                return;
            }
            if (interaction.isNapping || interaction.isEating)
            {
                // StartCoroutine(Wait(5));
                return;
            } else
            {
                // StartCoroutine(Wait(100));
                currentPhysHealth -= 0.1f;
                physHealthBar.SetHealth(currentPhysHealth);
            }
        } if (currentPhysHealth > 50)
        {
            currentPhysHealth = 50;
        }
    }

    IEnumerator Wait (float seconds) 
    {
        yield return new WaitForSeconds(seconds);
    }
    public void AddPhysHealth (float health) 
    {
        currentPhysHealth += health;
        physHealthBar.SetHealth(currentPhysHealth);
    }
    
    public void AddEmoHealth (float health) 
    {
        Debug.Log("adding emo health!");
        currentEmoHealth += health;
        emoHealthBar.SetHealth(currentEmoHealth);
    }

    public void EndGame ()
    {
        if (currentPhysHealth <= 0 || currentEmoHealth <= 0)
        {
            // Debug.Log("Game over!");
            animator.SetBool("Asleep", false);
            animator.SetBool("Dead", true);
            instructions.enabled = false;
            gameOver = true;
            gameOverScreen.SetActive(true);
        }
    }

}
