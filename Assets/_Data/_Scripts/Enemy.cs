using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    int currentHp = 100;
    int maxHp = 100;
    float weight = 2.5f;
    bool isDead = true;
    bool isBoss = true;

    EnemyHead head1 = new EnemyHead();
    EnemyHead head2 = new EnemyHead();
    //head1, head2 là đối tượng và EnemyHead là kiểu dữ liệu của đối tượng.
    //Vì head1, head2 được tạo ra bởi class nên được xem là đối tượng (Object)
    EnemyHeart heart = new EnemyHeart();

    public virtual void Moving()
    {
        //Write move logic here
        string logMessage = this.GetName() + " Moving";
        Debug.Log(logMessage);
    }

    public abstract string GetName();

    public virtual int GetCurrentHp()
    {
        return this.currentHp;
    }

    public virtual void SetHp(int newHp)
    {
        this.currentHp = newHp;
    }

    float GetWeight()
    {
        return this.weight;
    }

    /// <summary>
    /// Hàm này dùng để xác định trạng thái chết của enemy
    /// </summary>
    /// <returns>bool isDead</returns>
    public virtual bool IsDead()
    {
        if(this.currentHp > 0) this.isDead = false;
        else this.isDead = true;

        return this.isDead;
    }

    bool IsBoss()
    {
        return this.isBoss;
    }

        
}
