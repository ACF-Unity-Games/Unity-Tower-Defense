using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BulletInfo
{
    public Sprite BulletSprite;
    [Range(10, 60)]
    public float BulletMoveSpeed = 20;
    public int BulletDamage;
    [Tooltip("Time bullet will survive while in mid-air (in seconds)")]
    public float BulletLifetime = 1;
    [Tooltip("Amount of enemies bullet can damage until disappearing")]
    public int BulletPierce = 1;
    public Vector2 BulletScale = new Vector2(1, 1);
}

[CreateAssetMenu(fileName = "TowerInfo", menuName = "ScriptableObjects/TowerInfo", order = 1)]
public class TowerInfo : ScriptableObject
{

    [Header("Tower Properties")]
    public Sprite TowerSprite;
    public Vector2 TowerScale = new Vector2(1, 1);
    [Range(1, 10)]
    public float TowerRange;
    [Range(0.1f, 3f)]
    public float ReloadSpeed = 0.5f;

    [Header("Slot Properties")]
    public Sprite SlotSprite;
    public int SlotCost;

    [Header("Bullet Properties")]
    public BulletInfo BulletInfo;

}
