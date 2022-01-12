using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Room : MonoBehaviour
{
    public Conector[] Conectors;

    public void ConnectToSideOfAnotherRoom(Room room, Side side)
    {
        Transform roomTransform = gameObject.GetComponent<Transform>();

        switch (side)
        {
            case Side.Right:
                roomTransform.localPosition = room.GetConnectorWorldCoords(side) - GetConnectorLokalCoords(Side.Left);
                room.BlockConnector(side);
                BlockConnector(Side.Left);
                break;
            case Side.Left:
                roomTransform.localPosition = room.GetConnectorWorldCoords(side) - GetConnectorLokalCoords(Side.Right);
                room.BlockConnector(side);
                BlockConnector(Side.Right);
                break;
            case Side.Up:
                roomTransform.localPosition = room.GetConnectorWorldCoords(side) - GetConnectorLokalCoords(Side.Down);
                room.BlockConnector(side);
                BlockConnector(Side.Down);
                break;
            case Side.Down:
                roomTransform.localPosition = room.GetConnectorWorldCoords(side) - GetConnectorLokalCoords(Side.Up);
                room.BlockConnector(side);
                BlockConnector(Side.Up);
                break;
            default:
                break;
        }
    }

    private Vector3 GetConnectorLokalCoords(Side side)
    {
        return GetConectorBySide(side).GetComponent<Transform>().localPosition;
    }

    private Vector3 GetConnectorWorldCoords(Side side)
    {
        return GetConectorBySide(side).GetComponent<Transform>().position;
    }

    public void BlockConnector(Side side)
    {
        GetConectorBySide(side).Block();
    }

    public bool IsConnectorBlockedBySide(Side side)
    {
        return GetConectorBySide(side).IsBlocked();
    }

    private Conector GetConectorBySide(Side side)
    {
        foreach (Conector con in Conectors)
        {
            if (con.Side == side)
            {
                return con;
            }
        }

        return null;
    }
}
