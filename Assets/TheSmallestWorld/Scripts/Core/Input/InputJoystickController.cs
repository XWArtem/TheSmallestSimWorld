// CODE REUSE FROM A PREVIOUS PROJECT with some changes

using UnityEngine;
using UnityEngine.EventSystems;

public class InputJoystickController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    [SerializeField] private RectTransform joysctickBgRect, joystickCenterRect;

    [SerializeField] private Transform mainHero;
    private AnimationMainHeroMovement animationMainHeroMovement;
    //[SerializeField] private MainHeroNameCanvas charNameCanvas;
    private float heroMoveSpeed = 0.01f, joystickRadius;

    private bool touch = false;
    private bool isActive = true;

    private Vector3 moveVector;
    private float moveSpeed = 4f;

    private float actualWidth, actualHeight;

    private void OnEnable()
    {
        //StaticActions.OnLevelStarted += SetActive;
        //CanvasPlayMode.OnGameWon += (() => isActive = false);
    }

    private void OnDisable()
    {
        //StaticActions.OnLevelStarted -= SetActive;
        //CanvasPlayMode.OnGameWon -= (() => isActive = false);
    }

    private void Start()
    {
        animationMainHeroMovement = mainHero.GetComponent<AnimationMainHeroMovement>();

        joystickRadius = joysctickBgRect.rect.width / 2;
        actualWidth = GetComponent<RectTransform>().rect.width * GetComponent<RectTransform>().localScale.x;
        actualHeight = GetComponent<RectTransform>().rect.height * GetComponent<RectTransform>().localScale.y;
    }

    private void FixedUpdate()
    {
        if (!isActive) return;
        if (touch)
        {
            mainHero.position += moveVector * moveSpeed;
            if (moveSpeed < 8f) moveSpeed += 0.01f;
        }
        else
        {
            moveSpeed = 4f;
        }
    }

    private void OnTouch(Vector2 touchVec)
    {
        if (!isActive) return;
        if (!touch) return;

        Vector2 vec = new Vector2(touchVec.x - joysctickBgRect.position.x, touchVec.y - joysctickBgRect.position.y);

        // limit with radius
        vec = Vector2.ClampMagnitude(vec, joystickRadius);
        joystickCenterRect.localPosition = vec;

        //
        float fSqr = (joysctickBgRect.position - joystickCenterRect.position).sqrMagnitude / (joystickRadius * joystickRadius);

        // normalize
        Vector2 vecNormal = vec.normalized;

        moveVector = new Vector3(vecNormal.x * Time.deltaTime * fSqr, vecNormal.y * Time.deltaTime * fSqr, 0f).normalized * heroMoveSpeed;
        mainHero.eulerAngles = new Vector3(0f, 0f, -Mathf.Atan2(vecNormal.x, vecNormal.y) * Mathf.Rad2Deg + 90f);
        //if (charNameCanvas != null) charNameCanvas.UpdateRotation();
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (!isActive) return;
        OnTouch(eventData.position);
        //if (IsPointerDownToJoystick(eventData.position)) 
        //touch = true;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (!touch && IsPointerDownToJoystick(eventData.position)) // start movement
        {
            animationMainHeroMovement.StartMovement();
            Debug.Log("Start movement animation");
        }

        touch = IsPointerDownToJoystick(eventData.position);
        
        OnTouch(eventData.position);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        // get the origin pos
        joystickCenterRect.localPosition = Vector3.zero;
        touch = false;
        animationMainHeroMovement.StopMovement();
    }

    private bool IsPointerDownToJoystick(Vector2 pos)
    {
        return (pos.x < actualWidth && pos.x > actualWidth / 1.5f && pos.y < actualHeight / 2f);
    }

    private void SetActive(bool setActive) { isActive = setActive; }
}