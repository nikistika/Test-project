using _Project.Scripts.BattleQuest;
using Characters;
using UnityEngine;

namespace Patterns
{
    public class EntryPointGame : MonoBehaviour
    {

        [SerializeField] private CharactersFactory _charactersFactory;

        private Vector3 _spawnPositionCharacter1 = new (2, 1, 0);
        private Vector3 _spawnPositionCharacter2 = new (-2, 1, 0);
        
        public BaseCharacter Character1 { get; private set; }
        public BaseCharacter Character2 { get; private set; }

        private void Awake()
        {
            Character1 = _charactersFactory.CreateRandomCharacter(_spawnPositionCharacter1);
            
            Character2 = _charactersFactory.CreateRandomCharacter(_spawnPositionCharacter2);
        }
        
        private void Start()
        {

        }
        
    }
}