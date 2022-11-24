using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class InputFielder : MonoBehaviour
{
    public int STEPSIZE = 2;
    public InputField field; // вставь сюда через инспектор

    public void SomeMethod()
    {
        
        string[] fullCommand = field.text.Split('(');
        string command = fullCommand[0].Split('.')[1];
        int value = 0;
        int.TryParse(fullCommand[1].TrimEnd(')'), out value);

        switch (command)
        {
            case "move":
                Debug.Log($"Команда перемещения на {value} шагов выполнена");
                transform.position = transform.forward * STEPSIZE;//new Vector3(transform.position.x + STEPSIZE, transform.position.y, transform.position.z);
                break;

            case "left":
                Debug.Log("Команда поворота влево выполнена");
                transform.Rotate(0.0f, -90.0f, 0.0f);
                break;

            case "right":
                Debug.Log("Команда поворота вправо выполнена");
                transform.Rotate(0.0f, 90.0f, 0.0f);
                break;

            case "jump":
                Debug.Log($"Команда прыжка {value} раз выполнена");
                break;
        }
    }
}