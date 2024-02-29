using UnityEngine;

public class Skybox_Rotate : MonoBehaviour
{
    public float RotationSpeed = 2f;

    void Update()
    {
        RenderSettings.skybox.SetFloat("_Rotation", Time.time * RotationSpeed);
    }
}
