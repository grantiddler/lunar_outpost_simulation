using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
//ROS specific libraries
using Unity.Robotics.ROSTCPConnector;
using Unity.Robotics.ROSTCPConnector.ROSGeometry;
using RosMessageTypes.Geometry; //Twist message

/*
    Subscribes to the twist topic in order to drive armstrong in Unity.
    Author: Phaedra Curlin
*/

public class AxelDriveSubscriber : MonoBehaviour {
    // ROS Connector
    private ROSConnection ros;

    //armstrong robot parameters
    public GameObject axel;
    public float SagittalGain = 1f;
    public float TransverseGain = 1f;

    private int numRobotJoints = 2;    
    // Articulation Bodies
    private ArticulationBody[] jointArticulationBodies;

    Vector3 linearVelocity, angularVelocity;
    Vector3 prevLinear, prevAngular;

    void Update()
    {
        //Adjust the velocity of the wheels every frame
        jointArticulationBodies[0].AddRelativeTorque(linearVelocity * SagittalGain + angularVelocity * TransverseGain);
        jointArticulationBodies[1].AddRelativeTorque(linearVelocity * SagittalGain - angularVelocity * TransverseGain);
    }

    void drive(TwistMsg twist) {
        //Debug logging
        Debug.Log("ROS Linear velocity:" + twist.linear);
        Debug.Log("ROS Angular velocity:" + twist.angular);
        //Need to do a vector transformation because the coordinate system of Unity is different
        linearVelocity = new Vector3(0,0,-(float)twist.linear.x);
        angularVelocity = new Vector3(0, 0, (float)twist.angular.z);
    }

    void Start(){
        // Get ROS connection static instance
        ROSConnection.instance.Subscribe<TwistMsg>("/axel_velocity_controller/cmd_vel", drive);

        // Get the joints from the model in Unity
        jointArticulationBodies = new ArticulationBody[numRobotJoints];
        string l_wheel = "base_link/frame/l_wheel";
        jointArticulationBodies[0] = axel.transform.Find(l_wheel).GetComponent<ArticulationBody>();
        string r_wheel = "base_link/frame/r_wheel";
        jointArticulationBodies[1] = axel.transform.Find(r_wheel).GetComponent<ArticulationBody>();

    }
}
