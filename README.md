# DragonWorld
Dragon World is a text-based game that allows players to explore multiple dungeons that consist of enemies (dragons) or the routes to the next dungeons. The player can kill the enemies while the enemies can also kill the player. Each dungeon contains gold. After collecting all golds and kill all enemies, the player will go to the next level and the game will become more and more complex. At the end of the gameplay, the player (hero) would eventually save the princess that was caught by those enemies. 

This is a project in SIT305, Deakin University - 2018.
Unit Chair: Henry Larkin

SID: 215350188
Name: Hong Ly

# SouceTree Tutorial with GitHub 
https://youtu.be/t0hR0Q7I4mU

# Game Platform
- Unity (Can be run on both Android and iOS). 

# Project Link
Link: https://github.com/lyhd/Dragon-World

# Software Required to Compile 
- Unity 2017 (Personal version).
Download Link: https://unity3d.com/get-unity/download

# Steps to Compile DragonWorld Game in Unity
1. Download the project file by clicking on "Clone or download" button. 
2. Click on "Download Zip" button.
3. After downloading the zip file, extract it into a folder. 
4. Inside the Dragon-World-master folder, goes to Assets folder. 
5. click on Menu.unity to open the game with Unity software. 
6. Once the game is opened in Unity, press on the Play (Triangle) button to run the game. 

# Explanation of major features
- The game allows player to move in four directions, including north, east, south and west inside Player.cs.
- Player has the ability to fight, run, exit and open chest inside Encounter.cs.
  - Fight: player can fight against the enemy found in the dungeon.
  - Run: player can escape or avoid the enemy found in the dungeon.
  - Exit: player can exit the current dungeon to the next floor.
  - Open chest: player can open chest to get things that may include Trap, Heal, Enemy or Item & Gold.
- Player will also get prize once the enemy is killed such as items and gold.
- The game data can be easily changed since it is in JSON file.
- The game can generate new floors for the gameplay.
- Random dungeons will be created to avoid repetition.
- Each enemy has different energy, attack, defence and gold.
- Player, enemy and item stats are displayed and updated in real time. 

# API reference of major public classes and methods
![Alt text](/Screenshots/001.png?raw=true "Optional Title")


# Henry comments 13/April:
- You need many more commits per week to pass.
- So far I can't see any useful code, nor any text-based data files.

# Henry's Comments 27/April
- compile instructions + directory explanation still missing (just saying "Unity" and "Visual Studio" doesn't tell me which to use in what order)
- still no data for your game? That needs attention very very soon, as you can't start writing and developing your game world until you can load game data files.
