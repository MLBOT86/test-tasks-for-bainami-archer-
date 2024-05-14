using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="BowOption", menuName ="CreateBowOption")]
public class BowOption : ScriptableObject
{
    public string Name;
    public Sprite Sprite;
    public float StartPower;
    public float MaxPower;
    public GameObject BulletPrefab;

}
