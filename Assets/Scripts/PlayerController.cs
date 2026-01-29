using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 7f;
    public GameObject completePanel; 

    private Rigidbody2D rb;

    void Awake()
    {
        
        rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.freezeRotation = true;
        }
        else
        {
            Debug.LogError(gameObject.name + " üzerinde Rigidbody2D bulunamadı!");
        }
    }

    public void move(float x)
    {
        if (rb != null)
            rb.linearVelocity = new Vector2(x * moveSpeed, rb.linearVelocity.y);
    }

    public void jump()
    {
        if (rb != null && Mathf.Abs(rb.linearVelocity.y) < 0.05f)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Finish"))
        {
            if (completePanel != null)
            {
                completePanel.SetActive(true);
                Time.timeScale = 0f;
            }
            else
            {
                Debug.LogError("Lütfen CompletePanel'i Inspector'dan atayın!");
            }
        }
    }

    public string NesneRenginiOku()
    {
        
        float lazerMesafesi = 5f;

        
        int maske = ~LayerMask.GetMask("Ignore Raycast");

        
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, lazerMesafesi, maske);

        
        Debug.DrawRay(transform.position, Vector2.right * lazerMesafesi, Color.red);

        if (hit.collider != null)
        {
           
            Debug.Log("Lazer Şunu Gördü: " + hit.collider.gameObject.name);
            return hit.collider.gameObject.name;
        }

        return "Bos";
    }
}