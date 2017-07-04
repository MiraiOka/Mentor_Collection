using UnityEngine;

[System.SerializableAttribute]
public class Character 
{
	[SerializeField] private int uid, masterId, level;

	public int UniqueID { get { return uid; } }
	public int MasterId { get { return masterId; } }
	public int Level    { get { return level; } }

	public MstCharacter Master
	{
		get
		{
			return MasterDataManager.instance.GetCharacterById(masterId);
		}
	}

	public int Power 
	{
		get 
		{
			// 一旦 1 で返しておく。後で算出ロジック書く。
			return 1;
		}
	}

	// コンストラクタ
	public Character (int uniqueId, MstCharacter data)
	{
		uid = uniqueId;
		level = 1; 
		masterId = data.ID;
	}

	// ついで。後で使います。レベルマックスになってるかどうかを返すプロパティ
	public bool IsLevelMax 
	{ 
		get
		{  
			return (level >= Master.MaxLevel) ? true : false;
		} 
	}
}