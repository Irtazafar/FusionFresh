using IrtazaGeni.FusionFresh;
using StarterAssets;
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

    [SerializeField]
    GameObject UiCanvas;


    public void SubmitName()
    {
        FusionConnection.instance.ConnectToRunner(nameInputField.text, roomInputField.text);
        canvas.SetActive(false);
        UiCanvas.SetActive(true);
      
    }
    public void ActivateButton ()
    {
        submitButton.interactable = true;
    }
}
