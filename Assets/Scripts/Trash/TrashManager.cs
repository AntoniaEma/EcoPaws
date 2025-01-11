using UnityEngine;
using TMPro;

public class TrashManager : MonoBehaviour
{
    [SerializeField] private TMP_Text trashBagsDisplay;
    public static TrashManager instance;

    private int trashBags;

    private void Awake()
    {
        if(!instance)
        {
            instance = this;
        }
    }

    private void OnGUI()
    {
        trashBagsDisplay.text = trashBags.ToString();
    }

    public void ChangeTrashBags(int amount)
    {
        trashBags += amount;
    }

    public int GetTrashBags()
    {
        return trashBags;
    }

}
