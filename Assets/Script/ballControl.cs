using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Script;
public class ballControl : MonoBehaviour {
	public float SpeedX;
	float SpeedY;
	bool IsReset;
	public static bool isStart;
	Rigidbody2D ball;
	public float targetTime = 2.0f;
	float SavedSpeed;
	public static string Side;
	public static string[] Recv;
	// Use this for initialization
	void Start () {
		ball = GetComponent<Rigidbody2D>();
		SpeedX = -SpeedX;
		SavedSpeed = SpeedX;
		SpeedY = 0.0f;
		IsReset = false;
		isStart = false;
		Socket.Start();
		Socket.Send("GiveSide,null");
		Side = Socket.Recv();
		string Command= null;
	}

	// Update is called once per frame
	void Update () {
		if (!isStart)
		{

			Socket.Send("start," + Side);
			isStart = (Socket.Recv()== "True");
		}
		else
		{
			PongControl();
			RecvControl();
			ball.velocity = new Vector2(SpeedX, SpeedY);
			if (IsReset == true)
			{
				this.transform.position = new Vector3(0f, 0f);
				targetTime -= Time.deltaTime;
				if (targetTime <= 0.0f)
				{
					SpeedX = SavedSpeed;
					IsReset = false;
					targetTime = 2.0f;
				}
			}
		}
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		switch (other.tag)
		{
			case "Pong":
				SpeedX = -SpeedX;
				if (SpeedY < 0)
					SpeedY--;
				else
					SpeedY += 5f;
				break;
			case "UpDown":
				SpeedY = -SpeedY;
				break;
			case "Left Win":
				LeftScore.Score++;
				SpeedX = 0;
				SpeedY = 0;
				IsReset = true;
				break;
			case "Right Win":
				RightScore.Score++;
				SpeedX = 0;
				SpeedY = 0;
				IsReset = true;
				break;
		}
	}
	private void PongControl()
	{
			float input = Input.GetAxis("Vertical");
				if (input <-0.5f)
					Socket.Send("down," + Side);
				else if (input > 0.5f)
				Socket.Send("up," + Side);
				else
					Socket.Send("stay," + Side);
	}
	private void RecvControl()
	{
		for (int i = 0; i < 2; i++)
		{


			Recv = Socket.Recv().Split(',');
			string Command = Recv[0];
			if (Recv.Length > 1)
			{
				string Side = Recv[1];
				if (Command != "stay")
					print(Recv[0] + " " + Recv[1]);
				if (Side == "Left")
				{
					LeftControl.Command = Command;
				}
				else if(Side == "Right")
					PongRight.Command = Command;
			}
		}
	}
}
