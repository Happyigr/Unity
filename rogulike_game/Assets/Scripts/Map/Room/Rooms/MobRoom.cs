using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobRoom : Room
{
    //
    public GameObject RoomZone;
    public Door[] Doors;

    public MobSpawner Spawner;

    //
    private RoomZone _roomZone;

    private void OnEnable()
    {
        _roomZone = RoomZone.GetComponent<RoomZone>();
        _roomZone.IsEnteredByPlayer += OnRoomIsEntered;
    }

    private void OnDisable()
    {
        _roomZone.IsEnteredByPlayer += OnRoomIsEntered;
    }

    private void StartRoom()
    {
        //Spawner.Spawn(); 

        RoomZone.SetActive(false);

        foreach (Door dr in Doors)
        {
            dr.Close();
        }
    }

    private void EndRoom()
    {
        foreach (Door dr in Doors)
        {
            dr.Open();
        }
    }

    private void OnRoomIsEntered()
    {
        StartRoom();
    }
}
