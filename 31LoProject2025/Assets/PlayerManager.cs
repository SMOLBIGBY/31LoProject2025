using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance;

    public float playerHealth = 100f;

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
