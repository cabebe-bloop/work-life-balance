using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EggTriggerText : MonoBehaviour
{
    [SerializeField] Spawner eggSpawner;
    public TMP_Text instructions;
    // public Player player;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && eggSpawner.eggThere)
        {   
            instructions.enabled = true;
            instructions.SetText("Press 'space' to eat");
        }
        else if (!eggSpawner.eggThere)
        {
            instructions.enabled = false;
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            instructions.enabled = false;
        }
    }

}
