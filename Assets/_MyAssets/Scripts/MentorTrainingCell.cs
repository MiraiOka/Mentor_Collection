﻿using UnityEngine;
using UnityEngine.UI;

// 追記
using UniRx;

public class MentorTrainingCell : MonoBehaviour
{
	[SerializeField] private Image iconImage;

	[SerializeField] private Text
	nameLabel,
	rarityLabel,
	levelLabel,
	productivityLabel,
	costLabel;

	[SerializeField] private Button 
	levelUpButton, 
	discriptionButton, 
	vrButton;
	[SerializeField] private CanvasGroup levelUpButtonGroup;

	private Character characterData;

	// 追記
	private User User { get { return GameManager.instance.User; } }

	public void SetValue(Character data)
	{
		var master = data.Master;
		characterData = data;
		iconImage.sprite = Resources.Load<Sprite>("Face/" + master.ImageId);
		nameLabel.text = master.Name;
		rarityLabel.text = "";
		for (var i = 0; i < master.Rarity; i++) { rarityLabel.text += "★"; }
		UpdateValue();

		levelUpButton.onClick.AddListener(() =>
			{
				// 追記
				var cost = CulcLevelUpCost();
				if (User.Money.Value < cost) return;
				if (characterData.IsLevelMax) return;
				characterData.LevelUp();
				User.ConsumptionLevelUpCost(cost);
				UpdateValue();
			});

		discriptionButton.onClick.AddListener(() => {
			// Descriptionを表示させるところを作ってないのでまだ
		});

		vrButton.onClick.AddListener(() => {
			// VRViewを作ってないのでまだ
		});

		// 所持金のIntReactiveProperty化で対応しておく予定の部分
		if (User.Money.Value < CulcLevelUpCost()) levelUpButtonGroup.alpha = 0.5f;
		User.Money.Subscribe(value => {
			if (characterData.IsLevelMax) return;
			UpdateValue();
		});
	}

	private int CulcLevelUpCost()
	{
		// 編集
		return MasterDataManager.instance.GetConsumptionMoney (characterData);
	}

	private void UpdateValue()
	{
		var master = characterData.Master;
		levelLabel.text = "Lv." + characterData.Level;
		productivityLabel.text = string.Format("生産性 : ¥ {0:#,0} /tap", characterData.Power);
		var cost = CulcLevelUpCost();
		costLabel.text = string.Format("¥{0:#,0}", cost);

		// ifの条件を編集
		if (User.Money.Value < cost) levelUpButtonGroup.alpha = 0.5f;

		else levelUpButtonGroup.alpha = 1.0f;
		if (characterData.IsLevelMax) 
		{
			levelUpButtonGroup.alpha = 0.5f;
			costLabel.text = "Level Max";
		}
	}
}