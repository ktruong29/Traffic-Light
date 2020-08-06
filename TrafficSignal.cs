/*******************************************************************************
 *Author: Kien Truong
 *Program: Traffic signal
 ******************************************************************************/

using System;
using System.Drawing;
using System.Timers;
using System.Windows.Forms;
using System.Collections.Generic;

public class TrafficSignal: Form
{
  //Instantiateing buttons
 private Button startButton = new Button();
 private Button pauseButton = new Button();
 private Button exitButton  = new Button();

 //Instantiateing radio buttons and group box
 private RadioButton slowButton  = new RadioButton();
 private RadioButton fastButton  = new RadioButton();
 private GroupBox radioContainer = new GroupBox();

 private Size maximumFlashingRedInterfacesize = new Size(1280,720);
 private Size minimumFlashingRedInterfacesize = new Size(1280,720);

 //Instantiating timer
 private static System.Timers.Timer Tclock = new System.Timers.Timer();
 private ulong tickCounter = 0;
 private enum TrafficColor{red, yellow, green, gray};
 TrafficColor light = TrafficColor.gray;

 public TrafficSignal()
 {//Set the size of the user interface box.
  MaximumSize = maximumFlashingRedInterfacesize;
  MinimumSize = minimumFlashingRedInterfacesize;

  //Initialize text strings
  Text = "Traffic Light by Kien Truong";
  startButton.Text    = "Start";
  pauseButton.Text    = "Pause";
  exitButton.Text     = "Exit";
  fastButton.Text     = "Fast";
  slowButton.Text     = "Slow";
  radioContainer.Text = "Rate of Change";

  //Set sizes
  Size = new Size(1280,720);
  startButton.Size      = new Size(100,40);
  pauseButton.Size      = new Size(100,40);
  exitButton.Size       = new Size(100,40);
  fastButton.Size       = new Size(60,40);
  slowButton.Size       = new Size(60,40);
  radioContainer.Size   = new Size(300,100);

  //Set locations
  startButton.Location    = new Point(100,600);
  pauseButton.Location    = new Point(900,600);
  exitButton.Location     = new Point(1100,600);
  slowButton.Location     = new Point(20,30);
  fastButton.Location     = new Point(150,30);
  radioContainer.Location = new Point(400,590);

  //Set colors
  this.BackColor            = Color.Purple;
  pauseButton.BackColor     = Color.Yellow;
  exitButton.BackColor      = Color.Yellow;
  startButton.BackColor     = Color.Yellow;
  radioContainer.BackColor  = Color.Yellow;

  //Add controls to the form
  Controls.Add(pauseButton);
  Controls.Add(exitButton);
  Controls.Add(startButton);

  radioContainer.Controls.Add(fastButton);
  radioContainer.Controls.Add(slowButton);
  Controls.Add(radioContainer);

  //Register the event handler.  In this case each button has an event handler, but no other
  //controls have event handlers.
  pauseButton.Enabled = true;
  startButton.Enabled = true;

  //Set the clock rate - default: slow mode
  Tclock.Interval = 1000;
  Tclock.Enabled  = false;

  Tclock.Elapsed    += new ElapsedEventHandler(Signal);
  pauseButton.Click += new EventHandler(ShowMessage);
  startButton.Click += new EventHandler(Start);
  slowButton.Click  += new EventHandler(SlowMode);
  fastButton.Click  += new EventHandler(FastMode);
  exitButton.Click  += new EventHandler(stoprun);  //The '+' is required.

}//End of constructor TrafficSignal

//Method to execute when the exit button receives an event, namely: receives a mouse click
 protected void stoprun(Object sender, EventArgs events)
 {
   Close();
 }//End of stoprun

 protected void Start(Object sender, EventArgs events)
 {
   light = TrafficColor.yellow;
   Tclock.Enabled = true;
 }//End of Start

 protected void SlowMode(Object sender, EventArgs events)
 {
   Tclock.Interval = 1000;
 }//End of SlowMode

 protected void FastMode(Object sender, EventArgs events)
 {
   Tclock.Interval = 500;
 }//End FastMode

 private void ShowMessage(object sender, EventArgs e)
 {
   //This will execute when "Pause" is clicked
   if(pauseButton.Text == "Pause")
   {
     //Stop the animation
     Tclock.Enabled = false;
     pauseButton.Text = "Resume";
   }
   //This will execute when "Resume is clicked"
   else
   {
     //Starts the animation again
     Tclock.Enabled = true;
     pauseButton.Text = "Pause";
   }
 }//END private void ShowMessage(object sender, EventArgs e)

 protected void Signal(System.Object send, ElapsedEventArgs e)
 {
   tickCounter++;
   switch(light)
   {
     case TrafficColor.red:
     {
       if(tickCounter > 4)
       {
         tickCounter = 0;
         light = TrafficColor.green;
         Invalidate();
       }
     }
     break;

     case TrafficColor.yellow:
     {
       if(tickCounter > 1)
       {
         tickCounter = 0;
         light = TrafficColor.red;
         Invalidate();
       }
     }
     break;

     case TrafficColor.green:
     {
       if(tickCounter > 3)
       {
         tickCounter = 0;
         light = TrafficColor.yellow;
         Invalidate();
       }
     }
     break;
   }//END switch(light)
 }//END protected void Signal(Object send, ElapsedEvenArgs e)

 protected override void OnPaint(PaintEventArgs ee)
 {
   Graphics lights = ee.Graphics;

   lights.FillRectangle(Brushes.HotPink,0,580,1280,200);
   lights.FillEllipse(Brushes.Gray,550,25,175,175);
   lights.FillEllipse(Brushes.Gray,550,210,175,175);
   lights.FillEllipse(Brushes.Gray,550,395,175,175);

   switch(light)
   {
     case TrafficColor.gray:
     {
       lights.FillEllipse(Brushes.Gray,550,25,175,175);
       lights.FillEllipse(Brushes.Gray,550,210,175,175);
       lights.FillEllipse(Brushes.Gray,550,395,175,175);
     }
     break;

     case TrafficColor.red:
     {
       lights.FillEllipse(Brushes.Red,550,25,175,175);
       lights.FillEllipse(Brushes.Gray,550,210,175,175);
       lights.FillEllipse(Brushes.Gray,550,395,175,175);
     }
     break;

     case TrafficColor.yellow:
     {
       lights.FillEllipse(Brushes.Gray,550,25,175,175);
       lights.FillEllipse(Brushes.Yellow,550,210,175,175);
       lights.FillEllipse(Brushes.Gray,550,395,175,175);
     }
     break;

     case TrafficColor.green:
     {
       lights.FillEllipse(Brushes.Gray,550,25,175,175);
       lights.FillEllipse(Brushes.Gray,550,210,175,175);
       lights.FillEllipse(Brushes.Green,550,395,175,175);
     }
     break;
   }//END switch(light)

   base.OnPaint(ee);
 }//END protected override void OnPaint(PaintEventArgs ee)

}//End of class TrafficSignal
