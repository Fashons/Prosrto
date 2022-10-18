using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{

    public Transform par; // корневой родитель
    private Vector3 startPos;
    float err_len;
    Vector3 p;

    void Start()
    {
        startPos = transform.position;
    }

    void LateUpdate()
    {
        Vector3 offset = transform.position - startPos;
        transform.position = startPos;
        par.position += offset;
    }
}