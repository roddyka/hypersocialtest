using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bridgeCreator : MonoBehaviour
{
   public GameObject player;
   public GameObject[] items;

   public int numbersOfwood;
   public bool isActive = false;

   public AudioSource audio;

    void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player")
        {
            isActive = true;
            audio.Play();
        }
    }

    void Update() {
        if(isActive) 
        {
            if(player.GetComponent<Player>().backpack_item >= items.Length){
                for (int i = items.Length; i > 0; i--)
                {
                    numbersOfwood++;
                    // player.GetComponent<Player>().backpack_item = player.GetComponent<Player>().backpack_item - i;
                    player.GetComponent<Player>().backpack[i].gameObject.SetActive(false);
                    player.GetComponent<Player>().removeScore();
                    items[numbersOfwood - 1].gameObject.SetActive(true);
                }
            }else{
                isActive = false;
            }
            
        }
    }
}
