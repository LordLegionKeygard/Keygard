using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class AbilityView
{
	public Image Fill;
	public KeyCode Key;
	public float Cooldown;

	public void Update()
	{
		if (Input.GetKeyDown(Key))
			FillImage();
	}

	private void FillImage()
	{
		Fill.fillAmount = 1f;
		Fill.DOFillAmount(0f, Cooldown);
	}
}