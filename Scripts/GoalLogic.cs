using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GoalLogic:MonoBehaviour
{
    public GameObject playerB;
    public GameObject playerB2;
    public GameObject playerB3;
    public GameObject playerR;
    public GameObject playerR2;
    public GameObject playerR3;
    // initial positions to respawn
    public Transform playerPosB;
    public Transform playerPosB2;
    public Transform playerPosB3;
    public Transform playerPosR;
    public Transform playerPosR2;
    public Transform playerPosR3;

    public static List <GameObject> playerObjects;
    public static List <Transform> playerPositions;

    public string team;
    public GameObject ball;
    public Vector3 ballPos;

    public void Start(){
        playerObjects = new List<GameObject>() {playerB, playerB2, playerB3, playerR, playerR2, playerR3};
        playerPositions = new List<Transform>() {playerPosB, playerPosB2, playerPosB3, playerPosR, playerPosR2, playerPosR3};
    }

    public static void updateScore(string team){
            if(team == "red"){
                Score.redScore ++;
            }
            else{
                Score.blueScore ++;
            }
    }

    public static void onBallCollision(GameObject ball, Vector3 ballPos, string team){

            for(int i = 0; i < playerObjects.Count; i++){
                playerObjects[i].SetActive(false);  
                playerObjects[i].transform.position = playerPositions[i].transform.position;
                playerObjects[i].SetActive(true);
            }   
            updateScore(team);
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Ball"){
            onBallCollision(ball, ballPos, team);
            col.transform.position = ballPos;
        }
    }
}
