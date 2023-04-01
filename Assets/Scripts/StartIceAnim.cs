using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartIceAnim : MonoBehaviour
{
    [SerializeField] private float hoverHeight = 0.5f;
    float HH = 0f;

    public void Awake()
    {

       
        //[SerializeField] public float hoverSpeed = 2f;
        HH = Random.Range(0f, 2f);
    }
 
     

    private float startY;
    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        startY = transform.position.y;
        float newY = startY + Mathf.Sin(Time.time * HH) * hoverHeight;

        // Set the GameObject's position to the new position
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}
