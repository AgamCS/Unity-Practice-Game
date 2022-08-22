using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateManager : MonoBehaviour
{
    //public EnemyStats EnemyStats;
    public EnemyBaseState CurrentState; 

    // Sets a default state when the object activates
    void Start()
    {
        //CurrentState = idleState;
        CurrentState.EnterState(this);
    }

    // Called every frame
    void Update()
    {
        CurrentState.UpdateState(this);
    }

    // Method used in enemy states files to switch between states
    public void SwitchState(EnemyBaseState state)
    {
        CurrentState = state;
        state.EnterState(this);
    }
}
