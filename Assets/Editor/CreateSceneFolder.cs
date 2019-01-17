using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using System.IO;

public class CreateSceneFolder {
    [MenuItem("MyEditor/Create/SceneFolder")]
	public static void Create(){
		//フォルダ作成先パスの取得?
		string fullPath = EditorUtility.SaveFilePanel("フォルダ作成先の選択", "Assets/1ki", "", "");
		if (string.IsNullOrEmpty(fullPath)) return;
		//フルパスをAssets/...の形に変換
		string path = "Assets" + fullPath.Substring(Application.dataPath.Length);   //Substring : 先頭から"引数int"文字目以降を返す
		string sceneName = Path.GetFileName(path);  //シーンの名前として保持
        //シーンフォルダを作成
		string directory = Path.GetDirectoryName(path); //保存先ディレクトリ取得
		string sceneFolderGUID = AssetDatabase.CreateFolder(directory, sceneName);    //シーンフォルダ作成
		string sceneFolderPath = AssetDatabase.GUIDToAssetPath(sceneFolderGUID);  //GUIDをパスに変換

		//.unityフォルダを作成
		string unityFolderGUID = AssetDatabase.CreateFolder(sceneFolderPath, sceneName + ".unity");
		string unityFolderPath = AssetDatabase.GUIDToAssetPath(unityFolderGUID);

        //シーンを作成
        //EditorApplication.NewScene();
		var scene = EditorSceneManager.NewScene(NewSceneSetup.EmptyScene);
		//メインカメラを作成
		GameObject cameraObj = new GameObject();
		cameraObj.transform.position = new Vector3(0f, 0f, -10f);
		cameraObj.name = "Main Camera";
		cameraObj.tag = "MainCamera";
		Camera camera = cameraObj.AddComponent<Camera>();
		camera.orthographic = true;
		cameraObj.AddComponent<AudioListener>();

        //シーンを保存
		EditorSceneManager.SaveScene(scene, unityFolderPath + "/" + sceneName + ".unity");
	}
}
