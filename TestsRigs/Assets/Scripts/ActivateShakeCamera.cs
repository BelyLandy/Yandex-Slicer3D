using UnityEngine;

public class ActivateShakeCamera : MonoBehaviour
{  
    public void StartCameraShake()
    {
        Camera.main.GetComponent<Animator>().enabled = true;
    }

    public void StopCameraShake()
    {
        Camera.main.GetComponent<Animator>().enabled = false;
    }
}
