using DynamicMeshCutter;
using UnityEngine;
using UnityEngine.UI;

public class Shiat : MonoBehaviour
{
    [SerializeField] private GameObject Cutter;

    void Start()
    {

    }

    void Update()
    {
        
    }

    public static float startP;
    public static Vector3[] positions;

    private void OnMouseDown()
    {
        Cutter.GetComponent<LineRenderer>().GetPositions(positions);

        foreach (var position in positions)
        {
            Debug.Log(position);
        }
    }



}
