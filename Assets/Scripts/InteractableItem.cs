using UnityEngine;
using UnityEngine.Events;

public class InteractableItem : MonoBehaviour
{
    public bool isInRange;
    public KeyCode interactionControl;
    public UnityEvent executeInteraction;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isInRange)
        {
            if (Input.GetKeyDown(interactionControl))
            {
                executeInteraction.Invoke();
            }
        }
    }

    //Two copies one with collider and other with collider 2D
    private void OnTriggerEnter2D(Collider2D boxCollider)
    {
        if (boxCollider.gameObject.CompareTag("Player"))
        {
            isInRange = true;
            Debug.Log("Player in Range");
        }
    }
    
    private void OnTriggerExit2D(Collider2D boxCollider)
    {
        if (boxCollider.gameObject.CompareTag("Player"))
        {
            isInRange = false;
            Debug.Log("Player Left Range");
        }
    }
}
