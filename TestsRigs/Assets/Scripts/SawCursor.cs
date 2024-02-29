using UnityEngine;

public class SawCursor : MonoBehaviour
{
    
    void Update()
    {
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

}
