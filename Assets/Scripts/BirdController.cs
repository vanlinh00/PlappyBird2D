using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SoundController;

public class BirdController : Singleton<BirdController>
{
    [SerializeField] Rigidbody2D _rb;
    [SerializeField] private float _jumpSpeed;
    [SerializeField] private float _angleRotation;

    [SerializeField] Animator _animator;

    public  bool _isPlayGame = false;
    private void Awake()
    {
        base.Awake();
    }
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

private void Update()
  {
        if (_isPlayGame)
        {

            if (WasTouchedOrClicked())
            {
                // _rb.AddForce(new Vector2(0, _jumpSpeed), ForceMode2D.Impulse);
                SoundController._instance.OnPlayAudio(SoundType.fly);
                _rb.velocity = new Vector2(_rb.velocity.x, _jumpSpeed);
            }
            Rotation();
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
    public void Die()
    {
        _animator.SetBool("Die", true);
        _rb.GetComponent<BoxCollider2D>().isTrigger = true;
        transform.rotation = Quaternion.Euler(0, 0, -90);
        _isPlayGame = false;
        //_rb.velocity = new Vector2(_rb.velocity.x, -0.65f);
        //_rb.velocity = new Vector2(transform.position.x, -0.65f);
    }    
}
