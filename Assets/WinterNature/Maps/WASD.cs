﻿using UnityEngine;
using System.Collections;

public class WASD : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	
	public float speed = 5.0f;
	void Update()
	{
		if(Input.GetKey(KeyCode.D))
		{
			transform.Translate(new Vector3(speed * Time.deltaTime,0,0));
		}
		if(Input.GetKey(KeyCode.A))
		{
			transform.Translate(new Vector3(-speed * Time.deltaTime,0,0));
		}
		if(Input.GetKey(KeyCode.E))
		{
			transform.Translate(new Vector3(0,-speed * Time.deltaTime,0));
		}
		if(Input.GetKey(KeyCode.Q))
		{
			transform.Translate(new Vector3(0,speed * Time.deltaTime,0));
		}
		if(Input.GetKey(KeyCode.S))
		{
			transform.Translate(new Vector3(0,0,-speed * Time.deltaTime));
		}
		if(Input.GetKey(KeyCode.W))
		{
			transform.Translate(new Vector3(0,0,speed * Time.deltaTime));
		}
	}
}
