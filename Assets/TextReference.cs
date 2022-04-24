using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextReference : MonoBehaviour
{
    //Simple script to copy text from one object to another

    [SerializeField]
    private GameObject referenceText, targetText;

    void Update()
    {
        targetText.GetComponent<Text>().text = referenceText.GetComponent<Text>().text;
    }
}
