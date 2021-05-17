using System;

namespace Assignment
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] categories = { "Gardening tools", "Flooring Tools",
                "Fencing Tools", "Measuring Tools", "Cleaning Tools",
                "Painting Tools", "Electronic Tools", "Electricity Tools", "Automotive Tools" };

            string[] GardeningTools = { "Line Trimmers", "Lawn Mowers",
                "Hand Tools", "Wheelbarrows", "Garden Power Tools" };

            string[] FlooringTools = { "Scrapers", "Floor Lasers", "Floor Levelling Tools",
                "Floor Levelling Materials", "Floor Hand Tools", "Tiling Tools" };

            string[] FencingTools = { "Hand Tools", "Electric Fencing",
                "Steel Fencing Tools", "Power Tools", "Fencing Accessories" };

            string[] MeasuringTools = { "Distance Tools", "Laser Measurer",
                "Measuring Jugs", "Temperature & Humidity Tools", "Levelling Tools", "Markers" };

            string[] CleaningTools = { "Draining", "Car Cleaning",
                "Vacuum", "Pressure Cleaners", "Pool Cleaning", "Floor Cleaning" };

            string[] PaintingTools = { "Sanding Tools", "Brushes",
                "Rollers", "Paint Removal Tools", "Paint Scrapers", "Sprayers" };

            string[] ElectronicTools = { "Voltage Tester", "Oscilloscopes",
                "Thermal Imaging", "Data Test Tool", "Insulation Testers" };

            string[] ElectricityTools = { "Test Equipment", "Safety Equipment",
                "Basic Hand tools", "Circuit Protection", "Cable Tools" };

            string[] AutomotiveTools = { "Jacks", "Air Compressors",
                "Battery Chargers", "Socket Tools", "Braking", "Drivetrain" };

            string[][] toolTypes =
            {
                GardeningTools, FlooringTools, FencingTools, MeasuringTools, CleaningTools, 
                PaintingTools, ElectronicTools, ElectricityTools, AutomotiveTools
            };


            ToolLibrarySystem library = new ToolLibrarySystem(categories, toolTypes);
            UI menus = new UI(library);
        }
    }
}
