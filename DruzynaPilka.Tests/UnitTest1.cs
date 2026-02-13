using Xunit;
using DruzynaPilka;
using System;
using System.Collections.Generic;

namespace DruzynaPilka.Tests
{
    public class UnitTest1
    {
        #region Testy Klasy Druzyna
        [Fact]
        public void Druzyna_DodajCzlonka_PowinienDodacGdyNumerJestWolny()
        {
            // Sprawdzenie, czy poprawny obiekt pi³karza zostaje pomyœlnie dodany do listy sk³adu
            var druzyna = new Druzyna();
            var p1 = new Pilkarz { NumerKoszulki = 10, Imie = "Jan", Nazwisko = "Kowalski" };

            druzyna.DodajCzlonkaDruzyny(p1);

            Assert.Contains(p1, druzyna.Sklad);
            Assert.Equal(1, druzyna.LiczbaPilkarzy());
        }

        [Fact]
        public void Druzyna_DodajCzlonka_NiePowinienDodacGdyNumerZajety()
        {
            // Testowanie walidacji unikalnoœci numeru koszulki - drugi pi³karz z tym samym numerem nie powinien zostaæ dodany
            var druzyna = new Druzyna();
            var p1 = new Pilkarz { NumerKoszulki = 7, Imie = "Cristiano" };
            var p2 = new Pilkarz { NumerKoszulki = 7, Imie = "Kamil" };

            druzyna.DodajCzlonkaDruzyny(p1);
            druzyna.DodajCzlonkaDruzyny(p2);

            Assert.Equal(1, druzyna.LiczbaPilkarzy());
            Assert.DoesNotContain(p2, druzyna.Sklad);
        }
        #endregion

        #region Testy Klasy Pilkarz i Statystyki
        [Fact]
        public void Pilkarz_Bmi_PowinienLiczycPoprawnie()
        {
            // Weryfikacja poprawnoœci obliczeñ matematycznych wzoru na BMI (waga / wzrost^2)
            var p = new Pilkarz { Waga = 80, Wzrost = 2.0 };

            double wynik = p.Bmi();

            Assert.Equal(20, wynik);
        }

        [Fact]
        public void Pilkarz_Trening_PrzyKontuzji_PowinienRzucicWyjatek()
        {
            // Sprawdzenie mechanizmu bezpieczeñstwa - próba treningu kontuzjowanego gracza musi zg³osiæ b³¹d (wyj¹tek)
            var p = new Pilkarz();
            p.DodajKontuzje("Kolano", DateTime.Now, 10);

            var ex = Assert.Throws<WrongDataException>(() => p.TrenujPilkarza());
            Assert.Equal("Kontuzjowany zawodnik ma zakaz treningów!", ex.Message);
        }

        [Fact]
        public void Statystyki_Gole_Ujemne_PowinnyRzucicWyjatek()
        {
            // Testowanie walidacji danych wejœciowych - liczba goli nie mo¿e byæ mniejsza od zera
            var s = new Statystyki();

            Assert.Throws<WrongDataException>(() => s.LiczbaGoli = -5);
        }
        #endregion

        #region Testy Klasy Stadion
        [Fact]
        public void Stadion_ObliczZysk_ZwracaPoprawnaKwote()
        {
            // Testowanie logiki finansowej - obliczanie przychodu na podstawie procentowego zape³nienia trybun
            var stadion = new Stadion("Test", 1000, 50.0);

            var zysk = stadion.ObliczZysk(0.5);

            Assert.Equal(25000.0, zysk);
        }

        [Theory]
        [InlineData(-0.1)]
        [InlineData(1.1)]
        public void Stadion_ObliczZysk_BlednyProcent_RzucaWyjatek(double procent)
        {
            // Sprawdzenie walidacji zakresu (0-100%) dla ob³o¿enia stadionu przy u¿yciu testów parametrycznych
            var stadion = new Stadion();

            Assert.Throws<WrongDataException>(() => stadion.ObliczZysk(procent));
        }
        #endregion

        #region Testy Klasy Trener i Kontuzje
        [Fact]
        public void Trener_Zmotywuj_ZwiekszaStamineMaxDo100()
        {
            // Weryfikacja logiki motywacji - stamina powinna wzrosn¹æ, ale nie mo¿e przekroczyæ limitu 100 jednostek
            var trener = new Trener();
            var p = new Pilkarz { Stamina = 98 };

            trener.ZmotywujPilkarza(p);

            Assert.Equal(100, p.Stamina);
        }

        [Fact]
        public void Kontuzja_UpdateStatus_PowinnaSieZakonczycPoCzasie()
        {
            // Testowanie automatycznej aktualizacji statusu zdrowia - kontuzja powinna wygasn¹æ po up³ywie zdefiniowanego czasu
            var k = new Kontuzja("Kostka", DateTime.Now.AddDays(-5), 3);

            k.UpdateStatus(DateTime.Now);

            Assert.False(k.Aktywna);
        }
        #endregion

        #region Testy Porównywania
        [Fact]
        public void GoleComparer_PowinienSortowacMalejaco()
        {
            // Sprawdzenie poprawnoœci dzia³ania komparatora u¿ywanego do tworzenia rankingu strzelców (od najwiêkszej liczby goli)
            var p1 = new Pilkarz { Imie = "A", Staty = new Statystyki { LiczbaGoli = 5 } };
            var p2 = new Pilkarz { Imie = "B", Staty = new Statystyki { LiczbaGoli = 10 } };
            var comparer = new GoleComparer();

            int result = comparer.Compare(p1, p2);

            Assert.True(result > 0);
        }
        #endregion
    }
}