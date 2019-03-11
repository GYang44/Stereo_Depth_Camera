# Depth Camera Man

This use Unity game engine to generate stere-camera photo and depth photo for CNN training.

## 1.How to Setup

1. Install Unity engine

2. Open this project

## 2.How to Use

### 2.1 Manipulate the Environment
The default view port is set based on the main camera attached to the player, this camera help the user to position the snapshot cameras to shot. Snapshots are taken by depth camera and stereo cameras. Depth camera share the same position and direction as the main camera, though it's rendered with a different shader. The stereo camera comprise two cameras, one to the left of the main camera, the other to the right. To change the baseline of the stereo camera, you need to modify their transform > postition > X property in the Unity inspector, under hierarchy player > stereoCamera > StereoL/R.

This tool come with 3 running modes, manual, auto without CSV and auto with CSV. You can choose one of these three modes in the dropdown menu on top-left. In manual mode you can position the camera manually. Auto without CSV mode yet to be implemented. Auto with CSV require you to provide of disired attetude(s) in a CSV file and the software will execute accordinglly.

### 2.2 Manual Mode

In this mode, you can position the camera manually then shot as you wish. W S A D keys plus your mouse move the camera in FPS game fashion, R to assend, F to descend. 

1. Use keyboard to move the player to a desired position in the scene, use mouse to control the dirction of the camera.

2. Press "space" to take snapshot

3. Snapshots will be storeed in Assets/Snapshots (need to be created before first running)

### 2.3 Auto Without CSV
To be implemented...

### 2.4 Auto With CSV

In this mode, you can provide the camera with a CSV file specifying all desired locations, to that the system can take snapshots accordingly.

1. Create a CSV file named Test.csv in the asset folder.

2. In the CSV file, each line should has exactly 6 floading numbers, seperated by commas, specifying X, Y, Z, pitch, yaw, roll (in degrees to world)

3. Select auto with csv in the drop down manual, the system will take snapshots automaticly and store them in Assets/Snapshots. Once finish, the system will return to manual mode.
