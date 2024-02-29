using UnityEngine;
using YG;

public class SliceTheNubikLabel_Localization : MonoBehaviour
{

    [SerializeField] private Mesh meshRU;
    [SerializeField] private Mesh meshUS;
    [SerializeField] private Mesh meshTR;

    private MeshFilter _meshFilter;
    private BoxCollider _boxCollider;

    void Start()
    {
        _meshFilter = GetComponent<MeshFilter>();

        _boxCollider = GetComponent<BoxCollider>();

        if (YandexGame.EnvironmentData.language == "ru")
        {
            _meshFilter.mesh = meshRU;
            transform.position = new Vector3(0.49004f, 4.4218f, 6.2702f);
            _boxCollider.center = new Vector3(0.01629639f, 131.0083f, 0.001141571f);
            _boxCollider.size = new Vector3(727.8068f, 262.0166f, 133.5236f);
        }
        else if (YandexGame.EnvironmentData.language == "en")
        {
            _meshFilter.mesh = meshUS;
            transform.position = new Vector3(0.49004f, 6.77f, 6.09f);
            _boxCollider.center = new Vector3(3.96107f, 5.141739f, 0.001141953f);
            _boxCollider.size = new Vector3(880.8654f, 282.42f, 133.5236f);
        }
        else if (YandexGame.EnvironmentData.language == "tr")
        {
            _meshFilter.mesh = meshTR;
            transform.position = new Vector3(0.49004f, 4.26f, 6.29f);
            _boxCollider.center = new Vector3(-0.09896833f, 143.6616f, 0.001140293f);
            _boxCollider.size = new Vector3(868.6853f, 302.7039f, 133.5236f);
        }
    }

}
