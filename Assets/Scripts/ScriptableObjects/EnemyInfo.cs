using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyDeathInfo
{
    public EnemyInfo EnemyInfo;
    public int EnemyCount = 1;
}

[CreateAssetMenu(fileName = "EnemyInfo", menuName = "ScriptableObjects/EnemyInfo", order = 1)]
public class EnemyInfo : ScriptableObject
{

    [Header("Enemy Properties")]
    public Sprite EnemySprite;
    public int EnemyHealth;
    public Vector2 EnemyScale = new Vector2(1, 1);
    [Header("Enemies to Spawn On Death")]
    public List<EnemyDeathInfo> EnemiesToSpawnOnDeath;

}
