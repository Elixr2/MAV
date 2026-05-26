using UnityEngine;
using UnityEngine.SceneManagement;
public class Portal_next : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    [SerializeField] private string nextSceneName;
    private bool playerInPortal = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
    {
        if (other.CompareTag("Player"))
            {
                playerInPortal = true;
            }
    }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInPortal = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (playerInPortal && Input.GetKeyDown(KeyCode.UpArrow))
        {
            SceneManager.LoadScene(nextSceneName);
            print("Success");
        }
    }


}
    