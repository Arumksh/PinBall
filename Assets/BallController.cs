using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour {

    public GameObject scoreText;

    //ボールが見える可能性のあるz軸の最大値
    private float visiblePosZ = -6.5f;

    //ゲームオーバを表示するテキスト
    private GameObject gameoverText;

    int score;

    // Use this for initialization
    private void Start()
    {
        this.gameoverText = GameObject.Find("GameOverText");
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.GetComponent<Text>().text = ("Score :" + score.ToString());
        //ボールが画面外に出た場合
        if (this.transform.position.z < this.visiblePosZ)
        {
            //GameoverTextにゲームオーバを表示
            this.gameoverText.GetComponent<Text>().text = "Game Over";
        }
    }


    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "LargeStarTag")
        {
            score += 20;
        }
        if (col.gameObject.tag == "SmallStarTag")
        {
            score += 5;
        }
        if (col.gameObject.tag == "LargeCloudTag")
        {
            score += 15;
        }
        if (col.gameObject.tag == "SmallCloudTag")
        {
            score += 10;
        }
    }
}
