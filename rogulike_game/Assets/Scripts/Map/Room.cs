using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    //
    public Transform[] BreacbleObjectsSpawnpoints;
    public Transform[] ChestSpawnpoints;
    public Transform[] MobSpawnpoints;

    public GameObject RoomCollider;

    public Door[] Doors;

    //
    private Collider2D _roomCollider;

    private void Start()
    {
        _roomCollider = RoomCollider.GetComponent<Collider2D>();
    }

    public void StartRoom(BreakbleObject[] breakbleObjects, Chest[] chests, Mob[] mobs)
    {
        foreach(Door dr in Doors)
        {
            _roomInit(breakbleObjects, chests, mobs);
            RoomCollider.SetActive(false);
            dr.Close();
        }    
    }

    public void EndRoom()
    {
        foreach (Door dr in Doors)
        {
            dr.Open();
        }
    }

    private void _roomInit(BreakbleObject[] breakbleObjects, Chest[] chests, Mob[] mobs)
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
