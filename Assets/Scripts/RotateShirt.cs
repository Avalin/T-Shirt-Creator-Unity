using UnityEngine;

public class RotateShirt : MonoBehaviour
{

    public GameObject tShirtMale;
    public GameObject tShirtFemale;
    bool isRotating;
    bool isRotatingLeft;
    float speed = 500;

    void Update()
    {
        if (isRotating)
        {
            if (isRotatingLeft) 
            {
                RotateLeft();
            }
            else 
            {
                RotateRight();
            }
        }
    }

    public void StartRotatingLeft(bool directionIsLeft)
    {
        if (directionIsLeft) 
        {
            isRotatingLeft = true;
            isRotating = true;
        }
        else
        {
            isRotatingLeft = false;
            isRotating = true;
        }
    }

    public void StopRotating()
    {
        isRotating = false;
    }

    void RotateRight()
    {
        tShirtMale.transform.Rotate(Vector3.up * -speed * Time.deltaTime);
        tShirtFemale.transform.Rotate(Vector3.up * -speed * Time.deltaTime);
    }

    void RotateLeft()
    {
        tShirtMale.transform.Rotate(Vector3.up * speed * Time.deltaTime);
        tShirtFemale.transform.Rotate(Vector3.up * speed * Time.deltaTime);
    }
}
