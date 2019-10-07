using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponStats : MonoBehaviour
{
    public float DamagePerSecond;
    public float DamageInterval;
    public float DamagePerFrame
    {
        get
        {
            return 1000 / DamageInterval * DamagePerSecond;
        }
    }
}
