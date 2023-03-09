using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObmenScripts : MonoBehaviour
{

    private GameObject Text1;
    private GameObject Text2;

    void Start()
    {
        Test sourceTest = Text1.GetComponent<Test>();
        Test receiverTest = Text2.AddComponent<Test>();

        foreach (var field in typeof(Test).GetFields())
        {
            field.SetValue(receiverTest, field.GetValue(sourceTest));
        }
    }
}
