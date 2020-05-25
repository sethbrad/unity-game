using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMover : MonoBehaviour
{

    public float speed = 0;
    private int count;

    // Start is called before the first frame update
    void Start()
    {
        count = 0;
    }

    //detects collider for score
    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Item") {

            other.gameObject.SetActive(false);
            count++;
        }

        if(other.gameObject.tag== "Hazard"){
            
			other.gameObject.SetActive(false);
			Vector3 jump = new Vector3(0.0f, 30, 0.0f);
			GetComponent<Rigidbody>().AddForce (jump * speed * Time.deltaTime);
		}
       
    }

    //displays score on GUI
    void OnGUI() {
        string score;
        score = GUI.TextField(new Rect(10,10,200,20), count.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //allows player movement
    void FixedUpdate() {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        GetComponent<Rigidbody>().AddForce(movement * speed * Time.deltaTime);
        
    }
}
