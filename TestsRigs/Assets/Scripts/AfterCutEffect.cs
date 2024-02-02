using UnityEngine;

public class AfterCutEffect : MonoBehaviour
{
    //private Material _material;
    public Texture2D _texture;
    private Renderer _renderer;

    private void Start()
    {
        //_renderer = GetComponent<Renderer>();
    }

    public void AfterCutEffectMethod()
    {
        //_texture = (Texture2D)_renderer.material.mainTexture;

        Color[] pixels = _texture.GetPixels();    
        
        for(int i = 0; i < pixels.Length; i++)
        {
            pixels[i] = new Color(1 - pixels[i].r, 1 - pixels[i].g, 1 - pixels[i].b);
        }

        _texture.SetPixels(pixels);
        _texture.Apply();
        
    }
}
