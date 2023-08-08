# Football Simulator

The goal is to “teach” the computing system by using a genetic algorithm how to choose the best strategy.
The initial population will be populated with random strategies.
Each bit is a step/guide of the strategy that I presented.

A chromosome / a genome / an individual from the initial population will look something like this: 111 010 101 110
When an individual is created, a fitness score is attributed to that individual.
How is the fitness score calculated? 
By performing a difference between the target and the individual.

Based on the fitness we sort the population and we stop the algorithm when the best individual has the fitness 0 because there is no difference between him and the target.
If it’s not found what we do? How do we select individuals for reproduction?

2 Methods
1. The classic method: Best of 2.

Mating is done by combining genes based on random probabilities. 
If probability > 0.45 => we take the first parent> 0.90 => second else random gene

2. Geek for geek proposed method:

Perform Elitism => 10% of the population goes straight to the new generation 50% of the rest of the population will mate to produce new offspring.
Mating will be the same as presented in the previous method.

## Building my own simulator
I didn’t have the simulator available to test it, so I tried to build my own simulator with Unity.I tried to create a simulator like a street football (Volta game mode like in FIFA).3 vs 3






