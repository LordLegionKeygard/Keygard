using UnityEngine;

public class Abilities : MonoBehaviour
{
	public AbilityView[] PoisonAbilities;
	public AbilityView[] FireAbilities;
	public AbilityView[] IceAbilities;
	public AbilityView[] WindAbilities;
	
	private void Update()
	{
		foreach (AbilityView ability in PoisonAbilities)
			ability.Update();
		foreach (AbilityView ability in FireAbilities)
			ability.Update();
		foreach (AbilityView ability in IceAbilities)
			ability.Update();
		foreach (AbilityView ability in WindAbilities)
			ability.Update();
	}
}