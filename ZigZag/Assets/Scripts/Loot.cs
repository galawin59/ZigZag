using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loot : MonoBehaviour
{
    // Start is called before the first frame update
    int score = 2;
    [SerializeField] GameObject particules;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag =="Player")
        {
            score = int.Parse(GameManager.Instance.score.text) + 2;
            GameManager.Instance.score.text = score.ToString();
            GameObject go = Instantiate(particules, new Vector3(transform.position.x , transform.position.y, transform.position.z ), Quaternion.identity);
            go.transform.Rotate(new Vector3(-90f,0f,0f));
            
            Destroy(gameObject);
        }
    }
}
