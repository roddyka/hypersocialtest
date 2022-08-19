using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameController : MonoBehaviour
{
    public static GameController instance; //instance to call this item on anothers script
    public int language; //0 to english - 1 to Portuguese - 2 to spanish
    public bool translated = false; //if checked translate
    public TextMeshProUGUI ButtonPlayText; //play button text
    public TextMeshProUGUI titleText; //play button text
    public GameObject[] CanvasItems; //menu object
    public GameObject items; //menu object
    public GameObject[] item; //menu object
    //score
    public int totalScore;
    public TextMeshProUGUI totalScoreText;
    public TextMeshProUGUI timerText;

    //player controllers
    public GameObject player;
    
    public Animator anim;

    //Gameplay controllers
    private bool btnClicked = false;
    private bool isStarted = false;
    private bool isWinner = false;
    public bool isGameOver = false;

    public int counter = 3;
    public bool isCounting;
    float timer = 0.0f;

    void Start()
    {
        // player.GetComponent<PlayerMovement>().enabled = false;
        totalScoreText.text = "ITEMS: "+totalScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(btnClicked && !isStarted){
            timer += Time.deltaTime;
            int seconds = (int)(timer % 60);
            CanvasItems[2].SetActive(true);
            timerText.text = seconds.ToString();
            if(seconds > counter){
                CanvasItems[2].SetActive(false);
                StartGame();
            }
        }
    }

    public void BtnStartClick(){
        btnClicked = true;
        CanvasItems[0].SetActive(false);
        
        CanvasItems[3].SetActive(false);
        player.GetComponent<Rigidbody>().useGravity = true;
    }

    public void StartGame(){
        isStarted = true;
        CanvasItems[1].SetActive(true);
        player.GetComponent<PlayerMovement>().enabled = true;
        anim.SetBool("Run", true);
    }

    public void updateScoreText(){
        totalScoreText.text = totalScore.ToString();
    }

    public void Winner(){
        // Debug.Log("YOU WINNNN - this is gamecontroller win function sending you to win scene");
        SceneManager.LoadScene(1);
    }
    public void Loser(){
        // Debug.Log("Loser - this is gamecontroller loser function sending you to loser scene");
        SceneManager.LoadScene(2);
    }
    public void HomeScreen(){
        SceneManager.LoadScene(0);

        anim.SetBool("Run", false);
        btnClicked = false;
        CanvasItems[0].SetActive(true);
        CanvasItems[3].SetActive(true);
        
    }
}
