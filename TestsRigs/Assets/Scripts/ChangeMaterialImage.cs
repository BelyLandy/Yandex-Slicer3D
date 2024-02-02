using Microsoft.Unity.VisualStudio.Editor;
using Unity.VisualScripting;
using UnityEngine;

public class ChangeMaterialImage : MonoBehaviour
{
    [SerializeField] private Material _material;

    [SerializeField] private Texture m_Fredbear, m_Enderman, m_OptimusGang;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void ChangeMaterialImageMethod()
    {
        _material.SetTexture("_MainTex", m_Fredbear);
    }

    
}
