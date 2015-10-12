﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MonoBehaviour {

	private int maxHealth = 100;
	private int curHealth = 100;
	private int healthBarHeight = 20;

	public Text healthBarText;
	public Image healthBar;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	}
	
	private void updateHealthBar () {
		healthBarText.text = curHealth + " / " + maxHealth;
		healthBar.rectTransform.sizeDelta = new Vector2 (curHealth * 3, healthBarHeight);

		if (curHealth >= 60) 
		{
			healthBar.color = new Color32 (68, 223, 123, 166);
			healthBarText.color = new Color32 (68, 223, 123, 255);
		}
		else if (curHealth < 60 && curHealth >= 30) 
		{
			healthBar.color = new Color32 (223, 146, 68, 166);
			healthBarText.color = new Color32 (223, 146, 68, 255);
		} 
		else if (curHealth < 30) 
		{
			healthBar.color = new Color32 (223, 68, 68, 166);
			healthBarText.color = new Color32 (223, 68, 68, 255);
		}
	}

	public void takeDamage (int damageAmount) {
		if (damageAmount < 0) {
			damageAmount *= -1;
		}

		if ((curHealth - damageAmount) < 0) {
			curHealth = 0;
		} else {
			curHealth = curHealth - damageAmount;
		}
		updateHealthBar ();
	}

	public void addHealth (int healAmount) {
		if (healAmount < 0) {
			healAmount *= -1;
		}

		if ((curHealth + healAmount) > 100) {
			curHealth = 100;
		} else {
			curHealth = curHealth + healAmount;
		}
	}

	public void setCurHealth (int health) {
		if (health < 0) {
			health *= -1;
		}

		curHealth = health;
	}

	public int getCurHealth () {
		return curHealth;
	}
}
