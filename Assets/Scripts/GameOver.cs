using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOver : MonoBehaviour
{
    string programText = "";

    public GameObject Menu;

    [SerializeField] private AudioSource GameOverSound;

    //private float Tagger;


    private void OnTriggerEnter(Collider collision)
    {
        InputFielder inputFielder;

        if (collision.gameObject.TryGetComponent<InputFielder>(out inputFielder))
        {
            Menu.SetActive(true);

            programText = inputFielder.field.text;
            CodeSaver.Code = programText;
            inputFielder.ClearQueue();
            inputFielder.field.text = CodeSaver.Code;

            GameOverSound.Play();

        
        }
    }
}