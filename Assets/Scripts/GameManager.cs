using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public static GameManager sharedInstance;
    

    //Variables per guardaar els textos
    public TextMeshProUGUI level;

    public TextMeshProUGUI Diff;

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
        Diff.text = $"Hard Mode: {DataPersistence.sharedInstance.Diff}";
        username.text = $"Username: {DataPersistence.sharedInstance.username}";
        volumeValue.text = $"Volume: { DataPersistence.sharedInstance.volumeValue}";
    }

    
}
