using UnityEngine;

public class UpdateT : MonoBehaviour
{
    public float _playerHealth = 100;
    public bool _cutscene = false;

    void Start()
    {
        // Pobierz HP z PlayerManager
        _playerHealth = PlayerManager.Instance.playerHealth;
    }

    void Update()
    {
        // Zapisuj HP do PlayerManager na bieżąco
        PlayerManager.Instance.playerHealth = _playerHealth;
    }
}