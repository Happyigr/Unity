using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    //
    public Transform[] BreacbleObjectsSpawnpoints;
    public Transform[] ChestSpawnpoints;
    public Transform[] MobSpawnpoints;

    public Transform BreacbleObjFolder;
    public Transform ChestsFolder;
    public Transform MobFolder;

    public Door[] Doors;

    public void StartLevel()
    {
        
    }
    public void EndLevel()
    {

    }

    private void _Init(BreakbleObject[] breakbleObjects, Chest[] chests, Mob[] mobs)
    {
        foreach(Transform BOSpawnpoint in BreacbleObjectsSpawnpoints)
        {
            var BreackObj = breakbleObjects[Random.Range(0, breakbleObjects.Length)];
            Instantiate(BreackObj, BOSpawnpoint);
        }
        foreach (Transform CHSpawnpoint in ChestSpawnpoints)
        {
            var ChestObj = chests[Random.Range(0, chests.Length)];
            Instantiate(ChestObj, CHSpawnpoint);
        }
        foreach (Transform MOSpawnpoint in BreacbleObjectsSpawnpoints)
        {
            var MobObj = breakbleObjects[Random.Range(0, mobs.Length)];
            Instantiate(MobObj, MOSpawnpoint);
        }
    }
}
