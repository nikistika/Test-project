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
            
            Debug.Log($"characters.Count: {characters.Count}");

            
            if (characters.Count == 0)
            {
                return null;
            }
            
            int randomIndex = Random.Range(0, characters.Count-1);
            Debug.Log(randomIndex);
            if (characters[randomIndex] == null) Debug.Log($"characters[randomIndex] = null");

            BaseCharacter character = Instantiate(characters[randomIndex], position, Quaternion.identity);
            Debug.Log($"character: {characters}");

            characters.RemoveAt(randomIndex); //Надо удалять по индексу
            return character;
        }

        public void SetCharaccter(BaseCharacter character)
        {
            
            characters.Add(character);
        }
        
    }
}