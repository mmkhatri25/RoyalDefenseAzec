using UnityEngine;

public class _Trigger : MonoBehaviour
{
	public string ID;

	private string idName;

	private int idCode;

	public int alignment;

	public int alignmentType;

	public int triggerType;

	public int triggerClass;

	public int pureEffect;

	public int effectType;

	public int effectClass;

	public int knockEffectUnalterable;

	public int disableEffectUnalterable;

	public int msAttributeUnalterable;

	public int hpAttributeCriticalMultiplier;

	public int hpAttributeToggle;

	public int hpAttributeAmount;

	public int hpOverTimeAttributeToggle;

	public int hpOverTimeAttributeAmount;

	public int hpOverTimeAttributeNumber;

	public float hpOverTimeAttributeDelay;

	public int hpOverTimeAttributeEffectClass;

	public int hpOverTimeAttributeEffectNumber;

	public int mpAttributeToggle;

	public int mpAttributeAmount;

	public int colorEffectToggle;

	public Color colorEffectColor;

	public float colorEffectDuration;

	public int disableEffectToggle;

	public float disableEffectDuration;

	public int hexEffectToggle;

	public float hexEffectDuration;

	public int riseEffectToggle;

	public float riseEffectDistance;

	public float riseEffectDuration;

	public float riseEffectDamping;

	public int knockEffectToggle;

	public float knockEffectDistance;

	public float knockEffectDuration;

	public float knockEffectDamping;

	public int dmgAttributeToggle;

	public int dmgAttributeAmount;

	public float dmgAttributeDuration;

	public int msAttributeToggle;

	public int msAttributeAmount;

	public float msAttributeDuration;

	public int asAttributeToggle;

	public int asAttributeAmount;

	public float asAttributeDuration;

	public int apAttributeToggle;

	public int apAttributeAmount;

	public float apAttributeDuration;

	public int anpAttributeToggle;

	public int anpAttributeAmount;

	public float anpAttributeDuration;

	public int mrpAttributeToggle;

	public int mrpAttributeAmount;

	public float mrpAttributeDuration;

	public int crpAttributeToggle;

	public int crpAttributeAmount;

	public float crpAttributeDuration;

	public int acpAttributeToggle;

	public int acpAttributeAmount;

	public float acpAttributeDuration;

	public int evpAttributeToggle;

	public int evpAttributeAmount;

	public float evpAttributeDuration;

	public int effectClassID;

	public int effectSubID;

	private float resetTimer;

	private Statistic_Logic scriptStatisticLogic;

	private string DOT_name;

	private int state;

	private int hpAttributeToggle_BASE;

	private int hpAttributeAmount_BASE;

	private int hpOverTimeAttributeToggle_BASE;

	private int hpOverTimeAttributeAmount_BASE;

	private int hpOverTimeAttributeNumber_BASE;

	private float hpOverTimeAttributeDelay_BASE;

	private int hpOverTimeAttributeEffectClass_BASE;

	private int hpOverTimeAttributeEffectNumber_BASE;

	private int mpAttributeToggle_BASE;

	private int mpAttributeAmount_BASE;

	private int colorEffectToggle_BASE;

	private Color colorEffectColor_BASE;

	private float colorEffectDuration_BASE;

	private int disableEffectToggle_BASE;

	private float disableEffectDuration_BASE;

	private int riseEffectToggle_BASE;

	private float riseEffectDistance_BASE;

	private float riseEffectDuration_BASE;

	private float riseEffectDamping_BASE;

	private int knockEffectToggle_BASE;

	private float knockEffectDistance_BASE;

	private float knockEffectDuration_BASE;

	private float knockEffectDamping_BASE;

	private int dmgAttributeToggle_BASE;

	private int dmgAttributeAmount_BASE;

	private float dmgAttributeDuration_BASE;

	private int msAttributeToggle_BASE;

	private int msAttributeAmount_BASE;

	private float msAttributeDuration_BASE;

	private int asAttributeToggle_BASE;

	private int asAttributeAmount_BASE;

	private float asAttributeDuration_BASE;

	private int apAttributeToggle_BASE;

	private int apAttributeAmount_BASE;

	private float apAttributeDuration_BASE;

	private int anpAttributeToggle_BASE;

