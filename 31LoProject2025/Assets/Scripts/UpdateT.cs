using UnityEngine;
using UnityEngine.SceneManagement; 
using UnityEngine.UI;
public class UpdateT : MonoBehaviour
{
    [SerializeField] private int health = 100; 
    public bool _cutscene = false;
    private void Start()
    {
        
        health = PlayerPrefs.GetInt("playerHealth", 100);  
        Debug.Log("Załadowane zdrowie: " + health);
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

        PlayerPrefs.SetInt("playerHealth", health);
        PlayerPrefs.Save();  
    }

    public void SetHealth(int newHealth)
    {
        health = newHealth;
    }

    
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health < 0) health = 0;  
        Debug.Log("Zaktualizowane zdrowie: " + health);
    }
}
