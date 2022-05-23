using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public static GameManager sharedInstance;
    
    public TextMeshProUGUI level;

    public TextMeshProUGUI HardMode;

    public TextMeshProUGUI username;

    public TextMeshProUGUI volumeValue;


    private void Awake()
    {
        if (sharedInstance == null)
        {
            sharedInstance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    void Start()
    {
        // Aplicamos los cambios guardados en la escena Menu
        ApplyUserOptions();
    }

    public void ApplyUserOptions()
    {
        
        level.text = $"Level: { DataPersistence.sharedInstance.level}";
        HardMode.text = $"Hard Mode: {DataPersistence.sharedInstance.HardMode}";
        username.text = $"Username: {DataPersistence.sharedInstance.username}";
        volumeValue.text = $"Volume: { DataPersistence.sharedInstance.volumeValue}$";
    }

    
}