	private int anpAttributeAmount_BASE;

	private float anpAttributeDuration_BASE;

	private int mrpAttributeToggle_BASE;

	private int mrpAttributeAmount_BASE;

	private float mrpAttributeDuration_BASE;

	private int crpAttributeToggle_BASE;

	private int crpAttributeAmount_BASE;

	private float crpAttributeDuration_BASE;

	private int acpAttributeToggle_BASE;

	private int acpAttributeAmount_BASE;

	private float acpAttributeDuration_BASE;

	private int evpAttributeToggle_BASE;

	private int evpAttributeAmount_BASE;

	private float evpAttributeDuration_BASE;

	public _Trigger followTrigger;

	private void Awake()
	{
		base.useGUILayout = false;
		idName = ID;
		effectClassID = effectClass;
		idCode = UnityEngine.Random.Range(0, 999);
		ID = idName + idCode;
		base.name = ID;
		scriptStatisticLogic = GameScriptsManager.statisticLogicScript;
		TagFunction();
		BaseSetup();
	}

	private void OnSpawned()
	{
		idCode = UnityEngine.Random.Range(0, 999);
		ID = idName + idCode;
		base.name = ID;
		if (followTrigger != null)
		{
			TriggerTransfer();
		}
		else if (triggerType == 1 && triggerClass > 0)
		{
			SpellSetupFunction(triggerClass - 1);
		}
		if (triggerType == 1)
		{
			switch (alignment)
			{
			case 0:
				switch (alignmentType)
				{
				case 0:
					base.tag = "AtSB";
					break;
				case 1:
					base.tag = "AtSA";
					break;
				case 2:
					base.tag = "AtSAB";
					break;
				}
				break;
			case 1:
				switch (alignmentType)
				{
				case 0:
					base.tag = "AtSA";
					break;
				case 1:
					base.tag = "AtSB";
					break;
				case 2:
					base.tag = "AtSAB";
					break;
				}
				break;
			}
		}
		else
		{
			switch (alignment)
			{
			case 0:
				switch (alignmentType)
				{
				case 0:
					base.tag = "AtAB";
					break;
				case 1:
					base.tag = "AtAA";
					break;
				case 2:
					base.tag = "AtAAB";
					break;
				}
				break;
			case 1:
				switch (alignmentType)
				{
				case 0:
					base.tag = "AtBA";
					break;
				case 1:
					base.tag = "AtBB";
					break;
				case 2:
					base.tag = "AtBAB";
					break;
				}
				break;
			}
		}
		state = 0;
	}

	private void OnDespawned()
	{
		if (triggerType == 1 && triggerClass > 0)
		{
			SpellReset();
		}
		else
		{
			base.tag = "Untagged";
		}
		if (hpAttributeCriticalMultiplier > 2)
		{
			hpAttributeCriticalMultiplier = 0;
		}
		state = 0;
	}

	private void Update()
	{
		switch (state)
		{
		case 0:
			if (followTrigger != null)
			{
				TriggerTransfer();
			}
			else if (triggerType == 1 && triggerClass > 0)
			{
				SpellSetupFunction(triggerClass - 1);
			}
			if (idName == "static")
			{
				resetTimer = Time.time + 1f;
			}
			state++;
			break;
		case 1:
			if (idName == "static" && Time.time >= resetTimer)
			{
				idCode = UnityEngine.Random.Range(0, 999);
				ID = idName + idCode;
				base.name = ID;
				resetTimer = Time.time + 1f;
			}
			if (base.name.Contains("DOT") && DOT_name != base.name)
			{
				if (base.tag == "Untagged")
				{
					TagFunction();
				}
				if (followTrigger != null)
				{
					TriggerTransfer();
				}
				else if (triggerType == 1 && triggerClass > 0)
				{
					SpellSetupFunction(triggerClass - 1);
				}
				DOT_name = base.name;
			}
			break;
		}
	}

