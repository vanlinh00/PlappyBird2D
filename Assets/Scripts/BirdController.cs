using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : Singleton<BirdController>
{
    [SerializeField] Rigidbody2D _rb;
    [SerializeField] private float _jumpSpeed;
    [SerializeField] private float _angleRotation;
    [SerializeField] private float _testAngle;

    public  bool _isPlayGame = false;
    private void Awake()
    {
        base.Awake();
    }
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

private void Update()
  {
        if (_isPlayGame)
        {

            if (WasTouchedOrClicked())
            {
                // _rb.AddForce(new Vector2(0, _jumpSpeed), ForceMode2D.Impulse);
                GetComponent<Rigidbody2D>().velocity = new Vector2(_rb.velocity.x, _jumpSpeed);
            }
            Rotation();
        }
        else
        {

        }

    }
 
   void Rotation()
    {
        if (_rb.velocity.y > 0)
        {
            float angel = 0;
            angel = Mathf.Lerp(0, 80, _rb.velocity.y / 7);
            transform.rotation = Quaternion.Euler(0, 0, angel);
        }
        else if (_rb.velocity.y == 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            float angel = 0;
            angel = Mathf.Lerp(0, -90, -_rb.velocity.y / 7);
            transform.rotation = Quaternion.Euler(0, 0, angel);
        }
    }
    bool WasTouchedOrClicked()
    {
        if (Input.GetButtonUp("Jump")  || Input.GetMouseButtonDown(0)   ||(Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Ended))
            return true;
        else
            return false;
    }

    public void ChangeBodyTypeToDynamic()
    {
        _rb.bodyType = RigidbodyType2D.Dynamic;
    }
}
