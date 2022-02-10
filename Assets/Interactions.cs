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
                waterPlant();
            }

            if (target.tag == "Nap Spot")
            {
                Nap();
            }
        }
    }

    public void Nap() 
    {
        // turn off player sprite renderer + disable movement buttons 
        // When space is pressed, make animation of sprite show up on couch for 3 seconds
        StartCoroutine(napTime());
        Debug.Log("Zzzzzzz");
    }
    public void waterPlant() 
    {
        Debug.Log("I'm watering Plant!");
        StartCoroutine(plantColorFlash());
    }
    IEnumerator plantColorFlash () 
    {
        plantBeingWatered = true;
        for (int i = 0; i < 5; i++) {
            targetSpriteRenderer.color = beingWatered;
            yield return new WaitForSeconds(.13f);
            targetSpriteRenderer.color = plantDefault;
            yield return new WaitForSeconds(.13f);
        }
        plantBeingWatered = false;
        player.recentAction = false;
    }

    IEnumerator napTime ()
    {
        isNapping = true;
        yield return new WaitForSeconds(2);
        isNapping = false;
        playerAnimator.SetBool("Asleep", false);
    }
}
