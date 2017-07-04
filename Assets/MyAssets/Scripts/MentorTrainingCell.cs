using UnityEngine;
using UnityEngine.UI;

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
				// LevelUpのロジックがまだなのでまだ
			});

		discriptionButton.onClick.AddListener(() => {
			// Descriptionを表示させるところを作ってないのでまだ
		});

		vrButton.onClick.AddListener(() => {
			// VRViewを作ってないのでまだ
		});
	}

	private int CulcLevelUpCost()
	{
		// 一旦100円でLevelUpCostを返すようにしておく。あとで作る。
		return 100;
	}

	private void UpdateValue()
	{
		var master = characterData.Master;
		levelLabel.text = "Lv." + characterData.Level;
		productivityLabel.text = string.Format("生産性 : ¥ {0:#,0} /tap", characterData.Power);
		var cost = CulcLevelUpCost();
		costLabel.text = string.Format("¥{0:#,0}", cost);
		if (true) { //ここ、所持金がコストに足りてるかどうかっていうのに後で書き換える
			levelUpButtonGroup.alpha = 0.5f;
		}
		else levelUpButtonGroup.alpha = 1.0f;
		if (characterData.IsLevelMax) 
		{
			levelUpButtonGroup.alpha = 0.5f;
			costLabel.text = "Level Max";
		}
	}
}