using System.Collections.Generic;
using Characters;
using UnityEngine;

namespace _Project.Scripts.BattleQuest
{
    public class CharactersFactory : MonoBehaviour
    {
        
        [SerializeField] private List<BaseCharacter> characters;

        public BaseCharacter CreateRandomCharacter(Vector3 position)
        {
            
            if (characters.Count == 0)
            {
                return null;
            }
            
            int randomIndex = Random.Range(0, characters.Count-1);
            BaseCharacter character = Instantiate(characters[randomIndex], position, Quaternion.identity);

            characters.RemoveAt(randomIndex); //Надо удалять по индексу
            return character;
        }

        public void SetCharaccter(BaseCharacter character)
        {
            
            characters.Add(character);
        }
        
    }
}