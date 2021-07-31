using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class BetweenChillScript : MonoBehaviour
{
    public TextMeshProUGUI highText;
    public TextMeshProUGUI lastText;

    private SaveDataScript SaveData;

    // Start is called before the first frame update
    void Start()
    {
        if (ChillController.lastChillScore > MenuController.HighChillScore) MenuController.HighChillScore = ChillController.lastChillScore;

        highText.text = "High Score: " + MenuController.HighChillScore.ToString();
        lastText.text = "Last Score: " + ChillController.lastChillScore.ToString();

        MenuController.TimesPlayed++;


        if (MenuController.TimesPlayed >= 6)
        {
            if (!MenuController.Paid)
                AdController.AdInstance.ShowAd("video");
            MenuController.TimesPlayed = 0;
        }

        Save();
    }

    public void PlayAgain()
    {
        AudioManager.instance.Play("Click");
        SceneManager.LoadScene("ChillScene");
    }

    public void Menu()
    {
        AudioManager.instance.Play("Click");
        SceneManager.LoadScene("MainMenu");
    }

    private void Save()
    {
        SaveData = GameObject.Find("SaveObject").GetComponent<SaveDataScript>();

        SaveData.HighestScore1 = MenuController.HighScore;
        SaveData.HighestChillScore1 = MenuController.HighChillScore;
        SaveData.TimesPlayed1 = MenuController.TimesPlayed;
        SaveData.MusicSound1 = MenuController.Music;
        SaveData.Paid1 = MenuController.Paid;

        SaveSystem.SavePlayer(SaveData);
    }
}
