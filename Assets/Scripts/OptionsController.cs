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

    //Variables per guardar el nivell
    public TextMeshProUGUI LvlText;
    private int level;

    //Variables per guardar la dificultat
    private bool HardMode;
    public int Diff;
    public TextMeshProUGUI DifficultyText;

    //Variables per guardar el nom
    public string name;
    public TMP_InputField username;

    //Variable per guardar el volum
    public float volumeValue;

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
            Diff = 1;
        }
        else
        {
            DifficultyText.text = "Easy Mode";
            Diff = 0;
        }

        //name = username;

        
        
    }

    //Funció per activar el panels
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


    //Funcions per seleccionar els nivells
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
    
    //Funció per determinar el volum
    public void Volume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
        volumeValue = volume;
    }

    


    //Funcio per determinar que passa quan activam el
    public void ToggleFun(bool b)
    {
        if(b)
        {
            HardMode = true; 
            
        }
        else
        {
            HardMode = false;
            
        }
    }


    //Data persistance
    public void SaveUserOptions()
    {
        // Persistencia de datos entre escenas
        DataPersistence.sharedInstance.level = level;

        DataPersistence.sharedInstance.Diff = Diff;

        DataPersistence.sharedInstance.username = username.text;

        DataPersistence.sharedInstance.volumeValue = volumeValue;

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

            username.text = PlayerPrefs.GetString("USERNAME");

            volumeValue = PlayerPrefs.GetFloat("VOLUMEVALUE");

            Diff = PlayerPrefs.GetInt("MODE");
        }
    }

    private void UpdateLevel()
    {
        LvlText.text = "Level: " + level;
    }
}
