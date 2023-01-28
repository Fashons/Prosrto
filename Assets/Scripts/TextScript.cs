using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextScript : MonoBehaviour
{
    public Text TextGameObject;
    public Text TextGameObject2;
    private string text;
    public GameObject TextOnDisplay;
    public GameObject TextOnDisplay2;

    private void Start()
    {
        text = TextGameObject.text;
        TextGameObject.text = "";
        StartCoroutine(TextCoroutine());
        Invoke("Text2", 3f);
    }
    void Text2()
    {
        TextOnDisplay.SetActive(false);
        TextOnDisplay2.SetActive(true);
        text = TextGameObject2.text;
        TextGameObject2.text = "";
        StartCoroutine(TextCoroutine());
    }
    IEnumerator TextCoroutine()
    {
        foreach (char abc in text)
        {
            TextGameObject.text += abc;
            TextGameObject2.text += abc;
            yield return new WaitForSeconds(0.10f);
        }
    }
}