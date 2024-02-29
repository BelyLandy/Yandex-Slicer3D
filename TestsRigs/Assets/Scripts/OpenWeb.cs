using UnityEngine;

public class OpenWeb : MonoBehaviour
{
    [System.Obsolete]
    public static void UrlOpen(string url)
    {
#if UNITY_WEBGL
        Application.ExternalEval("window.open(\"" + url + "\")");
#else
        Application.OpenURL(url);
#endif
    }
}
