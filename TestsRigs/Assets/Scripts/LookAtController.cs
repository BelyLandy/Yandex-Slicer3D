using UnityEngine;

public class LookAtController : MonoBehaviour
{
    [SerializeField] private Transform objectToLookAt;

    private void Update()
    {
        gameObject.transform.LookAt(objectToLookAt, Vector3.up);
    }
}
