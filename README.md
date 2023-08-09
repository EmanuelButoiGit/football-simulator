# Football Simulator
The goal is to “teach” the computing system by using a genetic algorithm how to choose the best strategy.

# Building my own simulator
I didn’t have the simulator available to test it, so I tried to build my own simulator with Unity.
I tried to create a simulator like a street football game; my inspiration was the Volta game mode Volta from FIFA.
You can play 5v5, 4v4, and 3v3 but I created the simulator where are 3v3 players. 

In Volta, we have 3 types of formations for 3 vs 3 games. I tried to add the formation as a gene of a chromosome, but the complexity is too high
I tried to add the formation as a gene of a chromosome, but the complexity is too high.

<p align="center">
  <img src="https://github.com/EmanuelButoiGit/football-simulator/assets/72088440/1f91f3b6-bc3f-4c2e-b812-da69a44bf65f" width="30%" alt=Formation 1" />
  <img src="https://github.com/EmanuelButoiGit/football-simulator/assets/72088440/33031146-40ab-460b-81e3-9699f3b9ccdb" width="30%" alt="Formation 2" />
  <img src="https://github.com/EmanuelButoiGit/football-simulator/assets/72088440/a6bbb25a-e881-49bb-9ba7-4461847a7e7e" width="30%" alt="Formation 3" />
</p>


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








