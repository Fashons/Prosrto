using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class InputFielder : MonoBehaviour
{
    public int STEPSIZE = 2;
    public InputField field;

    private double currentValue = 0.0;
    private double limit = 0.0;

    public void SomeMethod()
    {
        string[] fullCommand = field.text.Split('(');
        string command = fullCommand[0].Split('.')[1];
        int value = 0;
        int.TryParse(fullCommand[1].TrimEnd(')'), out value);

        switch (command)
        {
            case "move":
                limit = value * STEPSIZE;
                currentValue = 0.0;
                break;

            case "left":
                transform.Rotate(Vector3.up, -90f);
                break;

            case "right":
                transform.Rotate(Vector3.up, 90f);
                break;
        }
    }


    void Update()
    {
        if (currentValue < limit)
        {
            var distance = Time.deltaTime * STEPSIZE;
            transform.Translate(Vector3.forward * distance);
            currentValue += distance;
        }
        // else
        //     currentValue = limit = 0;
    }
}