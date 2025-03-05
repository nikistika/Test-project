using InventoryQuest.Scripts.BattleQuest;
using Characters;
using Chatacter;
using UnityEngine;

namespace Patterns
{
    public class EntryPointScaneBattle : MonoBehaviour
    {
        private Vector3 _spawnPositionCharacter1 = new(2, 1, 0);
        private Vector3 _spawnPositionCharacter2 = new(-2, 1, 0);

        [SerializeField] private CharactersFactory _charactersFactory;
        [SerializeField] private VictoryPanel _victoryPanel;


        public BaseCharacter Character1 { get; private set; }
        public BaseCharacter Character2 { get; private set; }

        private void Awake()
        {
            Character1 = _charactersFactory.CreateRandomCharacter(_spawnPositionCharacter1);
            Character2 = _charactersFactory.CreateRandomCharacter(_spawnPositionCharacter2);

            Character1.Construct(_victoryPanel, Character2);
            Character2.Construct(_victoryPanel, Character1);
        }
    }
}