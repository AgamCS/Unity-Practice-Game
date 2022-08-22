using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "WeaponScriptableObject", menuName = "Brackey 8th GameJam/Weapon", order = 0)]
public class WeaponScriptableObject : ScriptableObject {
    [Tooltip("Amount of damage this weapon deals per shot")]
    public int Damage;
    [Tooltip("How many bullets you can fire before needing to reload")]
    public int MagazineSize;
    [Tooltip("The max amount of ammo for this weapon you can hold")]
    public int MaxAmmo;
    [Tooltip("Time it takes to reload")]
    public int ReloadSpeed;
    [Tooltip("Delay between shots")]
    public int RateOfFire;
    [Tooltip("The firing group of this weapon")]
    public FireType FireType;
}

