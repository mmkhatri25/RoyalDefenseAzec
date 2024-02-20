using System;
using UnityEngine;

public class MenuTransition : MonoBehaviour
{
	[Serializable]
	public class menuObjects
	{
		public Vector3 onPosition;

		public Vector3 offPosition;

		public GameObject menuObject;

		public int transitionDirection;

		public float transitionSpeed;

		public float transitionDelay;

		public float timeTransitionDelay;
	}

	public int transitionNumber;

	private int TOGGLE_transitionNumber = -100;

	private int TOGGLE2_transitionNumber = -100;

	private int menuObjectNumber;

	public float positionZ;

	private float scriptTimer = 5f;

	private float TIME_scriptTimer;

	private float transitionTimer;

	public menuObjects[] MenuObjects;

	private float REVERSETRANSITION_menuObjectTime;

	private int REVERSETRANSITION_objectNumber;

	private void Start()
	{
		SetupPositions();
	}

	private void SetupPositions()
	{
		menuObjectNumber = MenuObjects.Length;
		REVERSETRANSITION_objectNumber = menuObjectNumber;
		if (base.transform.localPosition != new Vector3(0f, 0f, positionZ))
		{
			base.transform.localPosition = new Vector3(0f, 0f, positionZ);
		}
		for (int i = 0; i < MenuObjects.Length; i++)
		{
			MenuObjects[i].onPosition = MenuObjects[i].menuObject.transform.localPosition;
			switch (MenuObjects[i].transitionDirection)
			{
			case 0:
				MenuObjects[i].offPosition = new Vector3(MenuObjects[i].onPosition.x, MenuObjects[i].onPosition.y + 10f, MenuObjects[i].onPosition.z);
				break;
			case 1:
				MenuObjects[i].offPosition = new Vector3(MenuObjects[i].onPosition.x, MenuObjects[i].onPosition.y - 10f, MenuObjects[i].onPosition.z);
				break;
			case 2:
				MenuObjects[i].offPosition = new Vector3(MenuObjects[i].onPosition.x + 10f, MenuObjects[i].onPosition.y, MenuObjects[i].onPosition.z);
				break;
			case 3:
				MenuObjects[i].offPosition = new Vector3(MenuObjects[i].onPosition.x - 10f, MenuObjects[i].onPosition.y, MenuObjects[i].onPosition.z);
				break;
			case 4:
				MenuObjects[i].offPosition = new Vector3(MenuObjects[i].onPosition.x + 10f, MenuObjects[i].onPosition.y + 10f, MenuObjects[i].onPosition.z);
				break;
			case 5:
				MenuObjects[i].offPosition = new Vector3(MenuObjects[i].onPosition.x + 10f, MenuObjects[i].onPosition.y - 10f, MenuObjects[i].onPosition.z);
				break;
			case 6:
				MenuObjects[i].offPosition = new Vector3(MenuObjects[i].onPosition.x - 10f, MenuObjects[i].onPosition.y + 10f, MenuObjects[i].onPosition.z);
				break;
			case 7:
				MenuObjects[i].offPosition = new Vector3(MenuObjects[i].onPosition.x - 10f, MenuObjects[i].onPosition.y - 10f, MenuObjects[i].onPosition.z);
				break;
			}
		}
	}

	private void Update()
	{
		if (menuObjectNumber == 1)
		{
			FunctionSingleMenuTransition();
		}
		else if (menuObjectNumber > 1)
		{
			FunctionMenuTransition();
		}
	}

