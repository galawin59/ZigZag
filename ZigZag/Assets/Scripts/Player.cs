using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rb;
    float speed = 5f;
    bool isBack = false;
    bool isbegin = false;
    int score;
    bool isactive = false;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    IEnumerator ScoreDist()
    {
        yield return new WaitForSeconds(0.5f);
        score = int.Parse(GameManager.Instance.score.text) + 1;
        GameManager.Instance.score.text = score.ToString();
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q) && !GameManager.Instance.isactive)
        {
            rb.velocity = Vector3.back * speed;
            isBack = true;
            isbegin = true;
            score= int.Parse(GameManager.Instance.score.text) + 1;
            GameManager.Instance.score.text = score.ToString();
        }
        if (Input.GetKeyDown(KeyCode.Z) && !GameManager.Instance.isactive)
        {
            rb.velocity = Vector3.left * speed;
            isBack = false;
            isbegin = true;
            score = int.Parse(GameManager.Instance.score.text) + 1;
            GameManager.Instance.score.text = score.ToString();
        }

        if (isBack && isbegin)
        {
            rb.velocity = Vector3.back * speed;
            StopCoroutine(ScoreDist());
            isactive = false;
        }
        else if(!isBack && isbegin)
        {
            if (!isactive)
                StartCoroutine(ScoreDist());
            isactive = true;

            rb.velocity = Vector3.left * speed;
           
        }
        if(transform.localPosition.y < 1.70f )
        {
            isbegin = false;
            rb.velocity = Vector3.down * 10f;
            GameManager.Instance.isactive = true;
        }
     
    }
}
