using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOver : MonoBehaviour
{
    //public GameObject Player;
    string programText = "";

    public GameObject Menu;

    [SerializeField] private AudioSource GameOverSound;


    private void OnTriggerEnter(Collider collision)
    {
        if (gameObject.CompareTag("Wall"))
        {
            InputFielder inputFielder;
            if (collision.gameObject.TryGetComponent<InputFielder>(out inputFielder))
            {
                programText = inputFielder.field.text;
                CodeSaver.Code = programText;

                inputFielder.ClearQueue();
                //SceneManager.LoadScene("1Level");
                Menu.SetActive(true);

                inputFielder.field.text = CodeSaver.Code;

                //GameOverSound.Play();
            }
        }
    }
}