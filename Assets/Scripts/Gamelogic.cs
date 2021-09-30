//****************************
//Creatisoft - Paper,  Rock, Scissors
//Chris M. 
//09/22/2021
//****************************

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//I import the namescape to manipulate the UI such as text, buttons, ect. 
using UnityEngine.UI;



public class Gamelogic : MonoBehaviour {

    //****************************
    //initialize my variables here
    //****************************

    public AudioSource audioSource;

    public SpriteRenderer cpuSquare;
    public SpriteRenderer playerSquare;

    public Sprite[] Objectsprites = new Sprite[3];

    public Text cpuScoreText;
    public Text playerScoreText;

    public Button paperButton;
    public Button rockButton;
    public Button scissorsButton;


    int playerScore = 0;
    int cpuScore = 0;


    int playersObjectState = -1;
    int cpuRandom = -1;


    //****************************
    //Set my random seed
    //make a reference to the audiosource component 
    //****************************

    void Start() {



        Random.InitState(13);

        audioSource = gameObject.GetComponent<AudioSource>();

        

    }


    //This is just here for my own personal reference
    //0 is paper
    //1 is rock
    //2 is scissors

    //****************************
    //the logic below is done on case by case.
    //what worked for the paper wasn't true for the rock, or scissors logic.
    //A point is added if the cpu / player wins, and updated appropriately
    //****************************


    private void PaperLogicCheck() {

        audioSource.Play();

        if (playersObjectState == 0 && cpuRandom != 2 && cpuRandom != 0) {

            //Debug.Log("player wins");
            playerScore = playerScore + 1;
            playerScoreText.text = "Points: " + playerScore.ToString();


        } else if(cpuRandom == 0 && playersObjectState == 0) {

            //Debug.Log("it's a tie");

        } else {

            //Debug.Log("cpu wins");
            cpuScore = cpuScore + 1;
            cpuScoreText.text = "Points: " + cpuScore.ToString();

        }


    }

    private void RockLogicCheck() {

        audioSource.Play();

        if (playersObjectState == 1 && cpuRandom != 1 && cpuRandom == 2 ) {

            //Debug.Log("player wins");
            playerScore = playerScore + 1;
            playerScoreText.text = "Points: " + playerScore.ToString();

        } else if (cpuRandom == 1 && playersObjectState == 1) {

            //Debug.Log("it's a tie");

        } else if(cpuRandom == 0 && playersObjectState == 1 ){

            //Debug.Log("cpu wins");
            cpuScore = cpuScore + 1;
            cpuScoreText.text = "Points: " + cpuScore.ToString();

        }


    }

    private void ScissorsLogicCheck() {

        audioSource.Play();

        if (playersObjectState == 2 && cpuRandom != 2 && cpuRandom == 0) {

            //Debug.Log("player wins");
            playerScore = playerScore + 1;
            playerScoreText.text = "Points: " + playerScore.ToString();

        } else if (cpuRandom == 2 && playersObjectState == 2) {

            //Debug.Log("it's a tie");

        } else if (cpuRandom == 1 && playersObjectState == 2) {

            //Debug.Log("cpu wins");
            cpuScore = cpuScore + 1;
            cpuScoreText.text = "Points: " + cpuScore.ToString();

        }


    }

    //****************************
    //I check the logic using a switch case,
    //and calling the appropriate function
    //****************************

    void CheckLogic() {


        switch (playersObjectState) {

            case 0:
                PaperLogicCheck();
                break;

            case 1:
                RockLogicCheck();
                break;

            case 2:
                ScissorsLogicCheck();
                break;

            default:
                break;


        }


    }


    // Update is called once per frame
    void Update() {



    }


    //****************************
    //This is where the cpu decides a random object to pick
    //****************************

    private void EnemyObjectPicker() {

        cpuRandom = Random.Range(0, 3);
        cpuSquare.sprite = Objectsprites[cpuRandom];
        
        
    }

    //****************************
    //when I press the buttons below the cpu's object is 'randomly' picked
    //I also call upon the object sprite based on the playerObectstate
    //I then call the CheckLogic function
    //****************************

    public void PaperButtonPressed() {

        EnemyObjectPicker();
        playerSquare.sprite = Objectsprites[0];
        playersObjectState = 0;
        CheckLogic();

    }

    public void RockButtonPressed() {

        EnemyObjectPicker();
        playerSquare.sprite = Objectsprites[1];
        playersObjectState = 1;
        CheckLogic();

    }

    public void ScissorButtonPressed() {

        EnemyObjectPicker();
        playerSquare.sprite = Objectsprites[2];
        playersObjectState = 2;
        CheckLogic();

    }

}
