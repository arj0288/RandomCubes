/****
 * Created by: Alex Jenkins
 * Date Created: Jan 24, 2022
 * Last edited by: Alex Jenkins
 * Last edited: Jan 26, 2022
 * 
 * Description: Spawns multiple cube prefabs into a scne
 * ****/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCubes : MonoBehaviour
{
    /*Variables*/
    public GameObject cubePrefab; //new GameObject
    public int numberOfCubes = 0;
    public float scalingFactor = 0.95f;
    [HideInInspector]
    public List<GameObject> gameObjectList; //list for all cubes
    



    // Start is called before the first frame update
    void Start()
    {
        gameObjectList = new List<GameObject>(); //instantiate list
    }

    // Update is called once per frame
    void Update()
    {
        numberOfCubes++; //increment # of cubes
        GameObject gObj = Instantiate<GameObject>(cubePrefab); //instantiate cube prefab
        gObj.name = "Cube" + numberOfCubes; //name each cube
        gObj.transform.position = Random.insideUnitSphere; //random point insdide sphere radius 1

        Color randColor = new Color(Random.value, Random.value, Random.value);
        gObj.GetComponent<Renderer>().material.color =randColor;

        gameObjectList.Add(gObj); //add cube to list

        List<GameObject> removeList = new List<GameObject>(); //list for removing cubes
        foreach(GameObject goTemp in gameObjectList)
        {
            float scale = goTemp.transform.localScale.x; //record starting scale
            scale *= scalingFactor; //set scale multiplied by scaling factor
            goTemp.transform.localScale = Vector3.one * scale; //transforms scale

            if(scale <=0.1f)
            {
                removeList.Add(goTemp); //add to remove list
            }

        }

        foreach(GameObject goTemp in removeList)
        {
            gameObjectList.Remove(goTemp); //remove List from gameobject list
            Destroy(goTemp); //destroy object from scene
        }
    }
}
