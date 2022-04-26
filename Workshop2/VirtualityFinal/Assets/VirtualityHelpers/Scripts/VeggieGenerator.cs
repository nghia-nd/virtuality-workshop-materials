﻿/*
 * Copyright (c) 2022 VinMaker Society
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

using UnityEngine;

/// <summary>
/// Generate Veggies based on instructions of a Song.
/// </summary>
public class VeggieGenerator : MonoBehaviour
{
    // Prefabs to be spawned.
    public GameObject[] veggies;

    // Interval between notes
    public float BPM = 175f;

    // Interval to spawn another note.
    private float interval = 0f;

    // How often veggies appear.
    public float StartCutoff = 0.3f;
    private float cutoff;
    
    // Have 4 unique starting positions for notes.
    private float[,] startPositions =
    {
        {0, 0, 0 },
        {-0.75f, -0.50f, 0 },
        {0.75f, -0.50f, 0 },
        {-0.35f, -.35f, 0 },
        {0.35f, -.35f, 0 },
        {0.0f, 0f, 0 }
    };

    // Reset the rate veggies appear at the start.
    void OnEnable()
    {
        cutoff = StartCutoff;
    }

    void Update()
    {
        interval += Time.deltaTime;
        float beatInterval = 60.0f / BPM;

        if (interval > beatInterval)
        {
            interval = 0f;
            if (Random.Range(0.0f, 1.0f) < cutoff)
            {
                CreateVeggie();
            }

            cutoff += 0.01f;
        }

    }

    void CreateVeggie()
    {
        if (veggies.Length == 0) return;

        // 1. Instantiate a random veggie model.
        int randomVeggie = Random.Range(0, veggies.Length - 1);
        GameObject veggie = Instantiate(veggies[randomVeggie]);
        veggie.transform.position = transform.position;

        // 2. Choose the lane veggie will run in.
        int pos = Random.Range(0, 5);
        Vector3 destination = transform.position + new Vector3(startPositions[pos, 0], startPositions[pos, 1], startPositions[pos, 2]);

        // 3. Add a VeggieBehaviour component.
        VeggieBehaviour comp = (VeggieBehaviour)veggie.AddComponent(typeof(VeggieBehaviour));
        comp.movement = new Vector3(0, 0, -6);
        comp.destination = destination;
    }
}
