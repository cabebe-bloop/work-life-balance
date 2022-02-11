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

    void Start() {
        spriteRenderer = GetComponent<SpriteRenderer>();
        // instructionsText = GetComponent<Text>();
    }
    void OnTriggerEnter2D(Collider2D other) {
        target = other.gameObject;
        targetSpriteRenderer = other.GetComponent<SpriteRenderer>();
        // instructionsText.enabled = !instructionsText.enabled;
    }

    void OnTriggerExit2D(Collider2D other) {
        target = null;
    }
    void Update() {           
        if (Input.GetKeyDown("space"))
        {   if (!target)
            {
                return;
            }
            if (target.tag == "Plant") 
            {
                WaterPlant();
            }
            if (target.tag == "Nap Spot")
            {
                Nap();
            }
            if (target.tag == "Food")
            {
                Eat();
            }
            
        }
    }

    public void Nap() 
    {
        // turn off player sprite renderer + disable movement buttons 
        // When space is pressed, make animation of sprite show up on couch for 3 seconds
        StartCoroutine(NapTime());
        Debug.Log("Zzzzzzz");
    }
    public void WaterPlant() 
    {
        Debug.Log("I'm watering Plant!");
        StartCoroutine(PlantColorFlash());
    }

    public void Eat()
    {
        Debug.Log("Yum!");
        StartCoroutine(FoodGetsEaten());
    }

    IEnumerator FoodGetsEaten()
    {
        isEating = true;
        // byte i = 225;
        for (byte i = 255; i > 20; i -= 45)
        {
            if (i < 20)
            {
                break;
            }
            targetSpriteRenderer.color = new Color32 (255, 255, 255, i);
            yield return new WaitForSeconds(.13f);
        }
        // targetSpriteRenderer.color = new Color32 (255, 255, 255, 170);
        // yield return new WaitForSeconds(.13f);
        // targetSpriteRenderer.color = new Color32 (255, 255, 255, 120);
        // yield return new WaitForSeconds(.13f);
        // targetSpriteRenderer.color = new Color32 (255, 255, 255, 80);
        // yield return new WaitForSeconds(.13f);
        // targetSpriteRenderer.color = new Color32 (255, 255, 255, 20);
        // yield return new WaitForSeconds(.13f);
        isEating = false;
    }
    IEnumerator PlantColorFlash () 
    {
        plantBeingWatered = true;
        for (int i = 0; i < 5; i++) {
            targetSpriteRenderer.color = beingWatered;
            yield return new WaitForSeconds(.13f);
            targetSpriteRenderer.color = plantDefault;
            yield return new WaitForSeconds(.13f);
        }
        plantBeingWatered = false;
        player.recentEmoAction = false;
    }

    IEnumerator NapTime ()
    {
        isNapping = true;
        yield return new WaitForSeconds(2);
        playerAnimator.SetBool("Asleep", false);
        isNapping = false;
        player.recentPhysAction = false;
    }
}
