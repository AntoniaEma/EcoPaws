using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishFlag : MonoBehaviour
{
    [SerializeField] private int requiredTrashBags; // Numărul total de pungi necesar

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            CheckTrashBags();
        }
    }

    private void CheckTrashBags()
    {
        if (TrashManager.instance != null)
        {
            int currentTrashBags = TrashManager.instance.GetTrashBags(); // Obținem numărul curent de pungi colectate
            if (currentTrashBags >= requiredTrashBags)
            {
                Invoke("LoadSortingScene", 1f);
            }
            else
            {
                Debug.Log("Nu ai colectat toate pungile de gunoi!");
            }
        }
    }

    private void LoadSortingScene()
    {
        SceneManager.LoadScene("Sorting");
    }
}
