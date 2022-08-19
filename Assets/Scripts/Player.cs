using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public GameObject[] backpack;
    public int backpack_item;
    public GameController gameController;


     void OnTriggerEnter(Collider collision)
    {

        // Debug.Log(gameController.GetComponent<GameController>().item.Length);
        if (collision.tag == "Item")
        {
          

            // Debug.Log(backpack);
            backpack_item++;
            // i need check when i remove the backpack item, hide the right wood from the list
            // ajustar backpack
            // backpack[backpack_item].gameObject.SetActive(true);

            collision.gameObject.SetActive(false);
            gameController.GetComponent<GameController>().totalScore++;
            gameController.GetComponent<GameController>().updateScoreText();

        }

        if (collision.tag == "winner")
        {
            GetComponent<PlayerMovement>().enabled = false;
            // Debug.Log("WINNER!!! go to gamecontroller win function");
            gameController.GetComponent<GameController>().Winner();
        }

        if (collision.tag == "loser")
        {
            GetComponent<PlayerMovement>().enabled = false;
            // Debug.Log("Loossseerrrr!!! go to gamecontroller loser function");
            gameController.GetComponent<GameController>().Loser();
        }
        
    }

    public void removeScore(){
        // Debug.Log(gameController.GetComponent<GameController>().totalScore);
        if(gameController.GetComponent<GameController>().totalScore <= 0){
            // Debug.Log("esse do 0");
                gameController.GetComponent<GameController>().totalScore = 0;
        }else {
            // Debug.Log("foi neste menos q 0");
            gameController.GetComponent<GameController>().totalScore--;
            backpack_item = gameController.GetComponent<GameController>().totalScore;
        }
        gameController.GetComponent<GameController>().updateScoreText();
    }
}
