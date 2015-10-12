using NUnit.Framework;

[TestFixture]
public class HealthManagerTests {

	[Test]
	public void SetHealth_PositiveAmount_Player()
	{
		var health = new Player ();
		health.setCurHealth (20);

		Assert.AreEqual (20, health.getCurHealth ());
	}

	[Test]
	public void SetHealth_NegativeAmount_Player() 
	{
		var health = new Player ();
		health.setCurHealth (-20);

		Assert.AreEqual (20, health.getCurHealth ());
	}

	[Test]
	public void TakeDamage_PositiveAmount_HealthUpdated() 
	{
		var health = new Player ();
		health.setCurHealth (50);

		health.takeDamage (20);

		Assert.AreEqual(30, health.getCurHealth());
	}

	[Test]
	public void TakeDamage_NegativeAmount_HealthUpdated()
	{
		var health = new Player ();
		health.setCurHealth (40);

		health.takeDamage(-30);

		Assert.AreEqual (10, health.getCurHealth());
	}

	[Test]
	public void AddHealth_PositiveAmount_HealthUpdated() 
	{
		var health = new Player ();
		health.setCurHealth (50);
		
		health.addHealth (20);
		
		Assert.AreEqual(70, health.getCurHealth());
	}
	
	[Test]
	public void AddHealth_NegativeAmount_HealthUpdated()
	{
		var health = new Player ();
		health.setCurHealth (40);
		
		health.addHealth(-30);
		
		Assert.AreEqual (70, health.getCurHealth());
	}

	[Test]
	public void SetHealth_PositiveAmount_Enemy()
	{
		var health = new fleshgolem_AI ();
		health.setCurHealth (20);
		
		Assert.AreEqual (20, health.getCurHealth ());
	}
	
	[Test]
	public void SetHealth_NegativeAmount_Enemy() 
	{
		var health = new fleshgolem_AI ();
		health.setCurHealth (-20);
		
		Assert.AreEqual (20, health.getCurHealth ());
	}

	[Test]
	public void Enemy_TakeDamage_PositiveAmount_HealthUpdated() 
	{
		var health = new fleshgolem_AI ();
		health.takeDamage (50);

		Assert.AreEqual (50, health.getCurHealth ());
	}

	[Test]
	public void Enemy_TakeDamage_NegativeAmount_HealthUpdated() 
	{
		var health = new fleshgolem_AI ();
		health.takeDamage (-50);
		
		Assert.AreEqual (50, health.getCurHealth ());
	}

	[Test]
	public void Enemy_AddHealth_PositiveAmount_HealthUpdated() 
	{
		var health = new fleshgolem_AI ();
		health.setCurHealth (50);
		
		health.addHealth (20);
		
		Assert.AreEqual(70, health.getCurHealth());
	}
	
	[Test]
	public void Enemy_AddHealth_NegativeAmount_HealthUpdated()
	{
		var health = new fleshgolem_AI ();
		health.setCurHealth (40);
		
		health.addHealth(-30);
		
		Assert.AreEqual (70, health.getCurHealth());
	}
}
