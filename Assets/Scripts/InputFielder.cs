using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputFielder : MonoBehaviour
{
    public int STEPSIZE = 2;
    public int RotTime = 7500;
    public InputField field;

    private float prevTime = 0.0f;

    public Text errorText;

    private static Queue<CommandBlock> queue = new Queue<CommandBlock>();

    internal class CommandBlock
    {
        public string command;
        public int value;
        public double currentValue = 0.0;
        public double limit = 0.0;
    }

    public void SomeMethod()
    {
        string[] lines = field.text.Split('\n', System.StringSplitOptions.RemoveEmptyEntries);

        foreach (var line in lines)
        {
            string command = "";
            int value = 0;

            try
            {
                string[] fullCommand = line.Split('(');
                command = fullCommand[0].Split('.')[1];
                if (command == "move")
                    if (!int.TryParse(fullCommand[1].TrimEnd(')'), out value))
                    {
                        ErrorMessage("");
                        return;
                    }
            }
            catch
            {
                ErrorMessage("");
                return;
            }

            float limit = 0.0f;

            switch (command)
            {
                case "move":
                    limit = value * STEPSIZE;
                    break;

                case "right":
                    limit = 90.0f;
                    break;

                case "left":
                    limit = -90.0f;
                    break;

                default:
                    ErrorMessage("");
                    return;
            }
            queue.Enqueue(new CommandBlock() { command = command, value = value, currentValue = 0.0, limit = limit });
        }
    }

    public void ClearQueue()
    {
        queue.Clear();
    }

    private void ErrorMessage(string errorMessage)
    {
        errorText.GetComponent<Text>().enabled = true;
        prevTime = 0.0f;
    }


    void Start()
    {
        GameObject.Find("InputField").GetComponent<InputField>().text = CodeSaver.Code;
    }


    void Update()
    {
        if (queue.Count > 0)
        {
            CommandBlock queuedCommand = queue.Peek();

            switch (queuedCommand.command)
            {
                case "move":
                    if (queuedCommand.currentValue < queuedCommand.limit)
                    {
                        var distance = Time.deltaTime * STEPSIZE;
                        transform.Translate(Vector3.forward * distance);
                        queuedCommand.currentValue += distance;
                    }
                    else
                    {
                        queue.Dequeue();
                    }
                    break;

                case "right":
                    if (queuedCommand.currentValue < queuedCommand.limit)
                    {
                        var rotateR = Time.deltaTime / 90.0f * RotTime;
                        transform.Rotate(Vector3.up, rotateR);
                        queuedCommand.currentValue += rotateR;
                    }
                    else
                    {
                        queue.Dequeue();
                    }
                    break;

                case "left":
                    if (queuedCommand.currentValue > queuedCommand.limit)
                    {
                        var rotateL = Time.deltaTime / -90.0f * RotTime;
                        transform.Rotate(Vector3.up, rotateL);
                        queuedCommand.currentValue += rotateL;
                    }
                    else
                    {
                        queue.Dequeue();
                    }
                    break;

                default:
                    break;
            }
        }

        prevTime += Time.deltaTime;
        if (prevTime >= 5.0f)
            errorText.GetComponent<Text>().enabled = false;
    }
}