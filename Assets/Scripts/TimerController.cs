﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerController : MonoBehaviour
{
	// Start is called before the first frame update
	public Text timerText;

	public float totalTime;
	int seconds;

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		totalTime -= Time.deltaTime;
		seconds = (int)totalTime;
		timerText.text = seconds.ToString();

	}
}
