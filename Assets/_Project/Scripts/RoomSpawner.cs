using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    // Start is called before the first frame update

    //1 exit top
    //2 exit button
    //3 exit right
    //4 exit left

    public int openSite;

    private int aux;

    private bool spowned = false;

    [SerializeField]
    private RougeLikeManager rougeLike;

    //
    //
    void Start()
    {
        Invoke("Spown", 0.1f);

    }

    void Spown() 
    {
        if (!spowned)
        {
            switch (openSite)
            {

                case 1:
                    aux = Random.Range(0, rougeLike.bottonRooms.Length);
                    Instantiate(rougeLike.bottonRooms[aux], transform.position, rougeLike.bottonRooms[aux].transform.rotation);
                    break;

                case 2:
                    aux = Random.Range(0, rougeLike.topRooms.Length);
                    Instantiate(rougeLike.topRooms[aux], transform.position, rougeLike.topRooms[aux].transform.rotation);
                    break;
                /*Fall through*/

                case 3:
                    aux = Random.Range(0, rougeLike.leftRooms.Length);
                    Instantiate(rougeLike.leftRooms[aux], transform.position, rougeLike.leftRooms[aux].transform.rotation);
                    break;

                case 4:
                    aux = Random.Range(0, rougeLike.rightRooms.Length);
                    Instantiate(rougeLike.rightRooms[aux], transform.position, rougeLike.rightRooms[aux].transform.rotation);
                    break;
            }
            spowned = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("SpawnPoint"))
        {
            if (!collision.GetComponent<RoomSpawner>().spowned && !spowned) 
            {
                Instantiate(rougeLike.closedRooms, transform.position, rougeLike.closedRooms.transform.rotation);
                Destroy(gameObject);
            }
            
        }
    }
}
