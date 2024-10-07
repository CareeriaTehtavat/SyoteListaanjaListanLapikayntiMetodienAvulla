# Kuvioiden tulostus

## JOHDANTO
- Muista aina hyödyntää jo aiemmin oppimaasi!
- Katso apuja myös edellisistä tehtävistä.
- Katso myös ensin if-else kirjallinen materiaali!
- Muu extra johdatteleva materiaali ja huomiot
 
## TEHTÄVÄNANTO
- Luo sovellus, jossa on yksi metodi, joka tulostaa neliön annetun luvun kokoisena
- Metodit: TulostaNeliö(int sivunPituus)
- Metodi ottaa sisälle int -luvun, ja kuvion koko perustuu annettuun arvoon



Esimerkkisuoritus:
```
Kuinka ison neliön haluat tehdä: 5
*****
*   *
*   *
*   *
*****

```

HINT:
Sivujen tulostus sisältää kaksi for lausetta ja if lauseen jonka avulla lisätään vasemmalle ja oikeimmalle kohdalle tähtikuvio
```
for (int i = 0; i < sivunPituus - 2; i++)
{
    for (int e = 0; e < sivunPituus; e++)
    {
        if (e == 0 || e == sivunPituus - 1)
        {
            // Your code logic here
        }
    }
}

```


> [!IMPORTANT]
> Koodin kirjoittamisen johdanto
1. Kloonaa projekti omalle koneellesi.
2. Avaa `ConsoleApp.sln`.
3. Solution-ikkunasta valitse "ConsoleApp".
4. Pääkoodi löytyy `Program.cs`-tiedostosta. Jos tarvitset, luo uudet itemit `ConsoleApp`-projektiin.
