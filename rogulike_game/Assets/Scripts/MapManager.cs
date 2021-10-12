using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System; // So the script can use serializible commands

public class MapManager 
{
    public static Tile[,] map; // the 2-dimensional map with the information for all the tiles
}

[Serializable] // Makes the class serializible so it can be saved out to a file
public class Tile{ // Holds all information of every object on map
    public int xPosition; // the position on x
    public int yPosition; // the position on y
    [NonSerialized]
    public GameObject baseObject; // the map game object, that attached to this tile (wall, floor, ...)
}