using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    public bool recentEmoAction = false;
    public bool recentPhysAction = false;

    public Plant currentPlant;

    void Start() {
        currentPhysHealth = maxHealth;
        currentEmoHealth = maxHealth;
        physHealthBar.SetMaxHealth(maxHealth);
        emoHealthBar.SetMaxHealth(maxHealth);
    }

    // public void OnTriggerEnter2D(Collider2D other)
    // {
    //     if (other.tag == "Plant")
    //     {
    //         GameObject thisPlant = other.gameObject;
    //         currentPlant = thisPlant;
    //     }
    // }

    void Update()
    {   
        movement.x = (interaction.isNapping) ? 0 : Input.GetAxis("Horizontal");
        movement.y = (interaction.isNapping) ? 0: Input.GetAxis("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.magnitude);

        DecreaseEmoHealth();
        DecreasePhysHealth();

        if (interaction.plantBeingWatered && Input.GetKeyDown("space"))
        {    
            // seems to be running multiple times (maybe for the entire duration the condition is true?)
            // how can I say "only run this once"
            if (recentEmoAction)
            {
                return;
            } else if (!recentEmoAction)
            {
                recentEmoAction = true;
                AddEmoHealth(5);
            }
        }

        if (interaction.isNapping && Input.GetKeyDown("space"))
        {
            if (recentPhysAction)
            {
                return;
            } else if (!recentPhysAction)
            {
                recentPhysAction = true;
                AddPhysHealth(10);
                animator.SetBool("Asleep", true);
            }
        }

        if (interaction.isEating && Input.GetKeyDown("space"))
        {
            AddPhysHealth(5);
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    public void DecreaseEmoHealth ()
    {
        if (currentEmoHealth > 0) 
        {
            if (interaction.plantBeingWatered)
            {
                StartCoroutine(Wait(2));
            } else
            {
                StartCoroutine(Wait(2));
                currentEmoHealth -= 0.03f;
                emoHealthBar.SetHealth(currentEmoHealth);
            }
        } 
    }

    public void DecreasePhysHealth ()
    {
        if (currentPhysHealth > 0)
        {
            if (interaction.isNapping || interaction.isEating)
            {
                StartCoroutine(Wait(5));
            } else
            {
                StartCoroutine(Wait(10));
                currentPhysHealth -= 0.03f;
                physHealthBar.SetHealth(currentPhysHealth);
            }
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
        currentEmoHealth += health;
        emoHealthBar.SetHealth(currentEmoHealth);
    }

}
