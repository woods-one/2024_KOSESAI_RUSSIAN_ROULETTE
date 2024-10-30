using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class TestPrefab : MonoBehaviour
{
    [SerializeField]
    GameObject hogehoge;

    [SerializeField] 
    private GameObject hoge;

    private bool isDeleted;
    
    List<GameObject> prefabs = new ();
    
    void Start()
    {
        prefabs.Add((GameObject)Instantiate(hogehoge));
        prefabs.Add((GameObject)Instantiate(hoge));
        isDeleted = false;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.E) && isDeleted == false)
        {
            isDeleted = true;
            Destroy(prefabs[prefabs.Count - 1]);
            prefabs.RemoveAt(prefabs.Count - 1);
        }
    }
}
