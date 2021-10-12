using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonInitializator : MonoBehaviour
{
    public int mapWidth;
    public int mapHeigth;

    public int widthMinRoom;
    public int widthMaxRoom;
    public int heigthMinRoom;
    public int heigthMaxRoom;

    public int maxCorridorLength;
    public int maxFeatures;

    public void InitializeDungeon() { 
        MapManager.map = new Tile[mapWidth, mapHeigth];
    }
}
