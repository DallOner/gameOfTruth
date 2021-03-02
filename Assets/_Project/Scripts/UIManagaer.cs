using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManagaer : MonoBehaviour
{
    // Start is called before the first frame update
 
    public Sprite[] hearts;

    public HealthManager playerHealth;

    // Update is called once per frame
    void Update()
    {
        this.GetComponent<Image>().sprite = hearts[playerHealth.currentHealth];

    }
}
