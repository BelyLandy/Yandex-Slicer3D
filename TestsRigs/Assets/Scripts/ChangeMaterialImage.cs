using Microsoft.Unity.VisualStudio.Editor;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

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

    public void ChangeMaterialImageMethod(Button but)
    {
        if (but.name == "NextSkin") _material.SetTexture("_MainTex", m_OptimusGang);
        else _material.SetTexture("_MainTex", m_Fredbear);
    }

    
}
