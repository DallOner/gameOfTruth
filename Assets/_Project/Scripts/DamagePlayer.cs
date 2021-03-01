using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
  
    private GameObject thePlayer;

    [SerializeField]
    private int damage;

    //Detectamos la colision del personaje con el enemigo.
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Comprobamos si el objeto que colisiono con el enemigo es el 'Player'.
        if (collision.gameObject.tag.Equals("Player"))
        {
            collision.gameObject.GetComponent<HealthManager>().DamageCharacter(damage);
        }
    }
}
