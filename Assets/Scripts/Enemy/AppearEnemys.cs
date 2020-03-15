using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppearEnemys : MonoBehaviour
{
    [SerializeField] GameObject[] enemys;
    [SerializeField] float appearNextTime;
    [SerializeField] int maxNumOfEnemys;

    private float elapsedTime;
    private int numberOfEnemys;

    void Start()
    {
        numberOfEnemys = 0;
        elapsedTime = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (numberOfEnemys >= maxNumOfEnemys)
        {
            return;
        }

        elapsedTime += Time.deltaTime;

        if(elapsedTime > appearNextTime)
        {
            elapsedTime = 0f;
            GenerateEnemy();
        }

    }

    void GenerateEnemy()
    {
        var randomValue = Random.Range(0, enemys.Length);
        var randomRotationY = Random.value * 360f;

        GameObject.Instantiate(enemys[randomValue], transform.position, Quaternion.Euler(0f, randomRotationY, 0f));

        numberOfEnemys++;
        elapsedTime = 0;
    }
}
