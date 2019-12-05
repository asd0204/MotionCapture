using UnityEngine;

public class Player : MonoBehaviour
{
    private Animator ani;

    private void Start()
    {
        ani = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) ani.SetTrigger("跳舞觸發器");

        ani.SetBool("跑步開關", Input.GetKey(KeyCode.R));
    }
}
