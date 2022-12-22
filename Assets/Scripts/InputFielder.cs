using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputFielder : MonoBehaviour
{
    public int STEPSIZE = 2;
    public InputField field;
    public int RotTime = 7500;

    private double currentValue = 0.0;
    private double limit = 0.0;
    private double currentValueL = 0.0;
    private double limitL = 0.0;
    private double currentValueR = 0.0;
    private double limitR = 0.0;

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
            if (queue.Count > 0)
            {
                var queuedElement = queue.Dequeue();
                RunCommand(queuedElement.command, queuedElement.value);
            }
        }
        
        if (currentValueR < limitR)
        {
            var rotateR = Time.deltaTime / 90.0f * RotTime;
            transform.Rotate(Vector3.up, rotateR);
            currentValueR += rotateR;
        }
        else
        {
            if (queue.Count > 0)
            {
                var queuedElement = queue.Dequeue();
                RunCommand(queuedElement.command, queuedElement.value);
            }
        }

        if (currentValueL < limitL)
        {
            var rotateL = Time.deltaTime / -90.0f * RotTime;
            transform.Rotate(Vector3.up, rotateL);
            currentValueL += rotateL;
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

            case "right":
                limitR = 90.0f;
                currentValueR = 0.0;
                break;

            case "left":
                limitL = -90.0f;
                currentValueL = 0.0;
                break;
        }
    }
}