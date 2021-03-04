using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    
    public static GameManager Instance { get; private set; }

    public bool CursorActive { get; private set; } = true;

    public TextMeshProUGUI targets;
    public TextMeshProUGUI targetsRemaining;
    public int targetsLeft;

    private void Awake()
    {
        if (Instance!= null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
    }

    private void Start()
    {
        targetsLeft = FindObjectsOfType<target>().Length;
        targetsRemaining.text = targetsLeft.ToString();
        targets.text = targetsLeft.ToString();
    }

    private void EnableCursor(bool enable)
    {
        if (enable)
        {
            CursorActive = true;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            CursorActive = false;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    private void OnEnable()
    {
        AppEvents.MouseCursorEnabled += EnableCursor;
    }

    private void OnDisable()
    {
        AppEvents.MouseCursorEnabled -= EnableCursor;
    }

    public void TargetHit()
    {
        targetsLeft -= 1;
        targetsRemaining.text = targetsLeft.ToString();
        if (targetsLeft == 0)
        {
            TimeController.instance.EndTimer();
        }
    }
}
