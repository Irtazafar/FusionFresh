using IrtazaGeni.FusionFresh;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class NameEntry : MonoBehaviour
{
    [SerializeField]
    TMP_InputField nameInputField;

    [SerializeField]
    TMP_InputField roomInputField;

    [SerializeField]
    Button submitButton;

    [SerializeField]
    GameObject canvas;

    public void SubmitName()
    {
        FusionConnection.instance.ConnectToRunner(nameInputField.text, roomInputField.text);
        canvas.SetActive(false);
    }
    public void ActivateButton ()
    {
        submitButton.interactable = true;
    }
}
