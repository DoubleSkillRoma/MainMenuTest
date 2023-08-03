using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerNameText : MonoBehaviour
{
    [SerializeField] private TMP_Text _playerNameText;
    private const string PlayerNameKey = "PlayerName";

    private void Start()
    {
        LoadPlayerName();
    }
    private void LoadPlayerName()
    {
        if (PlayerPrefs.HasKey(PlayerNameKey))
        {
            string playerName = PlayerPrefs.GetString(PlayerNameKey);
            _playerNameText.text = $" Hello {playerName}, choose your challenge.";
        }
        else
        {
            _playerNameText.text = "Player Welcome";
        }
    }
}
