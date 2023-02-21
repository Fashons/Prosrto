using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectTrash : MonoBehaviour
{
    public static float collectTrash; //������� ��������� ��������� �����
    public TextMesh AllCollectableTrash; //����� ���������� ������ �� ������
    private float AllTrashStart; //������� ���� ����� ����������� �� ������

    void Awake()
    {
        AllTrashStart = GameObject.FindGameObjectsWithTag("PickUpTrash").Length;
        collectTrash = 0;
        //SetAllCollectableTrash();
        //CurrentCollectedTrash();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUpTrash"))
        {
            other.gameObject.SetActive(false);
            collectTrash = collectTrash + 1;
            AllTrashStart = AllTrashStart - 1;
            //SetAllCollectableTrash();
            //CurrentCollectedTrash();
        }
    }
}
