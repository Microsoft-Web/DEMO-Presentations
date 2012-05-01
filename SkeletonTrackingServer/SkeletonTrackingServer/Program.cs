using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Microsoft.Kinect;
using Coding4Fun.Kinect.WinForm;
using SignalR.Client.Hubs;

namespace SkeletonTrackingServer
{
    class Program
    {
        private Skeleton[] _skeletonData;
        public KinectSensor _kinect;
        HubConnection _connection;
        IHubProxy _hub;

        static void Log(string message)
        {
            Console.WriteLine(message);
            Debug.WriteLine(message);
        }

        public Program()
        {
            _skeletonData = new Skeleton[0];
        }

        void Start()
        {
            _connection = new HubConnection("http://localhost:40143");
            _connection.Start().ContinueWith((t) =>
                {
                    _hub = _connection.CreateProxy("SkeletonTrackingClient.MoveShapeHub");

                    if (KinectSensor.KinectSensors.Any())
                    {
                        this._kinect = KinectSensor.KinectSensors.First();
                        this._kinect.SkeletonStream.Enable();
                        this._kinect.SkeletonFrameReady += Kinect_SkeletonFrameReady;
                        this._kinect.AllFramesReady += Kinect_AllFramesReady;
                        this._kinect.Start();
                    }
                });
        }

        void Stop()
        {
            Log("Stopping");
            this._kinect.Stop();
            Log("Stopped");
        }

        void Kinect_AllFramesReady(object sender, AllFramesReadyEventArgs e)
        {
            _skeletonData.ToList().ForEach(s =>
                {
                    if (s.TrackingState == SkeletonTrackingState.Tracked)
                    {
                        var rightHand = s.Joints.First(x => x.JointType == JointType.HandRight);
                        var leftHand = s.Joints.First(x => x.JointType == JointType.HandLeft);
                        var r = rightHand.ScaleTo(640, 480);
                        var l = leftHand.ScaleTo(640, 480);

                        _hub.Invoke("MoveShape", 
                            new { hand = "right", x = r.Position.X, y = r.Position.Y},
                            new { hand = "left", x = l.Position.X, y = l.Position.Y }
                            );

                        Log(string.Format("Right X: {0} Right Y: {1}, Left X: {2}, Left Y: {3}",
                            r.Position.X,
                            r.Position.Y,
                            l.Position.X,
                            l.Position.Y));
                    }
                });

            Array.Clear(_skeletonData, 0, _skeletonData.Length);
        }

        void Kinect_SkeletonFrameReady(object sender, SkeletonFrameReadyEventArgs e)
        {
            using (SkeletonFrame skeletonFrame = e.OpenSkeletonFrame())
            {
                _skeletonData = new Skeleton[skeletonFrame.SkeletonArrayLength];

                if (skeletonFrame != null)
                {
                    skeletonFrame.CopySkeletonDataTo(_skeletonData);
                }
            }
        }

        static void Main(string[] args)
        {
            Program p = new Program();

            p.Start();
            Log("Press Enter to Quit");
            Console.ReadLine();
            Log("Press Enter to Exit");
            Console.ReadLine();
            p.Stop();
        }
    }
}
