# Parittomat luvut
Tavoitteena on kirjoittaa ohjelma, joka pyytää käyttäjää syöttämään luvun, ja vertaa syötettyä lukua arvoon 8. Ohjelma jatkaa lukujen kysymistä, kunnes käyttäjä syöttää luvun, joka on enintään 8, tai kunnes käyttäjä on syöttänyt luvun kahdeksan kertaa.


## JOHDANTO
- Muista aina hyödyntää jo aiemmin oppimaasi!
- Katso apuja myös edellisistä tehtävistä.
- Parillisen luvun jakojäännös 2 jaettaessa on 0, eli koodissa jakojäännöksen tarkistus voidaan tehdä (i%2=0) kun i viittaa numeromuuttujaan int i.
- Jakojäännös-tarkistelussa käytetään useimmiten if-lausetta. If ehdossa tarkistetaan onko luku parillinen if(i%2=0) tai pariton if(i%2!= 0) ja jos halutaan tulostaa jommatkummat (parilliset tai parittomat) tarvitaan ifin lohkossa writeline, jossa i tulostuu.
 
## TEHTÄVÄNANTO
- Tee for loop, joka käy läpi luvut 1-100.
- Testaa laittamalla loopin sisälle (testaaja) WriteLine, joka tulostaa kaikki luvut 1-100 tarkistaaksesi, että looppisi toimii.
- Kun tuloste toimii, laita se kommenttiin ottaaksesi sen pois käytöstä laittamalla rivin alkuun //
- Nyt tee for-looppisi sisälle if-ehtolause, joka poimii kaikista luvuista vain parittomat ja sen jälkeen omassa ehdon tosilohkossaan tulostaa ne.

Esimerkkisuoritus:
```
1 3 5 7 9 11 13 15 17 19 21 23 25 27 29 31 33 35 37 39 41 43 45 47 49 51 53 55 57 59 61 63 65 67 69 71 73 75 77 79 81 83 85 87 89 91 93 95 97 99
```



> [!IMPORTANT]
> Koodin kirjoittamisen johdanto
1. Kloonaa projekti omalle koneellesi.
2. Avaa `ConsoleApp.sln`.
3. Solution-ikkunasta valitse "ConsoleApp".
4. Pääkoodi löytyy `Program.cs`-tiedostosta. Jos tarvitset, luo uudet itemit `ConsoleApp`-projektiin.
