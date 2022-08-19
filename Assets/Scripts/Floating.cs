using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// CODE BY http://www.donovankeith.com/2016/05/making-objects-float-up-down-in-unity/
//some comments by Rodrigo Antunes
public class Floating : MonoBehaviour
{
    //Degress per Second is self explanatory, the object will rotate, at this .5f amplitude and frequence 1f (second)
    public float degreesPerSecond = 15.0f;
    public float amplitude = 0.5f;
    public float frequency = 1f;
 
    // Create a storage for the first time of this object
    Vector3 posOffset = new Vector3 ();
    Vector3 tempPos = new Vector3 ();

    public AudioSource audioSource;
    void Start () {
        // Store the starting position & rotation of the object
        posOffset = transform.position;
    }
     
    // Update is called once per frame
    void Update () {
        // Spin object around Y-Axis
        transform.Rotate(new Vector3(0f, Time.deltaTime * degreesPerSecond, 0f), Space.World);
 
        // Float up/down with a Sin()
        tempPos = posOffset;
        tempPos.y += Mathf.Sin (Time.fixedTime * Mathf.PI * frequency) * amplitude;
 
        transform.position = tempPos;
    }

    void OnTriggerEnter(Collider collision)
    {
         if (collision.tag == "Player")
        {
            Debug.Log("entrou");
            // Debug.Log(audioData.GetComponent<AudioSource>());
            // audioData.PlayOneShot(mouseDownAudioClip, 1);
            audioSource.Play();
        }
    }
}
