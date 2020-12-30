using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android;
using Android.AccessibilityServices;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Media;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Views.Accessibility;
using Android.Widget;


namespace Utility.Droid.Services
{
    [Service(Label = "Input Service", Permission = Manifest.Permission.BindAccessibilityService)]
    [IntentFilter(new string[] { "android.accessibilityservice.AccessibilityService" })]
    [MetaData("android.accessibilityservice", Resource = "@xml/config")]
    public class InputService : AccessibilityService
    {
        FrameLayout mLayout;
        //private AccessibilityServiceInfo info = new AccessibilityServiceInfo();
        public override void OnAccessibilityEvent(AccessibilityEvent e)
        {

        }

        public override void OnInterrupt()
        {

        }

        public override bool OnUnbind(Intent intent)
        {
            return base.OnUnbind(intent);
        }

        protected override void OnServiceConnected()
        {

            base.OnServiceConnected();

            //GestureDescription.Builder builder = new GestureDescription.Builder();
            //Path p = new Path();
            //p.MoveTo(500, 500);
            //p.LineTo(600, 600);
            //builder.AddStroke(new GestureDescription.StrokeDescription(p, 10L, 200L));
            //GestureDescription gesture = builder.Build();
            //GestureResultCallback g;
            //Handler h;
            //bool isDispatched = DispatchGesture(gesture, g, h);



            IWindowManager wm = Application.Context.GetSystemService(Context.WindowService).JavaCast<IWindowManager>();
            mLayout = new FrameLayout(this);
            WindowManagerLayoutParams lp = new WindowManagerLayoutParams();
            lp.Type = WindowManagerTypes.AccessibilityOverlay;
            //lp.Type = WindowManagerTypes.ApplicationOverlay;
            lp.Format = Format.Translucent;
            lp.Flags |= WindowManagerFlags.NotFocusable;
            lp.Width = WindowManagerLayoutParams.WrapContent;
            lp.Height = WindowManagerLayoutParams.WrapContent;
            lp.Gravity = GravityFlags.Top;
            //LayoutInflater inflater = LayoutInflater.From(this);
            LayoutInflater inflater = (LayoutInflater)Application.Context.GetSystemService(Context.LayoutInflaterService);
            //View view = inflater.Inflate(Resource.Layout.InputBar, null);
            inflater.Inflate(Resource.Layout.InputBar, mLayout);
            wm.AddView(mLayout, lp);




            //Equivalent Java code:

            //WindowManager wm = (WindowManager)getSystemService(WINDOW_SERVICE);
            //WindowManager.LayoutParams lp = new WindowManager.LayoutParams();
            //lp.Type = WindowManager.LayoutParams.TYPE_ACCESSIBILITY_OVERLAY;
            //lp.format = PixelFormat.TRANSLUCENT;
            //lp.flags |= WindowManager.LayoutParams.FLAG_NOT_FOCUSABLE;
            //lp.width = WindowManager.LayoutParams.WRAP_CONTENT;
            //lp.height = WindowManager.LayoutParams.WRAP_CONTENT;
            //lp.gravity = Gravity.TOP;
            //LayoutInflater inflater = LayoutInflater.from(this);
            //inflater.inflate(R.layout.action_bar, mLayout);
            //wm.addView(mLayout, lp);

            configurePowerButton();
            configureSwipeButton();
            configureVolumeButton();

        }

        private void configurePowerButton()
        {
            //Button powerButton = (Button)mLayout.FindViewById(Resource.Id.power);
            //powerButton.Click += PowerButton_Click;
        }

        private void configureVolumeButton()
        {
           // Button volumeButton = (Button)mLayout.FindViewById(Resource.Id.volume_up);
           // volumeButton.Click += VolumeButton_Click;
        }



        private void configureSwipeButton()
        {
           // Button swipeButton = (Button)mLayout.FindViewById(Resource.Id.swipe);
           // swipeButton.Click += SwipeButton_Click;
        }



        private void configureScrollButton()
        {
           // Button scrollButton = (Button)mLayout.FindViewById(Resource.Id.scroll);
            //scrollButton.Click += ScrollButton_Click;
        }

        private void ScrollButton_Click(object sender, EventArgs e)
        {

            Path swipePath = new Path();
            swipePath.MoveTo(500, 1000);
            swipePath.LineTo(500, 100);
            GestureDescription.Builder gestureBuilder = new GestureDescription.Builder();
            gestureBuilder.AddStroke(new GestureDescription.StrokeDescription(swipePath, 0, 500));
            DispatchGesture(gestureBuilder.Build(), null, null);

        }

        private void SwipeButton_Click(object sender, EventArgs e)
        {
            Path swipePath = new Path();
            swipePath.MoveTo(1000, 1000);
            swipePath.LineTo(100, 1000);
            GestureDescription.Builder gestureBuilder = new GestureDescription.Builder();
            gestureBuilder.AddStroke(new GestureDescription.StrokeDescription(swipePath, 0, 500));
            DispatchGesture(gestureBuilder.Build(), null, null);

        }

        private void PowerButton_Click(object sender, EventArgs e)
        {
            PerformGlobalAction(Android.AccessibilityServices.GlobalAction.PowerDialog);
        }
        private void VolumeButton_Click(object sender, EventArgs e)
        {
            AudioManager audioManager = (AudioManager)GetSystemService(Context.AudioService);
            audioManager.AdjustStreamVolume(Stream.Music, Adjust.Raise, VolumeNotificationFlags.ShowUi);

        }




    }
}