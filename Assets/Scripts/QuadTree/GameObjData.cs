/**
 * 封装Gameobject的数据类，是四叉树中存储的数据
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjData{

    public string resourcePath;
    public Vector3 position;
    public Quaternion rotation;
    public GameObject gameObject;


    
    public GameObjData(string resourcePath,Vector3 position, Quaternion rotation)
    {
        this.resourcePath = resourcePath; ;
        this.position = position;
        this.rotation = rotation;
       
    }

    public void Instantiate()
    {
        GameObject go = Resources.Load<GameObject>(resourcePath);
        gameObject = GameObject.Instantiate(go, position, rotation);
    }

    public void ActiveObj()
    {
        gameObject.SetActive(true);
    }

    public void UnActiveObj()
    {
        gameObject.SetActive(false);
    }

    public bool isUnInstantiate()
    {
        return (gameObject==null)?true:false;
    }
}
