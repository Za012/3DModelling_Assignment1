using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public GameObject announcementObject;
    public Text announcementText;
    public Text levelText;

    public void Awake()
    {
        ClearScreen();
        Game.UI = this;
    }
    public void Start()
    {
        ChangeLevelText($"LEVEL: {Game.CURRENTLEVEL}");
    }
    public void ChangeAnnouncementText(string text, int time = 0)
    {
        announcementObject.SetActive(true);
        announcementText.text = text;
        if (time != 0)
        {
            StartCoroutine(TemporaryText(announcementText, time, announcementObject));
        }
    }

    private IEnumerator TemporaryText(Text textToEmpty, int time, GameObject go = null)
    {
        yield return new WaitForSeconds(time);
        textToEmpty.text = "";
        if(go != null)
        {
            go.SetActive(false);
        }
    }

    public void ChangeLevelText(string text, int time = 0)
    {
        levelText.text = text;
        if (time != 0)
        {
            StartCoroutine(TemporaryText(levelText,time));
        }
    }

    public void ClearScreen()
    {
        ChangeAnnouncementText("");
        ChangeLevelText("");
    }
}
