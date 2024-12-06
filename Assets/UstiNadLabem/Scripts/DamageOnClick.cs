using UnityEngine;

public class DamageOnClick : MonoBehaviour
{
    private Camera cam;
    
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            var ray = cam.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out RaycastHit hit, 100f))
            {
                var ustecak = hit.collider.GetComponent<Ustecak>();
                
                if(ustecak != null)
                {
                    ustecak.DoDamage();
                }
            }
        }
    }
}
