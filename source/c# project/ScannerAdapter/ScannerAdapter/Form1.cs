using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;
using WIA;
using Fleck;
namespace ScannerAdapter
{
    public partial class Form1 : Form
    {
        ArrayList devList = new ArrayList();
        private IWebSocketServer server;
        private int inUse;
        public Form1()
        {
            InitializeComponent();
        }

        private void ListDevices_Click(object sender, EventArgs e)
        {
            DevicesList.Items.Clear();
            var deviceManager = new DeviceManager();

            for (int i = 1; i <= deviceManager.DeviceInfos.Count; i++)
            {
                if (deviceManager.DeviceInfos[i].Type == WiaDeviceType.ScannerDeviceType) 
                {
                    deviceManager.DeviceInfos[i].Connect();
                    this.DevicesList.Items.Add(new Scanner(deviceManager.DeviceInfos[i]));
                    this.devList.Add(new Scanner(deviceManager.DeviceInfos[i]));
                }
            }
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            Scanner device = this.DevicesList.SelectedItem as Scanner;
            if (device == null)
            {
                int err_message = (int)MessageBox.Show("Please select a device.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else 
            {
                string ws = "ws://";
                string host = "localhost";
                string port = "8811";
                
                server = (IWebSocketServer) new WebSocketServer(ws + host + ":" + port);
                server.Start((Action<IWebSocketConnection>) (socket => socket.OnMessage = (Action<string>) (message =>
                {
                    var split_msg = message.Split('#');
                    switch(split_msg[0])
                    {
                        case "scan":
                            if(inUse == 0)
                            {
                                inUse = 1;
                                MemoryStream memoryStream = new MemoryStream((byte[]) device.Scan().FileData.get_BinaryData());
                                Image img = Image.FromStream((Stream) memoryStream);
                                memoryStream.Close();

                                int width = img.Width;
                                int height = img.Height;
                                var MaxHW = split_msg[4];
                                int widthMax = Int32.Parse(MaxHW.Split(',')[0]);
                                int heightMax = Int32.Parse(MaxHW.Split(',')[1]);

                                float ratio = Math.Min((float)widthMax / (float)width, (float)heightMax / (float)height);
                                int newW = (int) ((double) width * (double) ratio);
                                int newH = (int)((double)height * (double)ratio);
                                socket.Send(getBase64String(img, newW, newH));
                                inUse = 0;
                                break;
                            }
                            socket.Send("881");
                        break;
                        case "init":
                            if (inUse == 0) 
                            {
                                
                                string reply_msg = string.Join("#", ((string[]) this.devList.ToArray(Type.GetType("System.String"))));
                                socket.Send(reply_msg);
                                break;
                            }
                            socket.Send("1");
                        break;
                    }
                })));
                StatusLabel.Text = "Running on "+ host + " port "+port ;
            }
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            server.Dispose();
            StatusLabel.Text = "stopped";
        }

        private string getBase64String(Image img, int newW, int newH) 
        {
            using (Bitmap bmp = new Bitmap(newW, newH)) 
            {
                Graphics graphics = Graphics.FromImage((Image)bmp);
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.DrawImage(img, 0, 0, newW, newH);
                graphics.Dispose();
                return bmp.ToBase64ImageTag(bmp.RawFormat) ?? (string) null;
            }
        }
    }
}
