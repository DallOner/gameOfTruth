using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementCOntroller : MonoBehaviour
{
    /**** Variables. ****/

    public float speed = 128f;
    public bool isWalking;
    public float walkTime = 0.25f;
    public float waitTime = 0.25f;

    private float waitTimeCounter;
    private float walkCounter;
    private int currentDirection;

    private Animator enemyAnimator;//para transmitir los parametros horizontal y vertical 
    private const string horizontal = "Horizontal";//nombre de los parametros que estan en unity
    private const string vertical = "Vertical";//nombre de los parametros que estan en unity

    /**** Components. ****/

    private Vector2[] walkingDirections =
    {
        //Definimos las diferentes direcciones que tomará nuestro npc.
        new Vector2(1,0),
        new Vector2(0,1),
        new Vector2(-1,0),
        new Vector2(0, -1)
    };

    private Rigidbody2D rigidbody;


    /**** Metudus. ****/

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        enemyAnimator = GetComponent<Animator>();
        waitTimeCounter = waitTime;
        walkCounter = walkTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (isWalking)
        {
            rigidbody.velocity = walkingDirections[currentDirection] * speed;
            walkCounter -= Time.deltaTime;
            if (walkCounter < 0)
            {
                StopWalking();
            }
        }
        else
        {
            rigidbody.velocity = Vector2.zero;
            waitTimeCounter -= Time.deltaTime;

            if (waitTimeCounter < 0)
            {
                StartWalking();
            }
        }
        enemyAnimator.SetFloat(horizontal, walkingDirections[currentDirection].x);//lo movemos ya con los valores dados
        enemyAnimator.SetFloat(vertical, walkingDirections[currentDirection].y);//lo movemos ya con los valores dados
    }

    private void StartWalking()
    {
        isWalking = true;
        currentDirection = Random.Range(0, 4);
        walkCounter = walkTime;
    }

    private void StopWalking()
    {
        isWalking = false;
        waitTimeCounter = waitTime;
        rigidbody.velocity = Vector2.zero;
    }
}
