using System.Collections.Generic;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.EventSystems;


public class CameraController : MonoBehaviour
{
    [Header("Deðiþkenler")]
    public float MoveSpeed=15f;
    private float FieldOfView = 50f;
    public float MinView = 20f;
    public float MaxView = 50f;
    
    [Header("Compenentler")]
    private CinemachineCamera cinemachinecamera;
    public List <Transform> targets = new List<Transform>();
    public enum CameraStates {locked,freelook};
    public CameraStates currentstate = CameraStates.locked;


    void Start()
    {
        cinemachinecamera = GetComponent<CinemachineCamera>();
        cinemachinecamera.Lens.FieldOfView = FieldOfView;
        cinemachinecamera.Follow = targets[0];
          
    }

    // Update is called once per frame
    void Update()
    {
        

    }
    private void LateUpdate()
    {
        KameraYonetimi();
    }
    private void KameraYonetimi()
    {
        float h = InputManagerScript.Instance.horizontal;
        float v = InputManagerScript.Instance.vertical;
        float scroll = InputManagerScript.Instance.mouseScroll;
        bool space = InputManagerScript.Instance.isSpacePressed;
        float Mousex = InputManagerScript.Instance.MouseX;
        bool isRotating = InputManagerScript.Instance.isMiddleMousePressed;

        switch (currentstate)
        {
            case CameraStates.locked:
                targets[1].position = targets[0].position;
                if (h != 0 || v != 0)
                {
                    currentstate = CameraStates.freelook;
                    cinemachinecamera.Follow = targets[1];
                    
                }
                break;
            case CameraStates.freelook:

                Vector3 moveDir = new Vector3(h, 0, v).normalized;
                targets[1].Translate(moveDir * MoveSpeed * Time.deltaTime, Space.World);
                if (space==true)
                {
                    currentstate = CameraStates.locked;
                    InputManagerScript.Instance.ResetSpacePressed();
                }
                break;
        }
        //Kamera Zoomlama
        FieldOfView -= scroll * 10f;
        FieldOfView = Mathf.Clamp(FieldOfView, MinView, MaxView);
        cinemachinecamera.Lens.FieldOfView = FieldOfView;
    }
}
