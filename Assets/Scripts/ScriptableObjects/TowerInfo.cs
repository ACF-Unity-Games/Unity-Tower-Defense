using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TowerInfo", menuName = "ScriptableObjects/TowerInfo", order = 1)]
public class TowerInfo : ScriptableObject
{

    [Header("Tower Properties")]
    public Sprite TowerSprite;
    [Range(1, 10)]
    public float TowerRange;
    [Range(0.1f, 3f)]
    public float ReloadSpeed = 0.5f;

    [Header("Bullet Properties")]
    public Sprite BulletSprite;
    [Range(10, 60)]
    public float BulletMoveSpeed = 20;

}
