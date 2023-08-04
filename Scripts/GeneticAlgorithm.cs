using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GeneticAlgorithm : MonoBehaviour
{
    public GameObject ball;
    public NavMeshAgent navPlayerB;
    public NavMeshAgent navPlayerB2;
    public NavMeshAgent navPlayerB3;
    public NavMeshAgent navPlayerR;
    public NavMeshAgent navPlayerR2;
    public NavMeshAgent navPlayerR3;

    List<NavMeshAgent> playerNavAgents;

    // selection method
    private const string METHOD = "classic";

    // fixed population size
    private const int POPULATION_SIZE = 3;

    // Threshold can be changed so more individuals
    // go straight to the new generation 
    private const int ELITISM_PERCENT = 10;

    // Mating percent to generate new offspring
    // for the new generation
    private const int MATING_PERCENT = 50;

    // Valid Genes
    private const string GENES = "123";
    private const int individualLength = 3;
    private const int fitnessTarget = 7;
    private static readonly System.Random random = new System.Random();
    public static string bestIndividual;
    public static bool endOfAlgo = false;

    static void SelectPlayer(char input, GameObject playerObj, NavMeshAgent playerNav)
    {
        switch (input)
        {
            // midfielder
            case '1':
                playerObj.transform.localScale = new Vector3(1.25f, 1.25f, 1.25f);
                playerNav.speed = 3.5f;
                playerNav.acceleration = 8f;
                break;
            // defender
            case '2':
                playerObj.transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
                playerNav.speed = 2f;
                playerNav.acceleration = 5.5f;
                break;
            // attacker
            case '3':
                playerObj.transform.localScale = new Vector3(1.35f, 1.35f, 1.35f);
                playerNav.speed = 4.5f;
                playerNav.acceleration = 9f;
                break;
        }
    }

    // Function to generate random numbers in given range 
    public static int GenerateRandom(int start, int end)
    {
        int range = (end - start) + 1;
        int random_int = start + random.Next(0, range);
        return random_int;
    }

    // Create random genes for mutation
    public static char MutatedGenes()
    {
        int len = GENES.Length;
        int r = GenerateRandom(0, len - 1);
        return GENES[r];
    }

    // create chromosome or string of genes
    private static string CreateGnome()
    {
        string gnome = "";
        for (int i = 0; i < individualLength; i++)
            gnome += MutatedGenes();
        return gnome;
    }

    private static List<Individual> BestOfTwo(List<Individual> new_generation, List<Individual> population)
    {
        Individual parent1 = population[0];
        Individual parent2 = population[1];
        Individual offspring = parent1.Mate(parent2);
        Individual weakestIndividual = population[population.Count - 1];
        population.Remove(weakestIndividual);

        // add offspring only after removing the weakest individual
        new_generation.Add(offspring);
        foreach (Individual individual in population)
        {
            new_generation.Add(individual);
        }
        return new_generation;
    }

    void Start()
    {
        StartCoroutine(StartLogic());
    }

    IEnumerator StartLogic()
    {
        playerNavAgents = new List<NavMeshAgent>() { navPlayerB, navPlayerB2, navPlayerB3, navPlayerR, navPlayerR2, navPlayerR3 };

        // current generation
        int generation = 0;

        List<Individual> population = new();
        bool found = false;

        // create initial population
        for (int i = 0; i < POPULATION_SIZE; i++)
        {
            string gnome = CreateGnome();
            population.Add(new Individual(gnome));
        }

        while (!found)
        {
            // create fitness pop[i] vs pop[j]
            for (int i = 0; i < POPULATION_SIZE; i++)
            {
                for (int j = i + 1; j < POPULATION_SIZE; j++)
                {
                    // individual = blue team, individual 2 = red team
                    Debug.Log("Blue team chromosome = " + population[i].chromosome);
                    Debug.Log("Red team chromosome = " + population[j].chromosome);

                    for (int x = 0; x < playerNavAgents.Count / 2; x++)
                    {
                        SelectPlayer(population[i].chromosome[x], GoalLogic.playerObjects[x], playerNavAgents[x]);
                    }

                    for (int x = playerNavAgents.Count / 2, y = 0; x < playerNavAgents.Count && y < GENES.Length; x++, y++)
                    {
                        SelectPlayer(population[j].chromosome[y], GoalLogic.playerObjects[x], playerNavAgents[x]);
                    }

                    Score.timeRemaining = Score.MATCH_TIME;
                    Score.redScore = 0;
                    Score.blueScore = 0;
                    Score.start = true;

                    // set ball and players to true
                    foreach (GameObject playerObj in GoalLogic.playerObjects)
                    {
                        playerObj.SetActive(true);
                    }
                    ball.SetActive(true);

                    yield return new WaitForSecondsRealtime(Score.MATCH_TIME);

                    Score.start = false;
                    ball.SetActive(false);
                    for (int z = 0; z < GoalLogic.playerObjects.Count; z++)
                    {
                        GoalLogic.playerObjects[z].SetActive(false);
                        GoalLogic.playerObjects[z].transform.position = GoalLogic.playerPositions[z].transform.position;
                    }

                    population[i].fitness += Score.CalculateBluePoints();
                    Debug.Log("population[i].fitness = " + population[i].fitness);
                    population[j].fitness += Score.CalculateRedPoints();
                    Debug.Log("population[j].fitness = " + population[j].fitness);
                    Debug.Log("End of the match");
                }
            }

            // sort the population in increasing order of fitness score
            for (int i = 0; i < population.Count; i++)
            {
                for (int j = i + 1; j < population.Count; j++)
                {
                    if (population[i].fitness <= population[j].fitness)
                    {
                        (population[j], population[i]) = (population[i], population[j]);
                    }
                }

            }

            // if the individual having lowest fitness score ie. 
            // 0 then we know that we have reached to the target
            // and break the loop
            if (population[0].fitness >= fitnessTarget)
            {
                found = true;
                break;
            }

            // Otherwise generate new offsprings for new generation
            List<Individual> new_generation = new();

            if (METHOD == "classic" || METHOD == "mix")
            {
                // Mate the best 2 and eliminate the worst
                new_generation = BestOfTwo(new_generation, population);
            }

            population = new_generation;
            generation++;
        }

        Debug.Log("Generation: " + (generation + 1) + "\t");
        Debug.Log("String: " + population[0].chromosome + "\t");
        Debug.Log("Fitness: " + population[0].fitness + "\n");
    }

}