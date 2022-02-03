using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collisions : MonoBehaviour
{
    public GameObject target;

    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D other) {
        target = other.gameObject;
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
            }
        }
    }

}
