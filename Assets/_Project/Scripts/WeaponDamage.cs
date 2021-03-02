﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDamage : MonoBehaviour
{
    /**** Variables. ****/

    [SerializeField]
    private int damage;

    public GameObject hurtAnimation;
    public GameObject hitPoint;
    public GameObject damageNumber
        ;

    /**** Metudus. ****/

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            collision.gameObject.GetComponent<HealthManager>().DamageCharacter(damage);

            Instantiate(hurtAnimation, hitPoint.transform.position, hitPoint.transform.rotation);

            var clone = (GameObject)Instantiate(damageNumber, hitPoint.transform.position, Quaternion.Euler(Vector3.zero));
        }
    }
}
