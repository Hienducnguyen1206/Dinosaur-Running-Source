using System;

using UnityEngine;
using static AudioController;
public class PlayerController : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] bool isOnGround = true;
    [SerializeField] float jumpForce;

    [SerializeField] Animator animator;

    public static Action GameOver;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerControl();
    }

    public void PlayerControl()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isOnGround) {
            isOnGround = false;
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            animator.SetBool("Jumping", true);
            AudioController.Instance.PlayOnce(SoundEffect.JUMP);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            animator.SetBool("Jumping",false);
            AudioController.Instance.PlayOnce(SoundEffect.LAND);
        }

        if (collision.gameObject.layer == LayerMask.NameToLayer("Obstacle")) 
        {   
            GameController.Instance.speed = 0f;
            jumpForce = 0f;
            animator.SetBool("Death",true);
            AudioController.Instance.PlayOnce(SoundEffect.DIE);
            ObstacleSpawn.Instance.StopAllCoroutines();
            BackMoutainSpawn.Instance.StopAllCoroutines();
            Debug.Log("Game Over");
            GameOver?.Invoke();
        }
    }

   


}
