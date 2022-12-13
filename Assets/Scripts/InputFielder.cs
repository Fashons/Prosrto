using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputFielder : MonoBehaviour
{
    public int STEPSIZE = 2;
    public InputField field;

    private double currentValue = 0.0;
    private double limit = 0.0;
    private float delay = 0;

    private Queue<CommandBlock> queue = new Queue<CommandBlock>();


    public void SomeMethod()
    {
        string[] lines = field.text.Split('\n');

        foreach (var line in lines)
        {
            string[] fullCommand = line.Split('(');
            string command = fullCommand[0].Split('.')[1];
            int value = 0;
            int.TryParse(fullCommand[1].TrimEnd(')'), out value);

            queue.Enqueue(new CommandBlock() { command = command, value = value });
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
        else
        {
            while (delay < 2.0f)
            {
                delay += Time.deltaTime;
            }

            if (queue.Count > 0)
            {
                var queuedElement = queue.Dequeue();
                RunCommand(queuedElement.command, queuedElement.value);
            }
        }
        if (currentValue < limit)
        {
            var rotateR = Time.deltaTime * 90f;
            transform.Rotate(Vector3.up, rotateR);
            currentValue += rotateR;
        }
        else
        {
            if (queue.Count > 0)
            {
                var queuedElement = queue.Dequeue();
                RunCommand(queuedElement.command, queuedElement.value);
            }
        }
        if (currentValue < limit)
        {
            var rotateL = Time.deltaTime * -90f;
            transform.Rotate(Vector3.up, rotateL);
            currentValue += rotateL;
        }
        else
        {
            if (queue.Count > 0)
            {
                var queuedElement = queue.Dequeue();
                RunCommand(queuedElement.command, queuedElement.value);
            }
        }
    }


    internal class CommandBlock
    {
        public string command;
        public int value;
    }
    

    private void RunCommand(string command, int value)
    {
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
}