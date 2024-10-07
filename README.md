# Listan Summa

## JOHDANTO
- Muista aina hyödyntää jo aiemmin oppimaasi!
- Katso apuja myös edellisistä tehtävistä.
- Katso myös ensin if-else kirjallinen materiaali!
- Muu extra johdatteleva materiaali ja huomiot
 
## TEHTÄVÄNANTO
- Luo array lista numeroista -> int[] numerot = { numeroita }
- Käyttä 4 eri metodia, jotka ottavat parametriksi int[] -listan. 
Summa(int[] lista)
Erotus(int[] lista)
Osamaara(int[] lista)
Tulo(int[] lista)
- Jokainen metodi tulostaa kaikkien listalla olevien numeroiden arvon konsolliin.
- Vinkki: osamäärää ei voi laskea int-luvuilla, koska osamäärän tulos on harvemmin kokonaislukuja, sen sijaan int lista tarvitsee alustaa desimaaliluvuksi esimerkiksi käymällä int listan for-loopissa läpi lisäten luvun desimaalina double-listaan kierros kierrokselta tai oikoen allaolevan esimerkin kautta (älä käytä sokeasti vaan selvitä ensin mitä seuraavilla 2 rivillä tapahtuu ennen kuin teet niin):
int[] numerot = {3, 4, 5}
double osamäärä = numerot[0]
- Vinkki2: tulon ja osamäärän voi alustaa lukuun 1, mutta voit myös alustaa aloitusluvuksi listan ensimmäisen alkion ja käyttää toimintoa Skip(1) edellisen vinkin (joka siis alustaa listan ensimmäisen luvun laskutoimituksen aloitusluvuksi) kanssa. 
foreach (int luku in lista.Skip(1))


Esimerkkisuoritus:
```
Summa: 12
Erotus: -6
Osamäärä: 0,15
Tulo: 60

```

> [!IMPORTANT]
> Koodin kirjoittamisen johdanto
1. Kloonaa projekti omalle koneellesi.
2. Avaa `ConsoleApp.sln`.
3. Solution-ikkunasta valitse "ConsoleApp".
4. Pääkoodi löytyy `Program.cs`-tiedostosta. Jos tarvitset, luo uudet itemit `ConsoleApp`-projektiin.
