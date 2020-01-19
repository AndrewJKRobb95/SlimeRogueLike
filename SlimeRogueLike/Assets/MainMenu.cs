using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject settingsPanel;

    public void StartGame()
    {
        //may replace the scene index with string names later, depending on ease and if Unity scene PKs reassign themselves based on order or not
        Debug.Log("Starting game...");
        SceneManager.LoadScene(1);
    }

    public void SettingsMenuToggle()
    {
        settingsPanel.SetActive(!settingsPanel.activeSelf);
    }

    public void EndGame()
    {
        Debug.Log("Ending game...");
        Application.Quit();
    }
}
