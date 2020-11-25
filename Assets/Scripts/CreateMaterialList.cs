using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CreateMaterialList : MonoBehaviour
{
    private List<Material> materials;
    public Button BTN_Material;

    private void Start()
    {
        materials = new List<Material>();
        materials = Resources.LoadAll("Materials", typeof(Material)).Cast<Material>().ToList();
        Button firstButton = null;
        for(int i = 0; i < materials.Count; i++) 
        {
            if (i == 0) firstButton = CreateSelectButtonForMaterial(materials[i], i);
            else CreateSelectButtonForMaterial(materials[i], i);
        }
    }

    Button CreateSelectButtonForMaterial(Material mat, int index) 
    {
        var button = Instantiate(BTN_Material, Vector3.zero, Quaternion.identity) as Button;
        button.name = "BTN_"+mat.name;
        button.GetComponent<SelectMaterial>().material = mat;
        button.transform.SetParent(transform);
        button.transform.Find("Text").GetComponent<Text>().text = mat.name;
        var rectTransform = button.GetComponent<RectTransform>();
        rectTransform.offsetMax = Vector2.zero;
        rectTransform.offsetMin = Vector2.zero;
        rectTransform.anchorMin = new Vector2(0.5f, 1);
        rectTransform.anchorMax = new Vector2(0.5f, 1);
        rectTransform.sizeDelta = new Vector2(250,30);

        int moveFactor = 25;
        if (index >= 0) moveFactor += 10;
        Vector2 newPos = new Vector2(162, -((index+1)*moveFactor));
        rectTransform.localPosition = newPos;
        return button;
    }
}
