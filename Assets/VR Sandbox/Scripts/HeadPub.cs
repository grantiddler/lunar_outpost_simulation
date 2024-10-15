using RosMessageTypes.Assets;
using UnityEngine;
using Unity.Robotics.ROSTCPConnector;

/// <summary>
///
/// </summary>
public class HeadPub : MonoBehaviour
{
    ROSConnection ros;
    public string topicName = "head_pos";

    // The game object
    public GameObject hmd;
    // Publish the cube's position and rotation every N seconds
    public float publishMessageFrequency = 0.1f;

    // Used to determine how much time has elapsed since the last message was published
    private float timeElapsed;

    void Start()
    {
        // start the ROS connection
        ros = ROSConnection.instance;
        ros.RegisterPublisher<HeadMsg>(topicName);
    }

    private void Update()
    {
        timeElapsed += Time.deltaTime;

        if (timeElapsed > publishMessageFrequency)
        {

            HeadMsg HeadPos = new HeadMsg(
                mapPan((int)hmd.transform.eulerAngles.x),
                mapTilt((int)hmd.transform.eulerAngles.y)
            );

            // Finally send the message to server_endpoint.py running in ROS
            ros.Send(topicName, HeadPos);

            timeElapsed = 0;
        }
    }

    int map(int s, int a1, int a2, int b1, int b2)
    {
        return b1 + (s - a1) * (b2 - b1) / (a2 - a1);
    }

    int mapPan(int p)
    {
        if (p < 90)
        {
            return map(p, 90, 0, 10, 95);
        }

        else if (p > 270)
        {
            return map(p, 360, 270, 95, 180);
        }
        else
        {
            return map(p, 91, 269, 180, 10);
        }
    }

    int mapTilt(int t)
    {
        if (t < 90)
        {
            return map(t, 90, 0, 25, 115);
        }

        else if (t > 270)
        {
            return map(t, 360, 270, 115, 180);
        }
        else
        {
            return 115;
        }
    }
}