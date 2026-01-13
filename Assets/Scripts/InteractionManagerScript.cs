using UnityEngine.InputSystem;
using UnityEngine;
using UnityEngine.AI;

public class InteractionManagerScript : MonoBehaviour
{
    public NavMeshAgent agent;
    public Camera cam;
    public GameObject Marker;
    private GameObject aktifmaker;

    private void Start()
    {
       
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray isin = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(isin, out hit))
            {
                agent.SetDestination(hit.point);
                if (aktifmaker != null)
                {
                    Destroy(aktifmaker);
                }
               aktifmaker=Instantiate(Marker, hit.point + new Vector3(0f, 0.1f, 0f), Quaternion.Euler(90f, 0f, 0f));

            }
        }
    }
}

        
    

