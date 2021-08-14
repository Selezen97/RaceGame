using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CarController : MonoBehaviour
{
    public CarMover Car;
    public Text lapLabel;
    private byte lap=1,stage=0;
    public GameObject finishLabel;
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space))
            Car.Accelerate();
        if (Input.GetKey(KeyCode.D))
            Car.RotateRight();
        if (Input.GetKey(KeyCode.A))
            Car.RotateLeft();
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        switch (coll.gameObject.name)
        {
            case "1":
                if (stage == 0 || stage == 4)
                    stage = 1;
                break;
            case "2":
                if (stage == 1)
                    stage = 2;
                break;
            case "3":
                if (stage == 2)
                    stage = 3;
                break;
            case "4":
                if (stage == 3 && lap == 2)
                {
                    finishLabel.SetActive(true);
                    Invoke("GoMenu",3);
                }
                if (stage == 3)
                {
                    stage = 0;
                    lap++;
                    lapLabel.text = "Lap: 2/2";
                }
                break;
        }
    }

    private void GoMenu()
    {
        SceneManager.LoadScene(0);
    }
}
