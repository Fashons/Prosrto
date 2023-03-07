using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectTrashMap : MonoBehaviour
{
    public Text CollectedTrash; //���������� ��������� �����
    public Text AllCollectableTrash; //����� ���������� ����� �� ������

    public static float CollectTrash; //������� ��������� �������
    private float AllTrashStart; //������� ��� ������� ����������� �� ������

    void Awake()
    {
        AllTrashStart = GameObject.FindGameObjectsWithTag("Trash").Length;
        CollectTrash = 0;
        SetAllCollectableTrash();
        CurrentCollectedTrash();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Trash"))
        {
            other.gameObject.SetActive(false);
            CollectTrash = CollectTrash + 1;
            SetAllCollectableTrash();
            CurrentCollectedTrash();
        }
    }

    public void SetAllCollectableTrash()
    {
        AllCollectableTrash.text = AllTrashStart.ToString();
    }

    public void CurrentCollectedTrash()
    {
        CollectedTrash.text = CollectTrash.ToString();
    }
}