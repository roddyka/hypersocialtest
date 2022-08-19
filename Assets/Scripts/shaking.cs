using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shaking : MonoBehaviour
{
    public float speed;
    public GameObject obj1;
    public GameObject ob2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     void FixedUpdate()
     {
         // Calculate direction vector
         Vector3 dir = obj1.transform.position - ob2.transform.position;
         // Normalize resultant vector to unit Vector
         dir = dir.normalized;
         // Move in the direction of the direction vector every frame 
         obj1.transform.position += dir * Time.deltaTime * speed;
     }
}
