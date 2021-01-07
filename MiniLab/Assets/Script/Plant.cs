using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
    public float SpawnTime;
    public GameObject Flower;
    private Vector2 LU, RD;
    private int perdel;

    void Start()
    {
        StartCoroutine(Spawned());
        LU = GameObject.Find("LU").transform.position; //левый вверх
        RD = GameObject.Find("RD").transform.position; //правый низ
    }

    //зациклевающая хрень

    IEnumerator Spawned()
    {
        yield return new WaitForSeconds(SpawnTime);
        int CurentFlower = GameObject.FindGameObjectsWithTag("flower").Length;
        int NumOfPlant = GameObject.FindGameObjectWithTag("SUKAAAA").GetComponent<Global>().NumOfPlant;
        Vector2 pos;
            if (CurentFlower <= NumOfPlant)
            {
                pos = new Vector2(Random.Range(LU.x, RD.x), Random.Range(LU.y, RD.y));
                Instantiate(Flower, pos, Quaternion.identity).transform.parent = gameObject.transform;
                if (SpawnTime < 0f)
                {
                    SpawnTime = 0f;
                }
            }
                pos = new Vector2(Random.Range(LU.x, RD.x), Random.Range(LU.y, RD.y));
        Gone();
    }

    void Gone()
    {
        StartCoroutine(Spawned());
    }
}