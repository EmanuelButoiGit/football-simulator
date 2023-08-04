using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowBall : MonoBehaviour
{
    public UnityEngine.AI.NavMeshAgent agent;
    public Transform ball;
    public static bool stop = false;

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(ball.position);
    }
}
