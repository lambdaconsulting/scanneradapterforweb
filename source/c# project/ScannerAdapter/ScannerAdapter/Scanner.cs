using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WIA;
namespace ScannerAdapter
{
    class Scanner
    {
        private readonly DeviceInfo _deviceInfo;
        
        public Scanner(DeviceInfo deviceInfo) 
        {
            this._deviceInfo = deviceInfo;
        }

        public ImageFile Scan()
        {
            return (ImageFile)this._deviceInfo.Connect().Items[1].Transfer("{B96B3CAE-0728-11D3-9D7B-0000F81EF32E}");
        }

        public override string ToString()
        {
            return this._deviceInfo.Properties["Name"].get_Value();
        }
    }
}
