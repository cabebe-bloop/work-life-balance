using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
    // public SpriteRenderer spriteRenderer;
    // [SerializeField] Color32 plantColor1 = new Color32 (1, 1, 1, 1);
    // [SerializeField] Color32 plantColor2 = new Color32 (1, 1, 1, 1);

    // public bool isBeingWatered = false;

    // public bool recentlyWatered;

    // // will probably need to be named player
    // public GameObject player;

    // void Start()
    // {
    //     spriteRenderer = GetComponent<SpriteRenderer>();
    // }

    // void OnTriggerEnter2D(Collider2D other) {
    //     player = other.gameObject;
    // }

    // void OnTriggerExit2D(Collider2D other) {
    //     player = null;
    // }

    // void Update()
    // {
    //     if (Input.GetKeyDown("space"))
    //     {   if (!player)
    //         {
    //             return;
    //         }
    //         if (player.tag == "Player") 
    //         {
    //             WaterPlant();
    //         }
    //     }
    // }

    // public void WaterPlant() 
    // {
    //     Debug.Log("I'm watering Plant!");
    //     StartCoroutine(PlantColorFlash());
    // }

    // IEnumerator PlantColorFlash () 
    // {
    //     isBeingWatered = true;
    //     for (int i = 0; i < 5; i++) {
    //         spriteRenderer.color = plantColor1;
    //         yield return new WaitForSeconds(.13f);
    //         spriteRenderer.color = plantColor2;
    //         yield return new WaitForSeconds(.13f);
    //     }
    //     isBeingWatered = false;
    //     recentlyWatered = false;
    // }
}
