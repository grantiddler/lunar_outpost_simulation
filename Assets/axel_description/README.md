# axel_description

This package contains the XACRO and URDF descriptions for the robot as well as a simple RViz interface for it to be loaded in.

To do a simple launch of RViz with axel:
`roslaunch axel_description rviz_urdf.launch`

To convert from urdf.xacro to urdf:
`rosrun xacro xacro -o axel.urdf axel.urdf.xacro`

## About Axel

This rover is on the order of a 130 kg. The tether, which is spooled around the central axle, is about 60 kg but that mass changes as tether is rolled (probably hard to model). Of the 130 kg, the wheels probably make up 30 kg, with the axle and arms making up about 100 kg combined. The boom arms probably are ~5 kg each. The center-of-mass should be very close to the center of the tube and would be slightly offset by the boom arms.

