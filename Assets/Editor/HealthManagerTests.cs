using NUnit.Framework;

[TestFixture]
public class HealthManagerTests {

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
}
