using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FamOptions : MonoBehaviour
{
    public void Harvest()
    {
        FarmManager._instance.Harvest();
        FarmManager._instance.DisableUI();
    }

    public void Water()
    {
        FarmManager._instance.GetFarm().Water();
        FarmManager._instance.DisableUI();

    }

    public void Plant()
    {
        FarmManager._instance.GetFarm().Plant();
        FarmManager._instance.DisableUI();
    }
}