	private void TagFunction()
	{
		if (triggerType == 1)
		{
			switch (alignment)
			{
			case 0:
				switch (alignmentType)
				{
				case 0:
					base.tag = "AtSB";
					break;
				case 1:
					base.tag = "AtSA";
					break;
				case 2:
					base.tag = "AtSAB";
					break;
				}
				break;
			case 1:
				switch (alignmentType)
				{
				case 0:
					base.tag = "AtSA";
					break;
				case 1:
					base.tag = "AtSB";
					break;
				case 2:
					base.tag = "AtSAB";
					break;
				}
				break;
			}
			return;
		}
		switch (alignment)
		{
		case 0:
			switch (alignmentType)
			{
			case 0:
				base.tag = "AtAB";
				break;
			case 1:
				base.tag = "AtAA";
				break;
			case 2:
				base.tag = "AtAAB";
				break;
			}
			break;
		case 1:
			switch (alignmentType)
			{
			case 0:
				base.tag = "AtBA";
				break;
			case 1:
				base.tag = "AtBB";
				break;
			case 2:
				base.tag = "AtBAB";
				break;
			}
			break;
		}
	}

	private void BaseSetup()
	{
		hpAttributeToggle_BASE = hpAttributeToggle;
		hpAttributeAmount_BASE = hpAttributeAmount;
		hpOverTimeAttributeToggle_BASE = hpOverTimeAttributeToggle;
		hpOverTimeAttributeAmount_BASE = hpOverTimeAttributeAmount;
		hpOverTimeAttributeNumber_BASE = hpOverTimeAttributeNumber;
		hpOverTimeAttributeDelay_BASE = hpOverTimeAttributeDelay;
		hpOverTimeAttributeEffectClass_BASE = hpOverTimeAttributeEffectClass;
		hpOverTimeAttributeEffectNumber_BASE = hpOverTimeAttributeEffectNumber;
		mpAttributeToggle_BASE = mpAttributeToggle;
		mpAttributeAmount_BASE = mpAttributeAmount;
		colorEffectToggle_BASE = colorEffectToggle;
		colorEffectColor_BASE = colorEffectColor;
		colorEffectDuration_BASE = colorEffectDuration;
		disableEffectToggle_BASE = disableEffectToggle;
		disableEffectDuration_BASE = disableEffectDuration;
		riseEffectToggle_BASE = riseEffectToggle;
		riseEffectDistance_BASE = riseEffectDistance;
		riseEffectDuration_BASE = riseEffectDuration;
		riseEffectDamping_BASE = riseEffectDamping;
		knockEffectToggle_BASE = knockEffectToggle;
		knockEffectDistance_BASE = knockEffectDistance;
		knockEffectDuration_BASE = knockEffectDuration;
		knockEffectDamping_BASE = knockEffectDamping;
		dmgAttributeToggle_BASE = dmgAttributeToggle;
		dmgAttributeAmount_BASE = dmgAttributeAmount;
		dmgAttributeDuration_BASE = dmgAttributeDuration;
		msAttributeToggle_BASE = msAttributeToggle;
		msAttributeAmount_BASE = msAttributeAmount;
		msAttributeDuration_BASE = msAttributeDuration;
		asAttributeToggle_BASE = asAttributeToggle;
		asAttributeAmount_BASE = asAttributeAmount;
		asAttributeDuration_BASE = asAttributeDuration;
		apAttributeToggle_BASE = apAttributeToggle;
		apAttributeAmount_BASE = apAttributeAmount;
		apAttributeDuration_BASE = apAttributeDuration;
		anpAttributeToggle_BASE = anpAttributeToggle;
		anpAttributeAmount_BASE = anpAttributeAmount;
		anpAttributeDuration_BASE = anpAttributeDuration;
		mrpAttributeToggle_BASE = mrpAttributeToggle;
		mrpAttributeAmount_BASE = mrpAttributeAmount;
		mrpAttributeDuration_BASE = mrpAttributeDuration;
		crpAttributeToggle_BASE = crpAttributeToggle;
		crpAttributeAmount_BASE = crpAttributeAmount;
		crpAttributeDuration_BASE = crpAttributeDuration;
		acpAttributeToggle_BASE = acpAttributeToggle;
		acpAttributeAmount_BASE = acpAttributeAmount;
		acpAttributeDuration_BASE = acpAttributeDuration;
		evpAttributeToggle_BASE = evpAttributeToggle;
		evpAttributeAmount_BASE = evpAttributeAmount;
		evpAttributeDuration_BASE = evpAttributeDuration;
	}

