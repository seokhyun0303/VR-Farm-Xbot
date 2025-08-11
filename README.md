# VR-Farm-Xbot

## Overview
This project is the result of practicing the basics of implementing a vr environment using Unity.
It consists of one scene in which a Vr farm simulator is implemented and one scene in which detailed avatar manipulation is implemented using Quest3 hand tracking.

## Tech Stack
Unity 2022.3  
Meta Quest3  
Oculus Interacton SDK  

## VR Farm Simulator

- You can grab and put down farm tools, boxes, and tomato seedlings.
- If you hit the field in the fence several times with a hoe, it becomes land where tomatoes can be planted.
- Plant tomatoes and water them and they grow.
- Adult tomatoes can be harvested by hand and boxed.
- The npc in front of the table informs you in order using text and tts.
- Physics apply to all objects.

## Xbot Avatar
- Get Quest 3's hand tracking information (all hand joints) and manipulate xbot avatars in detail with the transform.
- By comparing the distance between your wrist and head, you can change the size of your avatar to suit your needs. Stretch your hands forward, turn your left hand around, and let your right thumb and index finger touch each other. Maintain the position until the avatar no longer changes in size.


