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
                targetSpriteRenderer.color = beingWatered;
            }
        }
    }

}
