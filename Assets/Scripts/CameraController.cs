using System.Collections.Generic;
using Unity.Cinemachine;
using UnityEngine;


public class CameraController : MonoBehaviour
{
    [Header("Deðiþkenler")]
    public float MoveSpeed=15f;
    private float CurrentWidth = 18f;
    private float minWiev = 9f;
    private float maxWiev = 18f;
    public float ZoomSpeed=15f;
    public float OrbitalVerticalAxsis = 45f;
    
    
    [Header("Compenentler")]
    private CinemachineCamera cinemachinecamera;
    private CinemachineFollowZoom followZoom;
    private CinemachineOrbitalFollow Orbitalfollow;
    public List <Transform> targets = new List<Transform>();
    public enum CameraStates {locked,freelook};
    public CameraStates currentstate = CameraStates.locked;


    void Start()
    {
        cinemachinecamera = GetComponent<CinemachineCamera>();
        followZoom = GetComponent<CinemachineFollowZoom>();
        Orbitalfollow = GetComponent<CinemachineOrbitalFollow>();
        followZoom.Width = CurrentWidth;
        Orbitalfollow.VerticalAxis.Value = OrbitalVerticalAxsis;
        targets[0].position = targets[1].position;
        cinemachinecamera.Follow = targets[0];
        cinemachinecamera.LookAt = targets[0];
          
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
                targets[0].position = targets[1].position;
                if (h != 0 || v != 0)
                {
                    currentstate = CameraStates.freelook;
                    cinemachinecamera.Follow = targets[0];
                    
                }
                break;
            case CameraStates.freelook:

                Vector3 camForward = cinemachinecamera.transform.forward;
                Vector3 camRight = cinemachinecamera.transform.right;

                camForward.y = 0f;
                camRight.y = 0f;
                Vector3 moveDirection = (camForward * v + camRight * h).normalized;
                targets[0].position += moveDirection * MoveSpeed * Time.deltaTime;
                if (space==true)
                {
                    currentstate = CameraStates.locked;
                    InputManagerScript.Instance.ResetSpacePressed();
                    Orbitalfollow.HorizontalAxis.Value = 0f;
                    
                }
                break;
        }
        if (scroll != 0)
        {
            CurrentWidth -= scroll * ZoomSpeed;
            CurrentWidth = Mathf.Clamp(CurrentWidth, minWiev, maxWiev);
            followZoom.Width = CurrentWidth;

        }
        if (isRotating == true)
        {
            Orbitalfollow.HorizontalAxis.Value += Mousex*10f;
        }
    }
}
