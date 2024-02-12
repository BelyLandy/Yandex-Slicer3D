using DynamicMeshCutter;
using UnityEngine;

public class DetectObjectToSlice : MonoBehaviour
{
    public static bool IsOneDetected;
    public static bool IsButtonPressed;

    private void OnMouseDown()
    {
        IsButtonPressed = true;
        Debug.Log("Pressed");
    }

    private void OnMouseEnter()
    {
        if (!IsOneDetected && IsButtonPressed)
        {
            gameObject.GetComponent<MeshTarget>().enabled = true;
            IsOneDetected = true;
        }
        Debug.Log("");
    }

    private void OnMouseUp()
    {
        IsOneDetected = false;
        IsButtonPressed = false;
        Debug.Log("Unpressed");
    }
}
