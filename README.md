# Numerolista

## JOHDANTO
- Muista aina hyödyntää jo aiemmin oppimaasi!
- Katso apuja myös edellisistä tehtävistä.
- Muista, kaikki käyttäjän tallettama syöte on tekstiä. Kaikki lukusyöte pitää muuntaa numeroiksi joko int.Parse(); tai Convert.ToInt32(); metodeilla
 
## TEHTÄVÄNANTO
- Alusta ensin numerolista ja sen jälkeen tee WriteLine, joka pyytää käyttäjää lisäämään lukuja (10kpl) listalle 
- Tee sen jälkeen while, jonka sisälle tulee listan add toiminto, joka lisää ReadLineä toiminnolla lukuja aiemmin alustetulle listalle
    - Tarvitset kierros-muuttujan, johon lisäät aina ReadLinen jälkeen +1 arvon.
    - Kun kierros saavuttaa arvon 10, jos-lause breikkaa while loopin
- Kun listalla on 10 lukua, tulosta erillisillä WriteLine toiminnoilla listan ensimmäinen, viides ja kymmenes luku.
- Muista, että listan indeksiluvut alkavat luvulla 0.

Esimerkkisuoritus:
```
Syötä listalle lukuja, kunnes lista on valmis (10kpl)
2
34
65
4
33
2
4
6
3
2
Listan ensimmäinen, viides ja kymmenes luku:
2
33
2
```


> [!IMPORTANT]
> Koodin kirjoittamisen johdanto
1. Kloonaa projekti omalle koneellesi.
2. Avaa `ConsoleApp.sln`.
3. Solution-ikkunasta valitse "ConsoleApp".
4. Pääkoodi löytyy `Program.cs`-tiedostosta. Jos tarvitset, luo uudet itemit `ConsoleApp`-projektiin.
