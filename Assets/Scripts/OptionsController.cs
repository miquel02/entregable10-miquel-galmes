using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Audio;

public class OptionsController : MonoBehaviour
{
    public GameObject gamePanel;
    public GameObject optionsPanel;

    public TextMeshProUGUI LvlText;
    private int Lvl;

    public AudioMixer audioMixer;

    void Start()
    {
        gamePanel.SetActive(true);
        optionsPanel.SetActive(false);
    }

    public void Options()
    {
        gamePanel.SetActive(false);
        optionsPanel.SetActive(true); 
    }
    public void Back()
    {
        gamePanel.SetActive(true);
        optionsPanel.SetActive(false);
    }

    public void Lvl1()
    {
        LvlText.text = $"Level: 1";
    }

    public void Lvl2()
    {
        LvlText.text = "Level: 2";
    }

    public void Lvl3()
    {
        LvlText.text = "Level: 3";
    }
   
    public void Volume(float volume)
    {
        audioMixer.SetFloat("volume", volume);      
    }
}
