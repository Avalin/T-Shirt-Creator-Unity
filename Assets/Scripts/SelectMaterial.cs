using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SelectMaterial : MonoBehaviour
{
    public Material material;
    public GameObject colorNode_prefab;
    private GameObject tShirtHolder;
    private GameObject tShirtMale;
    private GameObject tShirtFemale;
    List<GameObject> colorNodes = new List<GameObject>();

    private void Start()
    {
        colorNodes = new List<GameObject>();
        tShirtFemale = GameObject.FindGameObjectWithTag("FemaleModel");
        tShirtHolder = tShirtFemale.transform.parent.gameObject;
        tShirtMale = tShirtHolder.transform.Find("T-Shirt-Male").gameObject;
    }

    public void SelectTShirtMaterial()
    {
        tShirtMale.transform.Find("Base").GetComponent<MeshRenderer>().material = material;
        tShirtFemale.transform.Find("Base").GetComponent<MeshRenderer>().material = material;

        CreateColorContainer(material);
    }

    public void CreateColorContainer(Material mat)
    {
        string shaderCreator = "Avalin/";
        Transform colorContainer = GameObject.FindGameObjectWithTag("ColorContainer").transform;
        GameObject LogoChooser = GameObject.Find("Menu").transform.Find("LogoTexturePicker").gameObject;
        GameObject OtherTexChooser = GameObject.Find("Menu").transform.Find("OtherTexturePicker").gameObject;
        CleanUpColorContainer(colorContainer);


        int currentBaseTexID = GameObject.FindGameObjectWithTag("BaseTexImg").GetComponent<SetBaseTexture>().currentTextureID;

        if (mat.shader.name == shaderCreator + "T-Shirt-Shader-UV-Separator") 
        {
            CreateColorNode(colorContainer, "_MainColor", "Base Color");
            CreateColorNode(colorContainer, "_Color2", "Inside Color");
            CreateColorNode(colorContainer, "_Color3", "Sleeve Line Color");
            CreateColorNode(colorContainer, "_Color4", "Outline Color");
            CreateColorNode(colorContainer, "_Color5", "Left Sleeve Color");
            CreateColorNode(colorContainer, "_Color6", "Tiny Line Left Sleeve Color");

            LogoChooser.SetActive(false);
            OtherTexChooser.SetActive(false);
        }

        else if (mat.shader.name == shaderCreator + "T-Shirt-Shader-Standard")
        {
            CreateColorNode(colorContainer, "_MainColor", "Base Color");

            LogoChooser.SetActive(false);
            OtherTexChooser.SetActive(false);
        }

        else if (mat.shader.name == shaderCreator + "T-Shirt-Shader-Static-Logo")
        {
            CreateColorNode(colorContainer, "_MainColor", "Base Color");
            CreateColorNode(colorContainer, "_LogoColor", "Logo Color");

            LogoChooser.SetActive(true);
            OtherTexChooser.SetActive(false);
        }

        else if (mat.shader.name == shaderCreator + "T-Shirt-Shader-Animated-Logo")
        {
            CreateColorNode(colorContainer, "_MainColor", "Base Color");
            CreateColorNode(colorContainer, "_LogoColor", "Logo Color");

            LogoChooser.SetActive(true);
            OtherTexChooser.SetActive(false);
        }

        else if (mat.shader.name == shaderCreator + "T-Shirt-Shader-Duo-Colorino")
        {
            CreateColorNode(colorContainer, "_MainColor", "Base Color");
            CreateColorNode(colorContainer, "_OtherColor", "Other Color");

            LogoChooser.SetActive(false);
            OtherTexChooser.SetActive(true);
        }

        GameObject.FindGameObjectWithTag("BaseTexImg").GetComponent<SetBaseTexture>().UpdateBaseTexture(currentBaseTexID);

        colorContainer.GetComponent<RectTransform>().anchorMin = new Vector2(0, 1);
        colorContainer.GetComponent<RectTransform>().anchorMax = new Vector2(0, 1);
        colorContainer.GetComponent<RectTransform>().anchoredPosition = new Vector2(1, 0);
        colorContainer.GetComponent<RectTransform>().pivot = new Vector2(0f, 1f);

        tShirtHolder.GetComponent<ColorController>().UpdateColorNodes(colorNodes);
    }
    
    void CreateColorNode(Transform container, string shaderVarName, string UITitle) 
    {
        GameObject colorNode = Instantiate(colorNode_prefab, Vector3.zero, Quaternion.identity) as GameObject;
        colorNode.transform.SetParent(container);
        colorNode.transform.Find("BTN_ChooseColor").Find("ShaderVar").GetComponent<Text>().text = shaderVarName;
        colorNode.transform.Find("BTN_ChooseColor").Find("Title").GetComponent<TextMeshProUGUI>().text = UITitle;
        colorNodes.Add(colorNode);
    }

    void CleanUpColorContainer(Transform colorContainer) 
    {
        colorNodes = new List<GameObject>();
        foreach (Transform child in colorContainer)
        {
            Destroy(child.gameObject);
        }
    }
}
