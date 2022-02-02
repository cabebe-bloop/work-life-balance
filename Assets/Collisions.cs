using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collisions : MonoBehaviour
{
    // Start is called before the first frame update
    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Whoops!");
    }

}
