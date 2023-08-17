/*
All rights reserved to Code Monkey "How to use Machine Learning AI in Unity! (ML-Agents)"
https://youtu.be/zPFU30tbyKs
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;

public class MoveToGoal : Agent
{
    // Agent learning through Reinforcement learning

    // 1. observation = gathers data from environment
    // 2. decision = makes one based on the data he has
    // 3. then takes an action where the agent is rewarded
    // if he took the right one
    // back to 1

    private Transform targetTransform;
    private float moveSpeed = 0.5f;
    private Material winMaterial;
    private Material loseMaterial;
    private MeshRenderer wall;
    private MeshRenderer wall2;
    private MeshRenderer wall3;
    private MeshRenderer wall4;
    private bool isNormalScene;
    private List<MeshRenderer> walls;


    // In ML an episode means a run
    public override void OnEpisodeBegin()
    {
        // Reset to the initial position
        if (isNormalScene)
        {
            transform.position = new Vector3(4.13f, 2.208f, -5.836778f);
        }
    }

    // Agent observes the environment 
    public override void CollectObservations(VectorSensor sensor)
    {
        // capsule position
        sensor.AddObservation(transform.position);
        // ball position
        sensor.AddObservation(targetTransform.position);

        // the vector observator space size will have x,y,z
        // for both positions
    }

    // This buffer contains actions
    // as ints (discrete) / floats [-1, 1] (cont)
    // ML algorithm does not understand what is a GameObject or
    // how to move to the right, all it knows is numbers
    public override void OnActionReceived(ActionBuffers actions)
    {
        //Debug.Log(actions.DiscreteActions[0]);
        float moveX = actions.ContinuousActions[0];
        float moveZ = actions.ContinuousActions[1];
        Debug.Log("moveX " + moveX);
        Debug.Log("moveY " + moveZ);
        transform.position += new Vector3(moveX, 0, moveZ) * Time.deltaTime * moveSpeed;
    }

    // we can edit the actions
    public override void Heuristic(in ActionBuffers actionsOut)
    {
        ActionSegment<float> continuousActions = actionsOut.ContinuousActions;
        continuousActions[0] = Input.GetAxisRaw("Horizontal");
        continuousActions[1] = Input.GetAxisRaw("Vertical");
    }

    private void OnTriggerEnter(Collider col)
    {
        walls = new List<MeshRenderer>() { wall, wall2, wall3, wall4 };
        if (col.tag == "ball")
        {
            //AddReward(1f);
            SetReward(+1f);
            foreach (MeshRenderer mesh in walls)
            {
                mesh.material = winMaterial;
            }

            //if (isNormalScene)
            //{
                gameObject.SetActive(false);
            //}

            EndEpisode();
        }
        if (col.tag == "wall")
        {
            SetReward(-1f);
            foreach (MeshRenderer mesh in walls)
            {
                mesh.material = loseMaterial;
            }

            //if (isNormalScene)
            //{
                gameObject.SetActive(false);
            //}

            EndEpisode();
        }
    }
}
