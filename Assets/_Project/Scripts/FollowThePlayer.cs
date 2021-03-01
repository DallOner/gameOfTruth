using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowThePlayer : MonoBehaviour
{
    [SerializeField]
    private GameObject followTarget; //para poder seguir
    [SerializeField] //se usa para ver las variables en el editor a pesar de que sean privadas
    private Vector3 targetPosition; //tener siempre un lugar de referencia
    [SerializeField]
    private float cameraSpeed = 4.0f; //al mismo valor que el jugador

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        targetPosition = new Vector3(followTarget.transform.position.x, followTarget.transform.position.y, this.transform.position.z); //el target position seguira los pasos de x y y pero quedara alejada en z

        this.transform.position = Vector3.Lerp(this.transform.position, targetPosition, cameraSpeed * Time.deltaTime);//este objeto se movera en 3 dimenciones, partiendo de su punto original, a donde debe moverse la camara la cual es calculada por targetPosition, bajo que parametro se movera pues es la velocidad por los frame spor segundo
    }
}
