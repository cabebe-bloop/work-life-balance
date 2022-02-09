using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.UI;
using TMPro;

public class ShowInstructions : MonoBehaviour
{

    // public GameObject UIInstructionText;
    public TMP_Text UIInstructionText;

    // public TextMes
    void Start()
    {
        // UIInstructionText.SetActive(false);
        UIInstructionText.enabled = false;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            // UIInstructionText.SetActive(true);
            UIInstructionText.enabled = true;
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

    // void Update()
    // {
        
    // }
}
