using UnityEngine;
using System.Collections;

public class GameManager
	: SingletonMonoBehaviour<GameManager>
{
	private void Start()
	{
		MasterDataManager.instance.LoadData(() => 
			{
				// ここ編集しました
				PortrateUIManager.instance.Setup();
			});
	}

	public static void Log (object log)
	{
		if (Debug.isDebugBuild)
		{
			Debug.Log(log);
		}
	}
}