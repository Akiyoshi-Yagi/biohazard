using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeCamera : MonoBehaviour
{
    [SerializeField] GameObject mainCamera;
    [SerializeField] GameObject otherCamera;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            //GameObject自身がactiveがどうかを調べるプロパティとしてactiveSelf
            mainCamera.SetActive(!mainCamera.activeSelf);
            otherCamera.SetActive(!otherCamera.activeSelf);
        }
    }
}
