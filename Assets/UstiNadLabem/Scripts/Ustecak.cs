using UnityEngine;

public abstract class Ustecak : MonoBehaviour
{
    protected int lives;

    [SerializeField]
    private int maxLives;

    [SerializeField]
    protected float speed;

    public virtual void Start()
    {
        lives = maxLives;
    }
    public abstract void DoDamage();

    protected void RemoveLife()
    {
        lives--;
        if (lives <= 0)
        {
            Destroy(gameObject);
        }
    }

    protected virtual void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
}
