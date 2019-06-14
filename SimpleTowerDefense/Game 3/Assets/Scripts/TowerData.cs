using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class TowerData 
{
    public GameObject TowerPrefab;
    public int cost;
    public GameObject TowerUpPrefab;
    public int costUp;
    public TowerType type;
}

public enum TowerType
{
    LaserTower,
    MissileTower,
    MachineGunTower
}