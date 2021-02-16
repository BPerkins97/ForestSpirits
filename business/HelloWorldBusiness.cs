using System;

namespace ForestSpirits
{
    public class BaumPflanzenUseCase
    {
        private const int BAUM_CO2_WERT = 20;
        private int co2 = 5000;
        private int anzahlBaum = 1;
        private Co2Anzeige co2Anzeige;

        public BaumPflanzenUseCase(Co2Anzeige co2Anzeige)
        {
            this.co2Anzeige = co2Anzeige;
        }

        public void pflanzeBaum(int anzahlBaum)
        {
            this.anzahlBaum += anzahlBaum;
            int neuesLevel = berechneNeuesCo2Level();
            if (neuesLevel < 4500)
            {
                this.co2Anzeige.zeigeWinAn();
            }
            else
            {
                this.co2Anzeige.zeigeCo2Level(neuesLevel);
            }
        }

        private int berechneNeuesCo2Level()
        {
            return co2 - anzahlBaum * BAUM_CO2_WERT;
        }
    }

    public interface Co2Anzeige
    {
        void zeigeCo2Level(int co2Level);
        void zeigeWinAn();
    }
}
