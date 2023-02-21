using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectTrash : MonoBehaviour
{
    public static float CollectTrash; //������� ��������� ��������� �����
    public Text AllCollectableTrash; //����� ���������� ������ �� ������
    private float AllTrashStart; //������� ���� ����� ����������� �� ������

    void Awake()
    {
        AllTrashStart = GameObject.FindGameObjectsWithTag("PickUpTrash").Length;
        CollectTrash = 0;
        SetAllCollectableTrash();
        CurrentCollectedTrash();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUpTrash"))
        {
            other.gameObject.SetActive(false);
            CollectTrash = CollectTrash + 1;
            AllTrashStart = AllTrashStart - 1;
            SetAllCollectableTrash();
            CurrentCollectedTrash();
        }
    }
}
