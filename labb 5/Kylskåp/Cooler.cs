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
           : this()
       {

       }

       public Cooler(decimal temperature, decimal targetTemperature)
           : this()
       {

       }

       public Cooler(decimal temperature, decimal targetTemperature, bool isOn, bool doorIsOpen)
       {
           InsideTemperature = temperature;
           TargetTemperature = targetTemperature;
           IsOn = isOn;
           DoorIsOpen = doorIsOpen;
       }

       public void Tick()
       {

       }

       public override string ToString()
       {
           return string.Format("", _insideTemperature, _targetTemperature);
       }
    }
}
