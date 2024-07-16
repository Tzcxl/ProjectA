using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class PlayerControl : MonoBehaviour
{
    private bool _isRunning;
    private bool _isInvulnerable;
    private readonly Player _player = new Player();
    private readonly GhostEnemy _enemy = new GhostEnemy();

    public Rigidbody2D Rigidbody;
    public TextMeshProUGUI HealthText;
    public Slider HealthSlider;
    public float InvulnerabilityTime;
    public SpriteRenderer Sprite;
    public Animator Animator; 

    public void Start()
    {
        Sprite = GetComponent<SpriteRenderer>();
        Animator = gameObject.GetComponent<Animator>();
        Rigidbody.GetComponent<Rigidbody2D>();

        HealthSlider.value = _player.CurrentHealthPoint / _player.HealthPoint;
        HealthText.text = $"HP: {_player.CurrentHealthPoint}/{_player.HealthPoint}";
    }

    public void FixedUpdate()
    {
        // Получаем ввод от пользователя
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Вычисляем вектор движения
        _isRunning = Mathf.Abs(horizontalInput) > 0;
        Animator.SetBool("Run", _isRunning);

        Sprite.flipX = horizontalInput > 0;
        Animator.SetFloat("VerticalMove", verticalInput);
        // Применяем движение к Rigidbody2D
        Rigidbody.velocity = new Vector2(horizontalInput, verticalInput) * _player.Speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Enemy") || _isInvulnerable)
        {
            return;
        }

        TakeDamage(_enemy.Damage);
        StartCoroutine(InvulnerabilityTimer());
    }

    public void TakeDamage(float damage)
    {
        _player.CurrentHealthPoint -= damage;
        _player.CurrentHealthPoint = Mathf.Max(_player.CurrentHealthPoint, 0); // Ensure health doesn't go negative
        HealthSlider.value = _player.CurrentHealthPoint / _player.HealthPoint;
        HealthText.text = $"HP: {_player.CurrentHealthPoint}/{_player.HealthPoint}";
    }

    private IEnumerator InvulnerabilityTimer()
    {
        Physics2D.IgnoreLayerCollision(6, 8, true);
        _isInvulnerable = true;
        yield return new WaitForSeconds(InvulnerabilityTime);
        _isInvulnerable = false;
        Physics2D.IgnoreLayerCollision(6, 8, false);
    }
}

public class Player : CharacterBase
{
    public Player() : base(100)
    {
        Speed = 1f;
        Damage = 5f;
        CharName = "_player";
    }
}
