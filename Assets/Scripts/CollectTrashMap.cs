using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class CollectTrashMap : MonoBehaviour
{
    public Text CollectedTrash; //Количество собранных монет
    public Text AllCollectableTrash; //Общее количество монет на уровне

    public static float CollectTrash; //Считаем собранные монетки
    private float AllTrashStart; //Считаем все монетки находящиеся на уровне
    public GameObject Palka; //Привязываем слеш

    public GameObject Menu;

    [SerializeField] private AudioSource PickUpSound;
    [SerializeField] private AudioSource WinSound;


    void Awake()
    {
        AllTrashStart = GameObject.FindGameObjectsWithTag("Trash").Length;
        CollectTrash = 0;
        SetAllCollectableTrash();
        CurrentCollectedTrash();
    }

    private void Start()
    {
        Palka.SetActive(true);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Trash"))
        {
            other.gameObject.SetActive(false);
            CollectTrash = CollectTrash + 1;
            PickUpSound.Play();
            SetAllCollectableTrash();
            CurrentCollectedTrash();

            if (CollectTrash == 4)
            {
                GameObject.Find("Player").SendMessage("CanMoveUpdate", false);
                WinSound.Play();
                Menu.SetActive(true);
            }
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