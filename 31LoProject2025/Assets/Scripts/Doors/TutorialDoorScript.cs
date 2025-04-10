using UnityEngine;
using UnityEngine.SceneManagement; // <-- Dodaj to

public class TutorialDoorScript : MonoBehaviour
{
    public GameObject Letterprefab;
    bool playerInTrigger = false;

    void Start()
    {
        Letterprefab.SetActive(false);
    }

    void Update()
    {
        if (playerInTrigger && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("E key pressed");
            SceneManager.LoadScene("Level1"); // <-- Zmiana sceny
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !collision.GetComponent<Player>()._cutscene)
        {
            Letterprefab.SetActive(true);
            playerInTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Letterprefab.SetActive(false);
            playerInTrigger = false;
        }
    }
}
