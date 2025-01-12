using UnityEngine;

public class DraggableItem : MonoBehaviour
{
    private Vector3 initialPosition;
    private bool isDroppedCorrectly;

    [SerializeField] private string correctBinTag;

    private void Start()
    {
        initialPosition = transform.position;
    }

    private void OnMouseDrag()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(mousePosition.x, mousePosition.y, 0);
    }

    private void OnMouseUp()
    {
        if (isDroppedCorrectly)
        {
            Debug.Log($"{gameObject.name} a fost sortat corect.");
            Destroy(gameObject);
        }
        else
        {
            Debug.Log($"{gameObject.name} nu a fost sortat corect. Revenim la poziția inițială.");
            transform.position = initialPosition;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log($"{gameObject.name} a intrat în coliziune cu {collision.gameObject.name} (Tag: {collision.tag})");
        if (collision.CompareTag(correctBinTag))
        {
            isDroppedCorrectly = true;
            Debug.Log($"{gameObject.name} este deasupra coșului corect: {collision.tag}");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log($"{gameObject.name} a ieșit din coliziune cu {collision.gameObject.name} (Tag: {collision.tag})");
        if (collision.CompareTag(correctBinTag))
        {
            isDroppedCorrectly = false;
            Debug.Log($"{gameObject.name} nu mai este deasupra coșului corect: {collision.tag}");
        }
    }

    public bool IsSortedCorrectly()
    {
        return isDroppedCorrectly;
    }
}
