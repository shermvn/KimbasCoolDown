using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpBehavior : MonoBehaviour
{
    public float rotationSpeed = 100f;
    public float shrinkSpeed = 0.5f;
    private float hoverHeight = 0.001f;
    private float hoverSpeed = 2f;
    private float startY;


    private void Update()
    {
        startY = transform.position.y;
        float newY = startY + Mathf.Sin(Time.time * hoverSpeed) * hoverHeight;

        // Set the GameObject's position to the new position
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the GameObject collided with another object
        if (other.gameObject.CompareTag("Player")) // Replace "Player" with the tag of the object you want to collide with
        {
            //Obstacles.Instance.AnimOB();
            // Check if the GameObject has shrunk to nothing
            if (transform.localScale.x <= 0f)
            {
                // Destroy the GameObject
                Destroy(gameObject);
            }
        }
    }
}
