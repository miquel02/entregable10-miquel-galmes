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
    private int level;

    private bool HardMode;
    public TextMeshProUGUI DifficultyText;

    public AudioMixer audioMixer;

    void Start()
    {
        gamePanel.SetActive(true);
        optionsPanel.SetActive(false);
        LvlText.text = "Level: " + level;

        LoadUserOptions();

    }

    void Update()
    {
        if(HardMode== true)
        {
            DifficultyText.text = "Hard Mode";
        }
        else
        {
            DifficultyText.text = "Easy Mode";
        }
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
        level = 1;
        LvlText.text = "Level: "+ level;
    }

    public void Lvl2()
    {
        level = 2;
        LvlText.text = "Level: " + level;
    }

    public void Lvl3()
    {
        level = 3;
        LvlText.text = "Level: " + level;
    }

    public void HardBool()
    {
        HardMode = true;
    }

    public void EasyBool()
    {
        HardMode = false;
    }

    public void Volume(float volume)
    {
        audioMixer.SetFloat("volume", volume);      
    }



    //Data persistance
    public void SaveUserOptions()
    {
        // Persistencia de datos entre escenas
        DataPersistence.sharedInstance.level = level;
       
        // Persistencia de datos entre partidas
        DataPersistence.sharedInstance.SaveForFutureGames();
    }

    public void LoadUserOptions()
    {
        // Tal y como lo hemos configurado, si tiene esta clave, entonces tiene todas
        if (PlayerPrefs.HasKey("LEVEL"))
        {
            
            level = PlayerPrefs.GetInt("LEVEL");
            UpdateLevel();
        }
    }

    private void UpdateLevel()
    {
        LvlText.text = level.ToString();
    }
}
