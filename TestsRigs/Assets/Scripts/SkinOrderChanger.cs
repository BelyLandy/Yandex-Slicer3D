using System.Collections;
using UnityEngine;

public class SkinOrderChanger : MonoBehaviour
{
    [SerializeField] private Material _material;
    private sbyte order = 0;
         
    [SerializeField] private Texture2D[] sprites = new Texture2D[6];

    void Start()
    {      
        StartCoroutine(ITimer());
    }

    IEnumerator ITimer()
    {
        while (true) 
        {       
            if (order < sprites.Length)
            {
                _material.SetTexture("_MainTex", sprites[order]);
            }
            else
            {
                order = 0;
                _material.SetTexture("_MainTex", sprites[order]);
            }

            order += 1;

            yield return new WaitForSeconds(0.1f);
        }       
    }
}
