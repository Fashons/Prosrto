using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class InputFielder : MonoBehaviour
{
    public InputField field; // ������ ���� ����� ���������
    public ScriptableObject Movement;

    public void SomeMethod()
    {
        Debug.Log(field.text);
    }
}