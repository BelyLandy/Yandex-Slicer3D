using UnityEngine;

public class AfterCutEffect : MonoBehaviour
{
    [SerializeField] private Material _material;
     
    public void MakeRed()
    {
        _material.color = Color.red;

        Invoke("MakeDefault", 0.2f);

    }

    private void MakeDefault()
    {
        _material.color = Color.white;
    }
}
