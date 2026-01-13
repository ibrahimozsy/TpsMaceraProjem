using UnityEngine;

public class InputManagerScript : MonoBehaviour
{
    public static InputManagerScript Instance { get; private set; }

    [Header("Girdiler")]
    public float horizontal;
    public float vertical;
    public bool isSpacePressed;
    public bool isMiddleMousePressed;
    public float mouseScroll;
    public float MouseX;
    public bool isLeftClick;
    public Vector3 mousePos;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
         
        }
    }

    private void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        mouseScroll = Input.GetAxis("Mouse ScrollWheel");
        MouseX = Input.GetAxis("Mouse X");
        isLeftClick = Input.GetMouseButtonDown(0);
        mousePos = Input.mousePosition;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            isSpacePressed = true;
        }
        isMiddleMousePressed = Input.GetMouseButton(2);
    }

    public void ResetSpacePressed()
    {
        isSpacePressed = false;
    }
}