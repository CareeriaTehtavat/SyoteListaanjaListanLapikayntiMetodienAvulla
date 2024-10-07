# Syöte listaan ja listan läpikäynti Metodien avulla

## JOHDANTO
- Muista aina hyödyntää jo aiemmin oppimaasi!
- Katso apuja myös edellisistä tehtävistä.
- Katso myös ensin if-else kirjallinen materiaali!
- Muu extra johdatteleva materiaali ja huomiot
 
## TEHTÄVÄNANTO
- MUOKKAA Aiemman osion henkilöitä listaavaa tehtävää siten, että se käyttää metodia. Alla aiemman tehtävän ohjeet:
- Laita konsolisovellus pyytämään käyttäjältä henkilöiden nimiä, jonka jälkeen henkilön nimi tallennetaan List<string> henkilöt listaan. 
- Tip: for-silmukka, jossa on 5 silmukkan iteraatiota (läpikäyntiä) , silmukan sisällä kysytään käyttäjän syöte ja henkilö nimi tallennetaan listaan (henkilöt.Add(Console.ReadLine)). -> Muokkaa tämä toiminto metodiin, eli metodi, joka palauttaa uuden listan uudella henkilöllä -> static List<string> LisääHenkilö() -> muista paluttaa (return) uusittu lista lopuksi
- Kun listalla on 5 henkilö, sovellus tulostaa listan henkilöistä konsoliin. (foreach) -> Muokkaa tämä metodiin. Kutsu siis metodia (tulostamaan henkilöt listalta), jonka sisällä foreach on.
- Metodi on jo olemassa, sen pitää muokata,että se toimi oikein - Metodin nimi "LisääHenkilö".


Esimerkkisuoritus:
```
Anna 5 henkilön nimeä:
Pekka
Mauro
Timur
Olli
Karina

Pekka
Mauro
Timur
Olli
Karina
```


> [!IMPORTANT]
> Koodin kirjoittamisen johdanto
1. Kloonaa projekti omalle koneellesi.
2. Avaa `ConsoleApp.sln`.
3. Solution-ikkunasta valitse "ConsoleApp".
4. Pääkoodi löytyy `Program.cs`-tiedostosta. Jos tarvitset, luo uudet itemit `ConsoleApp`-projektiin.
