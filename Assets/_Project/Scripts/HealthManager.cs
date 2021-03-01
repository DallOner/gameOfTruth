using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    /**** Variables. ****/

    [SerializeField]
    private int maxHealth;
    [SerializeField]
    private int currentHealth;

    /**** Metudus. ****/

    // Start is called before the first frame update
    void Start()
    {
        //iniciamos el juego con la vida maxima.
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        //Verificamos si la vida es menor a cero.
        if (currentHealth <= 0)
        {
            //Desactivamos el GameObject porque no tiene mas vidas.
            gameObject.SetActive(false);
        }
    }

    //Metudus para calcular cuando el personaje reciba daño.
    public void DamageCharacter(int damage)
    {
        currentHealth -= damage;
    }

    //Cuando el personaje hace 'Level Up', le actualizamos la vida, con mas vida y se la rellenamos completamente.
    public void UpdateMaxHealth(int newMaxHealth)
    {
        maxHealth = newMaxHealth;
        currentHealth = maxHealth;
    }
}
