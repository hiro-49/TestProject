using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
/*
データをリスト形式で保存するときは
データクラス(DataClass_2)とそのリストを保持するクラス(DataClass)の2つを作成し、
DataClassをJsonに変換する

DataClassとDataClass_2は[Serializable]属性をつける using System;
*/

public class TestJson : MonoBehaviour {
	public List<DataClass_2> dataClassList = new List<DataClass_2>();
	public DataClass data = new DataClass();
	string jsonData;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < 5; i++){
			dataClassList.Add(CreateDataClass2(i));
		}
		data.data = dataClassList;

		jsonData = JsonUtility.ToJson(data);
		Debug.Log(jsonData);
		File.WriteAllText("Assets/1ki/TestJsonScene/SaveData/testData.json", jsonData);
	}

	DataClass_2 CreateDataClass2(int i){
		DataClass_2 Instance;
		Instance = new DataClass_2();
		Instance.ATK = i;
		Instance.HP = i;
		Instance.speed = i;

		return Instance;
	}
}
