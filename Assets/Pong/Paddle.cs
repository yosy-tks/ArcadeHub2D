using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] private float speed = 7f;
    [SerializeField] private bool isPaddle1;
    private float yBound = 3.75f;

    // Update is called once per frame
    void Update()
    {
        // Move depending on player
        float movement = Input.GetAxisRaw(isPaddle1 ? "Vertical" : "Vertical2");
        transform.position += new Vector3(0, movement * speed * Time.deltaTime, 0);
        
        // Limit paddle vertical movement
        Vector2 paddlePosition = transform.position;
        paddlePosition.y = Mathf.Clamp(paddlePosition.y + movement * speed * Time.deltaTime, -yBound, yBound);
        transform.position = paddlePosition;
    }
}
