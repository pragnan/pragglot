﻿using System.Threading.Tasks;
using Xamarin.Forms;

namespace Restaurant.Controls
{
    public class AnimateButton : Button
    {
        public AnimateButton()
        {
            const int animationTime = 100;
            Clicked += async (sender, e) =>
            {
                var btn = (AnimateButton)sender;
                await btn.ScaleTo(1.2, animationTime);
                await btn.ScaleTo(1, animationTime);
                await Task.Delay(400);
            };
        }
    }
}
