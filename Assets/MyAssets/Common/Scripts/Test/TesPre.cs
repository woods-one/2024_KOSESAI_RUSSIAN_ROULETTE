using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TesPre : MonoBehaviour
{
    [SerializeField]
    private GameObject hoge;
    
    void Start()
    {
        Instantiate(hoge);
    }
}
