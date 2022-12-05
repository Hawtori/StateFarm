using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Farm : MonoBehaviour
{
    public int index;

    public float maxTime;

    private float timer;

    public bool canHarvest = false;    
    public bool water = false;
    public bool active = false;


    private void Update()
    {
        if (!active) return;
        GetComponent<SpriteRenderer>().color = Color.magenta;
        timer += Time.deltaTime * (water ? 1.15f : 1f);
        if (timer > maxTime) canHarvest = true;

        if(canHarvest) 
        GetComponent<SpriteRenderer>().color = Color.green;
    }

    private void OnMouseDown()
    {
        FarmManager._instance.SetCurrentIndex(index);
    }

    public int Harvest()
    {
        Invoke("ResetFarm", 0.1f);
        if (!canHarvest)
        {
            if (timer >= maxTime / 2f) return Random.Range(1, 3) + (water ? 1 : 0);
            return 0;
        }

        return Random.Range(2, 5) + (water ? 2 : 0);
    }

    public void Water()
    {
        water = true;
    }

    public void Plant()
    {
        active = true;
    }

    public void ResetFarm()
    {
        GetComponent<SpriteRenderer>().color = Color.white;
        canHarvest = false;
        timer = 0f;
        water = false;
        active = false; 
    }

}
