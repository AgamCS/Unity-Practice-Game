using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "WeaponScriptableObject", menuName = "Brackey 8th GameJam/Weapon", order = 0)]
public class WeaponScriptableObject : ScriptableObject {
    public int Damage;
    public int MagazineSize;
    public int MaxAmmo;
    public int ReloadSpeed;
    public int RateOfFire;
    public string AmmoType;
    public FireType FireType;
}

