using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowInstructions : MonoBehaviour
{

    public GameObject UIInstructionText;

    // public TextMes
    void Start()
    {
        UIInstructionText.SetActive(false);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            UIInstructionText.SetActive(true);
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            UIInstructionText.SetActive(false);
        }
    }

    // void Update()
    // {
        
    // }
}
