using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 3f;
    public int movementSides = 3;

    private float screenCenterX;

    
    private void Start()
    {
        // save the horizontal center of the screen
        screenCenterX = Screen.width * 0.5f;
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);

        //TOUTCH MOVEMENTS - internet tips

        // if there are any touches currently
        if(Input.touchCount > 0)
        {
            // get the first one
            Touch firstTouch = Input.GetTouch(0);
 
            // if it began this frame
            // if(firstTouch.phase == TouchPhase.Began)
            // {
                if(firstTouch.position.x > screenCenterX)
                {
                    // if the touch position is to the right of center
                    // move right
                    transform.Translate(Vector3.left * Time.deltaTime * movementSides * -1);
                    Debug.Log("right");
                }
                else if(firstTouch.position.x < screenCenterX)
                {
                    // if the touch position is to the left of center
                    // move left
                    transform.Translate(Vector3.left * Time.deltaTime * movementSides);
                    Debug.Log("left");
                }
            // }
        }

        if(Input.GetKey(KeyCode.LeftArrow)){
             transform.Translate(Vector3.left * Time.deltaTime * movementSides);
        }
        if(Input.GetKey(KeyCode.RightArrow)){
            transform.Translate(Vector3.left * Time.deltaTime * movementSides * -1);
        }
    }
}
