using UnityEngine;

public class UpdateT : MonoBehaviour
{
    public float _playerHealth = 100;
    public bool _cutscene = false;
    public static UpdateT Instance;

    void Start()
    {

    }

    void Update()
    {

    }
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // <- Nie niszcz tego obiektu przy zmianie sceny
        }
        else
        {
            Destroy(gameObject); // <- Jeśli drugi taki powstanie, usuń go
        }
    }
}