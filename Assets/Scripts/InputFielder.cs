using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputFielder : MonoBehaviour
{
    public int STEPSIZE = 4;
    public int RotTime = 7500;
    public InputField field;

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
            string[] fullCommand = line.Split('(');
            string command = fullCommand[0].Split('.')[1];
            int value = 0;
            int.TryParse(fullCommand[1].TrimEnd(')'), out value);

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
                    break;
            }
            queue.Enqueue(new CommandBlock() { command = command, value = value, currentValue = 0.0, limit = limit });
        }
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
                        Debug.Log("Deque move");
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
                        Debug.Log("Deque right");
                        queue.Dequeue();
                    }
                    break;

                case "left":
                    if (queuedCommand.currentValue < queuedCommand.limit)
                    {
                        var rotateR = Time.deltaTime / -90.0f * RotTime;
                        transform.Rotate(Vector3.up, rotateR);
                        queuedCommand.currentValue += rotateR;
                    }
                    else
                    {
                        Debug.Log("Deque left");
                        queue.Dequeue();
                    }
                    break;

                default:
                    break;
            }
        }
    }
}