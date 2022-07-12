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
![image](https://user-images.githubusercontent.com/57681792/178491939-d50a3108-2baf-4d2f-ad9b-70d1019d6ac1.png)

BFS and DFS algorithms are fully coded and functioning. More searching algorithms will be added.
We need to decide the size of the map.
After we choose the size we want, we receive the map:
![image](https://user-images.githubusercontent.com/57681792/178492101-f1bb9fd4-e4fe-44a8-83d8-74928cd62fca.png)

Using the mouse, we are able to add / remove walls.
After pressing "Run Finder" button, we can see how the chosen searching algorithm behaves. 
If the ending box is accessible, the algorithm would find it, and show the path is has passed in order to get to it.
If the ending box is not accessible, no path would be shown. 
