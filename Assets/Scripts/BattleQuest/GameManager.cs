using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private string _nameCharacterVictory;
    
    public List<GameObject> enemiesList;
    
    [SerializeField] private GameObject _victoryPanel;
    
    private void Awake()
    {
        enemiesList = new List<GameObject>();
    }

    void Update()
    {
        Debug.Log($"Количество объектов на сцене {enemiesList.Count}");

        
        // if (enemiesList == null) return;
        
        if (enemiesList.Count == 1 && _nameCharacterVictory == null)
        {
            _nameCharacterVictory = enemiesList[0].GetComponent<InteractionData>().nameCharacter;
            Debug.Log($"_nameCharacterVictory: {_nameCharacterVictory}");

            
            
            _victoryPanel.GetComponent<VictoryPanel>().ShowVictoryText(_nameCharacterVictory);
            _victoryPanel.SetActive(true);
            
        }
        
    }
}
