using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySightSensor : MonoBehaviour
{
    public Transform Player { get; private set; }
    public float sightDistance = 10.0f;
    public float lostDistance = 15.0f;
    public float attackDistance = 4f;

    private void Awake()
    {
        Player = GameObject.FindWithTag("Player").transform;
    }

    private float GetPlayerDistance()
    {
        if (Player == null)
            return float.MaxValue;

        Vector2 direction = Player.position - transform.position;
        return direction.sqrMagnitude;
    }

    public bool Ping()
    {
        return GetPlayerDistance() <= sightDistance;
    }

    public bool Pong()
    {
        return GetPlayerDistance() > lostDistance;
    }

    public bool Slash()
    {
        return GetPlayerDistance() <= attackDistance;
    }

}