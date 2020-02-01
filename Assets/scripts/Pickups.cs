using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Pickups : MonoBehaviour {

    private IEnumerator coroutine; //IEnumerator = asynchronously
    
	// Update is called once per frame
	void Update () {

       var coroutine = Rotate();
        StartCoroutine(coroutine); //Buildin Function

	}

    IEnumerator Rotate()
    {
        float time = 0f;
        while (time < 5)
        {
            time += Time.deltaTime;
            transform.Rotate(0, 0,1.2f, Space.Self); //rotation of the candies
            
            yield return new WaitForSeconds(5/Time.deltaTime); 
        }
       
    }
}
