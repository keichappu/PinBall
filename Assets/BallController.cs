using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    Material myMaterial;

    private float visiblePosZ = -6.5f;

    private GameObject gameoverText;

    private GameObject pointText;

    private int point = 0;
    // Start is called before the first frame update
    void Start()
    {
        this.gameoverText = GameObject.Find("GameOverText");
        
        this.pointText = GameObject.Find("PointText");

       this.pointText.GetComponent<Text> ().text = this.point + "pts";

        this.myMaterial = GetComponent<Renderer>().material;

    }

    // Update is called once per frame
    void Update()
    {
        if(this.transform.position.z < this.visiblePosZ)
        {
            this.gameoverText.GetComponent<Text>().text = "Game Over";
        }

        this.pointText.GetComponent<Text>().text = this.point + "pts";
    }

    private void OnCollisionEnter(Collision Collision)
    {
        if (Collision.gameObject.tag == "SmallStarTag")
        {
            this.point += 5; 
        }
        else if (Collision.gameObject.tag == "LargeStarTag")
        {
            this.point += 10;
        }
        else if (Collision.gameObject.tag == "SmallCloudTag")
        {
            this.point += 15;
        }
        else if (Collision.gameObject.tag == "LargeCloudTag")
        {
            this.point += 20;
        }
    }
}
