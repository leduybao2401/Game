
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Damgeable : MonoBehaviour
{
    public UnityEvent<int, Vector2> damagableHit;
    public UnityEvent damageableDeath;
    public GameOver gameManager;
    public UnityEvent<int, int> healthChange;
	Animator animator;
	[SerializeField]
	private int _maxHealth=100;

	public int MaxHealth
    {
        get
        {
            return _maxHealth;
        }
        set
        {
            _maxHealth = value;
        }
    }
	[SerializeField]
	private int _health = 100;
    public int Health
    {
        get
        {
            return _health;
        }
        set
        {
            _health = value;
            healthChange?.Invoke(_health, MaxHealth);
            if(_health <= 0)
            {
                IsAlive = false;
				//Time.timeScale = 0;
				//gameObject.SetActive(false);
                gameManager.gameOver();

			}
        }
    }
	[SerializeField]
	private bool _isAlive = true;
	[SerializeField]
	private bool isInvincible = false;

	//public bool IsHit { get
 //       {
 //           return animator.GetBool(AnimationStrings.isHit);
 //       }
 //       private set {
 //           animator.SetBool(AnimationStrings.isHit, value);
 //       } }

	private float timeSinceHit = 0;
    public float invincibilityTime = 0.25f;
	public bool IsAlive { get
        {
            return _isAlive;

		} private set
        {
            _isAlive = value;
            animator.SetBool(AnimationStrings.isAlive, value);
            Debug.Log("IsAlive set " + value);
            if (value == false)
            {
                damageableDeath.Invoke();
            }
        } }

	public bool LocVelocity
	{
		get
		{
			return animator.GetBool(AnimationStrings.lockVelocity);
		}
		set
		{
			animator.SetBool(AnimationStrings.lockVelocity, value);
		}
	}

	private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        if(isInvincible)
         {
            if (timeSinceHit > invincibilityTime)
            {
                isInvincible = false;
                timeSinceHit = 0;

			}
            timeSinceHit += Time.deltaTime;
		}
        //Hit(1);
    }
    public bool Hit(int damage, Vector2 knockback)
    {
        if(IsAlive && !isInvincible)
        {
            Health -= damage;
            isInvincible = true;
            //bi trung don danh
            //IsHit = true;
            animator.SetTrigger(AnimationStrings.hitTrigger);
			LocVelocity = true;
            damagableHit?.Invoke(damage, knockback); //kiem tra co rong hay khong

            //18
            CharacterEvents.characterDameged.Invoke(gameObject, damage);
            return true;

        }
        return false;
    }

    //return whether the character was heal or not
    public bool Heal(int healthRestore)
    {
        if (IsAlive && Health < MaxHealth)
        {
            int maxHeal = Mathf.Max(MaxHealth - Health, 0);

            int actuaHeal = Mathf.Min(maxHeal, healthRestore);
            Health += actuaHeal;
            CharacterEvents.characterHealed(gameObject, actuaHeal);
            return true;
        }
        return false;
    }
}
