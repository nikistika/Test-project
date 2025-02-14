using System.Collections;
using ObjectPool;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


namespace DefaultNamespace
{
    public class CharacterInteraction : MonoBehaviour
    {
        
        private PoolMono<TextDamage> pool; //!!!
        
        private int _maxHealth;
        public int HP;
        
        public bool stunEffect;
        [SerializeField] private int poolCount = 10;
        [SerializeField] private bool autoExpand = false;
        [SerializeField] private TextDamage textPrefab;
        [SerializeField] private TMP_Text _hpCharacterTMP;
        [SerializeField] private Slider _hpSlider;
        
        void Awake()
        {
            pool = new PoolMono<TextDamage>(textPrefab, poolCount, transform);
            pool.autoExpand = autoExpand; 
            
            _hpSlider.maxValue = _maxHealth;
            _hpSlider.value = _maxHealth;
        }
        
        public void GetDamage(int damage)
        {
            HP -= damage;
            _hpSlider.value = HP;
            _hpCharacterTMP.text = $"{HP}/{_maxHealth}";
            Debug.Log($"Current health {data.CharacterName}: {HP}");
            if (HP <= 0) Destroy(gameObject);

            CreateTextDamage(damage);
        }
        
        private void CreateTextDamage(int damage)
        {
            Vector3 positionText = new Vector3(0.3f, 0.3f, -0.7f);

            var textDamage = pool.GetFreeElement();
            textDamage.transform.localPosition = positionText;
            textDamage.GetComponent<TextMeshPro>().text = $"- {damage}";
            StartCoroutine(ReturnToPoolAfterDelay(textDamage, 2f));
        }
    
        private IEnumerator ReturnToPoolAfterDelay(TextDamage textDamage, float delay)
        {
            yield return new WaitForSeconds(delay);
            pool.SetObject(textDamage);
        }
        
    }
}