# rpg-npc-creator
Tool to create NPCs for a video game that can be serialized into JSON format

# Purpose
Oftentimes when creating a larger application such as a game, any simple tools that can relieve a minor development burden at no cost is a boon to the project.
The goal of this project is to allow the simple creation of NPCs

# Usage
Calling the default constructor creates a nameless, stat-less NPC.
``` csharp
var GreenArrow = new Npc();
``` 
Calling the constructor with the name you would like to use
``` csharp
Name RealName = new Name("Oliver Queen"); 
var GreenArrow = new Npc(RealName);
```
You can also call the constructor with a stat value
``` csharp 
Stat Dexterity = new Stat(18);
var GreenArrow = new Npc(Dexterity);
```
Finally, you can define both the stat you would like as well as the name of the Npc
``` csharp 
Stat Dexterity = new Stat(18);
Name RealName = new Name("Oliver Queen"); 
var GreenArrow = new Npc(RealName,Dexterity);
```
