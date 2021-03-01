using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float distance = 32f;
    public float speed = 4f;
    private const string horizontal = "Horizontal";
    private const string vertical = "Vertical";
    private Animator animator;
    [SerializeField] //se usa para ver las variables en el editor a pesar de que sean privadas
    private Vector3 targetPosition; //tener siempre un lugar de referencia

    public float enemySpeed = 1;//velocidad movimiento
    private Rigidbody2D playerRigidbody;//rigidbody enemigo

    private bool isMoving;//saber si se esta moviendo o no

    public float timeBetweenSteps;//tiempo entre movimientos
    private float timeBetweenStepsCounter;//contador cuanto tiempo a pasado desde el ultimo movimiento

    public float timeToMakeStep;//el tiempo que pasa en hacer el paso de una celda a la siguiente
    private float timeToMakeStepCounter;//el condador de cuanto tiempo a pasado en hacer el paso

    public Vector2 directionToMakeStep;//una direccion de movimiento


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        playerRigidbody = GetComponent<Rigidbody2D>();//inicilisamos las variabes

        timeBetweenStepsCounter = timeBetweenSteps;//se inicialice con la informacion que le ponemos en unity
        timeToMakeStepCounter = timeToMakeStep;//se inicialice con la informacion que le ponemos en unity

    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.anyKeyDown) 
        //{
            
        //    //animator.SetFloat(horizontal, Input.GetAxisRaw(horizontal));
        //    //animator.SetFloat(vertical, Input.GetAxisRaw(vertical));

            

            

        //}

        if (isMoving)
        {
            timeToMakeStepCounter -= Time.deltaTime;//descuenta el tiempo del ultimo renderisado
            playerRigidbody.velocity = directionToMakeStep;//movemos al enemigo a la direccion

            if (timeToMakeStepCounter < 0)//si se acaba el tiempo de movimiento
            {
                isMoving = false;//pone en falso el movimiento
                timeBetweenStepsCounter = timeBetweenSteps;//reinicia el contador
                playerRigidbody.velocity = Vector2.zero;//para el movimiento
                directionToMakeStep = playerRigidbody.velocity;
            }
        }
        else//si no se esta moviendo
        {
            timeBetweenStepsCounter -= Time.deltaTime;//resta tiempo al contador
            if (timeBetweenStepsCounter < 0)//si se acaba el tiempo de espera para el siguiente
            {
                

                if (Mathf.Abs(Input.GetAxisRaw(horizontal)) > 0.5f)
                {
                    //this.transform.Translate(new Vector2(Input.GetAxisRaw(horizontal) * distance, 0));

                    directionToMakeStep = new Vector2( Input.GetAxisRaw(horizontal) * distance, 0);
                    isMoving = true;//ponemos en true para empesar a movernos
                    timeToMakeStepCounter = timeToMakeStep;//re iniciamos el contador
                }

                if (Mathf.Abs(Input.GetAxisRaw(vertical)) > 0.5f)
                {
                    
                    directionToMakeStep = new Vector2(0, Input.GetAxisRaw(vertical) * distance);
                    isMoving = true;//ponemos en true para empesar a movernos
                    timeToMakeStepCounter = timeToMakeStep;//re iniciamos el contador
                    //this.transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, (Input.GetAxisRaw(vertical) * distance), 0), (Input.GetAxisRaw(vertical) * distance) * Time.deltaTime);
                    //this.transform.Translate(new Vector2(0, Input.GetAxisRaw(vertical) * distance));

                }
            }
        }

        animator.SetFloat(horizontal, directionToMakeStep.x);//lo movemos ya con los valores dados
        animator.SetFloat(vertical, directionToMakeStep.y);//lo 






    }
}
