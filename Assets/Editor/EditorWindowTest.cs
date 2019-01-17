using UnityEngine;
using UnityEditor;

public class EditorWindowTest : EditorWindow{
	[MenuItem("MyEditor/Sample")]
	private static void Create(){
		//生成
		GetWindow<EditorWindowTest>("サンプル");
	}
}