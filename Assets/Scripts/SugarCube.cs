using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SugarCube: MonoBehaviour
{
    public float size;
    public GameObject sugarCubeObject;
    public GameObject sugarPixPrefab;
    private List<List<Transform>> grid = new List<List<Transform>>();
    private bool isStarted = false;

    void Start()
    {
        initCube();    
    }

    void Update() 
    {
        if(isStarted) flowWater();
        
    }

    public void runAnimation()
    {
        isStarted = true;
    }

    private void flowWater()
    {
        System.Random random = new System.Random();
        float waterMult = 0.07f;
        float probability = 0.04f;
        for(int i = 0; i < grid.Count; i++)
        {
            for(int j = 0; j < grid[i].Count; j++)
            {
                SugarPix sugarPix = grid[i][j].GetComponent<SugarPix>();
                if(i == 0 || i == grid.Count-1) sugarPix.addWater(waterMult);
                if(j == grid[0].Count-1) sugarPix.addWater(waterMult);


                if(i > 0){ 
                    //if(grid[i-1][j].GetComponent<SugarPix>().getWaterLevel() > sugarPix.getWaterLevel())
                    if(random.NextDouble() < probability) //grid[i-1][j].GetComponent<SugarPix>().getWaterLevel())
                        sugarPix.addWater(grid[i-1][j].GetComponent<SugarPix>().getWaterLevel()*waterMult);
                }
                if(j > 0){ 
                    //if(grid[i][j-1].GetComponent<SugarPix>().getWaterLevel() > sugarPix.getWaterLevel())
                    if(random.NextDouble() < probability) //grid[i][j-1].GetComponent<SugarPix>().getWaterLevel())
                        sugarPix.addWater(grid[i][j-1].GetComponent<SugarPix>().getWaterLevel()*waterMult);
                }
                if(i < grid.Count-1){ 
                    //if(grid[i+1][j].GetComponent<SugarPix>().getWaterLevel() > sugarPix.getWaterLevel())
                    if(random.NextDouble() < probability) //grid[i+1][j].GetComponent<SugarPix>().getWaterLevel())
                        sugarPix.addWater(grid[i+1][j].GetComponent<SugarPix>().getWaterLevel()*waterMult);
                }
                if(j < grid.Count-1){ 
                    //if(grid[i][j+1].GetComponent<SugarPix>().getWaterLevel() > sugarPix.getWaterLevel())
                    if(random.NextDouble() < probability) //grid[i][j+1].GetComponent<SugarPix>().getWaterLevel())
                        sugarPix.addWater(grid[i][j+1].GetComponent<SugarPix>().getWaterLevel()*waterMult);
                }
            }
        }
    }


    private void initCube()
    {
        float pixSize = sugarPixPrefab.transform.localScale.x;
        for(float i = -size/2; i<size/2; i+=pixSize)
        {
            List<Transform> newLst = new List<Transform>();
            for(float j = -size/2; j<size/2; j+=pixSize)
            {
                initSugarPix(i, j);
                newLst.Add(sugarCubeObject.transform.GetChild(sugarCubeObject.transform.childCount-1));
            }
            grid.Add(newLst);
        }
    }

    private void initSugarPix(float x, float y){
        GameObject newPix = Instantiate(sugarPixPrefab) as GameObject;
        newPix.transform.position = new Vector3(x, y, 10);
		newPix.transform.SetParent(sugarCubeObject.transform, false);
    }

    


}
