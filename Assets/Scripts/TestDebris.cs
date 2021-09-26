using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDebris : MonoBehaviour
{
    public float timeDelay = 5;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timeDelay <= 0)
        {
            GameManager.instance.debrisList.Remove(this.gameObject);
            Destroy(this.gameObject);
        }
        else
        {
            timeDelay -= Time.deltaTime;
        }

    }
}