	private void FunctionSingleMenuTransition()
	{
		if (TOGGLE_transitionNumber != transitionNumber)
		{
			transitionTimer = MenuObjects[0].transitionDelay;
			MenuObjects[0].timeTransitionDelay = MenuObjects[0].transitionDelay + Time.time;
			if (transitionNumber == 6 || transitionNumber == 7)
			{
				TIME_scriptTimer = transitionTimer + 0.25f + Time.time;
			}
			else
			{
				TIME_scriptTimer = transitionTimer + scriptTimer + Time.time;
			}
			TOGGLE2_transitionNumber = -1;
			TOGGLE_transitionNumber = transitionNumber;
		}
		if (TOGGLE2_transitionNumber == TOGGLE_transitionNumber)
		{
			return;
		}
		switch (TOGGLE_transitionNumber)
		{
		case -7:
			switch (MenuObjects[0].transitionDirection)
			{
			case 0:
				MenuObjects[0].menuObject.transform.localPosition = new Vector3(MenuObjects[0].offPosition.x, 0f - MenuObjects[0].offPosition.y, MenuObjects[0].offPosition.z);
				break;
			case 1:
				MenuObjects[0].menuObject.transform.localPosition = new Vector3(MenuObjects[0].offPosition.x, 0f - MenuObjects[0].offPosition.y, MenuObjects[0].offPosition.z);
				break;
			case 2:
				MenuObjects[0].menuObject.transform.localPosition = new Vector3(0f - MenuObjects[0].offPosition.x, MenuObjects[0].offPosition.y, MenuObjects[0].offPosition.z);
				break;
			case 3:
				MenuObjects[0].menuObject.transform.localPosition = new Vector3(0f - MenuObjects[0].offPosition.x, MenuObjects[0].offPosition.y, MenuObjects[0].offPosition.z);
				break;
			case 4:
				MenuObjects[0].menuObject.transform.localPosition = -MenuObjects[0].offPosition;
				break;
			case 5:
				MenuObjects[0].menuObject.transform.localPosition = -MenuObjects[0].offPosition;
				break;
			case 6:
				MenuObjects[0].menuObject.transform.localPosition = -MenuObjects[0].offPosition;
				break;
			case 7:
				MenuObjects[0].menuObject.transform.localPosition = -MenuObjects[0].offPosition;
				break;
			}
			transitionNumber = 0;
			break;
		case -6:
			MenuObjects[0].menuObject.transform.localPosition = MenuObjects[0].offPosition;
			transitionNumber = 0;
			break;
		case 0:
			switch (MenuObjects[0].transitionDirection)
			{
			case 0:
				if (Time.time >= MenuObjects[0].timeTransitionDelay)
				{
					Vector3 localPosition22 = MenuObjects[0].menuObject.transform.localPosition;
					if (localPosition22.y != MenuObjects[0].onPosition.y)
					{
						MenuObjects[0].menuObject.transform.localPosition = Vector3.Lerp(MenuObjects[0].menuObject.transform.localPosition, MenuObjects[0].onPosition, Time.deltaTime * MenuObjects[0].transitionSpeed);
					}
				}
				break;
			case 1:
				if (Time.time >= MenuObjects[0].timeTransitionDelay)
				{
					Vector3 localPosition21 = MenuObjects[0].menuObject.transform.localPosition;
					if (localPosition21.y != MenuObjects[0].onPosition.y)
					{
						MenuObjects[0].menuObject.transform.localPosition = Vector3.Lerp(MenuObjects[0].menuObject.transform.localPosition, MenuObjects[0].onPosition, Time.deltaTime * MenuObjects[0].transitionSpeed);
					}
				}
				break;
			case 2:
				if (Time.time >= MenuObjects[0].timeTransitionDelay)
				{
					Vector3 localPosition23 = MenuObjects[0].menuObject.transform.localPosition;
					if (localPosition23.x != MenuObjects[0].onPosition.x)
					{
						MenuObjects[0].menuObject.transform.localPosition = Vector3.Lerp(MenuObjects[0].menuObject.transform.localPosition, MenuObjects[0].onPosition, Time.deltaTime * MenuObjects[0].transitionSpeed);
					}
				}
				break;
			case 3:
				if (Time.time >= MenuObjects[0].timeTransitionDelay)
				{
					Vector3 localPosition24 = MenuObjects[0].menuObject.transform.localPosition;
					if (localPosition24.x != MenuObjects[0].onPosition.x)
					{
						MenuObjects[0].menuObject.transform.localPosition = Vector3.Lerp(MenuObjects[0].menuObject.transform.localPosition, MenuObjects[0].onPosition, Time.deltaTime * MenuObjects[0].transitionSpeed);
					}
				}
				break;
			case 4:
				if (Time.time >= MenuObjects[0].timeTransitionDelay && MenuObjects[0].menuObject.transform.localPosition != MenuObjects[0].onPosition)
				{
					MenuObjects[0].menuObject.transform.localPosition = Vector3.Lerp(MenuObjects[0].menuObject.transform.localPosition, MenuObjects[0].onPosition, Time.deltaTime * MenuObjects[0].transitionSpeed);
				}
				break;
			case 5:
				if (Time.time >= MenuObjects[0].timeTransitionDelay && MenuObjects[0].menuObject.transform.localPosition != MenuObjects[0].onPosition)
				{
					MenuObjects[0].menuObject.transform.localPosition = Vector3.Lerp(MenuObjects[0].menuObject.transform.localPosition, MenuObjects[0].onPosition, Time.deltaTime * MenuObjects[0].transitionSpeed);
				}
				break;
			case 6:
				if (Time.time >= MenuObjects[0].timeTransitionDelay && MenuObjects[0].menuObject.transform.localPosition != MenuObjects[0].onPosition)
				{
					MenuObjects[0].menuObject.transform.localPosition = Vector3.Lerp(MenuObjects[0].menuObject.transform.localPosition, MenuObjects[0].onPosition, Time.deltaTime * MenuObjects[0].transitionSpeed);
				}
				break;
			case 7:
				if (Time.time >= MenuObjects[0].timeTransitionDelay && MenuObjects[0].menuObject.transform.localPosition != MenuObjects[0].onPosition)
				{
					MenuObjects[0].menuObject.transform.localPosition = Vector3.Lerp(MenuObjects[0].menuObject.transform.localPosition, MenuObjects[0].onPosition, Time.deltaTime * MenuObjects[0].transitionSpeed);
				}
				break;
			}
			break;
		case 1:
			switch (MenuObjects[0].transitionDirection)
			{
			case 0:
				if (Time.time >= MenuObjects[0].timeTransitionDelay)
				{
					Vector3 localPosition18 = MenuObjects[0].menuObject.transform.localPosition;
					if (localPosition18.y != MenuObjects[0].offPosition.y)
					{
						MenuObjects[0].menuObject.transform.localPosition = Vector3.Lerp(MenuObjects[0].menuObject.transform.localPosition, MenuObjects[0].offPosition, Time.deltaTime * MenuObjects[0].transitionSpeed);
					}
				}
				break;
			case 1:
				if (Time.time >= MenuObjects[0].timeTransitionDelay)
				{
					Vector3 localPosition17 = MenuObjects[0].menuObject.transform.localPosition;
					if (localPosition17.y != MenuObjects[0].offPosition.y)
					{
						MenuObjects[0].menuObject.transform.localPosition = Vector3.Lerp(MenuObjects[0].menuObject.transform.localPosition, MenuObjects[0].offPosition, Time.deltaTime * MenuObjects[0].transitionSpeed);
					}
				}
				break;
			case 2:
				if (Time.time >= MenuObjects[0].timeTransitionDelay)
				{
					Vector3 localPosition19 = MenuObjects[0].menuObject.transform.localPosition;
					if (localPosition19.x != MenuObjects[0].offPosition.x)
					{
						MenuObjects[0].menuObject.transform.localPosition = Vector3.Lerp(MenuObjects[0].menuObject.transform.localPosition, MenuObjects[0].offPosition, Time.deltaTime * MenuObjects[0].transitionSpeed);
					}
				}
				break;
			case 3:
				if (Time.time >= MenuObjects[0].timeTransitionDelay)
				{
					Vector3 localPosition20 = MenuObjects[0].menuObject.transform.localPosition;
					if (localPosition20.x != MenuObjects[0].offPosition.x)
					{
						MenuObjects[0].menuObject.transform.localPosition = Vector3.Lerp(MenuObjects[0].menuObject.transform.localPosition, MenuObjects[0].offPosition, Time.deltaTime * MenuObjects[0].transitionSpeed);
					}
				}
				break;
			case 4:
				if (Time.time >= MenuObjects[0].timeTransitionDelay && MenuObjects[0].menuObject.transform.localPosition != MenuObjects[0].offPosition)
				{
					MenuObjects[0].menuObject.transform.localPosition = Vector3.Lerp(MenuObjects[0].menuObject.transform.localPosition, MenuObjects[0].offPosition, Time.deltaTime * MenuObjects[0].transitionSpeed);
				}
				break;
			case 5:
				if (Time.time >= MenuObjects[0].timeTransitionDelay && MenuObjects[0].menuObject.transform.localPosition != MenuObjects[0].offPosition)
				{
					MenuObjects[0].menuObject.transform.localPosition = Vector3.Lerp(MenuObjects[0].menuObject.transform.localPosition, MenuObjects[0].offPosition, Time.deltaTime * MenuObjects[0].transitionSpeed);
				}
				break;
			case 6:
				if (Time.time >= MenuObjects[0].timeTransitionDelay && MenuObjects[0].menuObject.transform.localPosition != MenuObjects[0].offPosition)
				{
					MenuObjects[0].menuObject.transform.localPosition = Vector3.Lerp(MenuObjects[0].menuObject.transform.localPosition, MenuObjects[0].offPosition, Time.deltaTime * MenuObjects[0].transitionSpeed);
				}
				break;
			case 7:
				if (Time.time >= MenuObjects[0].timeTransitionDelay && MenuObjects[0].menuObject.transform.localPosition != MenuObjects[0].offPosition)
				{
					MenuObjects[0].menuObject.transform.localPosition = Vector3.Lerp(MenuObjects[0].menuObject.transform.localPosition, MenuObjects[0].offPosition, Time.deltaTime * MenuObjects[0].transitionSpeed);
				}
				break;
			}
			break;
		case 2:
			if (MenuObjects[0].menuObject.transform.localPosition != MenuObjects[0].offPosition)
			{
				MenuObjects[0].menuObject.transform.localPosition = MenuObjects[0].offPosition;
			}
			break;
		case 3:
			if (MenuObjects[0].menuObject.transform.localPosition != MenuObjects[0].onPosition)
			{
				MenuObjects[0].menuObject.transform.localPosition = MenuObjects[0].onPosition;
			}
			break;
		case 4:
			switch (MenuObjects[0].transitionDirection)
			{
			case 0:
			{
				Vector3 localPosition16 = MenuObjects[0].menuObject.transform.localPosition;
				if (localPosition16.y != MenuObjects[0].onPosition.y)
				{
					MenuObjects[0].menuObject.transform.localPosition = Vector3.Lerp(MenuObjects[0].menuObject.transform.localPosition, MenuObjects[0].onPosition, Time.deltaTime * MenuObjects[0].transitionSpeed);
				}
				break;
			}
			case 1:
			{
				Vector3 localPosition14 = MenuObjects[0].menuObject.transform.localPosition;
				if (localPosition14.y != MenuObjects[0].onPosition.y)
				{
					MenuObjects[0].menuObject.transform.localPosition = Vector3.Lerp(MenuObjects[0].menuObject.transform.localPosition, MenuObjects[0].onPosition, Time.deltaTime * MenuObjects[0].transitionSpeed);
				}
				break;
			}
			case 2:
			{
				Vector3 localPosition15 = MenuObjects[0].menuObject.transform.localPosition;
				if (localPosition15.x != MenuObjects[0].onPosition.x)
				{
					MenuObjects[0].menuObject.transform.localPosition = Vector3.Lerp(MenuObjects[0].menuObject.transform.localPosition, MenuObjects[0].onPosition, Time.deltaTime * MenuObjects[0].transitionSpeed);
				}
				break;
			}
			case 3:
			{
				Vector3 localPosition13 = MenuObjects[0].menuObject.transform.localPosition;
				if (localPosition13.x != MenuObjects[0].onPosition.x)
				{
					MenuObjects[0].menuObject.transform.localPosition = Vector3.Lerp(MenuObjects[0].menuObject.transform.localPosition, MenuObjects[0].onPosition, Time.deltaTime * MenuObjects[0].transitionSpeed);
				}
				break;
			}
			case 4:
				if (MenuObjects[0].menuObject.transform.localPosition != MenuObjects[0].onPosition)
				{
					MenuObjects[0].menuObject.transform.localPosition = Vector3.Lerp(MenuObjects[0].menuObject.transform.localPosition, MenuObjects[0].onPosition, Time.deltaTime * MenuObjects[0].transitionSpeed);
				}
				break;
			case 5:
				if (MenuObjects[0].menuObject.transform.localPosition != MenuObjects[0].onPosition)
				{
					MenuObjects[0].menuObject.transform.localPosition = Vector3.Lerp(MenuObjects[0].menuObject.transform.localPosition, MenuObjects[0].onPosition, Time.deltaTime * MenuObjects[0].transitionSpeed);
				}
				break;
			case 6:
				if (MenuObjects[0].menuObject.transform.localPosition != MenuObjects[0].onPosition)
				{
					MenuObjects[0].menuObject.transform.localPosition = Vector3.Lerp(MenuObjects[0].menuObject.transform.localPosition, MenuObjects[0].onPosition, Time.deltaTime * MenuObjects[0].transitionSpeed);
				}
				break;
			case 7:
				if (MenuObjects[0].menuObject.transform.localPosition != MenuObjects[0].onPosition)
				{
					MenuObjects[0].menuObject.transform.localPosition = Vector3.Lerp(MenuObjects[0].menuObject.transform.localPosition, MenuObjects[0].onPosition, Time.deltaTime * MenuObjects[0].transitionSpeed);
				}
				break;
			}
			break;
		case 5:
			switch (MenuObjects[0].transitionDirection)
			{
			case 0:
			{
				Vector3 localPosition12 = MenuObjects[0].menuObject.transform.localPosition;
				if (localPosition12.y != MenuObjects[0].offPosition.y)
				{
					MenuObjects[0].menuObject.transform.localPosition = Vector3.Lerp(MenuObjects[0].menuObject.transform.localPosition, MenuObjects[0].offPosition, Time.deltaTime * MenuObjects[0].transitionSpeed);
				}
				break;
			}
			case 1:
			{
				Vector3 localPosition10 = MenuObjects[0].menuObject.transform.localPosition;
				if (localPosition10.y != MenuObjects[0].offPosition.y)
				{
					MenuObjects[0].menuObject.transform.localPosition = Vector3.Lerp(MenuObjects[0].menuObject.transform.localPosition, MenuObjects[0].offPosition, Time.deltaTime * MenuObjects[0].transitionSpeed);
				}
				break;
			}
			case 2:
			{
				Vector3 localPosition11 = MenuObjects[0].menuObject.transform.localPosition;
				if (localPosition11.x != MenuObjects[0].offPosition.x)
				{
					MenuObjects[0].menuObject.transform.localPosition = Vector3.Lerp(MenuObjects[0].menuObject.transform.localPosition, MenuObjects[0].offPosition, Time.deltaTime * MenuObjects[0].transitionSpeed);
				}
				break;
			}
			case 3:
			{
				Vector3 localPosition9 = MenuObjects[0].menuObject.transform.localPosition;
				if (localPosition9.x != MenuObjects[0].offPosition.x)
				{
					MenuObjects[0].menuObject.transform.localPosition = Vector3.Lerp(MenuObjects[0].menuObject.transform.localPosition, MenuObjects[0].offPosition, Time.deltaTime * MenuObjects[0].transitionSpeed);
				}
				break;
			}
			case 4:
				if (MenuObjects[0].menuObject.transform.localPosition != MenuObjects[0].offPosition)
				{
					MenuObjects[0].menuObject.transform.localPosition = Vector3.Lerp(MenuObjects[0].menuObject.transform.localPosition, MenuObjects[0].offPosition, Time.deltaTime * MenuObjects[0].transitionSpeed);
				}
				break;
			case 5:
				if (MenuObjects[0].menuObject.transform.localPosition != MenuObjects[0].offPosition)
				{
					MenuObjects[0].menuObject.transform.localPosition = Vector3.Lerp(MenuObjects[0].menuObject.transform.localPosition, MenuObjects[0].offPosition, Time.deltaTime * MenuObjects[0].transitionSpeed);
				}
				break;
			case 6:
				if (MenuObjects[0].menuObject.transform.localPosition != MenuObjects[0].offPosition)
				{
					MenuObjects[0].menuObject.transform.localPosition = Vector3.Lerp(MenuObjects[0].menuObject.transform.localPosition, MenuObjects[0].offPosition, Time.deltaTime * MenuObjects[0].transitionSpeed);
				}
				break;
			case 7:
				if (MenuObjects[0].menuObject.transform.localPosition != MenuObjects[0].offPosition)
				{
					MenuObjects[0].menuObject.transform.localPosition = Vector3.Lerp(MenuObjects[0].menuObject.transform.localPosition, MenuObjects[0].offPosition, Time.deltaTime * MenuObjects[0].transitionSpeed);
				}
				break;
			}
			break;
		case 6:
			switch (MenuObjects[0].transitionDirection)
			{
			case 0:
				if (Time.time >= MenuObjects[0].timeTransitionDelay)
				{
					Vector3 localPosition6 = MenuObjects[0].menuObject.transform.localPosition;
					if (localPosition6.y != 0f - MenuObjects[0].offPosition.y)
					{
						MenuObjects[0].menuObject.transform.localPosition = Vector3.Lerp(MenuObjects[0].menuObject.transform.localPosition, new Vector3(MenuObjects[0].offPosition.x, 0f - MenuObjects[0].offPosition.y, MenuObjects[0].offPosition.z), Time.deltaTime * MenuObjects[0].transitionSpeed);
					}
				}
				break;
			case 1:
				if (Time.time >= MenuObjects[0].timeTransitionDelay)
				{
					Vector3 localPosition5 = MenuObjects[0].menuObject.transform.localPosition;
					if (localPosition5.y != 0f - MenuObjects[0].offPosition.y)
					{
						MenuObjects[0].menuObject.transform.localPosition = Vector3.Lerp(MenuObjects[0].menuObject.transform.localPosition, new Vector3(MenuObjects[0].offPosition.x, 0f - MenuObjects[0].offPosition.y, MenuObjects[0].offPosition.z), Time.deltaTime * MenuObjects[0].transitionSpeed);
					}
				}
				break;
			case 2:
				if (Time.time >= MenuObjects[0].timeTransitionDelay)
				{
					Vector3 localPosition7 = MenuObjects[0].menuObject.transform.localPosition;
					if (localPosition7.x != 0f - MenuObjects[0].offPosition.x)
					{
						MenuObjects[0].menuObject.transform.localPosition = Vector3.Lerp(MenuObjects[0].menuObject.transform.localPosition, new Vector3(0f - MenuObjects[0].offPosition.x, MenuObjects[0].offPosition.y, MenuObjects[0].offPosition.z), Time.deltaTime * MenuObjects[0].transitionSpeed);
					}
				}
				break;
			case 3:
				if (Time.time >= MenuObjects[0].timeTransitionDelay)
				{
					Vector3 localPosition8 = MenuObjects[0].menuObject.transform.localPosition;
					if (localPosition8.x != 0f - MenuObjects[0].offPosition.x)
					{
						MenuObjects[0].menuObject.transform.localPosition = Vector3.Lerp(MenuObjects[0].menuObject.transform.localPosition, new Vector3(0f - MenuObjects[0].offPosition.x, MenuObjects[0].offPosition.y, MenuObjects[0].offPosition.z), Time.deltaTime * MenuObjects[0].transitionSpeed);
					}
				}
				break;
			case 4:
				if (Time.time >= MenuObjects[0].timeTransitionDelay && MenuObjects[0].menuObject.transform.localPosition != -MenuObjects[0].offPosition)
				{
					MenuObjects[0].menuObject.transform.localPosition = Vector3.Lerp(MenuObjects[0].menuObject.transform.localPosition, -MenuObjects[0].offPosition, Time.deltaTime * MenuObjects[0].transitionSpeed);
				}
				break;
			case 5:
				if (Time.time >= MenuObjects[0].timeTransitionDelay && MenuObjects[0].menuObject.transform.localPosition != -MenuObjects[0].offPosition)
				{
					MenuObjects[0].menuObject.transform.localPosition = Vector3.Lerp(MenuObjects[0].menuObject.transform.localPosition, -MenuObjects[0].offPosition, Time.deltaTime * MenuObjects[0].transitionSpeed);
				}
				break;
			case 6:
				if (Time.time >= MenuObjects[0].timeTransitionDelay && MenuObjects[0].menuObject.transform.localPosition != -MenuObjects[0].offPosition)
				{
					MenuObjects[0].menuObject.transform.localPosition = Vector3.Lerp(MenuObjects[0].menuObject.transform.localPosition, -MenuObjects[0].offPosition, Time.deltaTime * MenuObjects[0].transitionSpeed);
				}
				break;
			case 7:
				if (Time.time >= MenuObjects[0].timeTransitionDelay && MenuObjects[0].menuObject.transform.localPosition != -MenuObjects[0].offPosition)
				{
					MenuObjects[0].menuObject.transform.localPosition = Vector3.Lerp(MenuObjects[0].menuObject.transform.localPosition, -MenuObjects[0].offPosition, Time.deltaTime * MenuObjects[0].transitionSpeed);
				}
				break;
			}
			break;
		case 7:
			switch (MenuObjects[0].transitionDirection)
			{
			case 0:
				if (Time.time >= MenuObjects[0].timeTransitionDelay)
				{
					Vector3 localPosition2 = MenuObjects[0].menuObject.transform.localPosition;
					if (localPosition2.y != MenuObjects[0].offPosition.y)
					{
						MenuObjects[0].menuObject.transform.localPosition = Vector3.Lerp(MenuObjects[0].menuObject.transform.localPosition, MenuObjects[0].offPosition, Time.deltaTime * MenuObjects[0].transitionSpeed);
					}
				}
				break;
			case 1:
				if (Time.time >= MenuObjects[0].timeTransitionDelay)
				{
					Vector3 localPosition = MenuObjects[0].menuObject.transform.localPosition;
					if (localPosition.y != MenuObjects[0].offPosition.y)
					{
						MenuObjects[0].menuObject.transform.localPosition = Vector3.Lerp(MenuObjects[0].menuObject.transform.localPosition, MenuObjects[0].offPosition, Time.deltaTime * MenuObjects[0].transitionSpeed);
					}
				}
				break;
			case 2:
				if (Time.time >= MenuObjects[0].timeTransitionDelay)
				{
					Vector3 localPosition3 = MenuObjects[0].menuObject.transform.localPosition;
					if (localPosition3.x != MenuObjects[0].offPosition.x)
					{
						MenuObjects[0].menuObject.transform.localPosition = Vector3.Lerp(MenuObjects[0].menuObject.transform.localPosition, MenuObjects[0].offPosition, Time.deltaTime * MenuObjects[0].transitionSpeed);
					}
				}
				break;
			case 3:
				if (Time.time >= MenuObjects[0].timeTransitionDelay)
				{
					Vector3 localPosition4 = MenuObjects[0].menuObject.transform.localPosition;
					if (localPosition4.x != MenuObjects[0].offPosition.x)
					{
						MenuObjects[0].menuObject.transform.localPosition = Vector3.Lerp(MenuObjects[0].menuObject.transform.localPosition, MenuObjects[0].offPosition, Time.deltaTime * MenuObjects[0].transitionSpeed);
					}
				}
				break;
			case 4:
				if (Time.time >= MenuObjects[0].timeTransitionDelay && MenuObjects[0].menuObject.transform.localPosition != MenuObjects[0].offPosition)
				{
					MenuObjects[0].menuObject.transform.localPosition = Vector3.Lerp(MenuObjects[0].menuObject.transform.localPosition, MenuObjects[0].offPosition, Time.deltaTime * MenuObjects[0].transitionSpeed);
				}
				break;
			case 5:
				if (Time.time >= MenuObjects[0].timeTransitionDelay && MenuObjects[0].menuObject.transform.localPosition != MenuObjects[0].offPosition)
				{
					MenuObjects[0].menuObject.transform.localPosition = Vector3.Lerp(MenuObjects[0].menuObject.transform.localPosition, MenuObjects[0].offPosition, Time.deltaTime * MenuObjects[0].transitionSpeed);
				}
				break;
			case 6:
				if (Time.time >= MenuObjects[0].timeTransitionDelay && MenuObjects[0].menuObject.transform.localPosition != MenuObjects[0].offPosition)
				{
					MenuObjects[0].menuObject.transform.localPosition = Vector3.Lerp(MenuObjects[0].menuObject.transform.localPosition, MenuObjects[0].offPosition, Time.deltaTime * MenuObjects[0].transitionSpeed);
				}
				break;
			case 7:
				if (Time.time >= MenuObjects[0].timeTransitionDelay && MenuObjects[0].menuObject.transform.localPosition != MenuObjects[0].offPosition)
				{
					MenuObjects[0].menuObject.transform.localPosition = Vector3.Lerp(MenuObjects[0].menuObject.transform.localPosition, MenuObjects[0].offPosition, Time.deltaTime * MenuObjects[0].transitionSpeed);
				}
				break;
			}
			break;
		}
		if (TOGGLE_transitionNumber != 6 && TOGGLE_transitionNumber != 7)
		{
			if (Time.time >= TIME_scriptTimer)
			{
				TOGGLE2_transitionNumber = TOGGLE_transitionNumber;
			}
		}
		else if (TOGGLE_transitionNumber == 6)
		{
			if (Time.time >= TIME_scriptTimer)
			{
				transitionNumber = -6;
			}
		}
		else if (TOGGLE_transitionNumber == 7 && Time.time >= TIME_scriptTimer)
		{
			transitionNumber = -7;
		}
	}

