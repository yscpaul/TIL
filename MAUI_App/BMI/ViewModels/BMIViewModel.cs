using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BMI.Models;
using CommunityToolkit.Mvvm.ComponentModel;

namespace BMI.ViewModels
{
    internal class BMIViewModel : ObservableObject
    {
        public Models.BMI BMI { get; set; }
        public BMIViewModel()
        {
            BMI = new Models.BMI();
            BMI.Height = 170;
            BMI.Weight = 80;
        }
    }
}
