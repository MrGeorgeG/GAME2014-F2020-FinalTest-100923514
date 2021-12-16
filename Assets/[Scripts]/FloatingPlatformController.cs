/*
 *  Full Name        : Xinlin Gan
 *  Student ID       : 100923514
 *  Date Modified    : 2021/12/16
 *  File             : FloatingPlatformController.cs
 *  Description      : Floating Platform Control Script use to setting the platform.
 *  Revision History : v0.1 Create the Shrinking and Resetting function to control shrinking for the platform .
 *                     v0.2 Create the Collision function to check the player
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingPlatformController : MonoBehaviour
{
    [Header("Platform setting")]
    public float size;

    public bool isPlayer;
    public GameObject floatingPlatform;

    private Vector2 startingPosition;

    // Start is called before the first frame update
    void Start()
    {
        startingPosition = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Shrinking();

        Resetting();

    }

    //shrink the platform size
    private void Shrinking()
    {
        if (isPlayer && size >= 0.0f)
        {
            size -= 1.0f * Time.deltaTime;
            floatingPlatform.transform.localScale = new Vector2(size, 2.0f);

        }
    }

    //reset the platform size
    private void Resetting()
    {
        if (!isPlayer && size <= 3.0f)
        {
            size += 1.0f * Time.deltaTime;
            floatingPlatform.transform.localScale = new Vector2(size, 2.0f);

        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isPlayer = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isPlayer = false;
        }
    }
}