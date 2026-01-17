using UnityEngine;

public class InteractionScript : MonoBehaviour
{
    public GameObject ClickmarkerPrefab;
    private GameObject CurrentMarker;
    public PlayerManagerScript playerManager;
    
    void Start()
    {
       
    }

    
    void Update()
    {
        Vector3 mousePos = InputManagerScript.Instance.mousePos;
        bool isLeftClicked = InputManagerScript.Instance.isLeftClickPressed;
        bool numberOnePressed = InputManagerScript.Instance.numberOnePressed;
        bool numberTwoPressed = InputManagerScript.Instance.numberTwoPressed;

        

       

        Ray ray = Camera.main.ScreenPointToRay(mousePos);
        RaycastHit hit;

        if (!Physics.Raycast(ray, out hit, 100f)) return;
        if (!isLeftClicked) return;

        IInteractable interactable = hit.collider.GetComponent<IInteractable>();
        if (interactable != null)
        {
            interactable.OnLeftClick();
            return;
        }
        if (hit.collider.CompareTag("Ground"))
        {
            HandleMovement(hit.point);

            if (PlayerManagerScript.instance.ActiveLeader != null)
            {
                PlayerManagerScript.instance.ActiveLeader.moveTo(hit.point);
            }
        }
        
    }
    private void HandleMovement(Vector3 point)
    {
        if (CurrentMarker != null) Destroy(CurrentMarker);
        CurrentMarker = Instantiate(ClickmarkerPrefab, point + Vector3.up * 0.1f, Quaternion.identity);
    }
}
