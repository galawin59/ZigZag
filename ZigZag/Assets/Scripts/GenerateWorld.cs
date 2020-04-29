using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateWorld : MonoBehaviour
{
    [SerializeField] GameObject prefabsCube;
    [SerializeField] GameObject loot;
    int count;
    int countX;
    int countZ;

    IEnumerator Wait()
    {
        while (!GameManager.Instance.isactive)
        {
            yield return new WaitForSeconds(0.2f);

            GameObject go = Instantiate(prefabsCube, new Vector3(prefabsCube.transform.position.x - countX, prefabsCube.transform.position.y, prefabsCube.transform.position.z - countZ), Quaternion.identity);
            count++;
            if (count % 3 != 0)
            {
                if (Random.Range(0, 3) == 1)
                    countZ++;
                else
                    countX++;
            }

            else
                countZ++;


            if (Random.Range(0, 10) == 4)
            {
                GameObject go2 = Instantiate(loot, new Vector3(prefabsCube.transform.position.x - countX, prefabsCube.transform.position.y + 2f, prefabsCube.transform.position.z - countZ), Quaternion.identity);
            }

        }
    }
    void Start()
    {


        StartCoroutine(Wait());

    }


    void Update()
    {

    }
}
