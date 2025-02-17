using System.Collections;
using ObjectPool;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;


namespace DefaultNamespace
{
    public class InteractionData : MonoBehaviour
    {
        
        private PoolMono<TextDamage> pool; 
        
        public int maxHealth;
        public int HP;
        public bool stunEffect;
        public bool debuffEffect;
        public int debuffPercent;
        public string nameCharacter;
        
        [SerializeField] private int poolCount = 10;
        [SerializeField] private bool autoExpand = false;
        [SerializeField] private TextDamage textPrefab;
        [SerializeField] private TMP_Text _hpCharacterTMP;
        [SerializeField] private Slider _hpSlider;
        
        private Vector3 positionTextDamage = new (0.3f, 0.3f, -0.7f);

        private GameManager _gameManager;
        
        void Awake()
        {
            pool = new PoolMono<TextDamage>(textPrefab, poolCount, transform);
            pool.autoExpand = autoExpand; 
            
            HP = maxHealth;
            
            _hpSlider.maxValue = maxHealth;
            _hpSlider.value = maxHealth;
            
            _hpCharacterTMP.text = $"{HP}/{maxHealth}";
            
            _gameManager = FindObjectOfType<GameManager>();

        }
        
        public void GetDamage(int damage)
        {
            HP -= damage;
            _hpSlider.value = HP;
            _hpCharacterTMP.text = $"{HP}/{maxHealth}";

            if (HP <= 0)
            {
                _gameManager.enemiesList.Remove(gameObject);
                Destroy(gameObject);
                return;
            }

            string textDamage = $"-{damage}";
            CreateTextView(textDamage, positionTextDamage);
        }

        
        public void CreateTextView(string text, Vector3 positionText)
        {
            var textDamage = pool.GetFreeElement();
            textDamage.transform.localPosition = positionText;
            textDamage.GetComponent<TextMeshPro>().text = text;
            StartCoroutine(ReturnToPoolAfterDelay(textDamage, 2f));
        }
    
        private IEnumerator ReturnToPoolAfterDelay(TextDamage textDamage, float delay)
        {
            yield return new WaitForSeconds(delay);
            pool.SetObject(textDamage);
        }
        
    }
}