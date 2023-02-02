using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextScript : MonoBehaviour
{
    public Text TextGameObject;
    private int index = 0;
    private float prevTime = 0.0f;
    private float prevWordsTime = 0.0f; 
    Queue<string> queue = new Queue<string>();
    private string Vvod1 = "�����������!!!";
    private string Vvod2 = "����� ����� ������";
    private string Vvod3 = "������ � ��� ���� ����� ������� �� ����������";
    private string Vvod4 = "��� ���� ��� �������, ���� �� �������� ������� ��� ���������� �������";
    private string Vvod5 = "����� � ��� 3 �������:";
    private string Vvod6 = "bot.move(����� ���� �����) - ��� ������� ��������� ������� ������ �����";
    private string Vvod7 = "bot.right() - ��� ������� ������������ ������ ������";
    private string Vvod8 = "bot.left() - ��� ������� ������������ ������ �����";
    private string Vvod9 = "��� � ���� � ������ �������";
    private string Vvod10 = "����� � ����!";

    private void Start()
    {
        TextGameObject.text = "";
        queue.Enqueue(Vvod1);
        queue.Enqueue(Vvod2);
        queue.Enqueue(Vvod3);
        queue.Enqueue(Vvod4);
        queue.Enqueue(Vvod5);
        queue.Enqueue(Vvod6);
        queue.Enqueue(Vvod7);
        queue.Enqueue(Vvod8);
        queue.Enqueue(Vvod9);
        queue.Enqueue(Vvod10);
    }

    private void FixedUpdate()
    {
        if (queue.Count > 0)
        {
            string word = queue.Peek();
            if (index < word.Length)
            {
                prevTime += Time.deltaTime;
                if (prevTime > 0.1f)
                {
                    TextGameObject.text += word[index++];
                    prevTime = 0;
                }
            }
            else
            {
                prevWordsTime += Time.deltaTime;
                if (prevWordsTime > 2.0f)
                {
                    index = 0;
                    TextGameObject.text = "";
                    prevWordsTime = 0;
                    queue.Dequeue();
                }
            }
        }
    }
}