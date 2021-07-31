using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using TMPro;

public class MenuController : MonoBehaviour
{
    public static int HighScore = 0;
    public static int HighChillScore = 0;
    public static bool Music = true;
    public static bool Paid = false;
    public static int TimesPlayed = 0;

    public TextMeshProUGUI MusicBtext;
    public GameObject buyScreen;

    public GameObject BlueB;
    public static bool blue = false;
    public TextMeshProUGUI BlueText;

    private void Start()
    {
        LoadData();

        if (Music)
        {
            MusicBtext.text = "MUSIC ON";
        }
        else
        {
            MusicBtext.text = "MUSIC Off";
        }

        if (Paid) BlueB.SetActive(true);
        else BlueB.SetActive(false);

        if (blue)
        {
            BlueText.text = "Blue On";
        }
        else
        {
            BlueText.text = "Blue Off";
        }
    }

    public void BlueButton()
    {
        if (blue)
        {
            blue = false;
            BlueText.text = "Blue Off";
        }
        else
        {
            blue = true;
            BlueText.text = "Blue On";
        }
    }

    public void PlayButton()
    {
        AudioManager.instance.Play("Click");
        SceneManager.LoadScene("GameScene");
    }

    public void ChillButton()
    {
        AudioManager.instance.Play("Click");
        if (Paid) SceneManager.LoadScene("ChillScene");
        else buyScreen.SetActive(true);
    }

    public void MusicButton()
    {
        AudioManager.instance.Play("Click");
        if (Music)
        {
            Music = false;
            MusicBtext.text = "MUSIC OFF";
        }
        else
        {
            Music = true;
            MusicBtext.text = "MUSIC ON";
        }
    }

    public void QuitButton()
    {
        AudioManager.instance.Play("Click");
        Application.Quit();
    }

    private void LoadData()
    {
        string path = Application.persistentDataPath + "/player.scores";
        //File.Delete(path);
        if (File.Exists(path))
        {
            PlayerData data = SaveSystem.LoadPlayer();

            if (data != null)
            {
                HighScore = data.HighestSaveScore;
                HighChillScore = data.HighestChillScore;

                TimesPlayed = data.TimesPlayed2;

                Paid = data.paid;
                Music = data.MusicSound;
            }
            else
            {
                Debug.Log("No Saved Data");
            }
        }
    }
}
