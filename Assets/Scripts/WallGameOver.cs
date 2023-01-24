using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class WallGameOver : MonoBehaviour
{
    public GameObject Player;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player")
        {
            //очистить очередь и вернуть пылесос в координаты x = ? y = ?
            //то есть обратиться к объекту Player и вызвать в нём функцию ClearQeue()


            SceneManager.LoadScene("NewScene");
        }
    }
}