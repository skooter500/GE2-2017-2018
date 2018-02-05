# Game Engines 2 2017-2018

[![Video](http://img.youtube.com/vi/n3uJ--m3f6Y/0.jpg)](http://www.youtube.com/watch?v=n3uJ--m3f6Y)

## Resources
- [Course Notes](https://drive.google.com/drive/folders/1HbqIE6_hwy0osMKDmEG5GgOAUeGy7NXV?usp=sharing)
- [Previous lab tests](https://1drv.ms/u/s!Ak7y2552PWCrkNACJ7n8qiU8UPRs9w)
- [Assignment](ca.md)
- [A build of Infinite Forms](https://drive.google.com/file/d/1w24BcMAi6P1XmPc9D9ss6Lkro4KBvsMS/view?usp=sharing)
- [Forms git repo - Please Fork!](https://github.com/skooter500/Forms)
- [A spotify playlist of music to listen to while coding](https://open.spotify.com/user/1155805407/playlist/5NYFsIFTgNOI93hONLbqNI)
- [Exploring the Psychedelic Experience through Virtual Reality](https://www.facebook.com/askdirectdublin/videos/10155614575684395/)

## Contact the lecturer

- Web: http://bryanduggan.org
- Email: bryan.duggan@dit.ie
- Twitter: [@skooter500](http://twitter.com/skooter500)

## Web Resources
- [Unity Tutorials](https://unity3d.com/learn/tutorials) 
- [AI Game Dev](http://aigamedev.com/)
- [GDC Vault](http://www.gdcvault.com/)
- [Game maths tutorials](http://www.wildbunny.co.uk/blog/vector-maths-a-primer-for-games-programmers/)
- [Behavior trees in C#](https://github.com/BraveSirAndrew/DisciplineOak)

## Previous years courses
- 2016-2017
	- http://github.com/skooter500/GAI-2017
	- https://github.com/skooter500/GE2-Supplemental-2017
	- https://github.com/skooter500/GE2-LabTest2-2017
	- https://github.com/skooter500/OrbitalRingsSolution
- 2015-2016
    - https://github.com/skooter500/gameengines2015
    - https://github.com/skooter500/BGE4Unity
- 2014-2015
    - https://github.com/skooter500/BGE
    - https://github.com/skooter500/UnitySteeringBehaviours 
- 2013-2014
    - https://github.com/skooter500/XNA-3D-Steering-Behaviours-for-Space-Ships
	
## Assessment Schedule	
- Week 4 - CA proposal & Git repo - 10%
- Week 7 - Lab test - 20%
- Week 12 - CA Submission & Demo - 50%
- Exam - 30%

# Week 3
## Lab
## Learning Outcomes

Today's lab is all about constructing physics objects in code.

If you already have the repo for the course, you can pull the latest version:

```
cd GP-2017-2018
git checkout master
git pull
```

You might need to commit your changes to the branch you were working on before switching back to the master branch:

```
git add .
git commit -m "My changes"
```

Open up the UnityIdioms project we were working on in the class last week and open scene3. This scene uses the FPS Camera controller we started work on in the class last week. Check out the code if you want to see how it works. You can move the camera using WASD and mouse look. You can steer the tank using IJKL and fire using space. Press Y to spawn a wall in front of the camera. Have a look the code in the class PhysicsSpawner to see how to do this

### Task 1
- Write a method ```CreateTower``` that creates a round tower of cubes in front of the tank in response to the U key. Do this using sin and cos to calculate the block positions. Try and make the tower stable.

#### Task 2
- Check out the video of my creatures:

    [![Video](http://img.youtube.com/vi/Ycv309jyzus/0.jpg)](http://www.youtube.com/watch?v=Ycv309jyzus)

- See if you can write a method called ```CreateTentacle``` that creates an articulated tentacle in code. You can use a squashed cube as a prefab, scaled to .1 on the Y axis and a hinge joint between the segments of the tentacle. Your method should take a parameter of the number of segments in the tentacle. Check out the Unity docs for [hinge joints](https://docs.unity3d.com/ScriptReference/HingeJoint.html).

# Week 2

- Unity Fundamentals. Maks sure you know about:
    - GameObjects
    - GameComponents
    - Transforms, positions, quaternions
    - Lerping, Slerping and LookAt
    - Getting and adding gamecomponents programmatically
    - Awake, Start, Update
    - Instiantiating GameObjects from prefabs
    - Using materials an setting colours
    - The fundamentals of lighting
    - Using tags
    - Using Coroutines
    - Using Invoke

### Lab
### Learning Outcomes
- Creating game objects from prefabs
- Adding gamecomponents at runtime
- Using a coroutine    

Clone the repo for the course to get the tank game we started making in the class last week. Make a branch to store your changes to the code:
```
git clone http://github.com/skooter500/GE2-2017-2018
cd GP-2017-2018
git checkout -b lab1
```

The version here has a 3rd person camera that follows the tank and also the tank can fire bullets. You can use this as starter code for todays lab.

Make this in Unity:

[![Video](http://img.youtube.com/vi/wB4Ptbgwra0/0.jpg)](http://www.youtube.com/watch?v=wB4Ptbgwra0)
  
What is happening:

- Third person camera that follows the player tank, which is controlled with the wasd keys or joystick. Shoot with the a key or mouse click
- The game always tries to keep 5 target tanks around the player
- Tanks spawn every 2 seconds starting after 3 seconds into the game
- Bullets disappear after 5 seconds
- When a bullet hits a target tank, it should explode. After 3 seconds the pieces sink into the floor and a new tank will spawn    

## Week 1 - Introduction to Unity
- [Slides](https://drive.google.com/drive/folders/1HbqIE6_hwy0osMKDmEG5GgOAUeGy7NXV?usp=sharing)


