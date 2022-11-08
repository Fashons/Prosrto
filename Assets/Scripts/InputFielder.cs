using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class InputFielder : MonoBehaviour
{
    public InputField field; // вставь сюда через инспектор
    public ScriptableObject Movement;

    public void SomeMethod()
    {
        Debug.Log(field.text);
    }
}