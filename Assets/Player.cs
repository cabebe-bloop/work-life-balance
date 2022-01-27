using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]float moveSpeed = 0.5f;
    [SerializeField]float turnSpeed = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalMoveAmount = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        float verticalMoveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        float horizTurnAmount = Input.GetAxis("Horizontal") * turnSpeed * Time.deltaTime;
        transform.Translate(horizontalMoveAmount, verticalMoveAmount, 0);
        // 01.26.2022 - Figure out hot to make sprite fact the direction it's moving in
        // transform.Rotate(0, 0 , horizTurnAmount);
    }
}
