using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class CollectTrashMap : MonoBehaviour
{
    public Text CollectedTrash; //���������� ��������� �����
    public Text AllCollectableTrash; //����� ���������� ����� �� ������

    public static float CollectTrash; //������� ��������� �������
    private float AllTrashStart; //������� ��� ������� ����������� �� ������
    public GameObject Palka; //����������� ����

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