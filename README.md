# Luvun vertailu ohjelmassa ja rajoitettu silmukkatoisto
Tavoitteena on kirjoittaa ohjelma, joka pyytää käyttäjää syöttämään luvun, ja vertaa syötettyä lukua arvoon 8. Ohjelma jatkaa lukujen kysymistä, kunnes käyttäjä syöttää luvun, joka on enintään 8, tai kunnes käyttäjä on syöttänyt luvun kahdeksan kertaa.


## JOHDANTO
- Muista aina hyödyntää jo aiemmin oppimaasi!
- Katso apuja myös edellisistä tehtävistä.
 
## TEHTÄVÄNANTO
- Syötteen kysyminen: Ohjelma pyytää käyttäjää syöttämään luvun kahdeksan kertaa (tai kunnes kelvollinen luku on annettu).
- Luvun tarkistus: Jokaisen syötön jälkeen ohjelma tarkistaa, onko syötetty luku suurempi kuin 8.
- Jos luku on suurempi kuin 8, ohjelma tulostaa viestin "Iso luku" ja pyytää uuden syötteen.
- Jos luku on 8 tai pienempi, ohjelma tulostaa viestin "Pieni luku" ja lopettaa silmukan välittömästi.
- Rajoitettu toisto: Ohjelma käyttää for-silmukkaa, joka toistuu korkeintaan kahdeksan kertaa, mutta lopettaa heti, kun käyttäjä syöttää luvun, joka on 8 tai pienempi.

Esimerkkisuoritus:
```
Syötä luku:
10
Iso luku
Syötä luku:
12
Iso luku
Syötä luku:
8
Pieni luku
```

> [!IMPORTANT]
> Koodin kirjoittamisen johdanto
1. Kloonaa projekti omalle koneellesi.
2. Avaa `ConsoleApp.sln`.
3. Solution-ikkunasta valitse "ConsoleApp".
4. Pääkoodi löytyy `Program.cs`-tiedostosta. Jos tarvitset, luo uudet itemit `ConsoleApp`-projektiin.
