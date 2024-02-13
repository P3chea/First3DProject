using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    [SerializeField] private float maxHealth;
    private float currentHealth;
    private bool IsAlive;
    public GameObject _YouDied;

    public Animator _anim;

    public int NrOfHeart;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    private void Awake()
    {
        currentHealth = maxHealth;
        IsAlive = true;

        _anim = GetComponent<Animator>();
        _YouDied.SetActive(false);
    }
    private void Update()
    {
        YouDied();
    }
    private void FixedUpdate()
    {
        if(currentHealth > NrOfHeart)
        {
            currentHealth = NrOfHeart;
        }

        for (int i = 0; i < hearts.Length; i++)
        {
            if(i < Mathf.RoundToInt (currentHealth))
            {
                hearts[i].sprite = fullHeart;
            }

            else
            {
                hearts[i].sprite = emptyHeart;
            }
        }
    }
    public void takeDamage(float damage)
    {
        _anim.SetTrigger("Hurt");

        currentHealth -= damage;
        CheckLive();
    }

    private void CheckLive()
    {
        IsAlive = currentHealth >= 0;
        _anim.SetBool("IsDead", !IsAlive);

    }
    private void YouDied()
    {
        if (!IsAlive) 
        {
            _YouDied.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
