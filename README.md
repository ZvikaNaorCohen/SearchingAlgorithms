# SearchingAlgorithms
A program made with Windows Form GUI. 
It's purpose is to visualize the way that searching algorithms, such as BFS or DFS, are working.
The program is being updated on a weekly basis.

There are many searching algorithms in Computer Science world. 
Some of them are for weighted graphs. Some of them are for unweighted graphs. Some of them show us the fastest path to a selected point. 
I built this program to demonstrate how the different searching algorithms behave. 

Before showing the program, I want to explain the background of it. 
I made a Windows Form using Visual Studio, and added pictureboxes to it, in order to get a 2 dimensional matrix. 
Each picturebox holds it [X,Y] in the matrix.
Searching algorithms work for graphs, so I translated the given matrix to a graph:
Each picturebox is a vertex. There is an edge (u,v) if:
1. v's picturebox is under u's.
2. v's picturebox is left to u's.
3. v's picturebox is right to u's.
4. v's picturebox is above u's.

The different pictureboxes can be filled with different colors:
The default is White.
Starting Point color is Cyan.
Ending point color is Orange.
Walls are Dark Cyan.
When we run the algorithm, the picturebox can be marked in three different colors:
1. White: We haven't visited this picturebox yet.
2. Gray: We have visited this picturebox, but didn't finish scanning his neighbors.
3. Black: We have finished visiting this vertex and his neighbors.


We start the program and receive the main screen:  
<img width="252" alt="mainscreen" src="https://user-images.githubusercontent.com/57681792/178498106-083ee8a6-8437-4965-b7dc-3bbe9b66c9fb.png">


BFS and DFS algorithms are fully coded and functioning. More searching algorithms will be added.
We need to decide the size of the map.
After we choose the size we want, we receive the map:  
<img width="492" alt="algorithm screen" src="https://user-images.githubusercontent.com/57681792/178498300-4ad44f97-5920-4c4f-9c63-30a2a5c47280.png">

Using the mouse, we are able to add / remove walls.  

<img width="517" alt="algorithm screen" src="https://user-images.githubusercontent.com/57681792/178498533-f50e4ca2-9bb6-4e4c-8d4a-80afa9eea560.png">

After pressing "Run Finder" button, we can see how the chosen searching algorithm behaves. 
<img width="563" alt="algorithm screen" src="https://user-images.githubusercontent.com/57681792/178498672-1f84896a-0fdf-45c1-b8ef-b4f53342f2e1.png">

If the ending box is accessible, the algorithm would find it, and show the path is has passed in order to get to it. 
<img width="563" alt="algorithm screen" src="https://user-images.githubusercontent.com/57681792/178498776-0774fcc6-80a8-4c24-84d2-bdcf20620a24.png">


If the ending box is not accessible, no path would be shown. 


