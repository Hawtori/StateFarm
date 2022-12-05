using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FarmManager : MonoBehaviour
{
    public static FarmManager _instance { get; set; }
    public GameObject[] farm;

    public GameObject ui;

    public TextMeshProUGUI txt;


    private int selectedFarmIndex;
    private int crops;

    private void Awake()
    {
        if (_instance == null) _instance = this;
        else Destroy(this);
    }

    private void Update()
    {
        txt.text = crops.ToString();
        if (Input.GetMouseButton(1))
        {
            ui.SetActive(true);

            for (int i = 0; i < 3; i++) ui.transform.GetChild(i).gameObject.SetActive(false);

            if (GetFarm().canHarvest) ui.transform.GetChild(0).gameObject.SetActive(true);
            if (!GetFarm().water && GetFarm().active) ui.transform.GetChild(1).gameObject.SetActive(true);
            if (!GetFarm().active) ui.transform.GetChild(2).gameObject.SetActive(true);
        }
    }

    public void SetCurrentIndex(int i)
    {
        selectedFarmIndex = i;
    }

    public Farm GetFarm()
    {
        return farm[selectedFarmIndex].GetComponent<Farm>();
    }

    public void Harvest()
    {
        crops += GetFarm().Harvest();
    }

    public void DisableUI()
    {
        ui.SetActive(false);
    }

    public int GetCrops()
    {
        return crops;
    }

    public void TakeCrops(){
        crops--;
    }

    public void ResetCrop()
    {
        crops = 0;
    }
}

