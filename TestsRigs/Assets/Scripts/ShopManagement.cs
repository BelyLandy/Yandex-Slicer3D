using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using YG;

public class ShopManagement : MonoBehaviour
{    

    public Skin[] info;
    private bool[] StockCheck;

    public Button buyBttn;
    public Text priceText;
    public Text coinsText;
    public Text nameSkin;
    public int index;
    public int coins;
    [SerializeField] private GameObject envShopButtn;
    [SerializeField] private GameObject skinShopButtn;
    [SerializeField] private GameObject envShopStuff;
    [SerializeField] private GameObject skinShopStuff;
    [SerializeField] private GameObject Character;
    [SerializeField] private Texture[] Playerskins;
    [SerializeField] private Material _material;
    [SerializeField] private string[] ruskinNames;
    [SerializeField] private string[] engskinNames;
    [SerializeField] private string[] trskinNames;

    private void Awake()
    {
        LoadAndApplyCameraTransform();
        coins = PlayerPrefs.GetInt("coins", 0);
        index = PlayerPrefs.GetInt("chosenSkin");
        if (coins > YandexGame.savesData.coins)
        {
            YandexGame.NewLeaderboardScores("mostmoney", coins);
            YandexGame.savesData.coins = coins;
            YandexGame.SaveProgress();
        }
        if (SceneManager.GetActiveScene().buildIndex == 2) coinsText.text = coins.ToString();

        StockCheck = new bool[35];
        if (PlayerPrefs.HasKey("StockArray"))
            StockCheck = PlayerPrefsX.GetBoolArray("StockArray");

        else
            StockCheck[0] = true;

        info[index].isChosen = true;

        for (int i = 0; i < info.Length; i++)
        {
            info[i].inStock = StockCheck[i];
            if (i == index)
                _material.SetTexture("_MainTex", Playerskins[i]);
            //Debug.Log(i);
            //player.GetChild(i).gameObject.SetActive(true); // доработать
            //else
            //Debug.Log(i);
            //player.GetChild(i).gameObject.SetActive(false); // доработать
        }
        if (YandexGame.EnvironmentData.language == "ru")
        {
            nameSkin.text = ruskinNames[index];
        }
        else if (YandexGame.EnvironmentData.language == "en")
        {
            nameSkin.text = engskinNames[index];
        }
        else if (YandexGame.EnvironmentData.language == "tr")
        {
            nameSkin.text = trskinNames[index];
        }

        if (SceneManager.GetActiveScene().buildIndex == 2) priceText.text = "ВЫБРАН";
        if (SceneManager.GetActiveScene().buildIndex == 2) buyBttn.interactable = false;
    }

    public void Save()
    {
        PlayerPrefsX.SetBoolArray("StockArray", StockCheck);
    }

    public void ScrollRight()
    {
        if (index < Playerskins.Length - 1)
        {
            index++;

            if (info[index].inStock && info[index].isChosen)
            {
                priceText.text = "ВЫБРАН";
                buyBttn.interactable = false;
            }
            else if (!info[index].inStock)
            {
                priceText.text = info[index].cost.ToString();
                buyBttn.interactable = true;
            }
            else if (info[index].inStock && !info[index].isChosen)
            {
                priceText.text = "ВЫБРАТЬ";
                buyBttn.interactable = true;
            }

            //for (int i = 0; i < Playerskins.Length; i++)
            //player.GetChild(i).gameObject.SetActive(false);
            //Debug.Log(i);
            // Можно записать так: player.GetChild(index-1).gameObject.SetActive(false);
            _material.SetTexture("_MainTex", Playerskins[index]);
            if (YandexGame.EnvironmentData.language == "ru")
            {
                nameSkin.text = ruskinNames[index];
            }
            else if (YandexGame.EnvironmentData.language == "en")
            {
                nameSkin.text = engskinNames[index];
            }
            else if (YandexGame.EnvironmentData.language == "tr")
            {
                nameSkin.text = trskinNames[index];
            }
            //player.GetChild(index).gameObject.SetActive(true);
        }
    }

    public void ScrollLeft()
    {
        if (index > 0)
        {
            index--;

            if (info[index].inStock && info[index].isChosen)
            {
                priceText.text = "ВЫБРАН";
                buyBttn.interactable = false;
            }
            else if (!info[index].inStock)
            {
                priceText.text = info[index].cost.ToString();
                buyBttn.interactable = true;
            }
            else if (info[index].inStock && !info[index].isChosen)
            {
                priceText.text = "ВЫБРАТЬ";
                buyBttn.interactable = true;
            }

            //for (int i = 0; i < Playerskins.Length; i++)
            //Debug.Log(i);
            //player.GetChild(i).gameObject.SetActive(false);
            _material.SetTexture("_MainTex", Playerskins[index]);
            if (YandexGame.EnvironmentData.language == "ru")
            {
                nameSkin.text = ruskinNames[index];
            }
            else if (YandexGame.EnvironmentData.language == "en")
            {
                nameSkin.text = engskinNames[index];
            }
            else if (YandexGame.EnvironmentData.language == "tr")
            {
                nameSkin.text = trskinNames[index];
            }
            //player.GetChild(index).gameObject.SetActive(true);
        }
    }

    public void BuyButtonAction()
    {
        if (buyBttn.interactable && !info[index].inStock)
        {
            if (coins >= int.Parse(priceText.text))
            {
                coins -= int.Parse(priceText.text);
                coinsText.text = coins.ToString();
                PlayerPrefs.SetInt("coins", coins);
                StockCheck[index] = true;
                info[index].inStock = true;
                priceText.text = "ВЫБРАТЬ";
                Save();
            }
        }

        if (buyBttn.interactable && !info[index].isChosen && info[index].inStock)
        {
            PlayerPrefs.SetInt("chosenSkin", index);
            buyBttn.interactable = false;
            priceText.text = "ВЫБРАН";
            //for (int i = 0; i < info.Length; i++)
            //{
            //if (i != index) info[i].isChosen = false;
            //else info[i].isChosen = true;
            //Debug.Log(i);
            //player.GetChild(i).gameObject.SetActive(true); // доработать
            //else
            //Debug.Log(i);
            //player.GetChild(i).gameObject.SetActive(false); // доработать
            //}

        }
    }

    private void LoadAndApplyCameraTransform()
    {
        // Получите компонент Transform вашей камеры
        Transform cameraTransform = Camera.main.transform;

        // Загрузите сохраненные данные из PlayerPrefs
        if (SceneManager.GetActiveScene().buildIndex == 2)
        {
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
        else if (SceneManager.GetActiveScene().buildIndex == 1)
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
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            PlayerPrefs.SetFloat("12CameraPositionX", cameraTransform.position.x);
            PlayerPrefs.SetFloat("12CameraPositionY", cameraTransform.position.y);
            PlayerPrefs.SetFloat("12CameraPositionZ", cameraTransform.position.z);
            PlayerPrefs.SetFloat("12CameraRotationX", cameraTransform.rotation.eulerAngles.x);
            PlayerPrefs.SetFloat("12CameraRotationY", cameraTransform.rotation.eulerAngles.y);
            PlayerPrefs.SetFloat("12CameraRotationZ", cameraTransform.rotation.eulerAngles.z);
        }
        else if (SceneManager.GetActiveScene().buildIndex == 2)
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
        SceneManager.LoadScene("ShopScene");
    }

    public void Game()
    {
        SaveCameraTransform();
        SceneManager.LoadScene("GameplayScene");
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
