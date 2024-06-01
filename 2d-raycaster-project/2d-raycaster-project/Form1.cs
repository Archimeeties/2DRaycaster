﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace _2d_raycaster_project
{
    public partial class Form1 : Form
    {
        private Bitmap offScreenBitmap;
        private Graphics offScreenGraphics;
        private Graphics graphics;

        // classes
        private Controller controller;

        public Form1()
        {
            InitializeComponent();

            offScreenBitmap = new Bitmap(this.Width, this.Height);
            offScreenGraphics = Graphics.FromImage(offScreenBitmap);
            graphics = this.CreateGraphics();

            // initializing classes
            controller = new Controller(offScreenBitmap, offScreenGraphics, ClientSize);

            timer1.Interval = 1; // Approximately 60 FPS
            timer1.Start();
            this.KeyDown += Form1_KeyDown_1; // Connect the KeyDown event
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            controller.Run();
            graphics.DrawImage(offScreenBitmap, 0, 0); // Draw the offscreen bitmap to the form
        }

        private void Form1_KeyDown_1(object sender, KeyEventArgs e)
        {
            float moveSpeed = 0.1f;
            float rotSpeed = 0.08f;
            controller.HandleInput(e, moveSpeed, rotSpeed);
        }
    }
}