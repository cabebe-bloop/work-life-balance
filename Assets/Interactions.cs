using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.UI;

public class Interactions : MonoBehaviour
{
    public Player player;
    public SpriteRenderer spriteRenderer;
    public SpriteRenderer targetSpriteRenderer;

    public Animator playerAnimator;

    // public GameObject InstructionText;

    [SerializeField] Color32 beingWatered = new Color32 (1, 1, 1, 1);
    [SerializeField] Color32 plantDefault = new Color32 (1, 1, 1, 1);
    public GameObject target;

    public bool plantBeingWatered = false;
    public bool isNapping = false;
    public bool isEating = false;

    public Spawner spawner;

    void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void OnTriggerEnter2D(Collider2D other) {
        target = other.gameObject;
        targetSpriteRenderer = other.GetComponent<SpriteRenderer>();   
    }

    void OnTriggerExit2D(Collider2D other) {
        target = null;
    }
    void Update() {           
        if (Input.GetKeyDown("space") && !player.gameOver)
        {   if (!target)
            {
                return;
            }
            if (target.tag == "Plant") 
            {
                WaterPlant();
                return;
            }
            if (target.tag == "Nap Spot")
            {
                Nap();
            }
            if (target.tag == "Food")
            {
                Eat();
            }
            if (target.tag == "Egg")
            {
                EatEgg();
            }
            
        }
    }

    public void Nap() 
    {
        // turn off player sprite renderer + disable movement buttons 
        // When space is pressed, make animation of sprite show up on couch for 3 seconds
        
        player.AddPhysHealth(10);
        isNapping = true;
        StartCoroutine(NapTime());
        playerAnimator.SetBool("Asleep", true);
        Debug.Log("Zzzzzzz");
    }
    public void WaterPlant() 
    {   
        player.AddEmoHealth(5);
        plantBeingWatered = true;
        StartCoroutine(PlantColorFlash());
        Debug.Log("I'm watering Plant!");
    }

    public void Eat()
    {
        player.AddPhysHealth(5);
        isEating = true;
        StartCoroutine(FoodGetsEaten());
        Debug.Log("FOOD");
    }

    public void EatEgg()
    {
        player.AddPhysHealth(5);
        isEating = true;
        spawner.eggThere = false;
        StartCoroutine(FoodGetsEaten());
        Debug.Log("EGG");
    }

    IEnumerator FoodGetsEaten()
    {
        if (target.tag == "Food" || target.tag == "Egg")
        {
            Destroy(target);
            yield return new WaitForSeconds(.5f);
            isEating = false;
        }
    }
    IEnumerator PlantColorFlash () 
    {
        // if (!target)
        // {
        //     yield return null;
        // }
        for (int i = 0; i < 5; i++) {
            targetSpriteRenderer.color = beingWatered;
            yield return new WaitForSeconds(.13f);
            targetSpriteRenderer.color = plantDefault;
            yield return new WaitForSeconds(.13f);
        }
        targetSpriteRenderer.color = plantDefault;
        plantBeingWatered = false;
        // player.recentEmoAction = false;
    }

    IEnumerator NapTime ()
    {
        yield return new WaitForSeconds(2);
        playerAnimator.SetBool("Asleep", false);
        isNapping = false;
        // player.recentPhysAction = false;
    }
}
