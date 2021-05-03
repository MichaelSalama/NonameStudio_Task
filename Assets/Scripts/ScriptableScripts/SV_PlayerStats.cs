using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStats_Name", menuName = "Scriptables/Variables/PlayerStats")]
public class SV_PlayerStats : ScriptableObject
{
    public MovementStats movementStats;

    private void OnEnable()
    {
        movementStats.acceleratorMultiplier = 1;
    }

}

[System.Serializable]
public class MovementStats
{
    [Space]
    public float currentSpeed = 0;
    public float maxSpeed = 5;
    [Space]
    [Header("Time In Seconds")]
    [Tooltip("Time for Acceleration")] public float timeZeroToMax = 3f;
    [Tooltip("Time for Decelerataion")] public float timeMaxToZero = 0.5f;
    [Space]
    [Space]
    [Header("Moevment under Gravity")]
    public float currentGravity = 0;
    public float maxGravity = 9;
    public float GravityTime = 3f;
   


    

    [HideInInspector]
    public float acceleratorMultiplier = 1f;


    public void SetCurrentSpeed(float value)
    {
        currentSpeed = value;
    }

    public void SetCurrentGravity(float value)
    {
        currentGravity = value;
    }
}
