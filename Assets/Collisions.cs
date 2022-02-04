using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collisions : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public SpriteRenderer targetSpriteRenderer;

    [SerializeField] Color32 beingWatered = new Color32 (1, 1, 1, 1);
    [SerializeField] Color32 plantDefault = new Color32 (1, 1, 1, 1);
    public GameObject target;

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
        if (Input.GetKeyDown("space"))
        {   if (!target)
            {
                return;
            }

            if (target.tag == "Plant") 
            {
                Debug.Log("I'm watering Plant!");
                StartCoroutine(waterPlant());
                // increase emotional health bar
            }
        }
    }

    IEnumerator waterPlant () 
    {
        // learn how to write a for loop in C# for this
        targetSpriteRenderer.color = beingWatered;
        yield return new WaitForSeconds(.15f);
        targetSpriteRenderer.color = plantDefault;
        yield return new WaitForSeconds(.15f);
        targetSpriteRenderer.color = beingWatered;
        yield return new WaitForSeconds(.15f);
        targetSpriteRenderer.color = plantDefault;
        yield return new WaitForSeconds(.15f);
        targetSpriteRenderer.color = beingWatered;
        yield return new WaitForSeconds(.15f);
        targetSpriteRenderer.color = plantDefault;
        yield return new WaitForSeconds(.15f);
        targetSpriteRenderer.color = beingWatered;
        yield return new WaitForSeconds(.15f);
        targetSpriteRenderer.color = plantDefault;
    }
}