	private void SpellSetupFunction(int spellNUMBER)
	{
		if (scriptStatisticLogic == null)
		{
			scriptStatisticLogic = GameScriptsManager.statisticLogicScript;
		}
		if (hpAttributeToggle_BASE == 0)
		{
			hpAttributeToggle = scriptStatisticLogic.InGameAttribute[0].PlayerSpellAttribute[spellNUMBER].hpAttributeToggle;
		}
		hpAttributeAmount = hpAttributeAmount_BASE + scriptStatisticLogic.InGameAttribute[0].PlayerSpellAttribute[spellNUMBER].hpAttributeAmount;
		if (hpOverTimeAttributeToggle_BASE == 0)
		{
			hpOverTimeAttributeToggle = scriptStatisticLogic.InGameAttribute[0].PlayerSpellAttribute[spellNUMBER].hpOverTimeAttributeToggle;
		}
		hpOverTimeAttributeAmount = hpOverTimeAttributeAmount_BASE + scriptStatisticLogic.InGameAttribute[0].PlayerSpellAttribute[spellNUMBER].hpOverTimeAttributeAmount;
		hpOverTimeAttributeNumber = hpOverTimeAttributeNumber_BASE + scriptStatisticLogic.InGameAttribute[0].PlayerSpellAttribute[spellNUMBER].hpOverTimeAttributeNumber;
		hpOverTimeAttributeDelay = hpOverTimeAttributeDelay_BASE + scriptStatisticLogic.InGameAttribute[0].PlayerSpellAttribute[spellNUMBER].hpOverTimeAttributeDelay;
		if (mpAttributeToggle_BASE == 0)
		{
			mpAttributeToggle = scriptStatisticLogic.InGameAttribute[0].PlayerSpellAttribute[spellNUMBER].mpAttributeToggle;
		}
		mpAttributeAmount = mpAttributeAmount_BASE + scriptStatisticLogic.InGameAttribute[0].PlayerSpellAttribute[spellNUMBER].mpAttributeAmount;
		if (colorEffectToggle_BASE == 0 && scriptStatisticLogic.InGameAttribute[0].PlayerSpellAttribute[spellNUMBER].colorEffectToggle != 0)
		{
			colorEffectToggle = scriptStatisticLogic.InGameAttribute[0].PlayerSpellAttribute[spellNUMBER].colorEffectToggle;
			colorEffectColor = scriptStatisticLogic.InGameAttribute[0].PlayerSpellAttribute[spellNUMBER].colorEffectColor;
			colorEffectDuration = colorEffectDuration_BASE + scriptStatisticLogic.InGameAttribute[0].PlayerSpellAttribute[spellNUMBER].colorEffectDuration;
		}
		if (disableEffectUnalterable == 0)
		{
			if (disableEffectToggle_BASE == 0)
			{
				disableEffectToggle = scriptStatisticLogic.InGameAttribute[0].PlayerSpellAttribute[spellNUMBER].disableEffectToggle;
			}
			disableEffectDuration = disableEffectDuration_BASE + scriptStatisticLogic.InGameAttribute[0].PlayerSpellAttribute[spellNUMBER].disableEffectDuration;
		}
		if (riseEffectToggle_BASE == 0)
		{
			riseEffectToggle = scriptStatisticLogic.InGameAttribute[0].PlayerSpellAttribute[spellNUMBER].riseEffectToggle;
		}
		riseEffectDistance = riseEffectDistance_BASE + scriptStatisticLogic.InGameAttribute[0].PlayerSpellAttribute[spellNUMBER].riseEffectDistance;
		if (riseEffectDuration_BASE + scriptStatisticLogic.InGameAttribute[0].PlayerSpellAttribute[spellNUMBER].riseEffectDuration <= 1f)
		{
			riseEffectDuration = riseEffectDuration_BASE + scriptStatisticLogic.InGameAttribute[0].PlayerSpellAttribute[spellNUMBER].riseEffectDuration;
		}
		else
		{
			riseEffectDuration = 1f;
		}
		if (riseEffectDamping_BASE + scriptStatisticLogic.InGameAttribute[0].PlayerSpellAttribute[spellNUMBER].riseEffectDamping <= 5f)
		{
			riseEffectDamping = riseEffectDamping_BASE + scriptStatisticLogic.InGameAttribute[0].PlayerSpellAttribute[spellNUMBER].riseEffectDamping;
		}
		else
		{
			riseEffectDamping = 5f;
		}
		if (knockEffectUnalterable == 0)
		{
			if (knockEffectToggle_BASE == 0)
			{
				knockEffectToggle = scriptStatisticLogic.InGameAttribute[0].PlayerSpellAttribute[spellNUMBER].knockEffectToggle;
			}
			if (knockEffectDistance_BASE < 0f)
			{
				knockEffectDistance = knockEffectDistance_BASE - scriptStatisticLogic.InGameAttribute[0].PlayerSpellAttribute[spellNUMBER].knockEffectDistance;
			}
			else
			{
				knockEffectDistance = knockEffectDistance_BASE + scriptStatisticLogic.InGameAttribute[0].PlayerSpellAttribute[spellNUMBER].knockEffectDistance;
			}
			if (knockEffectDuration_BASE + scriptStatisticLogic.InGameAttribute[0].PlayerSpellAttribute[spellNUMBER].knockEffectDuration <= 1f)
			{
				knockEffectDuration = knockEffectDuration_BASE + scriptStatisticLogic.InGameAttribute[0].PlayerSpellAttribute[spellNUMBER].knockEffectDuration;
			}
			else
			{
				knockEffectDuration = 1f;
			}
			if (knockEffectDamping_BASE + scriptStatisticLogic.InGameAttribute[0].PlayerSpellAttribute[spellNUMBER].knockEffectDamping <= 5f)
			{
				knockEffectDamping = knockEffectDamping_BASE + scriptStatisticLogic.InGameAttribute[0].PlayerSpellAttribute[spellNUMBER].knockEffectDamping;
			}
			else
			{
				knockEffectDamping = 5f;
			}
		}
		if (dmgAttributeToggle_BASE == 0)
		{
			dmgAttributeToggle = scriptStatisticLogic.InGameAttribute[0].PlayerSpellAttribute[spellNUMBER].dmgAttributeToggle;
		}
		dmgAttributeAmount = dmgAttributeAmount_BASE + scriptStatisticLogic.InGameAttribute[0].PlayerSpellAttribute[spellNUMBER].dmgAttributeAmount;
		dmgAttributeDuration = dmgAttributeDuration_BASE + scriptStatisticLogic.InGameAttribute[0].PlayerSpellAttribute[spellNUMBER].dmgAttributeDuration;
		if (msAttributeUnalterable == 0)
		{
			if (msAttributeToggle_BASE == 0)
			{
				msAttributeToggle = scriptStatisticLogic.InGameAttribute[0].PlayerSpellAttribute[spellNUMBER].msAttributeToggle;
			}
			msAttributeAmount = msAttributeAmount_BASE + scriptStatisticLogic.InGameAttribute[0].PlayerSpellAttribute[spellNUMBER].msAttributeAmount;
			msAttributeDuration = msAttributeDuration_BASE + scriptStatisticLogic.InGameAttribute[0].PlayerSpellAttribute[spellNUMBER].msAttributeDuration;
		}
		if (asAttributeToggle_BASE == 0)
		{
			asAttributeToggle = scriptStatisticLogic.InGameAttribute[0].PlayerSpellAttribute[spellNUMBER].asAttributeToggle;
		}
		asAttributeAmount = asAttributeAmount_BASE + scriptStatisticLogic.InGameAttribute[0].PlayerSpellAttribute[spellNUMBER].asAttributeAmount;
		asAttributeDuration = asAttributeDuration_BASE + scriptStatisticLogic.InGameAttribute[0].PlayerSpellAttribute[spellNUMBER].asAttributeDuration;
		if (apAttributeToggle_BASE == 0)
		{
			apAttributeToggle = scriptStatisticLogic.InGameAttribute[0].PlayerSpellAttribute[spellNUMBER].apAttributeToggle;
		}
		apAttributeAmount = apAttributeAmount_BASE + scriptStatisticLogic.InGameAttribute[0].PlayerSpellAttribute[spellNUMBER].apAttributeAmount;
		apAttributeDuration = apAttributeDuration_BASE + scriptStatisticLogic.InGameAttribute[0].PlayerSpellAttribute[spellNUMBER].apAttributeDuration;
		if (anpAttributeToggle_BASE == 0)
		{
			anpAttributeToggle = scriptStatisticLogic.InGameAttribute[0].PlayerSpellAttribute[spellNUMBER].anpAttributeToggle;
		}
		anpAttributeAmount = anpAttributeAmount_BASE + scriptStatisticLogic.InGameAttribute[0].PlayerSpellAttribute[spellNUMBER].anpAttributeAmount;
		anpAttributeDuration = anpAttributeDuration_BASE + scriptStatisticLogic.InGameAttribute[0].PlayerSpellAttribute[spellNUMBER].anpAttributeDuration;
		if (mrpAttributeToggle_BASE == 0)
		{
			mrpAttributeToggle = scriptStatisticLogic.InGameAttribute[0].PlayerSpellAttribute[spellNUMBER].mrpAttributeToggle;
		}
		mrpAttributeAmount = mrpAttributeAmount_BASE + scriptStatisticLogic.InGameAttribute[0].PlayerSpellAttribute[spellNUMBER].mrpAttributeAmount;
		mrpAttributeDuration = mrpAttributeDuration_BASE + scriptStatisticLogic.InGameAttribute[0].PlayerSpellAttribute[spellNUMBER].mrpAttributeDuration;
		if (crpAttributeToggle_BASE == 0)
		{
			crpAttributeToggle = scriptStatisticLogic.InGameAttribute[0].PlayerSpellAttribute[spellNUMBER].crpAttributeToggle;
		}
		crpAttributeAmount = crpAttributeAmount_BASE + scriptStatisticLogic.InGameAttribute[0].PlayerSpellAttribute[spellNUMBER].crpAttributeAmount;
		crpAttributeDuration = crpAttributeDuration_BASE + scriptStatisticLogic.InGameAttribute[0].PlayerSpellAttribute[spellNUMBER].crpAttributeDuration;
		if (acpAttributeToggle_BASE == 0)
		{
			acpAttributeToggle = scriptStatisticLogic.InGameAttribute[0].PlayerSpellAttribute[spellNUMBER].acpAttributeToggle;
		}
		acpAttributeAmount = acpAttributeAmount_BASE + scriptStatisticLogic.InGameAttribute[0].PlayerSpellAttribute[spellNUMBER].acpAttributeAmount;
		acpAttributeDuration = acpAttributeDuration_BASE + scriptStatisticLogic.InGameAttribute[0].PlayerSpellAttribute[spellNUMBER].acpAttributeDuration;
		if (evpAttributeToggle_BASE == 0)
		{
			evpAttributeToggle = scriptStatisticLogic.InGameAttribute[0].PlayerSpellAttribute[spellNUMBER].evpAttributeToggle;
		}
		evpAttributeAmount = evpAttributeAmount_BASE + scriptStatisticLogic.InGameAttribute[0].PlayerSpellAttribute[spellNUMBER].evpAttributeAmount;
		evpAttributeDuration = evpAttributeDuration_BASE + scriptStatisticLogic.InGameAttribute[0].PlayerSpellAttribute[spellNUMBER].evpAttributeDuration;
		if (effectClass >= 0)
		{
			hpAttributeAmount += scriptStatisticLogic.EffectClassAttribute[effectClass].hpAttributeAmount;
			hpOverTimeAttributeAmount += scriptStatisticLogic.EffectClassAttribute[effectClass].hpOverTimeAttributeAmount;
			mpAttributeAmount += scriptStatisticLogic.EffectClassAttribute[effectClass].mpAttributeAmount;
			disableEffectDuration += scriptStatisticLogic.EffectClassAttribute[effectClass].disableEffectDuration;
			knockEffectDistance += scriptStatisticLogic.EffectClassAttribute[effectClass].knockEffectDistance;
			dmgAttributeAmount += scriptStatisticLogic.EffectClassAttribute[effectClass].dmgAttributeAmount;
			msAttributeAmount += scriptStatisticLogic.EffectClassAttribute[effectClass].msAttributeAmount;
			asAttributeAmount += scriptStatisticLogic.EffectClassAttribute[effectClass].asAttributeAmount;
			apAttributeAmount += scriptStatisticLogic.EffectClassAttribute[effectClass].apAttributeAmount;
			anpAttributeAmount += scriptStatisticLogic.EffectClassAttribute[effectClass].anpAttributeAmount;
			mrpAttributeAmount += scriptStatisticLogic.EffectClassAttribute[effectClass].mrpAttributeAmount;
			crpAttributeAmount += scriptStatisticLogic.EffectClassAttribute[effectClass].crpAttributeAmount;
			acpAttributeAmount += scriptStatisticLogic.EffectClassAttribute[effectClass].acpAttributeAmount;
			evpAttributeAmount += scriptStatisticLogic.EffectClassAttribute[effectClass].evpAttributeAmount;
		}
	}

