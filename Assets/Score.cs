using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//UIのTEXTに得点表示
//ボールがターゲットと接触するとポイント加算
//小星＝1点　大星＝2点　小雲＝3点　大雲＝4点
//得点は画面右上に

public class Score : MonoBehaviour {

	private int Point = 0;
	private GameObject ScoreText;


	void Start () {
		this.ScoreText = GameObject.Find ("ScoreText");
	}


	void Update () {
		this.ScoreText.GetComponent<Text> ().text = Point.ToString ();
	}



	//ボールとターゲットが衝突時に呼ばれる関数
	void OnCollisionEnter(Collision collision){

		if (collision.gameObject.tag == "SmallStarTag") {
			Point += 1;
			Debug.Log ("小星にヒット　１点追加　　現在 " + Point + " 点");
		}

		if (collision.gameObject.tag == "LargeStarTag") {
			Point += 2;
			Debug.Log ("大星にヒット　２点追加　　現在 " + Point + " 点");
		}

		if (collision.gameObject.tag == "SmallCloudTag") {
			Point += 3;
			Debug.Log ("小星にヒット　３点追加　　現在 " + Point + " 点");
		}

		if (collision.gameObject.tag == "LargeCloudTag") {
			Point += 4;
			Debug.Log ("小星にヒット　４点追加　　現在 " + Point + " 点");
		}
	}
}
