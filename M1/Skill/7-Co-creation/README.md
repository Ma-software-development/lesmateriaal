# starting Co-creating

## 1. Voorbereiding

### Benodigdheden
- Een **GitHub-account** per student: [https://github.com](https://github.com)
- Een **webbrowser** (bijv. Chrome, Firefox, Edge)
- (Optioneel) **Visual Studio Code** of een andere teksteditor

---

## 2. De gitmaster, maakt het project aan

1. **Maak een nieuwe repository**
   - Ga naar [https://github.com/new](https://github.com/new)
   - Geef de repository een naam, bijvoorbeeld:  
     `studenten-webpagina`
   - Vink aan: **“Add a README file”**
   - Klik op **Create repository**

2. **Voeg de andere studenten toe als collaborators**
   - Ga in de repository naar **Settings → Collaborators**
   - Klik op **Add people**
   - Voeg de GitHub-gebruikersnamen van de medestudenten toe
   - Zij ontvangen een uitnodiging via e-mail of via GitHub

---

## 3. Gitmaster maakt een webpagina aan
De Gitmaster:
1. cloont de repository naar zijn eigen computer in een folder waar geen git actief is
2. opent de repository in Visual Studio
3. Voegt zijn naam toe op de `README.md`
4. voegt een nieuw bestand `index.html` toe
5. plaatst een basic opzet van een html-pagina
6. add, commit en pusht dit naar github

---

## 4. Iedereen werkt samen op dezelfde pagina

Elke student kan nu direct bijdragen aan het project:

1. Ga naar de repository.
2. Klik op **index.html** (of een ander bestand of maak zelf een nieuw bestand aan).
4. Voeg je eigen stukje code toe, bijvoorbeeld:

   ```html
   <h2>Bijdrage van Sara</h2>
   <p>Ik heb dit stukje tekst toegevoegd!</p>
   ```

5. Scroll naar beneden en voeg een korte commit-boodschap toe, bijvoorbeeld:  
   `Voeg tekst van Sara toe`
6. Klik op **Commit changes**

> 💡 **Tip:** Om conflicten te voorkomen, spreek af dat steeds één student tegelijk bewerkt of dat iedereen op een ander moment werkt.

---

## 5. Bekijk de webpagina online

1. Ga naar **Settings → Pages**
2. Kies onder **Source**:  
   `Deploy from a branch`
3. Selecteer de branch: `main` en klik op **Save**
4. Na enkele minuten verschijnt bovenaan een link, bijvoorbeeld:  
   `https://gebruikersnaam.github.io/studenten-webpagina/`

Deze link toont jullie gezamenlijke webpagina live online!

---

## 6. Extra bestanden toevoegen

Elke student kan ook eigen bestanden toevoegen, bijvoorbeeld afbeeldingen of een extra HTML-pagina:

1. Klik op **Add file → Upload files** of **Create new file**
2. Voeg bijvoorbeeld `stijl.css` of `info.html` toe
3. Vergeet niet te **committen**

---

## 7. Tips voor samenwerking zonder branches

- **Communiceer goed** (bijv. via WhatsApp of Teams) wie wanneer aanpassingen doet.
- **Ververs de pagina** voordat je begint te bewerken, zodat je de laatste versie hebt.
- Als iemand per ongeluk iets overschrijft, kun je dat herstellen via:
  - **History → View commits → Revert**

---

## 8. Voorbeeld van een eenvoudige teamstructuur

Voorbeeld van een pagina: [voorbeeld](src/index.html)

| Student | Bestand | Verantwoordelijkheid |
|----------|----------|----------------------|
| Anna | index.html | Startpagina en structuur |
| Bas | stijl.css | Vormgeving en kleuren |
| Sara | about.html | Team-informatie |
| Tom | contact.html | Contactformulier |
| Emma | images/ | Afbeeldingen toevoegen |

---

## 9. Afronden en presenteren

Wanneer iedereen klaar is:
1. Lever de link naar de URL in github in bij Simulise
---

## 10. Samenvatting

✅ Eén student maakt de repository  
✅ Iedereen krijgt toegang als collaborator  
✅ Alle studenten bewerken rechtstreeks de bestanden  
✅ Geen branches of pull requests nodig  
✅ De website is automatisch online via GitHub Pages

---

*Laatste update: oktober 2025*
