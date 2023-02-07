using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOver : MonoBehaviour
{
    public GameObject Player;

    private void OnTriggerEnter(Collider collision)
    {
        InputFielder inputFielder;
        if (collision.gameObject.TryGetComponent<InputFielder>(out inputFielder))
        {
            inputFielder.ClearQueue();   
            SceneManager.LoadScene("1Level");
        }
    }
}