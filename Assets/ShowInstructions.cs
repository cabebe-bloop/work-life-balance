using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.UI;
using TMPro;

public class ShowInstructions : MonoBehaviour
{
        public TMP_Text UIInstructionText;

        // public GameObject gameOver;
        // public Player player;

    void Start()
    {
        UIInstructionText.enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown("space") && UIInstructionText.enabled)
        {
            UIInstructionText.enabled = false;
        } 
        // else if (Input.GetKeyDown("space") && !UIInstructionText.enabled)
        // {
        //     return;
        // }

        // if (player.gameOver)
        // {
        //     UIInstructionText.enabled = false;
        // }

        // if (gameOver)
        // {
        //     UIInstructionText.enabled = false;
        // }
    }

    public void OnTriggerEnter2D(Collider2D other)
    { if (other.gameObject.tag == "Player")
        {
            // UIInstructionText.SetActive(true);
            UIInstructionText.enabled = true;
            if (gameObject.tag == "Plant")
            {
                UIInstructionText.SetText("Press 'space' to water");
            } else if (gameObject.tag == "Nap Spot")
            {
                UIInstructionText.SetText("Press 'space' to nap");
            } else if (gameObject.tag == "Food")
            {
                UIInstructionText.SetText("Press 'space' to eat");
            }
        } else if (!other.gameObject)
        {
            return;
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            // UIInstructionText.SetActive(false);
            UIInstructionText.enabled = false;
        }
    }

}
