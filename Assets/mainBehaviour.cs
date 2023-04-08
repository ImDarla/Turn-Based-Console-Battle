using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainBehaviour : MonoBehaviour
{
	private static int playerHP = 10;
	private static bool defendFlag = false;
	private static int mpcHP = 10;
	private static bool charge = false;

	void exit()
	{
		Application.Quit();
	}

	void attack(bool player = false)
	{
		if(player) 
		{
			mpcHP -= Random.Range(1, 2);
			if(mpcHP<=0)
			{
				Debug.Log("you win");
				exit();
			}
		}
		else
		{
			if(charge == false)
			{
				if (Random.value > 0.35F && !defendFlag)
				{
					playerHP -= Random.Range(2, 4);
					if(playerHP<=0) 
					{
						Debug.Log("the mcp wins");
						exit();
					}
				}
				else
				{
					Debug.Log("MCP is charging enemy");
					charge = true;
				}
			}
			else
			{
				Debug.LogError("you get obliterated");
				exit();
			}
			
		}
	}

	void heal()
	{
		if(playerHP<10)
		{
			playerHP = ((playerHP == 9) ? 10 :  playerHP+ 2);
		}
	}

	void defend()
	{
		defendFlag = true;    
	}

	

	// Start is called before the first frame update
	void Start()
	{
		Debug.Log("press A for Attack, H for Heal and D for Defend");
		Debug.Log("draw");
	}

	// Update is called once per frame
	void Update()
	{
		defendFlag = false;
		if(Input.GetKey(KeyCode.A))
		{
			attack(true);
			attack(false);
		}

		if(Input.GetKey(KeyCode.H))
		{
			heal();
			attack(false);
		}

		if(Input.GetKey(KeyCode.D))
		{
			defend();
			attack(false);

		}
		
	}
}
