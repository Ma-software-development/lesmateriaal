# Collaboration – Galgje met Git

## Doel van de les
- Het opzetten van een samenwerking (collaboration) op GitHub.
- Oefenen met Git-collaboration in de vorm van een spelletje **galgje**.

---

## Rollen
- **Git-master:** zet de repo op, beheert de README en de spelstatus (letters invullen + afbeeldingen updaten).
- **Collaborators:** doen om de beurt een gok (één letter), committen en pushen.

---

## Opstarten

### Git-master
1. **Nieuwe repository aanmaken** (op GitHub):
   - **Public**
   - **README.md:** **aan**
   - **.gitignore:** **uit**
   - **License:** **geen**
2. **Clone** de repository naar je computer:
   ```bash
   git clone <URL-van-de-repo>
   cd <map-van-de-repo>
   ```
3. **README.md aanvullen**:
   - Zet bovenaan **teamnaam** en **namen + e-mailadressen** van alle studenten (in speelvolgorde).
4. **Collaborators uitnodigen**:
   - Ga naar **Settings → Collaborators** en voeg je teamleden toe (de volgorde waarin je ze toevoegt = speelvolgorde).
   - Zij krijgen automatisch een uitnodiging op het e-mailadres van hun GitHub-account.
5. **Woord bedenken**:
   - Bedenk een geheim woord van **12 of meer letters** (of kies zelf een lengte).
6. **Woordraster plaatsen** in `README.md` (voorbeeld: 12 letters; pas aan voor jouw woordlengte):

   ````md
   | . | . | . | . | . | . | . | . | . | . | . | . |
   | - | - | - | - | - | - | - | - | - | - | - | - |
   | 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 | 10 | 11 | 12 |
   ````

   *De Git-master vult straks de juiste letters in de bovenste rij in wanneer er goed geraden wordt.*
7. **Afbeeldingen toevoegen**:
   - Download en unzip de **galgje-afbeeldingen**.
   - Plaats ze in de map `images/` (bijv. `images/image1.png` t/m `images/image7.png`).
   - Zet onder het raster alvast:  
     `![status](images/image1.png)`
8. **Eerste commit & push**:
   ```bash
   git add README.md images/
   git commit -m "Init: spel opgezet + image1"
   git push
   ```

---

## Collaborators
1. **Uitnodiging accepteren** en repo **clonen** (bij voorkeur in `skill-github/les6`):
   ```bash
   git clone <URL-van-de-repo>
   cd <map-van-de-repo>
   ```
2. **Volgorde van spelen** = volgorde waarin je bent toegevoegd als collaborator.

---

## Spelverloop

### Beurt van Collaborator 1
1. **Pull de laatste stand**:
   ```bash
   git pull
   ```
2. **README.md editen**:
   - Voeg onderaan een logregel toe, bijvoorbeeld:
     - `beurt1: ik gok de letter "E"`
3. **Commit & push**:
   ```bash
   git add README.md
   git commit -m 'beurt1: gok "E"'
   git push
   ```

### Git-master verwerkt de beurt
1. **Wijzigingen ophalen**:
   ```bash
   git fetch
   # (optioneel) bekijk logs/diff
   git pull
   ```
2. **Controleer de letter**:
   - **Goed geraden?** Vul de letter op de juiste posities in het raster (vervang de betreffende `.` door de letter).
   - **Fout?** Voeg onder het log toe:  
     `De letter "E" komt niet in het woord voor.`  
     Update de statusafbeelding naar de volgende:  
     `![status](images/image2.png)`
3. **Commit & push**:
   ```bash
   git add README.md
   git commit -m 'Update: verwerk beurt1'
   git push
   ```

### Beurt van Collaborator 2 (enz.)
- Herhaal dezelfde stappen als Collaborator 1, maar met `beurt2`, `beurt3`, … en jouw gekozen letter.

**Ga door totdat:**
- Het **woord is geraden** (alle letters ingevuld), **of**
- De Git-master **`images/image7.png`** plaatst (spel verloren).

---

## Inleveren
- **Iedereen** in de groep: kopieer de **URL** van de GitHub-repository waar jullie de opdracht hebben uitgevoerd en lever deze in op **Simulise**.

---

## Snelle Git-cheatsheet
```bash
# eerste keer
git clone <URL>

# elke beurt: werk binnenhalen
git pull

# bestanden toevoegen + committen
git add README.md
git commit -m "beurtX: gok 'A'"

# naar GitHub sturen
git push

# vanuit Git-master: binnenhalen en verwerken
git fetch
git pull
```

---

## Kant-en-klare `README.md` template

> Kopieer dit in jullie README en vul aan.

```md
# Galgje – Git Collaboration

**Team:** <Teamnaam>  
**Spelvolgorde & contact:**
1. <Naam 1> – <email1@example.com>
2. <Naam 2> – <email2@example.com>
3. <Naam 3> – <email3@example.com>
4. <Naam 4> – <email4@example.com>

---

## Woordraster
<!-- Pas het aantal kolommen aan aan de woordlengte -->
| . | . | . | . | . | . | . | . | . | . | . | . |
| - | - | - | - | - | - | - | - | - | - | - | - |
| 1 | 2 | 3 | 4 | 5 | 6 | 7 | 8 | 9 | 10 | 11 | 12 |

## Status
![status](images/image1.png)

---

## Beurtenlog
- beurt1: <Naam> gokt "?"
- (Git-master vult hier reactie in: goed/fout + updates)
- beurt2: ...
```