	private void SpellReset()
	{
		hpAttributeToggle = hpAttributeToggle_BASE;
		hpAttributeAmount = hpAttributeAmount_BASE;
		hpOverTimeAttributeToggle = hpOverTimeAttributeToggle_BASE;
		hpOverTimeAttributeAmount = hpOverTimeAttributeAmount_BASE;
		hpOverTimeAttributeNumber = hpOverTimeAttributeNumber_BASE;
		hpOverTimeAttributeDelay = hpOverTimeAttributeDelay_BASE;
		hpOverTimeAttributeEffectNumber = hpOverTimeAttributeEffectClass_BASE;
		hpOverTimeAttributeEffectNumber = hpOverTimeAttributeEffectNumber_BASE;
		mpAttributeToggle = mpAttributeToggle_BASE;
		mpAttributeAmount = mpAttributeAmount_BASE;
		colorEffectToggle = colorEffectToggle_BASE;
		colorEffectColor = colorEffectColor_BASE;
		colorEffectDuration = colorEffectDuration_BASE;
		disableEffectToggle = disableEffectToggle_BASE;
		disableEffectDuration = disableEffectDuration_BASE;
		riseEffectToggle = riseEffectToggle_BASE;
		riseEffectDistance = riseEffectDistance_BASE;
		riseEffectDuration = riseEffectDuration_BASE;
		riseEffectDamping = riseEffectDamping_BASE;
		knockEffectToggle = knockEffectToggle_BASE;
		knockEffectDistance = knockEffectDistance_BASE;
		knockEffectDuration = knockEffectDuration_BASE;
		knockEffectDamping = knockEffectDamping_BASE;
		dmgAttributeToggle = dmgAttributeToggle_BASE;
		dmgAttributeAmount = dmgAttributeAmount_BASE;
		dmgAttributeDuration = dmgAttributeDuration_BASE;
		msAttributeToggle = msAttributeToggle_BASE;
		msAttributeAmount = msAttributeAmount_BASE;
		msAttributeDuration = msAttributeDuration_BASE;
		asAttributeToggle = asAttributeToggle_BASE;
		asAttributeAmount = asAttributeAmount_BASE;
		asAttributeDuration = asAttributeDuration_BASE;
		apAttributeToggle = apAttributeToggle_BASE;
		apAttributeAmount = apAttributeAmount_BASE;
		apAttributeDuration = apAttributeDuration_BASE;
		anpAttributeToggle = anpAttributeToggle_BASE;
		anpAttributeAmount = anpAttributeAmount_BASE;
		anpAttributeDuration = anpAttributeDuration_BASE;
		mrpAttributeToggle = mrpAttributeToggle_BASE;
		mrpAttributeAmount = mrpAttributeAmount_BASE;
		mrpAttributeDuration = mrpAttributeDuration_BASE;
		crpAttributeToggle = crpAttributeToggle_BASE;
		crpAttributeAmount = crpAttributeAmount_BASE;
		crpAttributeDuration = crpAttributeDuration_BASE;
		acpAttributeToggle = acpAttributeToggle_BASE;
		acpAttributeAmount = acpAttributeAmount_BASE;
		acpAttributeDuration = acpAttributeDuration_BASE;
		evpAttributeToggle = evpAttributeToggle_BASE;
		evpAttributeAmount = evpAttributeAmount_BASE;
		evpAttributeDuration = evpAttributeDuration_BASE;
	}

