using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Scoring : MonoBehaviour
{
    public Text player1Text;
    public Text player2Text;
    public bool isPlayer1Goal;
    private float player1Score;
    private float player2Score;

    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(isPlayer1Goal)
            player2Text.text = player2Score.ToString();
        else
            player1Text.text = player1Score.ToString();
        //Debug.Log("Player 1 score: " + player1Text.text);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Ball")
        {
            if(isPlayer1Goal)
            {
                Debug.Log("player 2 scored");
                player2Score++;
            }
            else
            {
                Debug.Log("player 1 scored");
                player1Score++;
                //Debug.Log(player1Score);
            }
            other.GetComponent<Ball>().ResetPosition();
        }
    }
}
