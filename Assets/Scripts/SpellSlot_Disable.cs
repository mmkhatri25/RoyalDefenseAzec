using System;
using UnityEngine;

public class SpellSlot_Disable : MonoBehaviour
{
	[Serializable]
	public class disable
	{
		public int slotDisable = 50;

		public int randomSlotDisable;

		public GameObject slotObject;
	}

	public float disableDuration = 5f;

	private GameObject targetSlot;

	public disable[] Disable = new disable[6];

	private Spell_Logic scriptSpellLogic;

	private Item_Control scriptItemControl;

	private Game_Logic scriptGameLogic;

	private Transform myTransform;

	private int state;

	private int RANDOM_disable;

	private int TOGGLE_disable;

	private float TIMER_disableDuration;

	private void Start()
	{
		base.useGUILayout = false;
		myTransform = base.transform;
		scriptSpellLogic = GameScriptsManager.spellLogicScript;
		scriptItemControl = GameScriptsManager.itemControlScript;
		scriptGameLogic = GameScriptsManager.gameLogicScript;
		Disable[0].slotObject = scriptSpellLogic.SpellControl[0].iconBackground.gameObject;
		Disable[1].slotObject = scriptSpellLogic.SpellControl[1].iconBackground.gameObject;
		Disable[2].slotObject = scriptSpellLogic.SpellControl[2].iconBackground.gameObject;
		Disable[3].slotObject = scriptSpellLogic.SpellControl[3].iconBackground.gameObject;
		Disable[4].slotObject = scriptItemControl.itemOneBG.gameObject;
		Disable[5].slotObject = scriptItemControl.itemTwoBG.gameObject;
		state = -1;
	}

	private void OnSpawned()
	{
		state = -1;
	}

	private void Update()
	{
		if (Time.timeScale != 0f)
		{
			switch (state)
			{
			case -1:
				TOGGLE_disable = -1;
				RANDOM_disable = 0;
				for (int i = 0; i < Disable.Length; i++)
				{
					if (i < 4)
					{
						if (Disable[i].slotDisable > 0 && scriptSpellLogic.SpellControl[i].spellState != -2)
						{
							Disable[i].randomSlotDisable = UnityEngine.Random.Range(0, Disable[i].slotDisable);
							if (Disable[i].randomSlotDisable > RANDOM_disable)
							{
								TOGGLE_disable = i;
								RANDOM_disable = Disable[i].randomSlotDisable;
							}
						}
						continue;
					}
					switch (i)
					{
					case 4:
						if (Disable[i].slotDisable > 0 && scriptItemControl.itemOneState != 0)
						{
							Disable[i].randomSlotDisable = UnityEngine.Random.Range(0, Disable[i].slotDisable);
							if (Disable[i].randomSlotDisable > RANDOM_disable)
							{
								TOGGLE_disable = i;
								RANDOM_disable = Disable[i].randomSlotDisable;
							}
						}
						break;
					case 5:
						if (Disable[i].slotDisable > 0 && scriptItemControl.itemTwoState != 0)
						{
							Disable[i].randomSlotDisable = UnityEngine.Random.Range(0, Disable[i].slotDisable);
							if (Disable[i].randomSlotDisable > RANDOM_disable)
							{
								TOGGLE_disable = i;
								RANDOM_disable = Disable[i].randomSlotDisable;
							}
						}
						break;
					}
				}
				if (TOGGLE_disable != -1)
				{
					targetSlot = Disable[TOGGLE_disable].slotObject;
					state++;
				}
				else
				{
					state = 3;
				}
				break;
			case 0:
			{
				TIMER_disableDuration = Time.time + disableDuration;
				Transform transform = myTransform;
				Vector3 position = targetSlot.transform.position;
				transform.position = new Vector3(position.x, -0.925f, 0f);
				if (TOGGLE_disable < 4)
				{
					scriptSpellLogic.SpellControl[TOGGLE_disable].spellState = 3;
				}
				else if (TOGGLE_disable == 4)
				{
					scriptItemControl.itemOneState = 0;
				}
				else if (TOGGLE_disable == 5)
				{
					scriptItemControl.itemTwoState = 0;
				}
				state++;
				break;
			}
			case 1:
				myTransform.position = targetSlot.transform.position;
				if (Time.time >= TIMER_disableDuration || scriptGameLogic.gameState != 2)
				{
					state++;
				}
				break;
			case 2:
				if (TOGGLE_disable < 4)
				{
					scriptSpellLogic.SpellControl[TOGGLE_disable].spellState = -1;
				}
				else if (TOGGLE_disable == 4)
				{
					scriptItemControl.itemOneState = 1;
				}
				else if (TOGGLE_disable == 5)
				{
					scriptItemControl.itemTwoState = 1;
				}
				state++;
				break;
			case 3:
				PoolManager.Pools["Effect Pool"].Despawn(myTransform);
				break;
			}
		}
		else
		{
			Vector3 position2 = myTransform.position;
			Vector3 position3 = targetSlot.transform.position;
			if (position2 != new Vector3(position3.x, -100f, 0f))
			{
				Transform transform2 = myTransform;
				Vector3 position4 = targetSlot.transform.position;
				transform2.position = new Vector3(position4.x, -100f, 0f);
			}
		}
	}
}
