using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCube : MonoBehaviour
{
   [SerializeField] Gradient colorGrad;
    // Start is called before the first frame update
    int score;
    static int tempScore;
    void Start()
    {
        score = int.Parse(GameManager.Instance.score.text);
      
            GetComponent<Renderer>().material.color = colorGrad.Evaluate((float)tempScore / 1000f);
    }

    // Update is called once per frame
    void Update()
    {
        if(score % 20 == 0)
        {
            GetComponent<Renderer>().material.color = colorGrad.Evaluate((float)score/1000f);
            tempScore = score;
        }
        
            GetComponent<Renderer>().material.color = colorGrad.Evaluate((float)tempScore / 1000f);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            Destroy(gameObject, 1f);
        }
    }
}
