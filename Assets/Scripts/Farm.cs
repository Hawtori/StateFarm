using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FarmManager;

public class Farm : MonoBehaviour
{
    public int index;

    private void OnMouseDown()
    {
        FarmManager.FarmManager._instance.SetCurrentIndex(index);
    }
}
