using UnityEngine;
public class HandleClickOnObject : MonoBehaviour
{
    private bool isInsideColorPicker;
    private GameObject title;

    private void Start()
    {
        title = transform.parent.Find("Title").gameObject;
    }


    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (!isInsideColorPicker)
            {
                gameObject.SetActive(false);
                title.SetActive(true);
            }
        }

    }

    public void SetInsideColorPicker(bool isInside)
    {
        isInsideColorPicker = isInside;
        transform.parent.parent.SetAsLastSibling();
    }
}
