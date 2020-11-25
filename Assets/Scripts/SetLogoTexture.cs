using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class SetLogoTexture : MonoBehaviour
{
    GameObject tShirtFemale;
    GameObject tShirtMale;
    List<Texture> logoTextures;
    List<Texture> logoTextureSplashes;
    List<Sprite> logoTextureIcons;

    public int currentTextureID = 0;

    void Start()
    {
        logoTextures = new List<Texture>();
        logoTextureSplashes = new List<Texture>();
        logoTextureIcons = new List<Sprite>();

        logoTextures = Resources.LoadAll("Textures/T-Shirt-Logos", typeof(Texture)).Cast<Texture>().ToList();
        logoTextureSplashes = Resources.LoadAll("Textures/T-Shirt-Logos-Splash", typeof(Texture)).Cast<Texture>().ToList();
        logoTextureIcons = Resources.LoadAll("Textures/UI/Logos", typeof(Sprite)).Cast<Sprite>().ToList();

        GameObject tShirtHolder = GameObject.Find("T-Shirt-Holder");
        tShirtFemale = tShirtHolder.transform.Find("T-Shirt-Female").Find("Base").gameObject;
        tShirtMale = tShirtHolder.transform.Find("T-Shirt-Male").Find("Base").gameObject;
        UpdateLogoTexture(currentTextureID);
    }

    public void UpdateLogoTexture(int id) 
    {
        UpdateLogoTextureOnImage(id);
        UpdateLogoTextureOnShirt();
    }

    void UpdateLogoTextureOnImage(int textureID) 
    {
        currentTextureID = textureID;
        GetComponent<Image>().sprite = logoTextureIcons[currentTextureID];
    }

    void UpdateLogoTextureOnShirt()
    {
        tShirtMale.GetComponent<Renderer>().material.SetTexture("_LogoTex", logoTextures[currentTextureID]);
        tShirtMale.GetComponent<Renderer>().material.SetTexture("_SplashTex", logoTextureSplashes[currentTextureID]); 
        tShirtFemale.GetComponent<Renderer>().material.SetTexture("_LogoTex", logoTextures[currentTextureID]);
        tShirtFemale.GetComponent<Renderer>().material.SetTexture("_SplashTex", logoTextureSplashes[currentTextureID]);
    }

    public void NextLogoTexture()
    {
        currentTextureID++;
        if (currentTextureID > logoTextures.Count-1) currentTextureID = 0;
        UpdateLogoTexture(currentTextureID);
    }

    public void PreviousLogoTexture()
    {
        currentTextureID--;
        if (currentTextureID < 0) currentTextureID = logoTextures.Count - 1;
        UpdateLogoTexture(currentTextureID);
    }

}
