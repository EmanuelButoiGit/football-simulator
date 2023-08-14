# Football Simulator
The goal is to “teach” the computing system using a genetic algorithm how to choose the best strategy.

# Building my own simulator
I didn’t have the simulator to create the algorithm and test it, so I tried to build my own simulator with Unity.
I tried to create a simulator like a street football game; my inspiration was the Volta game mode from FIFA.
You can play 5v5, 4v4, and 3v3; but I created the simulator where are 3v3 players. 

In Volta, we have 3 types of formations for 3 vs 3 games. I tried to add the formation as a gene of a chromosome, but the complexity is too high
I tried to add the formation as a gene of a chromosome, but the complexity is too high.

<p align="center">
  <img src="https://github.com/EmanuelButoiGit/football-simulator/assets/72088440/1f91f3b6-bc3f-4c2e-b812-da69a44bf65f" width="30%" alt=Formation 1" />
  <img src="https://github.com/EmanuelButoiGit/football-simulator/assets/72088440/33031146-40ab-460b-81e3-9699f3b9ccdb" width="30%" alt="Formation 2" />
  <img src="https://github.com/EmanuelButoiGit/football-simulator/assets/72088440/a6bbb25a-e881-49bb-9ba7-4461847a7e7e" width="30%" alt="Formation 3" />
</p>

# Setup
How do you setup your own simulator?
Well you attach the "BallScript" to a sphere, create the player as a capsule and add the "FollowBall" script.
For better AI, you could use Reinforcement Learning for the agent.
There are some steps when implementing something like this:
1. observation = gathers data from environment
2. decision = makes one based on the data he has
3. then takes an action where the agent is rewarded

The brain model that it will be generated..


# Football strategies
<p align="left">
  <img src="https://github.com/EmanuelButoiGit/football-simulator/assets/72088440/b59b61a8-a55c-4ccf-9b0c-3925a1116b4f" width="15%" alt=Formation 1" />
</p>

I did not add actions as a strategy like in the paper "Fernández, Antonio J., Carlos Cotta, and Rafael Campaña Ceballos. "Generating Emergent Team Strategies in Football Simulation Videogames via Genetic Algorithms." GAMEON. 2008".
A strategy will be a combination of formation and player type.

**Player type?**
I made my player a capsule with different attributes based on a type. 
A player can be a midfielder (1), an attacker (2), or a defender (3). Just like in Volta!

# The genetic algorithm

A chromosome of a population will look like this: 132, 111, 212, etc.
The initial population will be populated with random strategies.
Each gene of the chromosome will represent the player type. 

As for the method of selection 

**But here what is the goal?**
We want to see the best strategy, so we try to do a tournament (more like a group or league) and select the best team based on a fitness target.
That fitness target is the number of points that the team won. This is something like in the group stages of 

<p align="center">
  <img src="https://github.com/EmanuelButoiGit/football-simulator/assets/72088440/4f4bec01-d38b-4c3b-b401-2563ff806f04" width="50%" alt=World Cup group Stages" />
</p>

**What about the selection method?**


1. The classic method: Best of 2.

Mating is done by combining genes based on random probabilities. 
If probability > 0.45 => we take the first parent> 0.90 => second else random gene

2. Geek for geek proposed method:

Perform Elitism => 10% of the population goes straight to the new generation 50% of the rest of the population will mate to produce new offspring.
Mating will be the same as presented in the previous method.


# Other things to mention

<p align="left">
  <img src="https://github.com/EmanuelButoiGit/football-simulator/assets/72088440/4c9f9db5-006a-4eed-ad4f-ff9a8c9f2162" width="15%" alt=World Cup group Stages" />
</p>

It would be nice in the future to add different colors to individuals to see exactly which individuals are in that team.
I did add a short population and duration of time because of limited time.
It would be also interesting to scale it for more players more tactics, more attributes and to fix formations.
A complex algorithm because of the tournament logic.


# Conclusions
Genetic algorithms are crucial for making the player experience more unique and adding unpredictable complexity!










