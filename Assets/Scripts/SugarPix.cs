using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SugarPix: MonoBehaviour
{
    private Vector2 pos;
    private float waterLevel = 0f;
    private GameObject sugarPixObject;

    void Start()
    {
        sugarPixObject = this.gameObject;
    }

    public void addWater(float amount)
    {
        waterLevel += amount * Mathf.Pow(1-waterLevel, 300);
        if(waterLevel >= 1f) waterLevel = 1f;
        darkenColor(amount);
    }

    public float getWaterLevel()
    {
        return waterLevel;
    }

    private void darkenColor(float amount)
    {
        SpriteRenderer SRcomp = sugarPixObject.GetComponent<SpriteRenderer>();
        if (SRcomp.color == Color.clear) return;
        SRcomp.color -= new Color(255*amount, 255*amount, 255*amount, 0);
        if(SRcomp.color.r <= 0) SRcomp.color = Color.clear;
    }


}
