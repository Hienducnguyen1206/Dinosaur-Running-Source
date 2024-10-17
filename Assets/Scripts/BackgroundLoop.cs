using UnityEngine;

public class BackgroundLoop : MonoBehaviour
{

    Vector3 loopPosition;
   
    private void Start()
    {
        loopPosition = new Vector3(0, 0, 0);
       
    }

    private void Update()
    {
      if(gameObject.transform.position.x < -12)
        {
            gameObject.transform.position = loopPosition;
        }else
        {
            gameObject.transform.position += Vector3.left * GameController.Instance.speed * Time.deltaTime;

        }
    }
}
