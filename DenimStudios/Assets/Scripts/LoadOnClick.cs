﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadOnClick : MonoBehaviour
{
    public int level = 0;

    // Loads scene if application is used (or pressed when set on a button).
    public void LoadScene(int level)
    {
        Application.LoadLevel(level);
    }
}
