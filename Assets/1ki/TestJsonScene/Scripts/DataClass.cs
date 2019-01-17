using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class DataClass{
	public List<DataClass_2> data;

    //保存したいクラスがメソッドをもっていても良いかテスト
	void Dummy(){
		Debug.Log("実行してみたけど大丈夫そう");
	}
    
}
