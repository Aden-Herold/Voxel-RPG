using UnityEngine;
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

	public void takeDamage (int damageAmount) {
		if ((curHealth - damageAmount) < 0) {
			curHealth = 0;
		} else {
			curHealth = curHealth - damageAmount;
		}
		updateHealthBar ();
	}

	public int getCurHealth () {
		return curHealth;
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
}
