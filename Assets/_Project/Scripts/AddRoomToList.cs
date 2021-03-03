using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddRoomToList : MonoBehaviour
{
    // Start is called before the first frame update

    private RougeLikeManager rougeLike;
    void Start()
    {
        rougeLike = GameObject.FindGameObjectWithTag("Rooms").GetComponent<RougeLikeManager>();
        rougeLike.rooms.Add(this.gameObject);
    }
}
