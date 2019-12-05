﻿using UnityEngine;

public class Lady : MonoBehaviour
{
    private Animator ani;               // 動畫元件
    private Rigidbody rig;              // 剛體元件

    [Header("走路速度"), Range(0f, 80f)]
    public float speed = 1.5f;
    [Header("旋轉速度"), Range(1f, 100f)]
    public float turn = 1.5f;

    [Header("動畫控制器：參數名稱")]
    public string parRun = "跑步開關";
    public string parAtk = "攻擊觸發";
    public string parDam = "受傷觸發";
    public string parJump = "跳躍觸發";
    public string parDead = "死亡開關";

    private void Start()
    {
        ani = GetComponent<Animator>();     // 動畫元件欄位 =  取得元件<泛型>();
        rig = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Turn();
        Attack();
    }

    // FixedUpade 1 格執行 0.002 秒 (有使用物理寫在這裡)
    private void FixedUpdate()
    {
        Walk();
        Jump();
    }

    // 定義方法
    // 修飾詞 傳回類型 方法名稱 (參數) { 敘述 }
    // void 無回傳

    /// <summary>
    /// 前後左右走路
    /// </summary>
    private void Walk()
    {
        // 動畫：跑步 - 按下前後時 true
        ani.SetBool(parRun, Input.GetAxisRaw("Vertical") != 0 || Input.GetAxisRaw("Horizontal") != 0);
        //rig.AddForce(0, 0, Input.GetAxisRaw("Vertical") * speed);                 // 以世界座標移動
        //rig.AddForce(transform.forward * Input.GetAxisRaw("Vertical") * speed);   // 以區域座標移動

        // 前方 transform.forward (0, 0, 1)
        // 右方 transform.right   (1, 0, 0)
        // 上方 transform.up      (0, 1, 0)
        rig.AddForce(transform.forward * Input.GetAxisRaw("Vertical") * speed + transform.right * Input.GetAxisRaw("Horizontal") * speed);
    }

    /// <summary>
    /// 左右旋轉
    /// </summary>
    private void Turn()
    {
        float x = Input.GetAxis("Mouse X");   // 滑鼠左右，左 -1、右 1
        //print("玩家滑鼠 X：" + x);
        // Time.deltaTime 一幀的時間
        transform.Rotate(0, x * turn * Time.deltaTime, 0);
    }

    /// <summary>
    /// 攻擊
    /// </summary>
    private void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
            ani.SetTrigger(parAtk);
    }

    /// <summary>
    /// 跳躍
    /// </summary>
    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            ani.SetTrigger(parJump);
    }

    /// <summary>
    /// 受傷
    /// </summary>
    private void Hurt()
    {
        ani.SetTrigger(parDam);
    }

    /// <summary>
    /// 死亡
    /// </summary>
    private void Dead()
    {
        ani.SetBool(parDead, true);
    }
}
