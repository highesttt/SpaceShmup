using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum eWeaponType {
    none,
    blaster,
    spread,
    phaser,
    missile,
    laser,
    shield
}

[System.Serializable]
public class WeaponDefinition {
    public eWeaponType type = eWeaponType.none;
    [Tooltip("Letter to show on the PowerUp Cube")]
    public string letter;
    [Tooltip("The color of the PowerUp Cube")]
    public Color powerUpColor = Color.white;
    [Tooltip("Prefab for the Weapon")]
    public GameObject weaponModelPrefab;
    [Tooltip("Prefab for the projectile")]
    public GameObject projectilePrefab;
    [Tooltip("Color of the projectile")]
    public Color projectileColor = Color.white;
    [Tooltip("Damage caused by the projectile")]
    public float damageOnHit = 0;
    [Tooltip("Damage caused per second by the laser [Not Implemented]")]
    public float damagePerSec = 0;
    [Tooltip("Seconds to delay between shots")]
    public float delayBetweenShots = 0;
    [Tooltip("Velocity of the projectile")]
    public float velocity = 50;
}

public class Weapon : MonoBehaviour {

}