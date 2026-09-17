using UnityEngine;


public class hikoukiidou : MonoBehaviour
{
    [Header("飛行機の移動速度")]
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float speed = 5f; // 飛行機の移動速度

    [Header("傾きの設定")]
    public float MaxtiltAngle = 20f; // 飛行機の傾き角度
    public float tiltSpeed = 5f; // 飛行機の傾き速度

    [Header("移動方向フラグ")]
    private bool isMovingright = false;
    private bool isMovingleft = false;
    private bool isMovingup = false;
    private bool isMovingdown = false;

    private Rigidbody2D rb; // Rigidbody2Dコンポーネントへの参照

    [Header("X軸制限")]
    public float minX = -3f; // X軸の最小値
    public float maxX = 3f;  // X軸の最大値

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        float targetRotationZ = 0f;
        float moveX = 0f;
        if (isMovingright) { moveX = speed; targetRotationZ = -MaxtiltAngle; }
        else if (isMovingleft) { moveX = -speed; targetRotationZ = MaxtiltAngle; }

        float moveY = 0f;
        if (isMovingup) moveY = speed;
        else if (isMovingdown) moveY = -speed;

        // Rigidbody2D の速度を設定
        rb.linearVelocity = new Vector2(moveX, moveY);

        // X軸を minX ～ maxX の範囲に制限
        Vector2 clampedPos = rb.position;
        clampedPos.x = Mathf.Clamp(clampedPos.x, minX, maxX);
        rb.position = clampedPos;

        float newTiltZ = Mathf.LerpAngle(transform.localEulerAngles.z, targetRotationZ, tiltSpeed * Time.fixedDeltaTime);
        transform.localRotation = Quaternion.Euler(0f, 0f, newTiltZ);

    }
    public void pushleftButton() { isMovingleft = true; }
    public void pushrightButton() { isMovingright = true; }
    public void pushupButton() { isMovingup = true; }
    public void pushdownButton() { isMovingdown = true; }

    public void releasebutton()
    {
        isMovingright = false;
        isMovingleft = false;
        isMovingup = false;
        isMovingdown = false;
    }
}
