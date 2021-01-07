using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreyLogic : MonoBehaviour
{
    public float Hunger, TimeTick, DeadLine, Eat;
    public float speed, hung;
    public int MutationChance;
    private Vector2 point;
    public GameObject PreyBact, PredatorBact;
    GameObject[] flower;
    private int numBact;

    void Start()
    {
        hung = GameObject.FindGameObjectWithTag("SUKAAAA").GetComponent<Global>().PreyHunger;
        Hunger = 4;
        speed = GameObject.FindGameObjectWithTag("SUKAAAA").GetComponent<Global>().PreySpeed;

        StartCoroutine(Tick());
        StartCoroutine(findEat());

        MutationChance = GameObject.FindGameObjectWithTag("SUKAAAA").GetComponent<Global>().MutationChance;
        DeadLine = GameObject.FindGameObjectWithTag("SUKAAAA").GetComponent<Global>().PreyDead;
        Eat = GameObject.FindGameObjectWithTag("SUKAAAA").GetComponent<Global>().FlowerEat;
        if (Random.Range(0,100) <= MutationChance)
        {
            speed = speed + speed/ GameObject.FindGameObjectWithTag("SUKAAAA").GetComponent<Global>().ProcentOfSpeedMutation;
        } else
        {
            if (Random.Range(0, 100) >= 100 - MutationChance)
            {
                speed = speed - speed / GameObject.FindGameObjectWithTag("SUKAAAA").GetComponent<Global>().ProcentOfSpeedMutation;
            }
        }
    }

    void Update()
    {
        flower = GameObject.FindGameObjectsWithTag("flower");
        TimeTick = GameObject.FindGameObjectWithTag("SUKAAAA").GetComponent<Global>().Tick;
        transform.position = Vector2.MoveTowards(transform.position, point, speed * Time.deltaTime/TimeTick);
    }

    IEnumerator Tick()
    {
        yield return new WaitForSeconds(TimeTick);
        Hunger+= hung;
        gavno();
    }
    void gavno()
    {
        StartCoroutine(Tick());
        if(Hunger >= DeadLine)
        {
            Destroy(gameObject);
        }
        numBact = GameObject.FindGameObjectWithTag("SUKAAAA").GetComponent<Global>().NumOfBact;
        if (Hunger <= 0)
        {
            if (numBact > GameObject.FindGameObjectsWithTag("prey").Length + GameObject.FindGameObjectsWithTag("predator").Length)
            {
                Instantiate(PreyBact, gameObject.transform.position + new Vector3(0.02f, -0.04f, 0f), Quaternion.identity);
                Hunger = 2;
            }
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "flower")
        {
            Hunger -= Eat;
            Destroy(col.gameObject);
        }
    }

    IEnumerator findEat()
    {
        yield return new WaitForSeconds(0.1f);        
        jopa();
    }
    void jopa()
    {
        float st = 5000;
        for (int i = 0; i < flower.Length; i++)
        {
            if (Vector2.Distance(gameObject.transform.position, flower[i].transform.position) < st)
            {
                st = Vector2.Distance(gameObject.transform.position, flower[i].transform.position);
                point = flower[i].transform.position;
            }
        }
        StartCoroutine(findEat());
    }

}