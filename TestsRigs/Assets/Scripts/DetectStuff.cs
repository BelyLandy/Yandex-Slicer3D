using TMPro;
using UnityEngine;

public class DetectStuff : MonoBehaviour
{

    private GameObject playerObject;
    private SkinnedMeshRenderer playerMeshRenderer;
    private float playerMeshSize;

    [SerializeField] private TextMeshProUGUI textMesh;

    private void Start()
    {
        textMesh.text = PlayerPrefs.GetInt("coins").ToString();

        playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {         
            playerMeshRenderer = playerObject.GetComponent<SkinnedMeshRenderer>();
            if (playerMeshRenderer != null)
            {
                playerMeshSize = playerMeshRenderer.bounds.size.magnitude;
            }
            
        }
    }

    int updatedCoins;

    private void OnCollisionEnter(Collision collision)
    {  
        float otherMeshSize = collision.gameObject.GetComponentInChildren<MeshRenderer>().bounds.size.magnitude;
        float coins = (otherMeshSize / playerMeshSize) * 300; 
        int currentCoins = PlayerPrefs.GetInt("coins", 0);
        updatedCoins = currentCoins + Mathf.RoundToInt(coins);
        PlayerPrefs.SetInt("coins", updatedCoins);

        textMesh.text = PlayerPrefs.GetInt("coins").ToString();

        Destroy(collision.gameObject);
    }

}