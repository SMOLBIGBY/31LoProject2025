using UnityEngine;
using UnityEngine.SceneManagement; 
using UnityEngine.UI;
public class UpdateT : MonoBehaviour
{
    [SerializeField] private int health = 100; 
    public bool _cutscene = false;

    [SerializeField] Player _pl;

    void Start()
    {
        
        _pl._currentHealth = PlayerPrefs.GetFloat("playerHealth", 100f);  
        Debug.Log("Załadowane zdrowie: " + _pl._currentHealth);

        _pl = FindFirstObjectByType<Player>();
    }

    //Saves the parameters when the game is closed or the scene is changed

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

        PlayerPrefs.SetFloat("playerHealth", _pl._currentHealth);
        PlayerPrefs.Save();  
    }

    
    public void TakeDamage(int damage)
    {
        _pl._currentHealth -= damage;
        if (health < 0) _pl._currentHealth = 0;  
        Debug.Log("Zaktualizowane zdrowie: " + _pl._currentHealth);
    }
}
