using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorController : MonoBehaviour
{
    private GameObject tShirtMale;
    private GameObject tShirtFemale;

    public Color Color = Color.white;

    void Start()
    {
        tShirtFemale = transform.Find("T-Shirt-Female").Find("Base").gameObject;
        tShirtMale = transform.Find("T-Shirt-Male").Find("Base").gameObject;

    }

    public void UpdateColorNodes(List<GameObject> colorNodes)
    {
        var maleRenderer = tShirtMale.GetComponent<MeshRenderer>();
        var femaleRenderer = tShirtFemale.GetComponent<MeshRenderer>();
        foreach (GameObject colorNode in colorNodes)
        {
            ColorPicker cp = colorNode.transform.Find("BTN_ChooseColor").Find("ColorPicker").GetComponent<ColorPicker>();
            cp.onValueChanged.AddListener(color =>
            {
                string shaderVar = colorNode.transform.Find("BTN_ChooseColor").Find("ShaderVar").GetComponent<Text>().text;
                femaleRenderer.material.SetColor(shaderVar, color);
                maleRenderer.material.SetColor(shaderVar, color);
                Color = color;
            });

            femaleRenderer.material.color = cp.CurrentColor;
            maleRenderer.material.color = cp.CurrentColor;
            cp.CurrentColor = Color;
        }

    }
}
