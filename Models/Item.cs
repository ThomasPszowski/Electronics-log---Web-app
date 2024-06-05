using System.Collections.ObjectModel;

namespace projekt_web.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Datasheet { get; set; }

        public Item()
        {
            Id = 0;
            Name = "Name";
            Description = "Description";
            Datasheet = "";
        }

        public Item (int id, string name, string description = "", string datasheet = "")
        {
            Id = id;
            Name = name;
            Description = description;
            Datasheet = datasheet;
        }

        static public void FillTest(ObservableCollection<Item> items)
        {
            items.Clear();
            items.Add(new Item(1, "CY62256N, 256-Kbit (32 K × 8) Static RAM", "The CY62256N is a high performance CMOS static RAM\r\norganized as 32K words by 8 bits. Easy memory expansion is\r\nprovided by an active LOW chip enable (CE) and active LOW\r\noutput enable (OE) and tristate drivers. This device has an\r\nautomatic power-down feature, reducing the power consumption\r\nby 99.9 percent when deselected.\r\nAn active LOW write enable signal (WE) controls the\r\nwriting/reading operation of the memory. When CE and WE\r\ninputs are both LOW, data on the eight data input/output pins\r\n(I/O0 through I/O7) is written into the memory location addressed\r\nby the address present on the address pins (A0 through A14).\r\nReading the device is accomplished by selecting the device and\r\nenabling the outputs, CE and OE active LOW, while WE remains\r\ninactive or HIGH. Under these conditions, the contents of the\r\nlocation addressed by the information on address pins are\r\npresent on the eight data input/output pins.\r\nThe input/output pins remain in a high impedance state unless\r\nthe chip is selected, outputs are enabled, and write enable (WE)\r\nis HIGH. ", "CY62256N.pdf"));
            items.Add(new Item(2, "CD4081", "4x AND", "cd4081b.pdf"));
            items.Add(new Item(3, "NE 555", "The NE555, often simply referred to as the 555 timer IC, is a highly popular integrated circuit that has been widely used since its introduction in 1972 by Signetics (now owned by Texas Instruments). It's designed to generate precise time delays and oscillations. Here's a brief description:\r\n\r\nFunctionality: The 555 timer IC can operate in three different modes: astable (free-running oscillator), monostable (one-shot), and bistable (flip-flop). Each mode has its specific applications, making the 555 versatile for a wide range of timing and pulse generation tasks.\r\n\r\nInternal Structure: The NE555 contains comparators, voltage reference, a flip-flop, and output transistors within a single package. The internal block diagram typically includes two comparators, a flip-flop, a discharge transistor, and resistors arranged in a specific configuration.\r\n\r\nPin Configuration: The NE555 typically comes in an 8-pin dual in-line package (DIP-8). The pins are assigned specific functions, including power supply (VCC, GND), trigger, output, reset, threshold, and discharge.\r\n\r\nTiming Capacitor and Resistors: The timing of the NE555 is primarily controlled by an external resistor (R) and capacitor (C). By changing the values of these components, you can alter the timing characteristics of the IC.\r\n\r\nApplications: The NE555 finds applications in various fields such as pulse generation, oscillator circuits, timers, LED and lamp flashers, voltage regulators, tone generation, and more. Its simplicity, low cost, and versatility have made it a staple component in electronics projects for decades.\r\n\r\nOverall, the NE555 is prized for its simplicity, reliability, and versatility, making it an enduring favorite among hobbyists, students, and professionals alike in the realm of electronics.", "ne555.pdf"));
        }
    }
}
