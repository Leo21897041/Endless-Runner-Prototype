using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float expForce;
    public float radius;
    public float delay;

    private void OnCollisionEnter(Collision other)
    {
        Knockback();
        Destroy(gameObject);
    }
    private void Knockback()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);
        
        foreach (Collider nearby in colliders)
        {
            Rigidbody rigg = nearby.GetComponent<Rigidbody>();

            if (rigg != null)
            {
                rigg.AddExplosionForce(expForce, transform.position, radius);
            }
            if (nearby.gameObject.CompareTag("Box"))
            {
                rigg.constraints = RigidbodyConstraints.None;
                Destroy(nearby.gameObject, delay);
            }
        }
    }
}
/*    public float expForce, radius;

    public LayerMask layerToHit;

    private void OnCollisionEnter2D(Collision2D other)
    {
        Knockback();
        Destroy(gameObject);
    }

    private void Knockback()
    {
        Collider2D[] objects = Physics2D.OverlapCircleAll(transform.position, radius, layerToHit);

        foreach (Collider2D obj in objects)
        {
            Vector2 direction = obj.transform.position - transform.position;

            obj.GetComponent<Rigidbody2D>().AddForce(direction * expForce);

            Vector2 rotation = (Vector2)transform.position - (Vector2)obj.transform.position;

            float rotationZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.Euler(0, 0, rotationZ);
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }*/
/*private void Knockback()
{
    Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, radius);

    foreach (Collider2D nearby in colliders)
    {
        Rigidbody2D rb = nearby.GetComponent<Rigidbody2D>();

        if (rb != null)
        {
            Vector2 force = (transform.position - nearby.transform.position).normalized * expForce;
            rb.AddForce(force, ForceMode2D.Force);
        }
    }
}*/

