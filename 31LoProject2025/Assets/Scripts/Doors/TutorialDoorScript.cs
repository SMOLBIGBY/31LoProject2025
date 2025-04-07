using UnityEngine;

public class TutorialDoorScript : MonoBehaviour
{

    [SerializeField] UpdateT _up;

    public GameObject Letterprefab;

    bool playerInTrigger = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Letterprefab.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerInTrigger && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("E key pressed");
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !_up._cutscene)
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
