using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> _charactersList;

    void Start()
    {
        GameObject character1 = GetUniqueRandomCharacter(_charactersList);
        GameObject character2 = GetUniqueRandomCharacter(_charactersList);

        Instantiate(character1, new Vector3(2, 1, 0), Quaternion.identity);
        Instantiate(character2, new Vector3(-2, 1, 0), Quaternion.identity);
    }

    private GameObject GetUniqueRandomCharacter(List<GameObject> availableCharacters)
    {
        if (availableCharacters.Count == 0)
        {
            return null;
        }

        int randomIndex = Random.Range(0, availableCharacters.Count);
        GameObject selectedCharacter = availableCharacters[randomIndex];
        availableCharacters.RemoveAt(randomIndex); // Удаляем выбранный объект, чтобы он не повторялся

        return selectedCharacter;
    }
}