using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Assets.Script;


public class PongRight : MonoBehaviour
{
	public static float Speed = 20;
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
		print(Command + " Right");
		switch (Command)
		{
			case "up":
				Body.velocity = new Vector2(0f, 1f * Speed);
				print("up");
				break;
			case "down":
				print("down");
				Body.velocity = new Vector2(0f, -1f * Speed);
				break;
			case "stay":
				Body.velocity = new Vector2(0f, 0f);
				break;
		}
	}
}
	
