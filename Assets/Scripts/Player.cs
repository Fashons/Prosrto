using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public KeyCode MoveKey;

    void Update()
    {
        if(Input.GetKey(MoveKey))
        transform.position = new Vector3(0, 0, 0);
    }
}