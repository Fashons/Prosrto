using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOver : MonoBehaviour
{
    public GameObject Player;
    //string programText = "";


    private void OnTriggerEnter(Collider collision)
    {
        InputFielder inputFielder;
        if (collision.gameObject.TryGetComponent<InputFielder>(out inputFielder))
        {
            //programText = inputFielder.field.text;

            inputFielder.ClearQueue();
            SceneManager.LoadScene("1Level");

            //Debug.Log("Nen");

            //StartCoroutine("RestoreCode");
            
        }


        /*IEnumerator RestoreCode()
        {
            yield return new WaitForSeconds(5);
            inputFielder.field.text = programText;
        }*/
    }
}