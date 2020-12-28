namespace ReportDBmySQL
{
    /// <summary>
    /// Акт осмотра УСПД
    /// </summary>
    public class InfoActs
    {
        public InfoActs(int device, int floor, int entrance, string side)
        {
            this.Device = device;
            this.Floor = floor;
            this.Entrance = entrance;
            this.Side = side;
        }

        /// <summary>
        /// Устройство
        /// </summary>
        public int Device { get;  set; }

        /// <summary>
        /// Этаж
        /// </summary>
        public int Floor { get;  set; }

        /// <summary>
        /// Подъезд
        /// </summary>
        public int Entrance { get;  set; }

        /// <summary>
        /// Крыло, сторона
        /// </summary>
        public string Side { get;  set; }
    }
}

/*

по
{ 1 | 2}
УСПД Милур IC UREG-Z/P
на {4} этаже
в подъезде {1, 2, 3, 4, 5}
в
{ левом, правом, центральном}
крыле

Примеры:
по 2(два) УСПД Милур IC UREG-Z/P в каждом подъезде в этажных шкафах на 4 этаже.в левом и в правом крыле

по 1 (один) УСПД Милур IC UREG-Z/P в каждом подъезде в этажных шкафах на 5 этаже.

по 1 (одному) УСПД Милур IC UREG-Z/P в 2, 3 подъезде в этажных шкафах на 3 этаже.

устройство
этаж
подъезд
крыло

device
floor
entrance
side

*/
