using UnityEngine;
using UnityEngine.SceneManagement;

public class SortingManager : MonoBehaviour
{
    [SerializeField] private DraggableItem[] itemsToSort;

    private void Update()
    {
        if (AreAllItemsSorted())
        {
            Debug.Log("Toate obiectele au fost sortate corect. Încărcăm scena 'Thanks'.");
            Invoke("LoadThanksScene", 1f);
        }
    }

    private bool AreAllItemsSorted()
    {
        foreach (var item in itemsToSort)
        {
            if (item != null && !item.IsSortedCorrectly())
            {
                return false;
            }
        }
        return true;
    }

    private void LoadThanksScene()
    {
        SceneManager.LoadScene("Thanks");
    }
}
