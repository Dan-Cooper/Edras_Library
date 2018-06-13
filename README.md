# Menervas Library - DESIGN DOC

### Team
	-Garrett Bryant: Artist
	-Quinton Connell: Animator/ Designer
	-Dan Cooper: Programmer/ Producer
	-Austin Dulong: Designer/ Sound Designer
	-Zachary Dwyer: Designer
	-Kenneth Howell: Producer/ Director/ Designer
	-Amanda LeBlanc: Artist
	-Cathy Nguyen: Programmer
	-Jay Ortiz: Artist/ Designer
	-Sarah Scully: 3D Modeler/Narrative
 
### Pitch
	Edras is a First Person, 3D Platformer about a wizard in training conjuring platforms in order to escape the possessed Edras Library. 

### Big Features
-First Person Parkour
-Conjure Platforms to Navigate Through Levels
-5 different levels
### Quick Info
-Intended Platform: PC
-Intended Input: Mouse/Keyboard
-Genre: Puzzle, Platformer
-Target Audience: Rated E10+
-Amount of Players: 1
 
### Story / Background Information
The Edras Library, the largest academic library where any and all come to learn the history of magic and how to use different forms of magic. (The Playable Character) is an student still learning the basics of magic. They do not know any attack spells, but they are a little proficient in the ways of conjuration. One day as (the playable character) is studying spells in the library, the building is possessed by an evil spirit. The library is starting to move on its own; trying to make it so anyone in the library is trapped. The hallways are blocked, the exit is guarded by possessed books, and the stairs are moving away from you. The only way out is to get to the roof. You are going to have to summon platforms using your magic in order to make a path to escape yourself. The only catch is, you have a limited amount of platforms you can summon. Can you figure out a way to escape? 
  
### Gameplay
## Controls

### Mouse
-Look - Mouse
-Summon Platform - Left-Click
-Undo Summon - Midle Click
-Select Platform Type - Right Click
### Keyboard
	-Movement - W, A, S, D
	-Jump - Spacebar
	-Wallrun - Shift
	-Interact - E

### Breakdown
Atom
-Exploring a room
-Getting from one non conjured platform to another
-Activating a switch

Session
-Completing 2 or more rooms


Campaign
-Finishing all Rooms (5-10)

Win-State(s)
-Complete a Room Successfully


Fail-State(s)
-Get killed from a stage hazard
-Fall off a pit


### THE FEATURES
EXAMPLE GAMEPLAY
	As you are reading about spells in the grand Edras Library, you feel like something is wrong. The books and shelves are starting to move on their own. There is an evil presence in this library. You can’t fight it, you are not an advanced enough wizard to cast attack spells; you must escape. The floors are moving and the stairs are blocked. You use your conjuration magic to make a platform in the air, you jump onto it. This platform is the only stable thing to walk on, looks like you’ll need to make your own path to escape. 


### Feature List
-Ledge Grabbing
--Model Hands
--Animate Hands Grabbing onto a ledge
--Decide on what ledges can/cannot be grabbed
-Platform Spawning*
--Platform Types
---Ramp
---Floor 
---Wall 
---Lift
---Cross
---“L” Shape
--Switch Between types of platforms
--Be able to undo a platform that was spawned (QTBA)
--Platforms will not collide with environment
-Wall Running
--Decide what can/cannot be parkourable 
--Should we model/animate legs?
-Environmental Hazards
--Flying Books: Move along a set path,  collision = instant death
--Golem Bust (turret): Non-moving, damage over time w/ laser
--Swinging Chandeliers: pendulum hazard.
--Bottomless Pit: Kill Floor 
-Levers that open doors: Accessible
-Only certain surfaces can be used for parkour element

 
### Inspiration & Resources
A bullet list of what inspires specific parts of your game!
### Mechanics
-Assassin’s Creed Revelations, Desmond’s Journey (summon platforms/switch between platforms) 
-Mirror’s Edge (Ledge Grabbing/Wallrunning)

### Visual Style
-Harry Potter (Hogwarts Architecture) 
-Little Witch Academia (Witch School Library Reference)
-Hyrule Warriors (Lana’s Magic)
-The Library (Dr. Who)

### Narrative
-Portal (silent/no significant story)
 
### Tools and Workflow
-Unity 
