using UnityEngine;
using EZCameraShake;

public class CameraShakeCode : MonoBehaviour
{
    void ShakeCode()
    {
        CameraShaker.Instance.ShakeOnce(4f, 2.5f, 0.1f, 2f);
    }   
}
