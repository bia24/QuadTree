# QuadTree
A simple implementation of QuadTree in Unity
## How to use?   
Just clone and open project by Unity.Run it.   
* The gameobject withing player's bounds can be shown, others set not active. 
* To determin which gameobject is withing player's bounds, do not use O(n) time to traverse,which n is the number of all gameobjects in the secens.It just costs O(m) time, which m is depend on the number of QuadTree node and gameobject withing player's bounds.Fortunately, m is much smaller than n.     
## Example      
![QuadTree screen shot](https://github.com/bia24/QuadTree/blob/master/QuadTree.png)
