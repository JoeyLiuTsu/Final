using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LolMov : MonoBehaviour
{
    public float moveSpeed;
    public bool isSelected;
    private void Update()
    {
        if (isSelected)
        {
            if (Input.GetKey(KeyCode.W))
            {
                transform.position += Vector3.forward * moveSpeed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.position += Vector3.back * moveSpeed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.position += Vector3.left * moveSpeed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.position += Vector3.right * moveSpeed * Time.deltaTime;
            }
        }
    }

    public void SelectOnOff()
    {
        isSelected = !isSelected;
    }
}
