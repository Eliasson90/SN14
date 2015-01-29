using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kylskåp
{
   public class Cooler : Program
    {
       private decimal _insideTemperature;
       private decimal _targetTemperature;
       private const decimal OutsideTemperature = 23.7m;

       public bool DoorIsOpen { get; set; }

       public decimal InsideTemperature
       {
           get{return _insideTemperature; }

           set
           {
               if(value < 0 || value > 45)
               {
                   throw new ArgumentException();
               }
               _insideTemperature = value;
           }
       }
       public bool IsOn { get; set; }

       public decimal TargetTemperature 
       {
           get { return _targetTemperature; }

           set
           {
               if(value < 0 || value > 20 )
               {
                   throw new ArgumentException();
               }
               _targetTemperature = value;
           }
       }

       public Cooler()
           : this(0, 0)
       {

       }

       public Cooler(decimal insideTemperature, decimal targetTemperature)
           : this(insideTemperature, targetTemperature, false, false)
       {

       }

       public Cooler(decimal insideTemperature, decimal targetTemperature, bool isOn, bool doorIsOpen)
       {
           InsideTemperature = insideTemperature;
           TargetTemperature = targetTemperature;
           IsOn = isOn;
           DoorIsOpen = doorIsOpen;
       }

       public void Tick()
       {
           decimal change = 0.0m;

           if (IsOn == true && DoorIsOpen == false)
           {
               change = -0.2m;
           }
           else if (IsOn == true && DoorIsOpen == true)
           {
               change += 0.2m;
           }
           else if (IsOn == false && DoorIsOpen == false)
           {
               change += 0.1m;
           }
           else if (IsOn == false && DoorIsOpen == true)
           {
               change += 0.5m;
           }

           if (InsideTemperature + change < TargetTemperature)
           {
               InsideTemperature = TargetTemperature;
           }
           else if (InsideTemperature + change > OutsideTemperature)
           {
               InsideTemperature = OutsideTemperature;
           }
           else
           {
               InsideTemperature += change;
           }
       }

       public override string ToString()
       {
           string on = IsOn  ? "ON" : "OF";
           string open = DoorIsOpen ? "öppen" : "stängd";
           return string.Format("[{0}] : {1:f1}°C : ({2:f1}°C) - {3}", on, InsideTemperature, TargetTemperature, open);
       }
    }
}
