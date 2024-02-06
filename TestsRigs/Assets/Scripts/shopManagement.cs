using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class shopManagement : MonoBehaviour
{
    public Skin[] info;
    private bool[] StockCheck;

    public Button buyBttn;
    public Text priceText;
    public Text coinsText;
    //public Transform player;
    public int index;
    public int coins;

    private static bool isOpened = false;
    [SerializeField] private GameObject envShopButtn;
    [SerializeField] private GameObject skinShopButtn;
    [SerializeField] private GameObject envShopStuff;
    [SerializeField] private GameObject skinShopStuff;
    [SerializeField] private GameObject Character;

    [SerializeField] private Material _material;

    [SerializeField] private Texture[] skins;

    private void Awake()
    {
        LoadAndApplyCameraTransform();
        //PlayerPrefs.SetInt("coins", 100000);
        coins = PlayerPrefs.GetInt("coins");
        index = PlayerPrefs.GetInt("chosenSkin");
        coinsText.text = coins.ToString();

        StockCheck = new bool[16];
        if (PlayerPrefs.HasKey("StockArray"))
            StockCheck = PlayerPrefsX.GetBoolArray("StockArray");

        else
            StockCheck[0] = true;

        info[index].isChosen = true;

        for (int i = 0; i < info.Length; i++)
        {
            info[i].inStock = StockCheck[i];
            if (i == index)
                //player.GetChild(i).gameObject.SetActive(true); // доработать
                _material.SetTexture("_MainTex", skins[i]);
            //else
                //player.GetChild(i).gameObject.SetActive(false); // доработать
        }

        priceText.text = "CHOSEN";
        buyBttn.interactable = false;
    }

    public void Save()
    {
        PlayerPrefsX.SetBoolArray("StockArray", StockCheck);
    }

    public void ScrollRight()
    {
        if (index < skins.Length)
        {
            index++;

            if (info[index].inStock && info[index].isChosen)
            {
                priceText.text = "CHOSEN";
                buyBttn.interactable = false;
            }
            else if (!info[index].inStock)
            {
                priceText.text = info[index].cost.ToString();
                buyBttn.interactable = true;
            }
            else if (info[index].inStock && !info[index].isChosen)
            {
                priceText.text = "CHOOSE";
                buyBttn.interactable = true;
            }

            //for (int i = 0; i < player.childCount; i++)
            //player.GetChild(i).gameObject.SetActive(false);
            // Можно записать так: player.GetChild(index-1).gameObject.SetActive(false);

            //player.GetChild(index).gameObject.SetActive(true);
            Debug.Log(index);
            _material.SetTexture("_MainTex", skins[index]);
        }
    }

    public void ScrollLeft()
    {
        if (index > 0)
        {
            index--;

            if (info[index].inStock && info[index].isChosen)
            {
                priceText.text = "CHOSEN";
                buyBttn.interactable = false;
            }
            else if (!info[index].inStock)
            {
                priceText.text = info[index].cost.ToString();
                buyBttn.interactable = true;
            }
            else if (info[index].inStock && !info[index].isChosen)
            {
                priceText.text = "CHOOSE";
                buyBttn.interactable = true;
            }

            //for (int i = 0; i < player.childCount; i++)
            //    player.GetChild(i).gameObject.SetActive(false);
            Debug.Log(index);
            _material.SetTexture("_MainTex", skins[index]);
        }
    }

    public void BuyButtonAction()
    {
        if (buyBttn.interactable && !info[index].inStock)
        {
            if (coins > int.Parse(priceText.text))
            {
                coins -= int.Parse(priceText.text);
                coinsText.text = coins.ToString();
                PlayerPrefs.SetInt("coins", coins);
                StockCheck[index] = true;
                info[index].inStock = true;
                priceText.text = "CHOOSE";
                Save();
            }
        }

        if (buyBttn.interactable && !info[index].isChosen && info[index].inStock)
        {
            PlayerPrefs.SetInt("chosenSkin", index);
            buyBttn.interactable = false;
            priceText.text = "CHOSEN";
        }
    }

    private void LoadAndApplyCameraTransform()
    {
        // Получите компонент Transform вашей камеры
        Transform cameraTransform = Camera.main.transform;

        // Загрузите сохраненные данные из PlayerPrefs
        if (SceneManager.GetActiveScene().buildIndex == 1 ) {
            float positionX = PlayerPrefs.GetFloat("12CameraPositionX");
            float positionY = PlayerPrefs.GetFloat("12CameraPositionY");
            float positionZ = PlayerPrefs.GetFloat("12CameraPositionZ");
            float rotationX = PlayerPrefs.GetFloat("12CameraRotationX");
            float rotationY = PlayerPrefs.GetFloat("12CameraRotationY");
            float rotationZ = PlayerPrefs.GetFloat("12CameraRotationZ");

            // Примените загруженные данные к камере
            cameraTransform.position = new Vector3(positionX, positionY, positionZ);
            cameraTransform.rotation = Quaternion.Euler(rotationX, rotationY, rotationZ);
        }
        else if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            float positionX = PlayerPrefs.GetFloat("21CameraPositionX");
            float positionY = PlayerPrefs.GetFloat("21CameraPositionY");
            float positionZ = PlayerPrefs.GetFloat("21CameraPositionZ");
            float rotationX = PlayerPrefs.GetFloat("21CameraRotationX");
            float rotationY = PlayerPrefs.GetFloat("21CameraRotationY");
            float rotationZ = PlayerPrefs.GetFloat("21CameraRotationZ");

            // Примените загруженные данные к камере
            cameraTransform.position = new Vector3(positionX, positionY, positionZ);
            cameraTransform.rotation = Quaternion.Euler(rotationX, rotationY, rotationZ);
        }
            
    }

    private void SaveCameraTransform()
    {
        // Получите компонент Transform вашей камеры
        Transform cameraTransform = Camera.main.transform;

        // Сохраните позицию и вращение в PlayerPrefs
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            PlayerPrefs.SetFloat("12CameraPositionX", cameraTransform.position.x);
            PlayerPrefs.SetFloat("12CameraPositionY", cameraTransform.position.y);
            PlayerPrefs.SetFloat("12CameraPositionZ", cameraTransform.position.z);
            PlayerPrefs.SetFloat("12CameraRotationX", cameraTransform.rotation.eulerAngles.x);
            PlayerPrefs.SetFloat("12CameraRotationY", cameraTransform.rotation.eulerAngles.y);
            PlayerPrefs.SetFloat("12CameraRotationZ", cameraTransform.rotation.eulerAngles.z);
        }
        else if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            PlayerPrefs.SetFloat("21CameraPositionX", cameraTransform.position.x);
            PlayerPrefs.SetFloat("21CameraPositionY", cameraTransform.position.y);
            PlayerPrefs.SetFloat("21CameraPositionZ", cameraTransform.position.z);
            PlayerPrefs.SetFloat("21CameraRotationX", cameraTransform.rotation.eulerAngles.x);
            PlayerPrefs.SetFloat("21CameraRotationY", cameraTransform.rotation.eulerAngles.y);
            PlayerPrefs.SetFloat("21CameraRotationZ", cameraTransform.rotation.eulerAngles.z);
        }

        // Сохраните данные в PlayerPrefs
        PlayerPrefs.Save();
    }

    public void Shopping()
    {
        //envShopButtn.SetActive(!isOpened);
        //skinShopButtn.SetActive(!isOpened);
        //envShopStuff.SetActive(false);
        //skinShopStuff.SetActive(false);
        //Character.SetActive(true);
        //isOpened = !isOpened;
        SaveCameraTransform();
        SceneManager.LoadScene(1);
    }

    public void Game()
    {
        SaveCameraTransform();
        SceneManager.LoadScene(0);
    }

    public void ShoppingEnv()
    {
        envShopStuff.SetActive(true);
        skinShopStuff.SetActive(false);
        Character.SetActive(false);
    }
    public void ShoppingSkin()
    {
        envShopStuff.SetActive(false);
        skinShopStuff.SetActive(true);
        Character.SetActive(true);
    }   
}
[System.Serializable]
public class Skin
{
    public int cost;
    public bool inStock;
    public bool isChosen;
    public string name;
}
