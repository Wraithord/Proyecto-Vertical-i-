using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGround : MonoBehaviour
{
    public static bool isground;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isground = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isground = false;
    }



}
