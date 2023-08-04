using System;
using System.Collections.Generic;
public class Individual
{
    public string chromosome;
    public int fitness;
    public Individual(string chromosome)
    {
        this.chromosome = chromosome;
        fitness = 0;
    }
    public Individual Mate(Individual parent2)
    {
        // chromosome for offspring
        string child_chromosome = "";
        int len = chromosome.Length;
        for (int i = 0; i < len; i++)
        {
            // random probability 
            float p = GeneticAlgorithm.GenerateRandom(0, 100) / 100;
            // if prob is less than 0.45, insert gene
            // from parent 1 
            if (p < 0.45f)
                child_chromosome += chromosome[i];
            // if prob is between 0.45 and 0.90, insert
            // gene from parent 2
            else if (p < 0.90f)
                child_chromosome += parent2.chromosome[i];
            // otherwise insert random gene(mutate), 
            // for maintaining diversity
            else
                child_chromosome += GeneticAlgorithm.MutatedGenes();
        }
        // create new Individual(offspring) using 
        // generated chromosome for offspring
        return new Individual(child_chromosome);
    }
}