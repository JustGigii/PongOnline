using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Script;

public class LeftControl : MonoBehaviour
{
	Rigidbody2D Body;
	public static string Command;
	// Use this for initialization
	void Start()
	{
		Body = GetComponent<Rigidbody2D>();
		Command = "";
	}

	// Update is called once per frame
	void Update()
	{
		print(Command + " Left");
			switch (Command)
			{
				case "up":
					Body.velocity = new Vector2(0f, 1f * PongRight.Speed);

					break;
				case "down":
					Body.velocity = new Vector2(0f, -1f * PongRight.Speed);

					break;
				case "stay":
					Body.velocity = new Vector2(0f, 0f);
					break;
			}
	}

}
