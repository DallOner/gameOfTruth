using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RougeLikeManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] topRooms;
    public GameObject[] bottonRooms;
    public GameObject[] rightRooms;
    public GameObject[] leftRooms;
    public GameObject closedRooms;

    public List<GameObject> rooms;
    public GameObject enemies;
    public GameObject boss;
    public GameObject Life;
    public GameObject any;

    private void Start()
    {
        
    }

    void SpownEnemies() 
    {
        Instantiate(boss, rooms[rooms.Count - 1].transform.position, Quaternion.identity);

        foreach (var item in rooms)
        {
            Instantiate(enemies, item.transform.position, Quaternion.identity);
        }
    }

}
