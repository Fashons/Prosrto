using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObmenScripts : MonoBehaviour
{

    [SerializeField] GameObject source;
    [SerializeField] GameObject receiver;

    void Start()
    {
        Test sourceTest = source.GetComponent<Test>();
        Test receiverTest = receiver.AddComponent<Test>();
        
        foreach (var field in typeof(Test).GetFields())
        {
            field.SetValue(receiverTest, field.GetValue(sourceTest));
        }
    }
}