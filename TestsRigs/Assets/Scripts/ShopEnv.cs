using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using YG;

public class ShopEnv : MonoBehaviour
{
    public Env[] infoEnv;
    private bool[] StockCheckEnv;
    private string lang;
    public Button buyBttn;
    public Text priceText;
    public Text coinsText;
    public Text nameEnv;
    public Text envText;
    public Text skinText;
    public int index;
    public int coins;
    private Material _material;
    [SerializeField] private Texture[] skyTextures;
    [SerializeField] private Texture[] blockTextures;
    [SerializeField] private Material block;
    [SerializeField] private string[] ruenvNames;
    [SerializeField] private string[] engenvNames;
    [SerializeField] private string[] trenvNames;

    private void Awake()
    {
        _material = RenderSettings.skybox;
        coins = PlayerPrefs.GetInt("coins");
        index = PlayerPrefs.GetInt("chosenEnv");

        if (SceneManager.GetActiveScene().buildIndex == 2) coinsText.text = coins.ToString();
        lang = YandexGame.EnvironmentData.language;
        if (lang == "ru" && SceneManager.GetActiveScene().buildIndex == 2)
        {
            nameEnv.text = ruenvNames[index];
            envText.text = "Окружение";
            skinText.text = "Скины";
        }
        else if (lang == "en" && SceneManager.GetActiveScene().buildIndex == 2)
        {
            nameEnv.text = engenvNames[index];
            envText.text = "Environment";
            skinText.text = "Skins";
        }
        else if (lang == "tr" & SceneManager.GetActiveScene().buildIndex == 2)
        {
            nameEnv.text = trenvNames[index];
            envText.text = "Çevre";
            skinText.text = "Dış görünümler";
        }

        StockCheckEnv = new bool[15];
        if (PlayerPrefs.HasKey("StockArrayEnv"))
            StockCheckEnv = PlayerPrefsX.GetBoolArray("StockArrayEnv");

        else
            StockCheckEnv[0] = true;

        infoEnv[index].isChosen = true;
        if (YandexGame.EnvironmentData.language == "ru")
        {
            if (SceneManager.GetActiveScene().buildIndex == 2) nameEnv.text = ruenvNames[index];
        }
        else if (YandexGame.EnvironmentData.language == "en")
        {
            if (SceneManager.GetActiveScene().buildIndex == 2) nameEnv.text = engenvNames[index];
        }
        else if (YandexGame.EnvironmentData.language == "tr")
        {
            if (SceneManager.GetActiveScene().buildIndex == 2) nameEnv.text = trenvNames[index];
        }

        for (int i = 0; i < infoEnv.Length; i++)
        {
            infoEnv[i].inStock = StockCheckEnv[i];
            if (i == index)
            {
                _material.SetTexture("_Tex", skyTextures[i]);
                block.SetTexture("_MainTex", blockTextures[i]);
            }

                
            //Debug.Log(i);
            //player.GetChild(i).gameObject.SetActive(true); // доработать
            //else
            //Debug.Log(i);
            //player.GetChild(i).gameObject.SetActive(false); // доработать
        }
        _material.SetTexture("_Tex", skyTextures[index]);
        block.SetTexture("_MainTex", blockTextures[index]);

        if (SceneManager.GetActiveScene().buildIndex == 2) priceText.text = "ВЫБРАН";
        if (SceneManager.GetActiveScene().buildIndex == 2) buyBttn.interactable = false;
    }

    public void Save()
    {
        PlayerPrefsX.SetBoolArray("StockArrayEnv", StockCheckEnv);
    }

    public void ScrollRight()
    {
        if (index < infoEnv.Length - 1)
        {
            index++;

            if (infoEnv[index].inStock && infoEnv[index].isChosen)
            {
                priceText.text = "ВЫБРАН";
                buyBttn.interactable = false;
            }
            else if (!infoEnv[index].inStock)
            {
                priceText.text = infoEnv[index].cost.ToString();
                buyBttn.interactable = true;
            }
            else if (infoEnv[index].inStock && !infoEnv[index].isChosen)
            {
                priceText.text = "ВЫБРАТЬ";
                buyBttn.interactable = true;
            }

            //for (int i = 0; i < Playerskins.Length; i++)
            //player.GetChild(i).gameObject.SetActive(false);
            //Debug.Log(i);
            // Можно записать так: player.GetChild(index-1).gameObject.SetActive(false);
            _material.SetTexture("_Tex", skyTextures[index]);
            block.SetTexture("_MainTex", blockTextures[index]);
            if (YandexGame.EnvironmentData.language == "ru")
            {
                nameEnv.text = ruenvNames[index];
            }
            else if (YandexGame.EnvironmentData.language == "en")
            {
                nameEnv.text = engenvNames[index];
            }
            else if (YandexGame.EnvironmentData.language == "tr")
            {
                nameEnv.text = trenvNames[index];
            }
            //player.GetChild(index).gameObject.SetActive(true);
        }
    }

    public void ScrollLeft()
    {
        if (index > 0)
        {
            index--;

            if (infoEnv[index].inStock && infoEnv[index].isChosen)
            {
                priceText.text = "ВЫБРАН";
                buyBttn.interactable = false;
            }
            else if (!infoEnv[index].inStock)
            {
                priceText.text = infoEnv[index].cost.ToString();
                buyBttn.interactable = true;
            }
            else if (infoEnv[index].inStock && !infoEnv[index].isChosen)
            {
                priceText.text = "ВЫБРАТЬ";
                buyBttn.interactable = true;
            }

            //for (int i = 0; i < Playerskins.Length; i++)
            //Debug.Log(i);
            //player.GetChild(i).gameObject.SetActive(false);
            _material.SetTexture("_Tex", skyTextures[index]);
            block.SetTexture("_MainTex", blockTextures[index]);
            if (YandexGame.EnvironmentData.language == "ru")
            {
                nameEnv.text = ruenvNames[index];
            }
            else if (YandexGame.EnvironmentData.language == "en")
            {
                nameEnv.text = engenvNames[index];
            }
            else if (YandexGame.EnvironmentData.language == "tr")
            {
                nameEnv.text = trenvNames[index];
            }
            //player.GetChild(index).gameObject.SetActive(true);
        }
    }

    public void BuyButtonAction()
    {
        if (buyBttn.interactable && !infoEnv[index].inStock)
        {
            if (coins >= int.Parse(priceText.text))
            {
                coins -= int.Parse(priceText.text);
                coinsText.text = coins.ToString();
                PlayerPrefs.SetInt("coins", coins);
                StockCheckEnv[index] = true;
                infoEnv[index].inStock = true;
                priceText.text = "ВЫБРАТЬ";
                Save();
            }
        }

        if (buyBttn.interactable && !infoEnv[index].isChosen && infoEnv[index].inStock)
        {
            PlayerPrefs.SetInt("chosenEnv", index);
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
}
[System.Serializable]
public class Env
{
    public int cost;
    public bool inStock;
    public bool isChosen;
    public string name;
}
