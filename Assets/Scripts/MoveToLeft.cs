using UnityEngine;

public class MoveToLeft : MonoBehaviour
{
    [SerializeField] float controlSpeed = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position += Vector3.left * GameController.Instance.speed *controlSpeed *Time.deltaTime;
        if(gameObject.transform.position.x < -50 )
        {
           
            ObjectPooling.Instance.ReturnToPool( gameObject );
        }
    }
}
