using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int STEPSIZE = 2;
    public KeyCode MoveKey1;
    public KeyCode MoveKey2;
    public KeyCode MoveKey3;
    public KeyCode MoveKey4;
    


    void Update()
    {
        if(Input.GetKeyUp(MoveKey1))
        transform.position = new Vector3(transform.position.x + STEPSIZE, transform.position.y, transform.position.z);

        if (Input.GetKeyUp(MoveKey2))
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + STEPSIZE);

        if (Input.GetKeyUp(MoveKey3))
            transform.position = new Vector3(transform.position.x - STEPSIZE, transform.position.y, transform.position.z);

        if (Input.GetKeyUp(MoveKey4))
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - STEPSIZE);
    }
}