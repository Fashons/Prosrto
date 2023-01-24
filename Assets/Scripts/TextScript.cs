using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextScript : MonoBehaviour
{
    public Text TextGameObject;
    private string text;
    private Text Text;

    private void Start()
    {
        text = TextGameObject.text;
        TextGameObject.text = "";
        StartCoroutine(TextCoroutine());
        Invoke("TextSvitcher", 3f);

    }
    void TextSvitcher()
    {
        Text = GameObject.Find("TextOnDisplay").GetComponent<Text>();
        Text.text = "Давай научу тебя играть!";
    }
    IEnumerator TextCoroutine()
    {
        foreach (char abc in text)
        {
            TextGameObject.text += abc;
            yield return new WaitForSeconds(0.10f);
        }
    }
}