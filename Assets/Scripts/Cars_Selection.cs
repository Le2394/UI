using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Cars_Selection : MonoBehaviour
{
    public Button NextCar;
    public Button PreviousCar;
    public List<GameObject> cars = new List<GameObject>();
    public int currentCarIndex = 0;
    void Start()
    {
        if (NextCar != null)
        {
            NextCar.onClick.AddListener(OnNextCarButtonClicked);
        }
        if (PreviousCar != null)
        {
            PreviousCar.onClick.AddListener(OnPreviousCarButtonClicked);
        }
        for (int i = 0; i < cars.Count; i++)
        {
            cars[i].SetActive(i == 0);
        }
    }

    void OnNextCarButtonClicked()
    {
        if (NextCar)
        {
            currentCarIndex = (currentCarIndex + 1) % cars.Count;
            UpdateCarVisibility();
        }
    }
    void OnPreviousCarButtonClicked()
    {
        if (PreviousCar)
        {
            currentCarIndex = (currentCarIndex - 1 + cars.Count) % cars.Count;
            UpdateCarVisibility();
        }
    }

    void UpdateCarVisibility()
    {
        for (int i = 0; i < cars.Count; i++)
        {
            cars[i].SetActive(i == currentCarIndex);
        }
    }

    void OnDestroy()
    {
        if (NextCar != null)
        {
            NextCar.onClick.RemoveListener(OnNextCarButtonClicked);
        }

        if (PreviousCar != null)
        {
            PreviousCar.onClick.RemoveListener(OnPreviousCarButtonClicked);
        }
    }
}

