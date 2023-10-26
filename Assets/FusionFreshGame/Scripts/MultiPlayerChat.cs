using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;
using TMPro;
using System.Runtime.InteropServices;
using UnityEngine.InputSystem;
using System;

public class MultiPlayerChat : NetworkBehaviour 
{

    [Header("Objects")]
    public GameObject chatEntryCanvas;
    public TMP_InputField _Input;
    public TextMeshProUGUI chatbody;
    public GameObject chatDisplay; 

    [HideInInspector]
    public static TextMeshProUGUI MyChatBody;

    [Header("Action Reference")]
     public InputActionReference startChat;
     public InputActionReference sendChat;

    [Header("Networked")]
    public GameObject network;

    [HideInInspector][Networked(OnChanged =nameof(LastPublicChatChanged))] public NetworkString<_256> LastPublicChat { get; set; }
    [HideInInspector][Networked(OnChanged = nameof(LastPrivateChatChanged))] public NetworkString<_256> LastPrivateChat { get; set; }

    private string thisPlayerName;
    protected static void LastPublicChatChanged(Changed<MultiPlayerChat> change)
    {
  
        MyChatBody.text += "\n" + change.Behaviour.thisPlayerName + ": "+ change.Behaviour.LastPublicChat.ToString();
    }

    protected static void LastPrivateChatChanged(Changed<MultiPlayerChat> change)
    {

    }
    private void Start()
    {
        if(HasStateAuthority)
        {
            startChat.action.performed += StartChat;
            sendChat.action.performed += SendChat;
            chatDisplay.SetActive(true);
            MyChatBody = chatbody;
        }
        thisPlayerName = transform.root.GetComponent<PlayerStats>().PlayerName.ToString();
    }

    private void SendChat(InputAction.CallbackContext context)
    {
        LastPublicChat = _Input.text;
        chatEntryCanvas.SetActive(false);
    }

    private void StartChat(InputAction.CallbackContext context)
    {
        chatEntryCanvas.SetActive(true);
        _Input.Select();
    }

}
