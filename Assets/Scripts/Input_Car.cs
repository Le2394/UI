using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Input_car : Cars_Selection
{
    public Cars_Selection carSelection;
    private Vector3 MousePos;
    private float zoomSpeed = 0.4f;
    private float minScale = 0.5f;
    private float maxScale = 1.5f;

    private void Update()
    {
        CarRotation();
        Zoom();
    }
    void CarRotation()
    {
        int currentCarIndex = carSelection.currentCarIndex;
        GameObject currentCar = cars[currentCarIndex];

        if (Input.GetMouseButtonDown(0))
        {
            MousePos = Input.mousePosition;
        }

        else if (Input.GetMouseButton(0))
        {
            Vector3 deltaMouse = Input.mousePosition - MousePos;
            float rotationSpeed = 40f;

            currentCar.transform.Rotate(Vector3.up, -deltaMouse.x * rotationSpeed * Time.deltaTime);

            MousePos = Input.mousePosition;
        }
    }

    void Zoom()
    {
        int currentCarIndex = carSelection.currentCarIndex;
        if (currentCarIndex < 0 || currentCarIndex >= carSelection.cars.Count)
            return;

        GameObject currentCar = carSelection.cars[currentCarIndex];

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll != 0)
        {
            Vector3 newScale = currentCar.transform.localScale + Vector3.one * scroll * zoomSpeed;
            newScale = Vector3.Max(newScale, Vector3.one * minScale);
            newScale = Vector3.Min(newScale, Vector3.one * maxScale);
            currentCar.transform.localScale = newScale;
        }
    }
}
