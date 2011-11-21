using System;
using System.Collections.Generic;
using Microsoft.Devices.Sensors;
using Microsoft.Xna.Framework;

namespace GameInputs.Inputs
{
    public class AccelerometerInput
    {
        public Vector3 CurrentAccelerometerReading { get { return currentAccelerometerReading; } }
        
        private static Accelerometer accelerometerSensor;
        private static Vector3 currentAccelerometerReading;
        private Dictionary<Direction, float> accelerometerInputs = new Dictionary<Direction, float>();
        private static bool isAccelerometerStarted = false;

        public AccelerometerInput()
        {
            if (accelerometerSensor == null)
                InitializeAccelerometerSensor(); 
        }

        /// <summary>
        /// Initialize Accelerometer Sensor
        /// </summary>
        private void InitializeAccelerometerSensor()
        {
            accelerometerSensor = new Accelerometer();
            accelerometerSensor.CurrentValueChanged +=
                new EventHandler<SensorReadingEventArgs<AccelerometerReading>>(AccelerometerReadingChanged);
        }

        /// <summary>
        /// Handle Accelerometer reading changed event
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AccelerometerReadingChanged(object sender, SensorReadingEventArgs<AccelerometerReading> e)
        {
            currentAccelerometerReading.X = e.SensorReading.Acceleration.X;
            currentAccelerometerReading.Y = e.SensorReading.Acceleration.Y;
            currentAccelerometerReading.Z = e.SensorReading.Acceleration.Z;
        }

        /// <summary>
        /// Add accelerometer input
        /// </summary>
        /// <param name="direction"></param>
        /// <param name="tiltThreshold"></param>
        public void Add(Direction direction, float tiltThreshold)
        {
            if (!isAccelerometerStarted)
                StartAccelerometer();
            accelerometerInputs.Add(direction, tiltThreshold);
        }

        /// <summary>
        /// Start accelerometer
        /// </summary>
        private void StartAccelerometer()
        {
            try
            {
                accelerometerSensor.Start();
                isAccelerometerStarted = true;
            }
            catch (AccelerometerFailedException e)
            {
                isAccelerometerStarted = false;
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Remove all accelerometer inputs
        /// </summary>
        public void RemoveAccelerometerInputs()
        {
            if (!isAccelerometerStarted)
                StopAccelerometer();
            accelerometerInputs.Clear();
        }

        /// <summary>
        /// Stop accelerometer
        /// </summary>
        private void StopAccelerometer()
        {
            try
            {
                accelerometerSensor.Stop();
                isAccelerometerStarted = false;
            }
            catch (AccelerometerFailedException e)
            {
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// Check whether there is Accelerometer input
        /// </summary>
        /// <returns></returns>
        public bool IsPressed()
        {
            foreach (KeyValuePair<Direction, float> input in accelerometerInputs)
            {
                switch (input.Key)
                {
                    case Direction.Up:
                        {
                            if (Math.Abs(currentAccelerometerReading.Y) > input.Value &&
                                currentAccelerometerReading.Y < 0)
                                return true;
                            break;
                        }
                    case Direction.Down:
                        {
                            if (Math.Abs(currentAccelerometerReading.Y) > input.Value &&
                                currentAccelerometerReading.Y > 0)
                                return true;
                            break;
                        }
                    case Direction.Left:
                        {
                            if (Math.Abs(currentAccelerometerReading.X) > input.Value &&
                                currentAccelerometerReading.X < 0)
                                return true;
                            break;
                        }
                    case Direction.Right:
                        {
                            if (Math.Abs(currentAccelerometerReading.X) > input.Value &&
                                currentAccelerometerReading.X > 0)
                                return true;
                            break;
                        }
                }
            }
            return false;
        }


    }
}