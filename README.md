# Pelihahmonimigeneraattori (JA sekä TAI operaattorit)

## JOHDANTO
- Muista aina hyödyntää jo aiemmin oppimaasi!
- Katso apuja myös edellisistä tehtävistä.
- Katso myös ensin if-else kirjallinen materiaali!
## TEHTÄVÄNANTO
- Tarvitset konsolisovellukseen ainakin kaksi string tyyppistä muuttujaa nimeltä kuukausi ja väri sekä yhden int tyyppisen muuttujan nimeltä päivä. Lisäksi tarvitset string tyyppisen apumuuttujan päiväsana johon talletat if-else päivän tulostusarvon.
- Pyydä käyttäjää syöttämään konsolissa ensin syntymäkuukautensa, sitten päällä olevan paidan värin ja lopulta vielä päivän. Talleta käyttäjän kirjoittamat syötteet edellä mainittuihin muuttujiin kuten edellisissäkin tehtävissä olet tehnyt (jos et muista, tarkista miten Write, WriteLine ja ReadLine toimivat edellisistä tehtävistäsi).
- Laita ohjelma tarkistamaan syötetty päivämäärä if-else:llä. Käytä TAI operaattoria: || (päivä on pienempi kuin 1 tai suurempi kuin 31)
    - Muista tarkistaa materiaalista miten tai ehto kirjoitetaan!
- Laita ohjelma selvittämään if-else:llä TAI sekä JA operaattoreita hyödyntäen lopullisen nimitulosteen osat allaolevan ohjeen mukaisesti (kuukausi on Joulukuu TAI tammikuu TAI helmikuu) (päivä on suurempi kuin JA pienempi kuin)
    - Kuukausi: 
        - Joulukuu, Tammikuu, Helmikuu : Lumisateen
        - Maaliskuu, Huhtikuu, Toukokuu : Aamukasteen
        - Kesäkuu, Heinäkuu, Elokuu : Kesäpäivän
        - Syykuu, Lokakuu, Marraskuu : Syystuulen
        - Virheet (else lohkon tuloste: Kirjoitusvirheen
    - Päivä:
        - 1-5 : Kääpiö
        - 6-10 : Haltija
        - 11-15 : Ewok
        - 16-20 : Stormtrooper
        - 21-25 : Hobitti
        - 26-31 : Lohikäärme
        - else-lohko: Päivätön
- If-else tarkisteluiden jälkeen, laita ohjelma tulostamaan konsoliin seuraavanlainen syöte: "Pelinimesi on kuukausi väri päiväsana."
    - Huom! Kuten ehkä huomasit, on sovelluksesi todennäköisesti Case Sensitive (esimerkkituloste 2). Se on ihan okei, mutta jos haluat saada sen toimimaan kirjaimien koosta riippumatta tutustu itsenäisesti metodiin toLower(); googlen avulla tai vaikka tämän sivun kautta. Jos saat toLower(); metodin toimimaan, muuta myös if-else ehtosi siten, että siinä käytetään vain pieniä kirjaimia. Tähän ja tämän sisar-metodiin toUpper(); tutustutaan hieman kurssin metodit osiossa. Tämä kohta on täysin vapaaehtoinen tässä vaiheessa kurssia!
- Esimerkkitulosteita:


  
```
Missä kuussa synnyit? Tammikuu
Minkä värinen paita on päälläsi? Sininen
Monentena päivänä synnyit? 9

Pelinimesi on Lumisateen Sininen Haltija.
```
```
Missä kuussa synnyit? joulukuu
Minkä värinen paita on päälläsi? Vihreä
Monentena päivänä synnyit? 16

Pelinimesi on Kirjoitusvirheen Vihreä Stormtrooper.
```
```
Missä kuussa synnyit? Maaliskuu
Minkä värinen paita on päälläsi? Musta
Monentena päivänä synnyit? 0
Päivä ei ole oikein, syötä oikea päivä:
1

Pelinimesi on Aamukasteen Musta Kääpiö.
```



> [!IMPORTANT]
> Koodin kirjoittamisen johdanto
1. Kloonaa projekti omalle koneellesi.
2. Avaa `ConsoleApp.sln`.
3. Solution-ikkunasta valitse "ConsoleApp".
4. Pääkoodi löytyy `Program.cs`-tiedostosta. Jos tarvitset, luo uudet itemit `ConsoleApp`-projektiin.
