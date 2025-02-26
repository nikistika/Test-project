using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class VictoryPanel : MonoBehaviour
    {
        [SerializeField] private TMP_Text _textVictory;

        public void ShowVictoryText(string nameCharacter)
        {
            _textVictory.text = $"Победил:\n{nameCharacter}";
        }

        public void RestartGame()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}