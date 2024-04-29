# ECS635U-Final-Year-Project
This is my final year project.

This is a brief overview of how to run my program. For a more comprehensive guide on how to run my program, please read the PDF file I uploaded for the Supporting Material Submission. I highly recommend following the ReadMe section in that document.

Reason for not having an executable file:

I do not have an executable file due to the nature of my project. Since my project is a location-based AR exergame, the content will not be able to be tested or viewed unless you are at the actual real-world location. In the context of my game, this is the QMUL Mile End campus. So, to let examiners and potential users test my game I am using the simulation mode that Lightship offers. This allows the game to be tested in the Unity game view without having to go to the QMUL Mile End campus. My report goes into a lot more detail about this simulation mode, more can be read here:

https://lightship.dev/docs/ardk/how-to/unity/simulation_mocking/

How to run my program:

1. Download Unity Hub on your device: https://unity.com/download#how-get-started

2. Open Unity Hub

3. Agree to Unity’s Terms of Service

4. Skip the initial installation

5. Click on Installs and then Install Editor.

6. Click on Archive and then on the download archive hyperlink.

7. The hyperlink will take you to this website: https://unity.com/releases/editor/archive Click on the Unity 2021.X tab and then download Unity 2021.3.33 via Unity Hub

8. After clicking on the blue Unity Hub button a pop-up will appear. Click on Open Unity Hub.

9. Install the correct/recommended version depending on your device.

10. Make sure Visual Studio is installed (so you can view my code). Only iOS Build Support needs to be ticked under Platforms and then click Install.

11. You should now see a download bar

12. Now click on Projects and then Add

13. Go to the folder where you downloaded and unzipped my project. Click on the unzipped project folder and press Open

14.  The project should open successfully. The Game View should be shown on the right side and the display should already be set to iPhone 12 Pro. If it is not already set for any reason, click on the drop-down NEXT to Display 1 and select iPhone 12 Pro. If it’s too zoomed in, then be sure to adjust the scale slider so it zooms out

15.  Before you can start testing the game there is one more step. Click on Window and then Package Manager

16.  The Package Manager window should open. The Package Manager should already show the Niantic Lightship AR Plugin installed. But even though it shows this, not all of the functionalities of this plugin work

17.  To make it work as intended you have to install the Package again on your device. To do this, copy this link:
https://github.com/niantic-lightship/ardk-upm.git

18. In the Package Manager click on the plus icon in the top left and select “Add package from git URL”

19. Paste the link from Step 17 and click Add. After it installs you can close the Package Manager

20.  Important note: If the package doesn’t install then that means you need git on your device. To download git, go to this website: https://git-scm.com/downloads.
After git is downloaded make sure you restart Unity and Unity Hub.

21. You should now be able to successfully test my game. Press the play button located in the top middle of the screen.

Additional Important Information (Please Read):

To look around or move in the game screen you need to hold down the right click on your mouse. While holding down the right click on your mouse, you can look around (move the mouse), move forward (with W), move left (with A), move backwards (with S), move right (with D), move up (with Q), move down (with E). To move faster hold down the Shift Key while simultaneously pressing the other buttons. Keep in mind this is a simulation, in the actual game the user will be moving themselves.

To read more on how the simulation works you can visit this webpage:
https://lightship.dev/docs/ardk/how-to/unity/simulation_mocking/

Other important controls for simulation purposes:

In Location 1 – Left click to speak to the NPC.

In Location 2 – Left click to pick up the documents.

In Locations 3 and 4 – After pressing the Attack button, press SPACE to assassinate the NPC.

In Location 5 – Press F to throw the ball, and SPACE to attack the boss (after pressing the Attack button).

To interact with UI elements, just left-click on your mouse.


In the actual game, the user can tap on the interactable objects, tap in the middle of the screen to throw the ball and use gestures to attack/assassinate.
