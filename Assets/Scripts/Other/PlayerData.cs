using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int HighestSaveScore;
    public int HighestChillScore;

    public int TimesPlayed2;

    public bool paid;
    public bool MusicSound;

    public PlayerData(SaveDataScript player)
    {
        HighestSaveScore = player.HighestScore1;
        HighestChillScore = player.HighestChillScore1;
        TimesPlayed2 = player.TimesPlayed1;

        paid = player.Paid1;
        MusicSound = player.MusicSound1;
    }
}
