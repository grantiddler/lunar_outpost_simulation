//Do not edit! This file was generated by Unity-ROS MessageGeneration.
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;

namespace RosMessageTypes.Nav
{
    [Serializable]
    public class GetMapGoal : Message
    {
        public const string k_RosMessageName = "nav_msgs/GetMap";
        public override string RosMessageName => k_RosMessageName;

        //  Get the map as a nav_msgs/OccupancyGrid

        public GetMapGoal()
        {
        }
        public static GetMapGoal Deserialize(MessageDeserializer deserializer) => new GetMapGoal(deserializer);

        private GetMapGoal(MessageDeserializer deserializer)
        {
        }

        public override void SerializeTo(MessageSerializer serializer)
        {
        }

        public override string ToString()
        {
            return "GetMapGoal: ";
        }

#if UNITY_EDITOR
        [UnityEditor.InitializeOnLoadMethod]
#else
        [UnityEngine.RuntimeInitializeOnLoadMethod]
#endif
        public static void Register()
        {
            MessageRegistry.Register(k_RosMessageName, Deserialize);
        }
    }
}