	private void TriggerTransfer()
	{
		if (followTrigger != null)
		{
			alignment = followTrigger.alignment;
			alignmentType = followTrigger.alignmentType;
			triggerType = followTrigger.triggerType;
			triggerClass = followTrigger.triggerClass;
			pureEffect = followTrigger.pureEffect;
			effectType = followTrigger.effectType;
			effectClass = followTrigger.effectClass;
			hpAttributeCriticalMultiplier = followTrigger.hpAttributeCriticalMultiplier;
			hpAttributeToggle = followTrigger.hpAttributeToggle;
			hpAttributeAmount = followTrigger.hpAttributeAmount;
			hpOverTimeAttributeToggle = followTrigger.hpOverTimeAttributeToggle;
			hpOverTimeAttributeAmount = followTrigger.hpOverTimeAttributeAmount;
			hpOverTimeAttributeNumber = followTrigger.hpOverTimeAttributeNumber;
			hpOverTimeAttributeDelay = followTrigger.hpOverTimeAttributeDelay;
			hpOverTimeAttributeEffectClass = followTrigger.hpOverTimeAttributeEffectClass;
			hpOverTimeAttributeEffectNumber = followTrigger.hpOverTimeAttributeEffectNumber;
			mpAttributeToggle = followTrigger.mpAttributeToggle;
			mpAttributeAmount = followTrigger.mpAttributeAmount;
			colorEffectToggle = followTrigger.colorEffectToggle;
			colorEffectColor = followTrigger.colorEffectColor;
			colorEffectDuration = followTrigger.colorEffectDuration;
			disableEffectToggle = followTrigger.disableEffectToggle;
			disableEffectDuration = followTrigger.disableEffectDuration;
			riseEffectToggle = followTrigger.riseEffectToggle;
			riseEffectDistance = followTrigger.riseEffectDistance;
			riseEffectDuration = followTrigger.riseEffectDuration;
			riseEffectDamping = followTrigger.riseEffectDamping;
			knockEffectToggle = followTrigger.knockEffectToggle;
			knockEffectDistance = followTrigger.knockEffectDistance;
			knockEffectDuration = followTrigger.knockEffectDuration;
			knockEffectDamping = followTrigger.knockEffectDamping;
			dmgAttributeToggle = followTrigger.dmgAttributeToggle;
			dmgAttributeAmount = followTrigger.dmgAttributeAmount;
			dmgAttributeDuration = followTrigger.dmgAttributeDuration;
			msAttributeToggle = followTrigger.msAttributeToggle;
			msAttributeAmount = followTrigger.msAttributeAmount;
			msAttributeDuration = followTrigger.msAttributeDuration;
			asAttributeToggle = followTrigger.asAttributeToggle;
			asAttributeAmount = followTrigger.asAttributeAmount;
			asAttributeDuration = followTrigger.asAttributeDuration;
			apAttributeToggle = followTrigger.apAttributeToggle;
			apAttributeAmount = followTrigger.apAttributeAmount;
			apAttributeDuration = followTrigger.apAttributeDuration;
			anpAttributeToggle = followTrigger.anpAttributeToggle;
			anpAttributeAmount = followTrigger.anpAttributeAmount;
			anpAttributeDuration = followTrigger.anpAttributeDuration;
			mrpAttributeToggle = followTrigger.mrpAttributeToggle;
			mrpAttributeAmount = followTrigger.mrpAttributeAmount;
			mrpAttributeDuration = followTrigger.mrpAttributeDuration;
			crpAttributeToggle = followTrigger.crpAttributeToggle;
			crpAttributeAmount = followTrigger.crpAttributeAmount;
			crpAttributeDuration = followTrigger.crpAttributeDuration;
			acpAttributeToggle = followTrigger.acpAttributeToggle;
			acpAttributeAmount = followTrigger.acpAttributeAmount;
			acpAttributeDuration = followTrigger.acpAttributeDuration;
			evpAttributeToggle = followTrigger.evpAttributeToggle;
			evpAttributeAmount = followTrigger.evpAttributeAmount;
			evpAttributeDuration = followTrigger.evpAttributeDuration;
			effectClassID = followTrigger.effectClassID;
			effectSubID = followTrigger.effectSubID;
		}
	}
}
