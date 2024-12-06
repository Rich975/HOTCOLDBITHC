using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransparencyTest : MonoBehaviour
{
    GameObject go;

    [Range(0,1)]
    [SerializeField] private float transparencyAmount;

    // Start is called before the first frame update
    void Start()
    {
        go = this.gameObject;
        transparencyAmount = go.GetComponent<Renderer>().material.color.a;
        transparencyAmount = .5f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
