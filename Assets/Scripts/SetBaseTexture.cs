using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class SetBaseTexture : MonoBehaviour
{
    GameObject tShirtFemale;
    GameObject tShirtMale;
    List<Texture> baseTextures;

    public int currentTextureID = 0;

    void Start()
    {
        baseTextures = new List<Texture>();
        baseTextures = Resources.LoadAll("Textures/T-Shirt-Base-Textures", typeof(Texture)).Cast<Texture>().ToList();

        GameObject tShirtHolder = GameObject.Find("T-Shirt-Holder");
        tShirtFemale = tShirtHolder.transform.Find("T-Shirt-Female").Find("Base").gameObject;
        tShirtMale = tShirtHolder.transform.Find("T-Shirt-Male").Find("Base").gameObject;
        UpdateBaseTexture(currentTextureID);
    }

    public void UpdateBaseTexture(int id) 
    {
        UpdateBaseTextureOnImage(id);
        UpdateBaseTextureOnShirt();
    }

    void UpdateBaseTextureOnImage(int textureID) 
    {
        currentTextureID = textureID;
        Sprite newTexture = Sprite.Create((Texture2D) baseTextures[textureID], new Rect(0, 0, baseTextures[textureID].width, baseTextures[textureID].height), Vector2.zero);
        GetComponent<Image>().sprite = newTexture;
    }

    void UpdateBaseTextureOnShirt()
    {
        tShirtMale.GetComponent<Renderer>().material.SetTexture("_MainTex", baseTextures[currentTextureID]);
        tShirtFemale.GetComponent<Renderer>().material.SetTexture("_MainTex", baseTextures[currentTextureID]);
    }

    public void NextBaseTexture()
    {
        currentTextureID++;
        if (currentTextureID > baseTextures.Count-1) currentTextureID = 0;
        UpdateBaseTexture(currentTextureID);
    }

    public void PreviousBaseTexture()
    {

        currentTextureID--;
        if (currentTextureID < 0) currentTextureID = baseTextures.Count - 1;
        UpdateBaseTexture(currentTextureID);
    }

}
