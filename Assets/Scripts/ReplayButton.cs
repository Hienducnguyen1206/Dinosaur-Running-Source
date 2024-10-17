using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ReplayButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private Sprite defaultSprite; 
    [SerializeField] private Sprite pressedSprite;
    [SerializeField] GameObject GameOverText;
    private Image buttonImage;

   


    void Start()
    {

        buttonImage = GetComponent<Image>();

        buttonImage.sprite = defaultSprite;
    
    }


    

   
    public void OnPointerDown(PointerEventData eventData)
    {

        buttonImage.sprite = pressedSprite;
    }

    public void OnPointerUp(PointerEventData eventData)
    {

        buttonImage.sprite = defaultSprite;
    }

    public void GameOverUI()
    {
      gameObject.SetActive(true);
    }
}
