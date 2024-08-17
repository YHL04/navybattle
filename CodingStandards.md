# Coding Standards
The following document is aimed at future contributors to DayNNite to ensure they abide by standard coding standards throughout the project.

![Class Hierarchy](https://i.ibb.co/BPzLkN9/Day-NNite-Final-Presentation-Graphics-5.png)

## General Practices
This section enumerates several generic practices, we will begin with naming conventions:

 - Private member variables follow camelCase, with the exception of Game Object classes, which have a leading underscore (e.g. _camelCase).
 - Functions (including getters/setters) are in PascalCase.
 - Class names are in PascalCase.
 - Interface class names have an I before them (e.g. IInterface).
 - Name the file the same name as the class.

The following are assorted general practices:

- Private member variables should come first in a class.
- All script files should be in Assets/Scripts.
- All enum classes should be in Assets/Scripts/Enums.
- Do not put more than one class/interface in the same file.
- Our code base follows a Dependency Injection system. Please abide by this with the use of Game Objects and Spawner classes.

## Game Object Classes
When implementing a Game Object class, try your best to describe its behavior with appropriate interfaces. A very common thing to implement here are novel items and characters, in which you should inherit from other classes. Here are some common organizational points for implementing Game Object Classes:

- Place these files in Assets/Scripts/Items or Assets/Scripts/Characters folders.
- New characters should inherit from Character.
- New Firearms should inherit from Firearm. 
- Prefabs for new Game Objects should be located in Assets/Resources/Prefabs.

## Spawner Classes
Spawners are responsible for instantiating Game Objects. There are two types of Spawners. If you want to make a code-only object that can be held by other classes, inherit from Spawner. If you want to make a spawner that creates new Players or Enemies OR can be attatched to an object in a Scene, inherit EntitySpawner.

- Spawner classes should be located in Assets/Scripts/Spawners.
- Button Spawners (EntitySpawner) should be located in Assets/Scripts/Buttons and inherit from ButtonSpawner.
	- These classes should be called ObjectButton (e.g. SoldierButton).
- Location Spawners (EntitySpawner) should be located in Assets/Scripts/Locations and inherit from LocationSpawner.
	- These classes should be called ObjectLocation (e.g. SoldierLocation).
- Oftentimes, Spawners (not EntitySpawners) will define an Initialize() function to act as a constructor.
- Do not make spawners for Firearm items. Use the generic FirearmSpawner.


The following are additional practices for utilizing SpawnerLocation:

- Use the "Location" prefab and attatch the SpawnerLocation script to this object. (e.g. attatch SoldierLocation)
- Select either EnemyManager or PlayerManager for this script to describe which type of entity is spawned.

## Controller Object Classes
Controller Object Classes describe controllers for Game Objects, and usually refer to Players and Enemies. 

- Types of controllers for Characters should inherit from ControllableCharacter.
- Controllers that take user input from Unity should utilize the Unity InputSystem and use C# callback functions (see Player.cs as an example).
- All Controller Object Classes should be located in Assets/Scripts/ControllerObjects.

## Manager Classes
Manager classes describe management behavior in our class.

- Manager classes should be in Assets/Scripts/Managers.
- Manager classes usually have the naming convention TypeManager (e.g. GameManager).



## Scene Making
This final section does not describe code necessarily but the convention for making a new level or UI Screen.

### UI Scenes
- Place UI scenes in Assets/Scenes

### Level Scenes
- Place Level scenes in Assets/Scenes/Levels
- Name the scene "Level#" where # is a number (e.g. Level4).
- Use a Tilemap to paint the map, using the ScutPalette.
- Split up the Tilemap into a Background, Decoration, Wall, and Void tilemap and paint each differently. Each tilemap has its own layer. 
- Each layer needs a GameManager, EnemyManager, and PlayerManager object with the proper layers assigned.

The list here will get too granular to describe here, so please look at other levels (specifically Level1 through Level3) as an example for the proper structure. Here is an image of a sample level's GameObject list:

![Sample Level Scene](https://i.ibb.co/ykxQf37/Screenshot-2024-08-16-223407.png)

## Wrap Up

Have fun contributing to DayNNite! With your attention to coding standards we can help assure this project stays scalable and clean to read for future developers.
