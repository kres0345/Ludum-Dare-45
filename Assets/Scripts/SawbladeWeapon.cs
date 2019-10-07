using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawbladeWeapon : WeaponStats
{

    private float Timepassed;

    void Start()
    {

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Timepassed = DamageInterval;
        CheckDamage(col);
    }

    void OnCollision2D(Collision2D col)
    {
        Timepassed += Time.deltaTime;
        CheckDamage(col);
    }

    private void CheckDamage(Collision2D col)
    {
        print(Timepassed - (1000 / DamageInterval));
        if (Timepassed >= (DamageInterval / 1000))
        {
            print(col.gameObject.name);
            if (col.gameObject.CompareTag("Enemy"))
            {
                Entity entity = col.gameObject.GetComponent<Entity>();
                if (entity != null)
                {
                    entity.Damage(DamagePerFrame);
                    print(entity.HP);
                }

                Timepassed = 0;
            }
        }
    }
}
