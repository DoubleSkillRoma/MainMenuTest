using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.IO;
using System.Drawing;

public class Buttons : MonoBehaviour
{
    [SerializeField] private GameObject _easyRaw;
    [SerializeField] private GameObject _mediumRaw;
    [SerializeField] private GameObject _hardRaw;
    [SerializeField] private GameObject _startButton;
    public void NewGame()
    {
        SceneManager.LoadScene("DifficultyScene");
    }



    public void AccountScene()
    {
        SceneManager.LoadScene("AccountScene");
    }

    public void SettingsScene()
    {
        SceneManager.LoadScene("SettingsScene");
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif

    }

    public void BackScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        if (currentSceneIndex == 0)
        {
            Debug.Log("Нельзя переключиться на предыдущую сцену, так как это первая сцена в списке.");
            return;
        }

        int previousSceneIndex = currentSceneIndex - 1;

        SceneManager.LoadScene(previousSceneIndex);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void EasyButton()
    {
        _startButton.SetActive(true);
        _mediumRaw.SetActive(false);
        _hardRaw.SetActive(false);
        _easyRaw.SetActive(true);
    }

    public void MediumButton()
    {
        _startButton.SetActive(true);
        _easyRaw.SetActive(false);
        _hardRaw.SetActive(false);
        _mediumRaw.SetActive(true);
    }

    public void HardButton()
    {
        _startButton.SetActive(true);
        _easyRaw.SetActive(false);
        _mediumRaw.SetActive(false);
        _hardRaw.SetActive(true);
    }

}
