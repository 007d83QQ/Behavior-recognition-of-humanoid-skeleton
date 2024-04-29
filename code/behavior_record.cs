using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class aaa : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform[] body_control_points;
    public Transform man;
    public int posture;
    string data = "";
    //StreamWriter sw = new StreamWriter("/Users/shaoxi/Desktop/un.txt");

    int count = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (count >= 20 && count < 44)
        {
            Vector3 pos;
            //string data = "";
            float[] record_x = new float[13];
            float[] record_y = new float[13];
            for (int i = 0; i < body_control_points.Length; i++)
            {
                pos = Camera.main.WorldToScreenPoint(body_control_points[i].position);
              
                record_x[i] = pos.x;
                record_y[i] = pos.y;

            }

            float[] upper_pos = {(record_x[1]+record_x[2])/2,(record_y[1]+ record_y[2])/2 };
            float[] latter_pos = {(record_x[7]+record_x[8])/2, (record_y[7] + record_y[8]) / 2 };

            float standarize = Mathf.Sqrt((upper_pos[0] - latter_pos[0]) * (upper_pos[0] - latter_pos[0]) + (upper_pos[1] - latter_pos[1]) * (upper_pos[1] - latter_pos[1]));

            for (int i = 0; i < body_control_points.Length; i++)
            {
                record_x[i] = (record_x[i] - latter_pos[0]) / standarize;
                record_y[i] = (record_y[i] - latter_pos[1]) / standarize;
                if (i == 0)
                {
                    data += record_x[i] + "," + record_y[i];
                }
                else {

                    data += "," +record_x[i] + "," + record_y[i];
                }
            }

            data += ","+posture+"\n";
            //sw.WriteLine(data);
            man.Rotate(new Vector3(0, 15, 0));

        }
        count++;

        if (count == 44) {
            Debug.Log(data);
            //sw.Close();
        }
    }
}