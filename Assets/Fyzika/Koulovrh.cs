using UnityEngine;

public class Koulovrh : MonoBehaviour
{
    private Camera cam;

    private void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            VrhniKouli(Input.mousePosition);
        }
    }

    private void VrhniKouli(Vector3 mousePosition)
    {
        var koule = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        // chyb� vytvo�en� prefabu p�es Instantiate

        var ray = cam.ScreenPointToRay(mousePosition);

        koule.transform.position = ray.origin;
        // chyb� aplikov�n� s�ly 
    }
}
