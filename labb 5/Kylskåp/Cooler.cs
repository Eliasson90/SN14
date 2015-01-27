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
       private const decimal OutsideTemperature = 23;

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
           if (IsOn)
           {
               if (DoorIsOpen)
               {
                   InsideTemperature += 0.2M;
               }
               else
               {
                   InsideTemperature -= 0.2M;
               }
           }
           else
           {
               if (DoorIsOpen)
               {
                   InsideTemperature += 0.5M;
               }
               else
               {
                   InsideTemperature += 0.1M;
               }
           }
       }

       public override string ToString()
       {
           string on = IsOn  ? "ON" : "OF";
           string open = DoorIsOpen ? "öppen" : "stängd";
           return string.Format("{[0]} : {0:m} : {(0:m)} - {0}", on, InsideTemperature, TargetTemperature, open);
       }
    }
}
