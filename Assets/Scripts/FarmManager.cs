using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FarmManager
{
    public class FarmManager : MonoBehaviour
    {
        public static FarmManager _instance { get; set; }
        public GameObject[] farm;

        private int selectedFarmIndex;

        private void Awake()
        {
            if (_instance == null) _instance = this;
            else Destroy(this);
        }

        private void Update()
        {
            if (Input.GetMouseButton(1))
            {
                farm[selectedFarmIndex].GetComponent<SpriteRenderer>().color = Color.red;
            }
        }

        public void SetCurrentIndex(int i)
        {
            selectedFarmIndex = i;
        }

    }
}
