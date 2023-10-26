using Fusion;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using IrtazaGeni.FusionFresh;
using System;

public class PlayerStats : NetworkBehaviour
{
    [Networked(OnChanged=nameof(UpdatePlayerName))]
    public NetworkString<_32> PlayerName { get; set; }

    

    [SerializeField]
    TextMeshPro playerNameLabel;

    private void Start()
    {
        if(this.HasStateAuthority)
        {
            PlayerName = FusionConnection.instance._playerName;
        }
    }

    protected static void UpdatePlayerName(Changed<PlayerStats> changed)
    {
        changed.Behaviour.transform.root.gameObject.name = changed.Behaviour.PlayerName.ToString();
        changed.Behaviour.playerNameLabel.text = changed.Behaviour.PlayerName.ToString();
    }
}
