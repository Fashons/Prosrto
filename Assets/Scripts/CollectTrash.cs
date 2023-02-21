using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectTrash : MonoBehaviour
{
    public static float CollectTrash; //—читаем собранные собранный мусор
    public Text AllCollectableTrash; //ќбщее количество мусора на уровне
    private float AllTrashStart; //—читаем весь мусор наход€щиес€ на уровне

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
