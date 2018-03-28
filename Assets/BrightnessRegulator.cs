using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BrightnessRegulator : MonoBehaviour {
	//Materialを入れる
	Material myMaterial;
	//Emissionの最小値
	private float minEmission = 0.3f;
	//Emissionの強度
	private float magEmission = 2.0f;
	//角度
	private int degree = 0;
	//発光速度
	private int speed = 10;
	//ターゲットのデフォルト色
	Color defaultColor = Color.white;


	void Start () {
		 
		//タグによって光らせる色を変える　得点に影響を与えるよう改変
		if (tag == "SmallStarTag") {
			this.defaultColor = Color.white;
		} else if (tag == "LargeStarTag") {
			this.defaultColor = Color.yellow;
		} else if (tag == "SmallCloudTag") {
			this.defaultColor = Color.blue;
		} else if (tag == "LargeCloudTag") {
			this.defaultColor = Color.blue;
		}
		//オブジェクトにアタッチしているMaterialを取得
		this.myMaterial = GetComponent<Renderer> ().material;
		//オブジェクトの最初の色を設定
		myMaterial.SetColor("_EmissionColor",this.defaultColor*minEmission);

	}

	void Update () {
		if (this.degree >= 0) {
			//光らせる強度を計算
			Color emissionColor = this.defaultColor * (this.minEmission + Mathf.Sin (this.degree * Mathf.Deg2Rad) * this.magEmission);
			//エミッションに色を指定する
			myMaterial.SetColor ("_EmissionColor", emissionColor);
			//現在の角度を小さくする
			this.degree -= this.speed;
		
			}
	}
	//衝突時に呼ばれる関数
	void OnCollisionEnter(Collision other){
		//角度を１８０に設定
			this.degree = 180;
		}
}