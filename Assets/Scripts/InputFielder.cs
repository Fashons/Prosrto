using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class InputFielder : MonoBehaviour
{
    public int STEPSIZE = 2;
    public InputField field; // ������ ���� ����� ���������

    public void SomeMethod()
    {
        
        string[] fullCommand = field.text.Split('(');
        string command = fullCommand[0].Split('.')[1];
        int value = 0;
        int.TryParse(fullCommand[1].TrimEnd(')'), out value);

        switch (command)
        {
            case "move":
                Debug.Log($"������� ����������� �� {value} ����� ���������");
                transform.position += (transform.forward * STEPSIZE);
                break;

            case "left":
                Debug.Log("������� �������� ����� ���������");
                transform.Rotate(Vector3.up, -90f);
                break;

            case "right":
                Debug.Log("������� �������� ������ ���������");
                transform.Rotate(Vector3.up, 90f);
                break;
        }
    }
}