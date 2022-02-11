using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.UI;
using TMPro;

public class ShowInstructions : MonoBehaviour
{
        public TMP_Text UIInstructionText;

    void Start()
    {
        // UIInstructionText.SetActive(false);
        UIInstructionText.enabled = false;
    }

    void Update()
    {
        if (Input.GetKeyDown("space") && UIInstructionText.enabled)
        {
            UIInstructionText.enabled = false;
        }
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
