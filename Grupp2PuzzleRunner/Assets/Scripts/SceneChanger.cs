using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour {

    public void HowToPlayScene()
    {
        SceneManager.LoadScene("HowToPlayScene");
    }

    public void MainManuScene()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void SettingsScene()
    {
        SceneManager.LoadScene("SettingsScene");
    }

    public void EarlyAccessBestAcess()
    {
        SceneManager.LoadScene("PreAlphaEarlyAcces");
    }

    public void LevelSelect()
    {
        SceneManager.LoadScene("LevelSelect");
    }
}
