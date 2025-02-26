using System.Collections.Generic;
using BattleQuest;
using UI;
using UnityEngine;

namespace System
{
    public class GameManager : MonoBehaviour
    {
        
        public List<GameObject> EnemiesList;
        
        [SerializeField] private GameObject _victoryPanel;
        
        private string _nameCharacterVictory;

        private void Awake()
        {
            EnemiesList = new List<GameObject>();
        }

        private void Update()
        {
            if (EnemiesList.Count == 1 && _nameCharacterVictory == null)
            {
                _nameCharacterVictory = EnemiesList[0].GetComponent<InteractionData>().NameCharacter;


                _victoryPanel.GetComponent<VictoryPanel>().ShowVictoryText(_nameCharacterVictory);
                _victoryPanel.SetActive(true);
            }
        }
    }
}