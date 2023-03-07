using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectTrashMap : MonoBehaviour
{
    public Text CollectedTrash; //Количество собранных монет
    public Text AllCollectableTrash; //Общее количество монет на уровне

    public static float CollectTrash; //Считаем собранные монетки
    private float AllTrashStart; //Считаем все монетки находящиеся на уровне

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