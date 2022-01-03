using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    // public things
    public Room[] Maps;
    public BreakbleObject[] BreakbleObjectsPrefabs;
    public Chest[] ChestsPrefabs;
    public Mob[] MobsPrefabs;

    private Room _currentMap;

    public void SolveLevelMap()
    {
        _MapInit();
    }

    private void _MapInit()
    {
        _currentMap.StartRoom(BreakbleObjectsPrefabs, ChestsPrefabs, MobsPrefabs);
    }
}

