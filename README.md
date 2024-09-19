# Kuvioita ja muotoja

## JOHDANTO
- Muista aina hyödyntää jo aiemmin oppimaasi!
- Muista: Numeromuuttuja ei voi sisältää tekstiä, pelkästään numeroita ja samalla tekstimuuttuja voi olla mitä tahansa merkkejä, mutta vain numeroita käyttävää tekstimuuttuja ei voi käyttää matemaattisiin toimintoihin, ellei sitä ensin muunna numeromuuttujatyyppiin.
- Console.Write(); kirjoittaa tulosteen konsoliin ja jatkaa seuraavaa tulostetta samalta riviltä
- Console.WriteLine(); kirjoittaa tulosteen konsoliin ja ohjaa seuraavan tulosteen alkamaan seuraavalta riviltä
- Console.ReadLine(); poimii käyttäjän syötteen String-muotoisena muuttujaan, jos syöte ei ole tekstiä se täytyy muistaa muuntaa numeromuotoon joko Convert.ToInt32(); tai int.Parse(); toiminnolla. 
- Katso myös ensin if-else kirjallinen materiaali!
- ehto - kyllä - ei ; ensimmäisten aaltosulkeiden sisällä on koodi mikä ajetaan mikäli ehto on totta, elsen jälkeen tulevien aaltosulkeiden sisällä on koodi mikä ajetaan jos ehto ei ole totta, eli kaikki muut tapaukset paitsi tosiehdon (tai ehtojen) tapaus toteuttaa elsen koodin. 
## TEHTÄVÄNANTO
- Tarvitset konsolisovellukseen ika muuttujan, joka on muuttujatyypiltään int - eli kokonaisluku.   
- Laita konsolisovellus pyytämään käyttäjää syöttämään konsoliin ikänsä, talleta syötetty ikä ika-muuttujaan.
- Tarkista iän kysymisen jälkeen if-else lauseen avulla onko käyttäjä lapsi (alle 10 vuotta), teini (alle 18 vuotta) vai aikuinen (yli 18 vuotta). 
- Muista: toiminto lohkon sisällä päätetään puolipisteeseen (esim WriteLine();), jokainen ehtolohko on omien aaltosulkeiden { } sisällä, ehdon päätteeksi ei tule puolipistettä, koska ehto ei ole toiminto 
- Esimerkkituloste:
  
```
Syötä ikäsi: 19
olet aikuinen.
```

> [!IMPORTANT]
> Koodin kirjoittamisen johdanto
1. Kloonaa projekti omalle koneellesi.
2. Avaa `ConsoleApp.sln`.
3. Solution-ikkunasta valitse "ConsoleApp".
4. Pääkoodi löytyy `Program.cs`-tiedostosta. Jos tarvitset, luo uudet itemit `ConsoleApp`-projektiin.
