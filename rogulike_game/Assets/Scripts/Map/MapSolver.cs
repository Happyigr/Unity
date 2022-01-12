using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Problem !!!!
//when amount of rooms is to big, romms starting to connect to free conectors from another connector.
//we have A,B,C rooms. If I connect room B to room A from left side, and room C located on the up connector of room B, but room C not connected to room A
//problem - i can connect room A to a down connector of room C

public class MapSolver : MonoBehaviour
{
    // public things
    public Room[] RoomPrefabs;
    public int RoomsAmount; //start room not included
    public GameObject RoomContainer; //must to be a child of Grid

    private void Start()
    {
        SolveLevelMap(RoomsAmount);
    }

    //random map generation
    public void SolveLevelMap(int roomsAmount)
    {
        Transform roomContainer = RoomContainer.GetComponent<Transform>();

        for (int i = 0; i < roomsAmount; i++)
        {
            Room nRoom = RoomPrefabs[Random.Range(0, RoomPrefabs.Length)]; //chosing a room prefab, which we want to create
            Room createdRoomPrefab = Instantiate(nRoom, roomContainer);    //creating a room prefab

            Room[] roomsToConnect = RoomContainer.GetComponentsInChildren<Room>();   //solving all of created rooms

            Room roomToConect = roomsToConnect[Random.Range(0, roomsToConnect.Length)]; //chosing a room to conect
            List<Side> freeSides = FreeSidesOfRoom(roomToConect); //get a list of all free sides of room


            while (freeSides.Count == 0) //cheking, that room have a free conector(that haven't connected room)
            {
                freeSides = FreeSidesOfRoom(roomToConect); //get a list of all free sides of room
                roomToConect = roomsToConnect[Random.Range(0, roomsToConnect.Length)]; //chosing a room to conect
            }

            createdRoomPrefab.ConnectToSideOfAnotherRoom(roomToConect, RandomSideFromList(freeSides));
        }
    }

    private Side RandomSideFromList(List<Side> sides)
    {
        if (sides.Count == 1)
        {
            return sides[0];
        }

        while (true)
        {
            foreach(Side side in sides)
            {
                if(Random.Range(0,2) > 0)
                {
                    return side;
                }
            }
        }
    }

    private List<Side> FreeSidesOfRoom(Room room)
    {
        List<Side> sides = new List<Side>();

        foreach(Conector con in room.Conectors)
        {
            if (!con.IsBlocked())
            {
                sides.Add(con.Side);
            }
        }

        return sides;
    }
}

