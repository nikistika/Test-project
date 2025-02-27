using System.Collections.Generic;
using UnityEngine;

namespace SystemScane
{
    public class SpawnManager : MonoBehaviour
    {
        [SerializeField] private List<GameObject> _charactersList;
        private List<GameObject> _copyСharactersList;
        private void Awake()
        {
            _copyСharactersList = new List<GameObject>(_charactersList);
            
            Debug.Log(_charactersList == null? "_charactersList is null" : "_charactersList is not null");
            Debug.Log(_copyСharactersList == null? "_copyСharactersList is null" : "_copyСharactersList is not null");
        }
        
        private void Start()
        {
            GameObject character1 = GetUniqueRandomCharacter();
            GameObject character2 = GetUniqueRandomCharacter();
            
            Debug.Log(character1 == null? "character1 is null" : "character1 is not null");
            Debug.Log(character2 == null? "character2 is null" : "character2 is not null");

            
            Instantiate(character1, new Vector3(2, 1, 0), Quaternion.identity);
            Instantiate(character2, new Vector3(-2, 1, 0), Quaternion.identity);
        }

        private GameObject GetUniqueRandomCharacter()
        {
            if (_copyСharactersList.Count == 0)
            {
                return null;
            }

            int randomIndex = Random.Range(0, _copyСharactersList.Count);
            GameObject selectedCharacter = _copyСharactersList[randomIndex];
            _copyСharactersList.RemoveAt(randomIndex); // Удаляем выбранный объект, чтобы он не повторялся

            return selectedCharacter;
        }
    }
}