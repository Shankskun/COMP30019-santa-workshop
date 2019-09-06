using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameProperties : MonoBehaviour {

    // easy access to game mechanics
    public float SetConveyorBeltSpeed = 2;
    public static float ConveyorBeltSpeed;

    public float SetBoxMovementSpeed = 0.8f;
    public static float BoxMovementSpeed;

    public float SetBoxSpawnRate = 3.0f;
    public static float BoxSpawnRate;

    public float SetTotalTime = 90.0f;
    public static float TotalTime;

    public float SetIncreaseSpeed1 = 45.0f;
    public static float IncreaseSpeed1;

    public float SetIncreaseSpeed2 = 15.0f;
    public static float IncreaseSpeed2;

    public bool SetSnowmanCheat = true;
    public static bool SnowmanCheat;

    [Range(1, 10)]
    public int SetSnowmanSpawnRate = 2;
    public static int SnowmanSpawnRate;

    public float SetSnowmanTime = 70.0f;
    public static float SnowmanTime;

    [Range(1, 10)]
    public int SetTimeIntervalBetweenSnowmanSpawn = 3;
    public static int TimeIntervalBetweenSnowmanSpawn;

    [Range(0, 1)]
    public float SetSlowTimePowerUp = 0.5f;
    public static float SlowTimePowerUp;

    [Range(0,5)]
    public float SetPowerUpTimeInterval = 5.0f;
    public static float PowerUpTimeInterval;

    [Range(0, 100)]
    public float SetPowerUpChance = 70.0f;
    public static float PowerUpChance;

    // set all the variables
    private void Awake()
    {
        // boxes
        ConveyorBeltSpeed = SetConveyorBeltSpeed;
        BoxMovementSpeed  = SetBoxMovementSpeed;
        BoxSpawnRate = SetBoxSpawnRate;
        // general time
        TotalTime = SetTotalTime;
        IncreaseSpeed1 = SetIncreaseSpeed1;
        IncreaseSpeed2 = SetIncreaseSpeed2;
        // snowman
        SnowmanSpawnRate = SetSnowmanSpawnRate;
        SnowmanTime = SetSnowmanTime;
        TimeIntervalBetweenSnowmanSpawn = SetTimeIntervalBetweenSnowmanSpawn;
        // powerup
        SlowTimePowerUp = SetSlowTimePowerUp;
        PowerUpTimeInterval = SetPowerUpTimeInterval;
        PowerUpChance = SetPowerUpChance;
    }

    // speed of the appearence of the belt moving
    public static float GetConveyorBeltSpeed() 
    { 
        return ConveyorBeltSpeed; 
    }

    // speed of box
    public static float GetBoxMovementSpeed()
    {
        return BoxMovementSpeed;
    }

    // speed on box respawn rate
    public static float GetBoxSpawnRate()
    {
        return BoxSpawnRate;
    }

    // total game time
    public static float GetTotalTime()
    {
        return TotalTime;
    }

    // time1 where box should increase in speed
    public static float GetIncreaseSpeedTime1()
    {
        return IncreaseSpeed1;
    }

    // time2 where box should increase in speed
    public static float GetIncreaseSpeedTime2()
    {
        return IncreaseSpeed2;
    }

    // percentage of snowman spawning 
    public static int GetSnowmanSpawnRate()
    {
        return SnowmanSpawnRate;
    }

    // snowman cheat mode (press P to remove)
    public static bool GetSnowmanCheat()
    {
        return SnowmanCheat;
    }

    // snowman cheat mode (press P to remove)
    public static float GetSnowmanTime()
    {
        return SnowmanTime;
    }

    // time interval between snowman being spawn
    public static int GetTimeIntervalBetweenSnowmanSpawn()
    {
        return TimeIntervalBetweenSnowmanSpawn;
    }

    // rate if time being slowed down
    public static float GetSlowTimePowerUp()
    {
        return SlowTimePowerUp;
    }

    // chance of powerUp activating
    public static float GetPowerUpChance()
    {
        return PowerUpChance;
    }

    // powerUp time interval
    public static float GetPowerUpTimeInterval()
    {
        return PowerUpTimeInterval;
    }

}
