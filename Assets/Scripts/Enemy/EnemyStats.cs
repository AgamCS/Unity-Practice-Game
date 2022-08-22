using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "EnemyStats", menuName = "Brackey 8th GameJam/EnemyStats", order = 0)]
public class EnemyStats : ScriptableObject {
    
    [Tooltip("Movement speed of this enemy")]
    public int Speed;
    [Tooltip("Amount of damage this enemy deals per shot")]
    public int Damage;
    [Tooltip("Delay between shots in miliseconds")]
    public int RateOfFire;
    [Tooltip("The number of bullets any enemy can fire before needing to reload")]
    public int MagazineSize;
    [Tooltip("Number of shots per burst")]    
    public int ShotsPerBurst;
    [Tooltip("Minimum and maximum delay between bursts")]
    public int BurstDelayMin, BurstDelayMax;
    [Tooltip("Time it takes for this enemy to reload")]
    public int ReloadSpeed;
    [Tooltip("The range in which the bullets are likely to deviate on the y-axis")]
    public float Accuracy;
}

