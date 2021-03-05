using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour
{
    /**** Variables. ****/

    [SerializeField]
    private int maxHealth;
    private Transform playerPosition;

    public int currentHealth;
    private SFXManager sfxManager;
    

    /**** Metudus. ****/

    // Start is called before the first frame update
    void Start()
    {
        //iniciamos el juego con la vida maxima.
        currentHealth = maxHealth;
        sfxManager = FindObjectOfType<SFXManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //Verificamos si la vida es menor a cero.
        if (currentHealth <= 0)
        {
            SceneManager.LoadScene("GameOver");
            //Desactivamos el GameObject porque no tiene mas vidas.
            gameObject.SetActive(false);
            sfxManager.playerDead.Play();
            
            // Instanciar un objeto que contenga el Gameover y pueda oir el PressX to Try Again.
        }
    }

    //Metudus para calcular cuando el personaje reciba daño.
    public void DamageCharacter(int damage)
    {
        currentHealth -= damage;
        sfxManager.playerHurt.Play();
    }

    //Cuando el personaje hace 'Level Up', le actualizamos la vida, con mas vida y se la rellenamos completamente.
    public void UpdateMaxHealth(int newMaxHealth)
    {
        maxHealth = newMaxHealth;
        currentHealth = maxHealth;
    }
}
