using UnityEngine;

public class TextDamage : MonoBehaviour
{
    [SerializeField] private float speedTranslate = 0.6f;

    private void Update()
    {
        transform.Translate(0, speedTranslate * Time.deltaTime, 0);
    }
}