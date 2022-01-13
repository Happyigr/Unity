using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobSpawner : Spawner
{
    public BreakbleObject[] BreakbleObjectsPrefabs;
    public Mob[] MobsPrefabs;
    public int amount;
    public float MobSpawnRangeX; // In tiles amount
    public float MobSpawnRangeY;

    private Mob MobPrefabChoose(Mob[] MobArr)
    {
        return MobArr[Random.Range(0, MobArr.Length)];
    }

    private void SetMobInRangeOf0Coords(Mob mob, float xRange, float yRange)
    {
        Transform mobTransform = mob.GetComponent<Transform>();
        Vector3 point = new Vector3(Random.Range(-xRange, xRange), Random.Range(-yRange, yRange), 0);
        mobTransform.position += point;
    }

    public override void Spawn(int amount)
    {
        for (int i = 0; i < Amount; i++)
        {
            Mob MobPrefab = MobPrefabChoose(MobsPrefabs);
            Mob MobObject = Instantiate(MobPrefab, Container.GetComponent<Transform>());
            SetMobInRangeOf0Coords(MobObject, MobSpawnRangeX, MobSpawnRangeY);
        }
    }
}
