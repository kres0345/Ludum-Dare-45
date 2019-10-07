using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Entity : MonoBehaviour
{
    public float MaxHP;
    public float HP { get; private set; }
    public TextMeshProUGUI HealthBarText;
    public RawImage HealthBarParent;
    public bool isPlayer = false;

    private Vector3 spawn;

    void Start()
    {
        HP = MaxHP;
        UpdateHealthbar();

        spawn = transform.position;
    }

    void Update()
    {
        if (transform.position.y < Constants.BoundaryMinY)
        {
            Dead();
        }
    }

    public void Damage(float damage)
    {
        // Play animation



        // Subtract damage
        HP -= damage;
        if (HP <= 0)
        {
            Dead();
        }

        UpdateHealthbar();
    }

    public void Dead()
    {
        if (isPlayer)
        {
            transform.position = spawn;
            HP = MaxHP;
        } else
        {
            Destroy(gameObject);
        }
    }

    private void UpdateHealthbar()
    {
        if (HealthBarParent == null || HealthBarText == null)
        {
            return;
        }
        HealthBarParent.color = Color.Lerp(Color.red, Color.green, HP / MaxHP);

        HealthBarText.text = $"{HP} / {MaxHP}";
    }
}
