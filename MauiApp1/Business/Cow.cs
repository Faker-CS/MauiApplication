using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Business
{
    public class Cow
    {
        public double PoidsVif { get; set; }
        public double ProductionLait { get; set; }
        public double NoteEtatCorporel { get; set; }
        public string Parite { get; set; }
        public int SemaineLactation { get; set; }
        public int SemaineGestation { get; set; }
        public int Age { get; set; }

        public double CalculateCI()
        {
            double IL = CalculateIL();
            double IG = CalculateIG();
            double IM = CalculateIM();

            return (13.9 + (0.015 * (PoidsVif - 600)) + (0.15 * ProductionLait) + (1.5 * (3 - NoteEtatCorporel))) * IL * IG * IM;
        }

        private double CalculateIL()
        {
            if (Parite == "Primipare")
            {
                if (SemaineLactation >= 1 && SemaineLactation <= 9)
                    return 0.775;
                else if (SemaineLactation >= 10 && SemaineLactation <= 24)
                    return 0.96;
                else
                    return 1;
            }
            else if (Parite == "Multipare")
            {
                if (SemaineLactation >= 1 && SemaineLactation <= 9)
                    return 0.83;
                else if (SemaineLactation >= 10 && SemaineLactation <= 24)
                    return 0.97;
                else
                    return 1;
            }
            else // Tarie
            {
                return 1;
            }
        }

        private double CalculateIG()
        {
            if (SemaineGestation < 30)
                return 1;
            else if (SemaineGestation >= 30 && SemaineGestation <= 39)
                return 0.94;
            else
                return 0.80;
        }

        private double CalculateIM()
        {
            if (Age >= 20 && Age <= 32)
                return 0.8525;
            else if (Age >= 32 && Age <= 44)
                return 0.945;
            else if (Age >= 44 && Age <= 56)
                return 0.98;
            else
                return 1;
        }
    }
}