	private void FunctionMenuTransition()
	{
		if (TOGGLE_transitionNumber != transitionNumber)
		{
			if (transitionNumber == 7 || transitionNumber == -5 || transitionNumber == 8)
			{
				REVERSETRANSITION_objectNumber = menuObjectNumber - 1;
				for (int i = 0; i < MenuObjects.Length; i++)
				{
					if (transitionTimer < MenuObjects[i].transitionDelay)
					{
						transitionTimer = MenuObjects[i].transitionDelay;
					}
					MenuObjects[i].timeTransitionDelay = MenuObjects[REVERSETRANSITION_objectNumber].transitionDelay + Time.time;
					REVERSETRANSITION_objectNumber--;
				}
			}
			else if (transitionNumber == 5)
			{
				for (int j = 0; j < MenuObjects.Length; j++)
				{
					MenuObjects[j].timeTransitionDelay = 0f;
				}
			}
			else
			{
				for (int k = 0; k < MenuObjects.Length; k++)
				{
					if (transitionTimer < MenuObjects[k].transitionDelay)
					{
						transitionTimer = MenuObjects[k].transitionDelay;
					}
					MenuObjects[k].timeTransitionDelay = MenuObjects[k].transitionDelay + Time.time;
				}
			}
			if (transitionNumber == 6 || transitionNumber == 7)
			{
				TIME_scriptTimer = transitionTimer + 0.25f + Time.time;
			}
			else
			{
				TIME_scriptTimer = transitionTimer + scriptTimer + Time.time;
			}
			TOGGLE2_transitionNumber = -1;
			TOGGLE_transitionNumber = transitionNumber;
		}
		if (TOGGLE2_transitionNumber == TOGGLE_transitionNumber)
		{
			return;
		}
		switch (TOGGLE_transitionNumber)
		{
		case -7:
			for (int num5 = 0; num5 < MenuObjects.Length; num5++)
			{
				switch (MenuObjects[num5].transitionDirection)
				{
				case 0:
					MenuObjects[num5].menuObject.transform.localPosition = new Vector3(MenuObjects[num5].offPosition.x, 0f - MenuObjects[num5].offPosition.y, MenuObjects[num5].offPosition.z);
					break;
				case 1:
					MenuObjects[num5].menuObject.transform.localPosition = new Vector3(MenuObjects[num5].offPosition.x, 0f - MenuObjects[num5].offPosition.y, MenuObjects[num5].offPosition.z);
					break;
				case 2:
					MenuObjects[num5].menuObject.transform.localPosition = new Vector3(0f - MenuObjects[num5].offPosition.x, MenuObjects[num5].offPosition.y, MenuObjects[num5].offPosition.z);
					break;
				case 3:
					MenuObjects[num5].menuObject.transform.localPosition = new Vector3(0f - MenuObjects[num5].offPosition.x, MenuObjects[num5].offPosition.y, MenuObjects[num5].offPosition.z);
					break;
				case 4:
					MenuObjects[num5].menuObject.transform.localPosition = -MenuObjects[num5].offPosition;
					break;
				case 5:
					MenuObjects[num5].menuObject.transform.localPosition = -MenuObjects[num5].offPosition;
					break;
				case 6:
					MenuObjects[num5].menuObject.transform.localPosition = -MenuObjects[num5].offPosition;
					break;
				case 7:
					MenuObjects[num5].menuObject.transform.localPosition = -MenuObjects[num5].offPosition;
					break;
				}
			}
			transitionNumber = -5;
			break;
		case -6:
			for (int num9 = 0; num9 < MenuObjects.Length; num9++)
			{
				MenuObjects[num9].menuObject.transform.localPosition = MenuObjects[num9].offPosition;
			}
			transitionNumber = 0;
			break;
		case -5:
			for (int num = 0; num < MenuObjects.Length; num++)
			{
				switch (MenuObjects[num].transitionDirection)
				{
				case 0:
					if (Time.time >= MenuObjects[num].timeTransitionDelay)
					{
						Vector3 localPosition10 = MenuObjects[num].menuObject.transform.localPosition;
						if (localPosition10.y != MenuObjects[num].onPosition.y)
						{
							MenuObjects[num].menuObject.transform.localPosition = Vector3.Lerp(MenuObjects[num].menuObject.transform.localPosition, MenuObjects[num].onPosition, Time.deltaTime * MenuObjects[num].transitionSpeed);
						}
					}
					break;
				case 1:
					if (Time.time >= MenuObjects[num].timeTransitionDelay)
					{
						Vector3 localPosition9 = MenuObjects[num].menuObject.transform.localPosition;
						if (localPosition9.y != MenuObjects[num].onPosition.y)
						{
							MenuObjects[num].menuObject.transform.localPosition = Vector3.Lerp(MenuObjects[num].menuObject.transform.localPosition, MenuObjects[num].onPosition, Time.deltaTime * MenuObjects[num].transitionSpeed);
						}
					}
					break;
				case 2:
					if (Time.time >= MenuObjects[num].timeTransitionDelay)
					{
						Vector3 localPosition11 = MenuObjects[num].menuObject.transform.localPosition;
						if (localPosition11.x != MenuObjects[num].onPosition.x)
						{
							MenuObjects[num].menuObject.transform.localPosition = Vector3.Lerp(MenuObjects[num].menuObject.transform.localPosition, MenuObjects[num].onPosition, Time.deltaTime * MenuObjects[num].transitionSpeed);
						}
					}
					break;
				case 3:
					if (Time.time >= MenuObjects[num].timeTransitionDelay)
					{
						Vector3 localPosition12 = MenuObjects[num].menuObject.transform.localPosition;
						if (localPosition12.x != MenuObjects[num].onPosition.x)
						{
							MenuObjects[num].menuObject.transform.localPosition = Vector3.Lerp(MenuObjects[num].menuObject.transform.localPosition, MenuObjects[num].onPosition, Time.deltaTime * MenuObjects[num].transitionSpeed);
						}
					}
					break;
				case 4:
					if (Time.time >= MenuObjects[num].timeTransitionDelay && MenuObjects[num].menuObject.transform.localPosition != MenuObjects[num].onPosition)
					{
						MenuObjects[num].menuObject.transform.localPosition = Vector3.Lerp(MenuObjects[num].menuObject.transform.localPosition, MenuObjects[num].onPosition, Time.deltaTime * MenuObjects[num].transitionSpeed);
					}
					break;
				case 5:
					if (Time.time >= MenuObjects[num].timeTransitionDelay && MenuObjects[num].menuObject.transform.localPosition != MenuObjects[num].onPosition)
					{
						MenuObjects[num].menuObject.transform.localPosition = Vector3.Lerp(MenuObjects[num].menuObject.transform.localPosition, MenuObjects[num].onPosition, Time.deltaTime * MenuObjects[num].transitionSpeed);
					}
					break;
				case 6:
					if (Time.time >= MenuObjects[num].timeTransitionDelay && MenuObjects[num].menuObject.transform.localPosition != MenuObjects[num].onPosition)
					{
						MenuObjects[num].menuObject.transform.localPosition = Vector3.Lerp(MenuObjects[num].menuObject.transform.localPosition, MenuObjects[num].onPosition, Time.deltaTime * MenuObjects[num].transitionSpeed);
					}
					break;
				case 7:
					if (Time.time >= MenuObjects[num].timeTransitionDelay && MenuObjects[num].menuObject.transform.localPosition != MenuObjects[num].onPosition)
					{
						MenuObjects[num].menuObject.transform.localPosition = Vector3.Lerp(MenuObjects[num].menuObject.transform.localPosition, MenuObjects[num].onPosition, Time.deltaTime * MenuObjects[num].transitionSpeed);
					}
					break;
				}
			}
			break;
		case 0:
			for (int num7 = 0; num7 < MenuObjects.Length; num7++)
			{
				switch (MenuObjects[num7].transitionDirection)
				{
				case 0:
					if (Time.time >= MenuObjects[num7].timeTransitionDelay)
					{
						Vector3 localPosition30 = MenuObjects[num7].menuObject.transform.localPosition;
						if (localPosition30.y != MenuObjects[num7].onPosition.y)
						{
							MenuObjects[num7].menuObject.transform.localPosition = Vector3.Lerp(MenuObjects[num7].menuObject.transform.localPosition, MenuObjects[num7].onPosition, Time.deltaTime * MenuObjects[num7].transitionSpeed);
						}
					}
					break;
				case 1:
					if (Time.time >= MenuObjects[num7].timeTransitionDelay)
					{
						Vector3 localPosition29 = MenuObjects[num7].menuObject.transform.localPosition;
						if (localPosition29.y != MenuObjects[num7].onPosition.y)
						{
							MenuObjects[num7].menuObject.transform.localPosition = Vector3.Lerp(MenuObjects[num7].menuObject.transform.localPosition, MenuObjects[num7].onPosition, Time.deltaTime * MenuObjects[num7].transitionSpeed);
						}
					}
					break;
				case 2:
					if (Time.time >= MenuObjects[num7].timeTransitionDelay)
					{
						Vector3 localPosition31 = MenuObjects[num7].menuObject.transform.localPosition;
						if (localPosition31.x != MenuObjects[num7].onPosition.x)
						{
							MenuObjects[num7].menuObject.transform.localPosition = Vector3.Lerp(MenuObjects[num7].menuObject.transform.localPosition, MenuObjects[num7].onPosition, Time.deltaTime * MenuObjects[num7].transitionSpeed);
						}
					}
					break;
				case 3:
					if (Time.time >= MenuObjects[num7].timeTransitionDelay)
					{
						Vector3 localPosition32 = MenuObjects[num7].menuObject.transform.localPosition;
						if (localPosition32.x != MenuObjects[num7].onPosition.x)
						{
							MenuObjects[num7].menuObject.transform.localPosition = Vector3.Lerp(MenuObjects[num7].menuObject.transform.localPosition, MenuObjects[num7].onPosition, Time.deltaTime * MenuObjects[num7].transitionSpeed);
						}
					}
					break;
				case 4:
					if (Time.time >= MenuObjects[num7].timeTransitionDelay && MenuObjects[num7].menuObject.transform.localPosition != MenuObjects[num7].onPosition)
					{
						MenuObjects[num7].menuObject.transform.localPosition = Vector3.Lerp(MenuObjects[num7].menuObject.transform.localPosition, MenuObjects[num7].onPosition, Time.deltaTime * MenuObjects[num7].transitionSpeed);
					}
					break;
				case 5:
					if (Time.time >= MenuObjects[num7].timeTransitionDelay && MenuObjects[num7].menuObject.transform.localPosition != MenuObjects[num7].onPosition)
					{
						MenuObjects[num7].menuObject.transform.localPosition = Vector3.Lerp(MenuObjects[num7].menuObject.transform.localPosition, MenuObjects[num7].onPosition, Time.deltaTime * MenuObjects[num7].transitionSpeed);
					}
					break;
				case 6:
					if (Time.time >= MenuObjects[num7].timeTransitionDelay && MenuObjects[num7].menuObject.transform.localPosition != MenuObjects[num7].onPosition)
					{
						MenuObjects[num7].menuObject.transform.localPosition = Vector3.Lerp(MenuObjects[num7].menuObject.transform.localPosition, MenuObjects[num7].onPosition, Time.deltaTime * MenuObjects[num7].transitionSpeed);
					}
					break;
				case 7:
					if (Time.time >= MenuObjects[num7].timeTransitionDelay && MenuObjects[num7].menuObject.transform.localPosition != MenuObjects[num7].onPosition)
					{
						MenuObjects[num7].menuObject.transform.localPosition = Vector3.Lerp(MenuObjects[num7].menuObject.transform.localPosition, MenuObjects[num7].onPosition, Time.deltaTime * MenuObjects[num7].transitionSpeed);
					}
					break;
				}
			}
			break;
		case 1:
			for (int num3 = 0; num3 < MenuObjects.Length; num3++)
			{
				switch (MenuObjects[num3].transitionDirection)
				{
				case 0:
					if (Time.time >= MenuObjects[num3].timeTransitionDelay)
					{
						Vector3 localPosition18 = MenuObjects[num3].menuObject.transform.localPosition;
						if (localPosition18.y != MenuObjects[num3].offPosition.y)
						{
							MenuObjects[num3].menuObject.transform.localPosition = Vector3.Lerp(MenuObjects[num3].menuObject.transform.localPosition, MenuObjects[num3].offPosition, Time.deltaTime * MenuObjects[num3].transitionSpeed);
						}
					}
					break;
				case 1:
					if (Time.time >= MenuObjects[num3].timeTransitionDelay)
					{
						Vector3 localPosition17 = MenuObjects[num3].menuObject.transform.localPosition;
						if (localPosition17.y != MenuObjects[num3].offPosition.y)
						{
							MenuObjects[num3].menuObject.transform.localPosition = Vector3.Lerp(MenuObjects[num3].menuObject.transform.localPosition, MenuObjects[num3].offPosition, Time.deltaTime * MenuObjects[num3].transitionSpeed);
						}
					}
					break;
				case 2:
					if (Time.time >= MenuObjects[num3].timeTransitionDelay)
					{
						Vector3 localPosition19 = MenuObjects[num3].menuObject.transform.localPosition;
						if (localPosition19.x != MenuObjects[num3].offPosition.x)
						{
							MenuObjects[num3].menuObject.transform.localPosition = Vector3.Lerp(MenuObjects[num3].menuObject.transform.localPosition, MenuObjects[num3].offPosition, Time.deltaTime * MenuObjects[num3].transitionSpeed);
						}
					}
					break;
				case 3:
					if (Time.time >= MenuObjects[num3].timeTransitionDelay)
					{
						Vector3 localPosition20 = MenuObjects[num3].menuObject.transform.localPosition;
						if (localPosition20.x != MenuObjects[num3].offPosition.x)
						{
							MenuObjects[num3].menuObject.transform.localPosition = Vector3.Lerp(MenuObjects[num3].menuObject.transform.localPosition, MenuObjects[num3].offPosition, Time.deltaTime * MenuObjects[num3].transitionSpeed);
						}
					}
					break;
				case 4:
					if (Time.time >= MenuObjects[num3].timeTransitionDelay && MenuObjects[num3].menuObject.transform.localPosition != MenuObjects[num3].offPosition)
					{
						MenuObjects[num3].menuObject.transform.localPosition = Vector3.Lerp(MenuObjects[num3].menuObject.transform.localPosition, MenuObjects[num3].offPosition, Time.deltaTime * MenuObjects[num3].transitionSpeed);
					}
					break;
				case 5:
					if (Time.time >= MenuObjects[num3].timeTransitionDelay && MenuObjects[num3].menuObject.transform.localPosition != MenuObjects[num3].offPosition)
					{
						MenuObjects[num3].menuObject.transform.localPosition = Vector3.Lerp(MenuObjects[num3].menuObject.transform.localPosition, MenuObjects[num3].offPosition, Time.deltaTime * MenuObjects[num3].transitionSpeed);
					}
					break;
				case 6:
					if (Time.time >= MenuObjects[num3].timeTransitionDelay && MenuObjects[num3].menuObject.transform.localPosition != MenuObjects[num3].offPosition)
					{
						MenuObjects[num3].menuObject.transform.localPosition = Vector3.Lerp(MenuObjects[num3].menuObject.transform.localPosition, MenuObjects[num3].offPosition, Time.deltaTime * MenuObjects[num3].transitionSpeed);
					}
					break;
				case 7:
					if (Time.time >= MenuObjects[num3].timeTransitionDelay && MenuObjects[num3].menuObject.transform.localPosition != MenuObjects[num3].offPosition)
					{
						MenuObjects[num3].menuObject.transform.localPosition = Vector3.Lerp(MenuObjects[num3].menuObject.transform.localPosition, MenuObjects[num3].offPosition, Time.deltaTime * MenuObjects[num3].transitionSpeed);
					}
					break;
				}
			}
			break;
		case 2:
			for (int m = 0; m < MenuObjects.Length; m++)
			{
				if (MenuObjects[m].menuObject.transform.localPosition != MenuObjects[m].offPosition)
				{
					MenuObjects[m].menuObject.transform.localPosition = MenuObjects[m].offPosition;
				}
			}
			break;
		case 3:
			for (int num8 = 0; num8 < MenuObjects.Length; num8++)
			{
				if (MenuObjects[num8].menuObject.transform.localPosition != MenuObjects[num8].onPosition)
				{
					MenuObjects[num8].menuObject.transform.localPosition = MenuObjects[num8].onPosition;
				}
			}
			break;
		case 4:
			for (int num6 = 0; num6 < MenuObjects.Length; num6++)
			{
				switch (MenuObjects[num6].transitionDirection)
				{
				case 0:
				{
					Vector3 localPosition28 = MenuObjects[num6].menuObject.transform.localPosition;
					if (localPosition28.y != MenuObjects[num6].onPosition.y)
					{
						MenuObjects[num6].menuObject.transform.localPosition = Vector3.Lerp(MenuObjects[num6].menuObject.transform.localPosition, MenuObjects[num6].onPosition, Time.deltaTime * MenuObjects[num6].transitionSpeed);
					}
					break;
				}
				case 1:
				{
					Vector3 localPosition26 = MenuObjects[num6].menuObject.transform.localPosition;
					if (localPosition26.y != MenuObjects[num6].onPosition.y)
					{
						MenuObjects[num6].menuObject.transform.localPosition = Vector3.Lerp(MenuObjects[num6].menuObject.transform.localPosition, MenuObjects[num6].onPosition, Time.deltaTime * MenuObjects[num6].transitionSpeed);
					}
					break;
				}
				case 2:
				{
					Vector3 localPosition27 = MenuObjects[num6].menuObject.transform.localPosition;
					if (localPosition27.x != MenuObjects[num6].onPosition.x)
					{
						MenuObjects[num6].menuObject.transform.localPosition = Vector3.Lerp(MenuObjects[num6].menuObject.transform.localPosition, MenuObjects[num6].onPosition, Time.deltaTime * MenuObjects[num6].transitionSpeed);
					}
					break;
				}
				case 3:
				{
					Vector3 localPosition25 = MenuObjects[num6].menuObject.transform.localPosition;
					if (localPosition25.x != MenuObjects[num6].onPosition.x)
					{
						MenuObjects[num6].menuObject.transform.localPosition = Vector3.Lerp(MenuObjects[num6].menuObject.transform.localPosition, MenuObjects[num6].onPosition, Time.deltaTime * MenuObjects[num6].transitionSpeed);
					}
					break;
				}
				case 4:
					if (MenuObjects[num6].menuObject.transform.localPosition != MenuObjects[num6].onPosition)
					{
						MenuObjects[num6].menuObject.transform.localPosition = Vector3.Lerp(MenuObjects[num6].menuObject.transform.localPosition, MenuObjects[num6].onPosition, Time.deltaTime * MenuObjects[num6].transitionSpeed);
					}
					break;
				case 5:
					if (MenuObjects[num6].menuObject.transform.localPosition != MenuObjects[num6].onPosition)
					{
						MenuObjects[num6].menuObject.transform.localPosition = Vector3.Lerp(MenuObjects[num6].menuObject.transform.localPosition, MenuObjects[num6].onPosition, Time.deltaTime * MenuObjects[num6].transitionSpeed);
					}
					break;
				case 6:
					if (MenuObjects[num6].menuObject.transform.localPosition != MenuObjects[num6].onPosition)
					{
						MenuObjects[num6].menuObject.transform.localPosition = Vector3.Lerp(MenuObjects[num6].menuObject.transform.localPosition, MenuObjects[num6].onPosition, Time.deltaTime * MenuObjects[num6].transitionSpeed);
					}
					break;
				case 7:
					if (MenuObjects[num6].menuObject.transform.localPosition != MenuObjects[num6].onPosition)
					{
						MenuObjects[num6].menuObject.transform.localPosition = Vector3.Lerp(MenuObjects[num6].menuObject.transform.localPosition, MenuObjects[num6].onPosition, Time.deltaTime * MenuObjects[num6].transitionSpeed);
					}
					break;
				}
			}
			break;
		case 5:
			for (int num4 = 0; num4 < MenuObjects.Length; num4++)
			{
				switch (MenuObjects[num4].transitionDirection)
				{
				case 0:
				{
					Vector3 localPosition24 = MenuObjects[num4].menuObject.transform.localPosition;
					if (localPosition24.y != MenuObjects[num4].offPosition.y)
					{
						MenuObjects[num4].menuObject.transform.localPosition = Vector3.Lerp(MenuObjects[num4].menuObject.transform.localPosition, MenuObjects[num4].offPosition, Time.deltaTime * MenuObjects[num4].transitionSpeed);
					}
					break;
				}
				case 1:
				{
					Vector3 localPosition22 = MenuObjects[num4].menuObject.transform.localPosition;
					if (localPosition22.y != MenuObjects[num4].offPosition.y)
					{
						MenuObjects[num4].menuObject.transform.localPosition = Vector3.Lerp(MenuObjects[num4].menuObject.transform.localPosition, MenuObjects[num4].offPosition, Time.deltaTime * MenuObjects[num4].transitionSpeed);
					}
					break;
				}
				case 2:
				{
					Vector3 localPosition23 = MenuObjects[num4].menuObject.transform.localPosition;
					if (localPosition23.x != MenuObjects[num4].offPosition.x)
					{
						MenuObjects[num4].menuObject.transform.localPosition = Vector3.Lerp(MenuObjects[num4].menuObject.transform.localPosition, MenuObjects[num4].offPosition, Time.deltaTime * MenuObjects[num4].transitionSpeed);
					}
					break;
				}
				case 3:
				{
					Vector3 localPosition21 = MenuObjects[num4].menuObject.transform.localPosition;
					if (localPosition21.x != MenuObjects[num4].offPosition.x)
					{
						MenuObjects[num4].menuObject.transform.localPosition = Vector3.Lerp(MenuObjects[num4].menuObject.transform.localPosition, MenuObjects[num4].offPosition, Time.deltaTime * MenuObjects[num4].transitionSpeed);
					}
					break;
				}
				case 4:
					if (MenuObjects[num4].menuObject.transform.localPosition != MenuObjects[num4].offPosition)
					{
						MenuObjects[num4].menuObject.transform.localPosition = Vector3.Lerp(MenuObjects[num4].menuObject.transform.localPosition, MenuObjects[num4].offPosition, Time.deltaTime * MenuObjects[num4].transitionSpeed);
					}
					break;
				case 5:
					if (MenuObjects[num4].menuObject.transform.localPosition != MenuObjects[num4].offPosition)
					{
						MenuObjects[num4].menuObject.transform.localPosition = Vector3.Lerp(MenuObjects[num4].menuObject.transform.localPosition, MenuObjects[num4].offPosition, Time.deltaTime * MenuObjects[num4].transitionSpeed);
					}
					break;
				case 6:
					if (MenuObjects[num4].menuObject.transform.localPosition != MenuObjects[num4].offPosition)
					{
						MenuObjects[num4].menuObject.transform.localPosition = Vector3.Lerp(MenuObjects[num4].menuObject.transform.localPosition, MenuObjects[num4].offPosition, Time.deltaTime * MenuObjects[num4].transitionSpeed);
					}
					break;
				case 7:
					if (MenuObjects[num4].menuObject.transform.localPosition != MenuObjects[num4].offPosition)
					{
						MenuObjects[num4].menuObject.transform.localPosition = Vector3.Lerp(MenuObjects[num4].menuObject.transform.localPosition, MenuObjects[num4].offPosition, Time.deltaTime * MenuObjects[num4].transitionSpeed);
					}
					break;
				}
			}
			break;
		case 6:
			for (int num2 = 0; num2 < MenuObjects.Length; num2++)
			{
				switch (MenuObjects[num2].transitionDirection)
				{
				case 0:
					if (Time.time >= MenuObjects[num2].timeTransitionDelay)
					{
						Vector3 localPosition14 = MenuObjects[num2].menuObject.transform.localPosition;
						if (localPosition14.y != 0f - MenuObjects[num2].offPosition.y)
						{
							MenuObjects[num2].menuObject.transform.localPosition = Vector3.Lerp(MenuObjects[num2].menuObject.transform.localPosition, new Vector3(MenuObjects[num2].offPosition.x, 0f - MenuObjects[num2].offPosition.y, MenuObjects[num2].offPosition.z), Time.deltaTime * MenuObjects[num2].transitionSpeed);
						}
					}
					break;
				case 1:
					if (Time.time >= MenuObjects[num2].timeTransitionDelay)
					{
						Vector3 localPosition13 = MenuObjects[num2].menuObject.transform.localPosition;
						if (localPosition13.y != 0f - MenuObjects[num2].offPosition.y)
						{
							MenuObjects[num2].menuObject.transform.localPosition = Vector3.Lerp(MenuObjects[num2].menuObject.transform.localPosition, new Vector3(MenuObjects[num2].offPosition.x, 0f - MenuObjects[num2].offPosition.y, MenuObjects[num2].offPosition.z), Time.deltaTime * MenuObjects[num2].transitionSpeed);
						}
					}
					break;
				case 2:
					if (Time.time >= MenuObjects[num2].timeTransitionDelay)
					{
						Vector3 localPosition15 = MenuObjects[num2].menuObject.transform.localPosition;
						if (localPosition15.x != 0f - MenuObjects[num2].offPosition.x)
						{
							MenuObjects[num2].menuObject.transform.localPosition = Vector3.Lerp(MenuObjects[num2].menuObject.transform.localPosition, new Vector3(0f - MenuObjects[num2].offPosition.x, MenuObjects[num2].offPosition.y, MenuObjects[num2].offPosition.z), Time.deltaTime * MenuObjects[num2].transitionSpeed);
						}
					}
					break;
				case 3:
					if (Time.time >= MenuObjects[num2].timeTransitionDelay)
					{
						Vector3 localPosition16 = MenuObjects[num2].menuObject.transform.localPosition;
						if (localPosition16.x != 0f - MenuObjects[num2].offPosition.x)
						{
							MenuObjects[num2].menuObject.transform.localPosition = Vector3.Lerp(MenuObjects[num2].menuObject.transform.localPosition, new Vector3(0f - MenuObjects[num2].offPosition.x, MenuObjects[num2].offPosition.y, MenuObjects[num2].offPosition.z), Time.deltaTime * MenuObjects[num2].transitionSpeed);
						}
					}
					break;
				case 4:
					if (Time.time >= MenuObjects[num2].timeTransitionDelay && MenuObjects[num2].menuObject.transform.localPosition != -MenuObjects[num2].offPosition)
					{
						MenuObjects[num2].menuObject.transform.localPosition = Vector3.Lerp(MenuObjects[num2].menuObject.transform.localPosition, -MenuObjects[num2].offPosition, Time.deltaTime * MenuObjects[num2].transitionSpeed);
					}
					break;
				case 5:
					if (Time.time >= MenuObjects[num2].timeTransitionDelay && MenuObjects[num2].menuObject.transform.localPosition != -MenuObjects[num2].offPosition)
					{
						MenuObjects[num2].menuObject.transform.localPosition = Vector3.Lerp(MenuObjects[num2].menuObject.transform.localPosition, -MenuObjects[num2].offPosition, Time.deltaTime * MenuObjects[num2].transitionSpeed);
					}
					break;
				case 6:
					if (Time.time >= MenuObjects[num2].timeTransitionDelay && MenuObjects[num2].menuObject.transform.localPosition != -MenuObjects[num2].offPosition)
					{
						MenuObjects[num2].menuObject.transform.localPosition = Vector3.Lerp(MenuObjects[num2].menuObject.transform.localPosition, -MenuObjects[num2].offPosition, Time.deltaTime * MenuObjects[num2].transitionSpeed);
					}
					break;
				case 7:
					if (Time.time >= MenuObjects[num2].timeTransitionDelay && MenuObjects[num2].menuObject.transform.localPosition != -MenuObjects[num2].offPosition)
					{
						MenuObjects[num2].menuObject.transform.localPosition = Vector3.Lerp(MenuObjects[num2].menuObject.transform.localPosition, -MenuObjects[num2].offPosition, Time.deltaTime * MenuObjects[num2].transitionSpeed);
					}
					break;
				}
			}
			break;
		case 7:
			for (int n = 0; n < MenuObjects.Length; n++)
			{
				switch (MenuObjects[n].transitionDirection)
				{
				case 0:
					if (Time.time >= MenuObjects[n].timeTransitionDelay)
					{
						Vector3 localPosition6 = MenuObjects[n].menuObject.transform.localPosition;
						if (localPosition6.y != MenuObjects[n].offPosition.y)
						{
							MenuObjects[n].menuObject.transform.localPosition = Vector3.Lerp(MenuObjects[n].menuObject.transform.localPosition, MenuObjects[n].offPosition, Time.deltaTime * MenuObjects[n].transitionSpeed);
						}
					}
					break;
				case 1:
					if (Time.time >= MenuObjects[n].timeTransitionDelay)
					{
						Vector3 localPosition5 = MenuObjects[n].menuObject.transform.localPosition;
						if (localPosition5.y != MenuObjects[n].offPosition.y)
						{
							MenuObjects[n].menuObject.transform.localPosition = Vector3.Lerp(MenuObjects[n].menuObject.transform.localPosition, MenuObjects[n].offPosition, Time.deltaTime * MenuObjects[n].transitionSpeed);
						}
					}
					break;
				case 2:
					if (Time.time >= MenuObjects[n].timeTransitionDelay)
					{
						Vector3 localPosition7 = MenuObjects[n].menuObject.transform.localPosition;
						if (localPosition7.x != MenuObjects[n].offPosition.x)
						{
							MenuObjects[n].menuObject.transform.localPosition = Vector3.Lerp(MenuObjects[n].menuObject.transform.localPosition, MenuObjects[n].offPosition, Time.deltaTime * MenuObjects[n].transitionSpeed);
						}
					}
					break;
				case 3:
					if (Time.time >= MenuObjects[n].timeTransitionDelay)
					{
						Vector3 localPosition8 = MenuObjects[n].menuObject.transform.localPosition;
						if (localPosition8.x != MenuObjects[n].offPosition.x)
						{
							MenuObjects[n].menuObject.transform.localPosition = Vector3.Lerp(MenuObjects[n].menuObject.transform.localPosition, MenuObjects[n].offPosition, Time.deltaTime * MenuObjects[n].transitionSpeed);
						}
					}
					break;
				case 4:
					if (Time.time >= MenuObjects[n].timeTransitionDelay && MenuObjects[n].menuObject.transform.localPosition != MenuObjects[n].offPosition)
					{
						MenuObjects[n].menuObject.transform.localPosition = Vector3.Lerp(MenuObjects[n].menuObject.transform.localPosition, MenuObjects[n].offPosition, Time.deltaTime * MenuObjects[n].transitionSpeed);
					}
					break;
				case 5:
					if (Time.time >= MenuObjects[n].timeTransitionDelay && MenuObjects[n].menuObject.transform.localPosition != MenuObjects[n].offPosition)
					{
						MenuObjects[n].menuObject.transform.localPosition = Vector3.Lerp(MenuObjects[n].menuObject.transform.localPosition, MenuObjects[n].offPosition, Time.deltaTime * MenuObjects[n].transitionSpeed);
					}
					break;
				case 6:
					if (Time.time >= MenuObjects[n].timeTransitionDelay && MenuObjects[n].menuObject.transform.localPosition != MenuObjects[n].offPosition)
					{
						MenuObjects[n].menuObject.transform.localPosition = Vector3.Lerp(MenuObjects[n].menuObject.transform.localPosition, MenuObjects[n].offPosition, Time.deltaTime * MenuObjects[n].transitionSpeed);
					}
					break;
				case 7:
					if (Time.time >= MenuObjects[n].timeTransitionDelay && MenuObjects[n].menuObject.transform.localPosition != MenuObjects[n].offPosition)
					{
						MenuObjects[n].menuObject.transform.localPosition = Vector3.Lerp(MenuObjects[n].menuObject.transform.localPosition, MenuObjects[n].offPosition, Time.deltaTime * MenuObjects[n].transitionSpeed);
					}
					break;
				}
			}
			break;
		case 8:
			for (int l = 0; l < MenuObjects.Length; l++)
			{
				switch (MenuObjects[l].transitionDirection)
				{
				case 0:
					if (Time.time >= MenuObjects[l].timeTransitionDelay)
					{
						Vector3 localPosition2 = MenuObjects[l].menuObject.transform.localPosition;
						if (localPosition2.y != MenuObjects[l].offPosition.y)
						{
							MenuObjects[l].menuObject.transform.localPosition = Vector3.Lerp(MenuObjects[l].menuObject.transform.localPosition, MenuObjects[l].offPosition, Time.deltaTime * MenuObjects[l].transitionSpeed);
						}
					}
					break;
				case 1:
					if (Time.time >= MenuObjects[l].timeTransitionDelay)
					{
						Vector3 localPosition = MenuObjects[l].menuObject.transform.localPosition;
						if (localPosition.y != MenuObjects[l].offPosition.y)
						{
							MenuObjects[l].menuObject.transform.localPosition = Vector3.Lerp(MenuObjects[l].menuObject.transform.localPosition, MenuObjects[l].offPosition, Time.deltaTime * MenuObjects[l].transitionSpeed);
						}
					}
					break;
				case 2:
					if (Time.time >= MenuObjects[l].timeTransitionDelay)
					{
						Vector3 localPosition3 = MenuObjects[l].menuObject.transform.localPosition;
						if (localPosition3.x != MenuObjects[l].offPosition.x)
						{
							MenuObjects[l].menuObject.transform.localPosition = Vector3.Lerp(MenuObjects[l].menuObject.transform.localPosition, MenuObjects[l].offPosition, Time.deltaTime * MenuObjects[l].transitionSpeed);
						}
					}
					break;
				case 3:
					if (Time.time >= MenuObjects[l].timeTransitionDelay)
					{
						Vector3 localPosition4 = MenuObjects[l].menuObject.transform.localPosition;
						if (localPosition4.x != MenuObjects[l].offPosition.x)
						{
							MenuObjects[l].menuObject.transform.localPosition = Vector3.Lerp(MenuObjects[l].menuObject.transform.localPosition, MenuObjects[l].offPosition, Time.deltaTime * MenuObjects[l].transitionSpeed);
						}
					}
					break;
				case 4:
					if (Time.time >= MenuObjects[l].timeTransitionDelay && MenuObjects[l].menuObject.transform.localPosition != MenuObjects[l].offPosition)
					{
						MenuObjects[l].menuObject.transform.localPosition = Vector3.Lerp(MenuObjects[l].menuObject.transform.localPosition, MenuObjects[l].offPosition, Time.deltaTime * MenuObjects[l].transitionSpeed);
					}
					break;
				case 5:
					if (Time.time >= MenuObjects[l].timeTransitionDelay && MenuObjects[l].menuObject.transform.localPosition != MenuObjects[l].offPosition)
					{
						MenuObjects[l].menuObject.transform.localPosition = Vector3.Lerp(MenuObjects[l].menuObject.transform.localPosition, MenuObjects[l].offPosition, Time.deltaTime * MenuObjects[l].transitionSpeed);
					}
					break;
				case 6:
					if (Time.time >= MenuObjects[l].timeTransitionDelay && MenuObjects[l].menuObject.transform.localPosition != MenuObjects[l].offPosition)
					{
						MenuObjects[l].menuObject.transform.localPosition = Vector3.Lerp(MenuObjects[l].menuObject.transform.localPosition, MenuObjects[l].offPosition, Time.deltaTime * MenuObjects[l].transitionSpeed);
					}
					break;
				case 7:
					if (Time.time >= MenuObjects[l].timeTransitionDelay && MenuObjects[l].menuObject.transform.localPosition != MenuObjects[l].offPosition)
					{
						MenuObjects[l].menuObject.transform.localPosition = Vector3.Lerp(MenuObjects[l].menuObject.transform.localPosition, MenuObjects[l].offPosition, Time.deltaTime * MenuObjects[l].transitionSpeed);
					}
					break;
				}
			}
			break;
		}
		if (TOGGLE_transitionNumber != 6 && TOGGLE_transitionNumber != 7)
		{
			if (Time.time >= TIME_scriptTimer)
			{
				TOGGLE2_transitionNumber = TOGGLE_transitionNumber;
			}
		}
		else if (TOGGLE_transitionNumber == 6)
		{
			if (Time.time >= TIME_scriptTimer)
			{
				transitionNumber = -6;
			}
		}
		else if (TOGGLE_transitionNumber == 7 && Time.time >= TIME_scriptTimer)
		{
			transitionNumber = -7;
		}
	}
}
