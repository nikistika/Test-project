using System.Collections.Generic;
using BattleQuest;
using UI;
using UnityEngine;

namespace System
{
    public class GameManager : MonoBehaviour
    {
        
        [HideInInspector] public List<GameObject> EnemiesList;
        
        [SerializeField] private VictoryPanel _victoryPanel;
        
        private string _nameCharacterVictory;

        private void Update()
        {
            if (EnemiesList.Count == 1 && _nameCharacterVictory == null)
            {
                _nameCharacterVictory = EnemiesList[0].GetComponent<InteractionData>().NameCharacter;


                _victoryPanel.ShowVictoryText(_nameCharacterVictory);
                _victoryPanel.gameObject.SetActive(true);
            }
        }
    }
}