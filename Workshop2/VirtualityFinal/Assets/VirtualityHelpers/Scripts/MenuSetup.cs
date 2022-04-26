﻿/*
 * Copyright (c) 2022 VinMaker Society
 * This file has been modified.
 * 
 * Copyright (c) 2019 Razeware LLC
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 *
 * Notwithstanding the foregoing, you may not use, copy, modify, merge, publish, 
 * distribute, sublicense, create a derivative work, and/or sell copies of the 
 * Software in any work that is designed, intended, or marketed for pedagogical or 
 * instructional purposes related to programming, coding, application development, 
 * or information technology.  Permission for such use, copying, modification,
 * merger, publication, distribution, sublicensing, creation of derivative works, 
 * or sale is expressly withheld.
 *    
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 */
 
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MenuSetup : MonoBehaviour
{
    public GameObject[] sabers;
    public GameObject gameManager;
    public GameObject highScoreText;
    public GameObject scoreText;
    private Vector3 leftStart;
    private Vector3 rightStart;

    private void Awake()
    {
        leftStart = sabers[0].transform.position;
        rightStart = sabers[1].transform.position;
    }

    private void SetSaberLocation(GameObject saber, Vector3 position)
    {
        if (saber)
        {
            //saber.transform.SetParent(null);
            saber.GetComponent<OVRGrabbable>().grabbedBy.ForceRelease(saber.GetComponent<OVRGrabbable>());
            saber.transform.position = transform.position;
            saber.transform.localPosition = position;
            saber.transform.localRotation = Quaternion.identity;
        }
    }

    public void OnEnable()
    {
        // 1.
        SetSaberLocation(sabers[0], leftStart);
        SetSaberLocation(sabers[1], rightStart);

        // 2.
        SetScores();
    }

    public void SetScores()
    {
        // 1.
        TextMeshProUGUI highscore = highScoreText.GetComponent<TextMeshProUGUI>();
        highscore.text = gameManager.GetComponent<GameManager>().highScore.ToString();

        // 2. 
        TextMeshProUGUI score = scoreText.GetComponent<TextMeshProUGUI>();
        score.text = gameManager.GetComponent<GameManager>().score.ToString();
    }
}
