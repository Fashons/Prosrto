using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public KeyCode MoveKey1;
    public KeyCode MoveKey2;


    void Update()
    {
        if(Input.GetKeyUp(MoveKey1))
        transform.position = new Vector3(transform.position.x+2, 1, 0);

        if (Input.GetKeyUp(MoveKey2))
        transform.position = new Vector3(transform.position.y+0, 1, 2);
    }
}