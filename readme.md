Digital Games Course Project
============================

Project which contains several gameplay extensions to Survival Shooter Unity tutorial.

Project contains 4 scenes, first scene is the default complete version of game tutorial. Each of the other scenes
contains one new mechanic and a new level:
* Main - Completed tutorial version of game
* LightsAndFear - Player has fear attribute which keeps slowly increasing and results in player death when it reaches peak.
The fear can be reset by walking into yellow lights that spawn randomly at certain locations inside the level.
* ZombirdsNest - Level with new enemy - Zombird. Zombird flies around, patrolling, and when it sees a player, it charges to the location when it first saw the player, and explodes when it hits the floor, hurting all characters in its blast radius.
* Doctor - Adds additional npc - a doctor, which is randomly wandering through map. When player is near the doctor, he gets healed. Enemies attack the doctor when they are near him. Once doctor is dead, a new one spawns after some time. There is only one doctor on the map in the moment. The doctor has four spawn points.

Changes made to initial gameplay mechanic and level design
----------------------------------------------------------
* LightsAndFear:
    - Gameplay mechanic remains unchanged
    - Level is modified - narrow passages were removed, because they would quickly become bottlenecks for enemy movement;
    enemy and light zone spawn points remain mostly the same, one spawn point for light zone was removed, four light zone
    spawns worked out better for a relatively small level; light spawn which was blocked from 3 sides was altered to be
    accessible from 2 sides - most of the time the one side would become blocked by enemies, entering this area was too risky

* ZombirdsNest
    - Gameplay mechanic remains unchanged
    - Level was modified because the original proved to be too complicated and the current level still demonstrates all of zombirds abilites

* Doctor
    - Different map layout, more spawn points
    - The doctor moves randomly
    
Notes
-----
* Level selection is available from main menu
* Main menu can be opened by pressing escape button
