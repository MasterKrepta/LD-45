

public interface IHasHealth
{
    float MaxHealth { get; }
    float CurrentHealth { get;  }
    void TakeDamage(float dmg);
    
    void Die();
    
}

