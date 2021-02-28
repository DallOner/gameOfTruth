using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float distance = 32f;
    private const string horizontal = "Horizontal";
    private const string vertical = "Vertical";


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown) 
        {
            if (Mathf.Abs(Input.GetAxisRaw(horizontal)) > 0.5f)
            {
                this.transform.Translate(new Vector2(Input.GetAxisRaw(horizontal) * distance, 0));
            }

            if (Mathf.Abs(Input.GetAxisRaw(vertical)) > 0.5f)
            {
                this.transform.Translate(new Vector2(0, Input.GetAxisRaw(vertical) * distance));
            }
        }
            
    }
}
