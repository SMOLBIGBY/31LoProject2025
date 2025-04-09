using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float _maxHealth = 100;
    public float _currentHealth = 100;
    public static Player Instance;
    private Image _hpBarImage;


    void Start()
    {
        _hpBarImage = FindAnyObjectByType<HealthBar>().gameObject.GetComponent<Image>();
        _currentHealth = _maxHealth;
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
    //void Awake()
    //{
    //    if (Instance == null)
    //    {
    //        Instance = this;
    //        DontDestroyOnLoad(gameObject); // <- Nie niszcz tego obiektu przy zmianie sceny
    //    }
    //    else
    //    {
    //        Destroy(gameObject); // <- Jeśli drugi taki powstanie, usuń go
    //    }
    //}
}
