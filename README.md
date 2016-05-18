# rpg-npc-creator
Tool to create NPCs for a video game that can be serialized into JSON format

# Purpose
Oftentimes when creating a larger application such as a game, any simple tools that can relieve a minor development burden at no cost is a boon to the project.
The goal of this project is to allow the simple creation of NPCs

# Installation
Install this directly into your primary application directory. Be aware that logfiles will be created in a "logfiles" folder which the application will need to be able to write in. Running this application from a protected directory without the correct access might generate unintended results.

The following files are currently going to be leveraged:
```bash
Npc.cs
Stat.cs
Name.cs
Logger.cs
```
# Usage
You may use this toolset by including it directly into your C# application using the following technique
```csharp
using rpg_npc_creator;
```
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
You can define both the stat you would like as well as the name of the Npc
``` csharp 
Stat Dexterity = new Stat(18);
Name RealName = new Name("Oliver Queen"); 
var GreenArrow = new Npc(RealName,Dexterity);
```
