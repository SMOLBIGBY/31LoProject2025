using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float _maxHealth = 100;
    public float _currentHealth = 100;
    public static Player Instance;
    private Image _hpBarImage;
    public bool _cutscene = false;


    void Start()
    {
        _hpBarImage = FindAnyObjectByType<HealthBar>().gameObject.GetComponent<Image>();
        _currentHealth = _maxHealth;

        _currentHealth = PlayerPrefs.GetFloat("playerHealth");
        Debug.Log("Załadowane zdrowie: " + _currentHealth);
    }

    void Update()
    {
        _hpBarImage.fillAmount = _currentHealth / _maxHealth;
        if (_currentHealth > _maxHealth)
        {
            _currentHealth = _maxHealth;
        }
        else if (_currentHealth < 0)
        {
            _currentHealth = 0;
        }
    }
    private void OnApplicationQuit()
    {

        SaveHealth();
    }

    private void OnDisable()
    {

        SaveHealth();
    }

    public void SaveHealth()
    {

        PlayerPrefs.SetFloat("playerHealth", _currentHealth);
        PlayerPrefs.Save();
    }


    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        if (_currentHealth < 0) _currentHealth = 0;
        Debug.Log("Zaktualizowane zdrowie: " + _currentHealth);
    }
}
