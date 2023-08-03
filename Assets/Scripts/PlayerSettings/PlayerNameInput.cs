using UnityEngine;
using TMPro;

public class PlayerNameInput : MonoBehaviour
{
    [SerializeField] private TMP_InputField _nameInputField;

    private const string PlayerNameKey = "PlayerName";

    private void Start()
    {
        LoadPlayerName();
    }

    public void OnNameChanged(string newName)
    {
        SavePlayerName(newName);
    }

    public void SavePlayerName(string playerName)
    {
        PlayerPrefs.SetString(PlayerNameKey, playerName);
    }

    private void LoadPlayerName()
    {
        if (PlayerPrefs.HasKey(PlayerNameKey))
        {
            string playerName = PlayerPrefs.GetString(PlayerNameKey);
            _nameInputField.text = playerName;
        }
        else
        {
            _nameInputField.text = "Player";
        }
    }
}