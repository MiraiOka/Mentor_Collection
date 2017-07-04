using UnityEngine;
using System.Collections;

public class GameManager
	: SingletonMonoBehaviour<GameManager>
{

	private void Start()
	{
		MasterDataManager.instance.LoadData(() => 
			{
				print("ロード終わったお");
				// このラムダ式の部分、後で書き換えるつもりで書いてます。
				var purchaseView = GameObject.FindObjectOfType<MentorPurchaseView>();
				purchaseView.SetCells();
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