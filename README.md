# 🏆 Football Simulator ⚽


![Genetic Algorithm](https://img.shields.io/badge/-Genetic%20Algorithm-brightgreen) 
![Unity Built](https://img.shields.io/badge/-Built%20with%20Unity-blue) 
![Strategy Evolution](https://img.shields.io/badge/-Strategy%20Evolution-orange)
![GitHub](https://img.shields.io/github/license/EmanuelButoiGit/football-simulator)

This Football Simulator uses genetic algorithms to figure out the best football strategy. <br><br>
🔗 See it in action: [YouTube Video Link](https://youtu.be/8z4btXaj4DI?si=ykuby8xe1rw34b1K) <br>
🕹️ Give it a try: [Itch.io Link](https://candyscape.itch.io/football-strategies-simulator) <br><br>

## 🏗 Building my own simulator
I didn’t have the simulator to create the algorithm and test it, so I tried to create my own simulator with Unity. <br>
I built this simulator based on the Volta mode in FIFA. <br>
While you can play in team sizes like 5v5, 4v4, and 3v3, this simulator focuses on 3v3. <br>
I wanted to use the three formations from Volta as parts of a chromosome. But it was too complex to do. <br><br>

<p align="center">
  <img src=Images/Formation1.png width="30%" alt=Formation 1" />
  <img src=Images/Formation2.png width="30%" alt=Formation 2" />
  <img src=Images/Formation3.png width="30%" alt=Formation 3" />
</p>
<br>


## 🚀 Setup
To get the simulator ready:
- Attach "BallScript" to a sphere.
- Make a player using a capsule and add the "FollowBall" script.

<br>
<p align="center">
  <img src=Images/Capsule.png width="45%" alt="Capsule" />
  <img src=Images/Ball.png width="45%" alt="Ball" />
</p>
<br>

- Use cubes for goal posts and add the "GoalScript"

<br>
<p align="center">
  <img src=Images/Post.png width="50%" alt="Goal Script" />
</p>
<br>

Another thing that I would like to mention is that I created an aquarium-like pitch so the ball won't jump outside. <br> 
The other scripts will be active in the environment and you need to assign the right Game Objects to work. <br><br>


## ⚽ Football Strategies 
<p align="left">
  <img src=Images/Klopp.png width="15%" alt="Klopp" />
</p>

I did not add actions as a strategy like in this [paper](https://www.researchgate.net/publication/221024459_Generating_Emergent_Team_Strategies_in_Football_Simulation_Videogames_via_Genetic_Algorithms). <br>
A strategy will be a combination of formation and player type and a player type will be a capsule with different attributes. <br>

Players can be:
1. Midfielder
2. Attacker
3. Defender

Just like in Volta! <br><br>


## 🧬 The Genetic Algorithm

The initial population will be populated with random strategies. <br>
Here, a chromosome might look like: `132, 111, 212, ...` where each part tells the player type.

**What's the aim?** 🥅 <br>
Find the best strategy. Teams play in tournaments and the algorithm pick the best team based on their points (which will be the fitness target). <br><br>

<p align="center">
  <img src=Images/WC.png width="45%" alt="World Cup group Stages" />
</p>
<br>

**How do we select?** 🔄 <br>

1. **The classic method:** Best of 2.

Mating is done by combining genes based on random probabilities. 
If probability **>** : <br> 
- 0.45 => we take the first parent <br>
- 0.90 => second else random gene <br>

2. **[Geek for Geek Method](https://www.geeksforgeeks.org/genetic-algorithms/)**:

Perform Elitism => 10% of the population goes straight to the new generation 50% of the rest of the population will mate to produce new offspring.
Mating will be the same as presented in the previous method. <br> <br>


## 🎓 Reinforcement Learning

For better AI, you could use Reinforcement Learning to generate a brain model that could be used for the players, for the AI agents. <br><br>

<p align="center">
  <img src=Images/Reinforcement.png width="45%" alt="Training with RL" />
</p>
<br>

There are some steps when implementing something like this:
1. **Watch**: Gather data.
2. **Think**: Decide using data.
3. **Act**: Do something and get a reward if it's good. <br><br>


## 📌 Other things to mention

<p align="left">
  <img src=Images/Mou.png width="15%" alt="Mou screaming" />
</p>

It would be nice in the future to add different colors to individuals to see exactly which individuals are in that team. <br>
I did add a short population and duration of time because of limited time. <br>
It would be also interesting to scale the project (to add more players, more tactics, more attributes and to fix formations). <br><br>


## 💡 Conclusion
Genetic algorithms are crucial for making the player experience more unique and adding unpredictable complexity!










