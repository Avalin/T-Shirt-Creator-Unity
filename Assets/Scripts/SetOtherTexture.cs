using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class SetOtherTexture : MonoBehaviour
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
        UpdateOtherTexture(currentTextureID);
    }

    public void UpdateOtherTexture(int id) 
    {
        UpdateOtherTextureOnImage(id);
        UpdateOtherTextureOnShirt();
    }

    void UpdateOtherTextureOnImage(int textureID) 
    {
        currentTextureID = textureID;
        Sprite newTexture = Sprite.Create((Texture2D) baseTextures[textureID], new Rect(0, 0, baseTextures[textureID].width, baseTextures[textureID].height), Vector2.zero);
        GetComponent<Image>().sprite = newTexture;
    }

    void UpdateOtherTextureOnShirt()
    {
        tShirtMale.GetComponent<Renderer>().material.SetTexture("_OtherTex", baseTextures[currentTextureID]);
        tShirtFemale.GetComponent<Renderer>().material.SetTexture("_OtherTex", baseTextures[currentTextureID]);
    }

    public void NextOtherTexture()
    {
        currentTextureID++;
        if (currentTextureID > baseTextures.Count-1) currentTextureID = 0;
        UpdateOtherTexture(currentTextureID);
    }

    public void PreviousOtherTexture()
    {

        currentTextureID--;
        if (currentTextureID < 0) currentTextureID = baseTextures.Count - 1;
        UpdateOtherTexture(currentTextureID);
    }

}
